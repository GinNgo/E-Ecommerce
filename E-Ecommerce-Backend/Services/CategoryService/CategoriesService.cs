using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.Admin;
using E_Ecommerce_Shared.DTO.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace E_Ecommerce_Backend.Services.CategoryService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesService(EcommecreDbContext ecommecreDbContext, IMapper mapper)
        {
            _context = ecommecreDbContext;
            _mapper = mapper;
        }
        public async Task<List<CategoriesDto>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoriesDto = _mapper.Map<List<Category>, List<CategoriesDto>>(categories);
            categoriesDto = SubCategories(categoriesDto);
            return categoriesDto;
        }

        public async Task<CategoryAdmin> GetOneCategoryAsync(int id)
        {
            var categories = await _context.Categories.Where(i=>i.CategoryId==id).FirstOrDefaultAsync();
            var categoryAdmin = _mapper.Map<Category, CategoryAdmin>(categories!);
            return categoryAdmin;
        }
        public async Task<List<CategoriesDto>> GetBreadCrumb(int id)
        {
            List<CategoriesDto> ListBreadCrumb = new List<CategoriesDto>();
            int check = id;
            var categories = await _context.Categories.ToListAsync();
            var categoriesDto = _mapper.Map<List<Category>, List<CategoriesDto>>(categories);
            while (check>0)
            {
                int index = categoriesDto.FindIndex(i=>i.CategoryId.Equals(check));
                if (index != 0  )
                {
                    check = (int)categoriesDto[index].ParentId!;
                    ListBreadCrumb.Add(categoriesDto[index]);
                }
                
            }
            if (ListBreadCrumb != null)
            {
                ListBreadCrumb.Reverse();
            }
            return ListBreadCrumb?? new List<CategoriesDto>();
        }
        public async Task<List<int>> GetCategoriesIdChild(int id)
        {
            List<int> subNavId = new List<int>();
            var categories = await _context.Categories.Where(e => e.ParentId > 0&& e.IsDeleted==false&&e.Status==true).ToListAsync();
            var categoriesDto = _mapper.Map<List<Category>, List<CategoriesDto>>(categories);
            categoriesDto = SubCategories(categoriesDto, id);
            if (categoriesDto.Count() > 0)
                subNavId = SubCategoriesChildId(categoriesDto);
            else
            {
                subNavId.Add(id);
            }
            return subNavId;
        }
        public List<CategoriesDto> SubCategories(List<CategoriesDto> categoriesDtos, int ParentId = 0)
        {
            var categories = new List<CategoriesDto>();
            foreach (var category in categoriesDtos)
            {
                if (category.ParentId.Equals(ParentId))
                {
                    List<CategoriesDto> categoriesDtos1 = new List<CategoriesDto>(categoriesDtos);
                    categoriesDtos1.Remove(category);
                    var child = SubCategories(categoriesDtos, category.CategoryId);
                    category.Child = child;
                    categories.Add(category);
                }
            }
            return categories;
        }
        public List<int> SubCategoriesChildId(List<CategoriesDto> categories)
        {

            List<int> subNavId = new List<int>();

            foreach (var category in categories)
            {
                if (category.Child != null && category.Child.Count >0 )
                {
                    var subnav = SubCategoriesChildId(category.Child);
                    subnav.ForEach(s =>
                    {
                        subNavId.Add(s);
                    });
                }
                else
                {
                    subNavId.Add(category.CategoryId);
                }
            }


            return subNavId;
        }
        //admin
        public async Task<List<CategoryAdmin>> GetCategoriesAdminAsync()
        {
    
            var categories = await _context.Categories.Where(c=>c.CategoryId!=0&c.IsDeleted==false).OrderByDescending(c=>c.CategoryId).ToListAsync();
            categories.ForEach(i =>
            {
                if (i.ParentId > 0)
                {
                    var nameParent = categories.FirstOrDefault(e => e.CategoryId == i.ParentId)!.CategoryName;
                    var category = categories.FirstOrDefault(e => e.CategoryId == i.CategoryId);
                    category!.CategoryName = nameParent + " >> " + category!.CategoryName;
                    
                }
            });

            var categoriesAdmin = _mapper.Map<List<Category>, List<CategoryAdmin>>(categories);
            return categoriesAdmin;
        }
        public async Task<List<CategoryAdmin>> GetCategoriesAdminTrashAsync()
        {

            var categories = await _context.Categories.Where(c => c.CategoryId != 0  & c.IsDeleted == true).OrderByDescending(c => c.CategoryId).ToListAsync();
            categories.ForEach(i =>
            {
                if (i.ParentId > 0)
                {
                    var nameParent = _context.Categories.FirstOrDefault(e => e.CategoryId == i.ParentId)!.CategoryName;
                    var category = _context.Categories.FirstOrDefault(e => e.CategoryId == i.CategoryId);
                    category!.CategoryName = nameParent + " >> " + category!.CategoryName;

                }
            });
            var categoriesAdmin = _mapper.Map<List<Category>, List<CategoryAdmin>>(categories);
            return categoriesAdmin;
        }
        public async Task<List<CategoryParent>> GetCategoriesParentAsync()
        {

            var categories = await _context.Categories.Where(c => c.CategoryId != 0).ToListAsync();
            categories.ForEach(i =>
            {
                if (i.ParentId > 0)
                {
                    var nameParent = categories.FirstOrDefault(e => e.CategoryId == i.ParentId)!.CategoryName;
                    var category = categories.FirstOrDefault(e => e.CategoryId == i.CategoryId);
                    category!.CategoryName = nameParent + " >> " + category!.CategoryName;

                }
            });
            var categoriesParent = new List<CategoryParent>()
            {
                new CategoryParent
                {
                    value=0,
                    label="None"
                }
            };
            categoriesParent.AddRange(
                _mapper.Map<List<Category>, List<CategoryParent>>(categories));
            return categoriesParent;
        }

        public async Task<Boolean> PostCategoryAsync(Category category)
        {
           
            try
            {
                category.CreateDate = DateTime.Now;
                category.CreateBy = "Admin";
                category.Status = true;
                category.IsDeleted = false;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
        public async Task<Boolean> PutCategoryAsync(Category category)
        {

            try
            {
                category.UpdateDate = DateTime.Now;
                category.UpdateBy = "Admin";
                category.Status = true;
                category.IsDeleted = false;
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }

        public async Task<Boolean> PutCategoryTrashAsync(List<int> ids)
        {
            List<Category> categories = new List<Category>();

            try
            {
                ids.ForEach(id =>
                {
                    var category = _context.Categories.Find(id);
                    if (category != null)
                    {
                        category.UpdateDate = DateTime.Now;
                        category.UpdateBy = "Admin";
                   if(category.IsDeleted == true)
                        {
                            category.IsDeleted = false;
                        }
                        else { category.IsDeleted = true; }
                        categories.Add(category);
                    }

                });
                if (ids.Count() != categories.Count()) return false;
                categories.ForEach(
                    category =>
                    {
                        _context.Entry(category).State = EntityState.Modified;
                    });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }

        public async Task<Boolean> DeletedCategoryAsync(List<int> ids)
        {
            List<Category> categories = new List<Category>();
            try
            {
                ids.ForEach(id =>
                {
                    var category = _context.Categories.Find(id);
                    if (category != null)
                    {
                        categories.Add(category);
                    }

                });
                if (ids.Count() != categories.Count()) return false;
                categories.ForEach(
                    category =>
                    {
                        _context.Categories.Remove(category);
                    });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
    }
}
