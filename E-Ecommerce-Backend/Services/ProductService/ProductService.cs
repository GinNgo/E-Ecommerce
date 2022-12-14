using AutoMapper;
using AutoMapper.QueryableExtensions;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;

using E_Ecommerce_Backend.Services.CategoryService;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Admin;
using E_Ecommerce_Shared.DTO.Product;
using E_Ecommerce_Shared.DTO.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace E_Ecommerce_Backend.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoriesService _categoriesService;
  
        public ProductService(EcommecreDbContext context, IMapper mapper, ICategoriesService categoriesService)
        {
            _context = context;
            _mapper = mapper;
            _categoriesService = categoriesService;
 
        }
        public async Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto)
        {
             ProductPagingDto productPagingDto = new ProductPagingDto();
            List<Product> Listproducts = new List<Product>(); 
            productPagingDto.totalCount = await _context.Products.CountAsync();
            var products = _context.Products
                .Where(p=>p.Status==true&& p.IsDeleted == false)
                  .OrderByDescending(i => i.ProductId)
                .Skip(pagingRequestDto.pageSize * (pagingRequestDto.pageIndex - 1))
                .Take(pagingRequestDto.pageSize)
                .Include(c => c.Rating).Include(c=>c.Images)
            .AsQueryable();
            if (pagingRequestDto.sort == 1)
            {
                Listproducts =  await  products.OrderByDescending(i => i.ProductId).ToListAsync();
            
            }
            else
            {
                Listproducts = await products.OrderBy(i => i.ProductId).ToListAsync();
                
            }
            var productsDto = _mapper.Map<List<Product>, List<ProductsDto>>(Listproducts);
            productPagingDto.products = productsDto;
            return productPagingDto ?? new ProductPagingDto();
        }

        public async Task<List<ProductAdmin>> GetAllProductsAsync()
        {
            var products = await _context.Products
                 .Where(p => p.IsDeleted == false)
                .Include(c => c.Rating)
                .Include(c => c.Brand)
                .Include(c => c.Categories)
                .Include(c => c.Origin).Include(c => c.Images)
                .OrderByDescending(p=>p.ProductId)
                .ToListAsync();
            var productAdmin = _mapper.Map<List<Product>, List<ProductAdmin>>(products);
            return productAdmin ?? new List<ProductAdmin>();
        }
        public async Task<List<ProductAdmin>> GetAllProductsTrashAsync()
        {
            var products = await _context.Products
                 .Where(p => p.IsDeleted == true)
                .Include(c => c.Rating)
                .Include(c => c.Brand)
                .Include(c => c.Categories)
                .Include(c => c.Origin).Include(c => c.Images)
                .OrderByDescending(p => p.ProductId)
                .ToListAsync();
            var productAdmin = _mapper.Map<List<Product>, List<ProductAdmin>>(products);
            return productAdmin ?? new List<ProductAdmin>();
        }
        public async Task<ProductsDto> GetProductAsync(int id)
        {
           
            var product = await _context.Products
               .Where(e => e.ProductId == id)
               .Include(c => c.Brand)
               .Include(c => c.Categories).Include(c => c.Images)
               .Include(c => c.Origin).Include(c => c.Rating).FirstOrDefaultAsync();
            var productDto = _mapper.Map<ProductsDto>(product);
         
            return productDto;
        }

        public async Task<ActionResult<ProductAdmin>> GetProductAdminAsync(int id)
        {
            ProductAdmin productAdmin = new ProductAdmin();
            var product = await _context.Products
                .Where(e => e.ProductId == id)
                .Include(c => c.Brand)
                .Include(c => c.Categories).Include(c => c.Images)
                .Include(c => c.Origin).Include(c => c.Rating).FirstOrDefaultAsync();
            if (product != null)
            {
                productAdmin = _mapper.Map<Product, ProductAdmin>(product);
            }
            return productAdmin;
        }
        public async Task<ProductPagingDto> GetProductByCatIdAsync(PagingRequestDto pagingRequestDto)
        {
            ProductPagingDto ProductPagingDto = new ProductPagingDto();
            List<ProductsDto> productsDtos = new List<ProductsDto>();
            List<int> ListId = await _categoriesService.GetCategoriesIdChild(pagingRequestDto.id);
            ProductPagingDto.totalCount = await GetTotalProByCatAsync(ListId);

            if (ListId.Count > 1)
            {
                foreach (var i in ListId)
                {
                    if (productsDtos.Count == 10)
                    {
                        break;
                    }
                    var products = (from p in _context.Products
                                   join c in _context.Categories
                                   on p.CategoryId equals c.CategoryId
                                   where c.CategoryId == i&& p.Status == true && p.IsDeleted == false
                                   select p).AsQueryable();


                    products= products
                     .Skip((pagingRequestDto.pageSize - productsDtos.Count) * (pagingRequestDto.pageIndex - 1))
                     .Take(pagingRequestDto.pageSize)
                    .Include(c => c.Rating).Include(c => c.Images)
                     .AsQueryable();

                    var Listproducts = products.ToList();
                    if (Listproducts != null)
                    {
                        var result = _mapper.Map<List<Product>, List<ProductsDto>>(Listproducts);
                        result.ForEach(pro =>
                        {
                            productsDtos.Add(pro);
                        });
                    }
                };
               
            }
            else
            {
              var  Listproducts = await (from p in _context.Products
                                         join c in _context.Categories
                                         on p.CategoryId equals c.CategoryId
                                         where c.CategoryId == ListId.First() && p.Status == true && p.IsDeleted == false
                                         select p)
                    .Skip(pagingRequestDto.pageSize * (pagingRequestDto.pageIndex - 1)).Take(pagingRequestDto.pageSize)
                    .Include(c => c.Rating).Include(c => c.Images)
                    .ToListAsync();
                productsDtos= _mapper.Map<List<Product>, List<ProductsDto>>(Listproducts);
            }
            ProductPagingDto.products = productsDtos;
            return ProductPagingDto;
        }
        public async Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto)
        {
            ProductPagingDto ProductPagingDto = new ProductPagingDto();
            if (pagingRequestDto.Search == null)
            {
                ProductPagingDto = await GetAllProductsPaingAsync(pagingRequestDto);
            }
            else { 
            ProductPagingDto.totalCount = _context.Products.Where(c => c.ProductName!.Contains(pagingRequestDto.Search)&&c.Status==true&&c.IsDeleted==false).Count();
            var products = await _context.Products
             
                .Where(c => c.ProductName!.Contains(pagingRequestDto.Search) && c.Status == true && c.IsDeleted == false)
                .Skip(pagingRequestDto.pageSize * (pagingRequestDto.pageIndex - 1)).Take(pagingRequestDto.pageSize)
                .Include(c => c.Rating).Include(c => c.Images)
                .ToListAsync();
            
            ProductPagingDto.products = _mapper.Map<List<Product>, List<ProductsDto>>(products);
            }
            return ProductPagingDto;
        }
        public async Task<int> GetTotalProByCatAsync(List<int> ListId)
        {
            int total = 0;

            if (ListId.Count > 1)
            {
                ListId.ForEach(e =>
                {
                    var numberPro =(from p in _context.Products
                                    join c in _context.Categories
                                    on p.CategoryId equals c.CategoryId
                                    where c.CategoryId == e && p.Status == true && p.IsDeleted == false
                                    select p).Count();
                total += numberPro;
                });
            }
            else
            {
                var numberPro = await (from p in _context.Products
                                        join c in _context.Categories
                                        on p.CategoryId equals c.CategoryId
                                        where c.CategoryId == ListId.First() && p.Status == true && p.IsDeleted == false
                                       select p).CountAsync();
                total += numberPro;
            }
            return total;
        }

        public async Task<ProductsDto> PostProductRatingAsync(RatingDto ratingDto,int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            ratingDto.Email = user.Email;
            ratingDto.Name = user.FullName;
            var rating = _mapper.Map<Rating>(ratingDto);
            rating.Product = await _context.Products.Where(e => e.ProductId == ratingDto.ProductId).FirstOrDefaultAsync();
            _context.ratings.Add(rating);
            _context.SaveChanges();
            var product = await _context.Products
                .Where(e => e.ProductId == ratingDto.ProductId)
                .Include(c => c.Brand)
                .Include(c => c.Categories).Include(c => c.Images)
                .Include(c => c.Origin).Include(c => c.Rating).FirstOrDefaultAsync();
            var productDto = _mapper.Map<ProductsDto>(product);
            
            return productDto ?? new ProductsDto();
        }
        public async Task<Boolean> PutProductTrashAsync(List<int> ids)
        {
            List<Product> products = new List<Product>();

            try
            {
                ids.ForEach(id =>
                {
                    var product = _context.Products.Find(id);
                    if (product != null)
                    {
                        product.UpdateDate = DateTime.Now;
                        product.UpdateBy = "admin";
                        if (product.IsDeleted == true)
                        {
                            product.IsDeleted = false;
                        }
                        else { product.IsDeleted = true; }
                        products.Add(product);
                    }

                });
                if (ids.Count() != products.Count()) return false;
                products.ForEach(
                    product =>
                    {
                        _context.Entry(product).State = EntityState.Modified;
                    });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
        public async Task<Boolean> DeletedProdutAsync(List<int> ids)
        {
            List<Product> products = new List<Product>();
            try
            {
                ids.ForEach(id =>
                {
                    var product = _context.Products.Find(id);
                    if (product != null)
                    {
                        products.Add(product);
                    }

                });

                if (ids.Count() != products.Count()) return false;
                products.ForEach(
                    product =>
                    {
                        _context.Images.Where(i => i.Product == product).ToList().ForEach(e =>
                        {
                     var   imgdel = Path.Combine("wwwroot", "Upload", e.ImageUrl);
                        FileInfo fileInfo = new FileInfo(imgdel);
                            if (fileInfo.Exists)
                            {
                                System.IO.File.Delete(imgdel);
                                fileInfo.Delete();
                            } 
                            _context.Images.Remove(e);
                        } );
                        _context.Products.Remove(product);
                    });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }

        public async Task<int> PostProductAsync(ProductCreate productCreate)
        {
            List<Category> categories = new List<Category>();
            foreach(var cat in productCreate.Categories!)
            {
                categories.Add(_context.Categories.FirstOrDefault(c => c.CategoryId == cat.value)!);
            };

            Product product = new Product
            {

                ProductName = productCreate.ProductName,
                FullDescription = productCreate.FullDescription,
                Price = productCreate.Price,
                PriceDiscount = productCreate.PriceDiscount,
                Quantity = productCreate.Quantity,
                Categories = categories,
                BrandId = productCreate.BrandId,
                OriginId = productCreate.OriginId,
                Status = true,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            };
            try
            {
              
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return await _context.Products!.Where(p => p.ProductName == product.ProductName).OrderByDescending(p=>p.ProductId).Select(p=>p.ProductId)!.FirstOrDefaultAsync();
            }
            catch (DbException)
            {
                return 0;
            }
        }
    }
}
