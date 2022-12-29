using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.Admin;
using Microsoft.EntityFrameworkCore;

namespace E_Ecommerce_Backend.Services.BrandService
{
    public class BrandService:IBrandService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;

        public BrandService(EcommecreDbContext ecommecreDbContext, IMapper mapper)
        {
            _context = ecommecreDbContext;
            _mapper = mapper;
        }
        public async Task<List<BrandAdmin>> GetCategoriesParentAsync()
        {

            var brands = await _context.Brands.ToListAsync();

            var brandsAdmin = _mapper.Map<List<Brand>, List<BrandAdmin>>(brands);
            return brandsAdmin;
        }
    }
}
