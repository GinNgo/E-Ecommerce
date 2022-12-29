using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.Admin;
using E_Ecommerce_Shared.DTO.Categories;
using Microsoft.EntityFrameworkCore;

namespace E_Ecommerce_Backend.Services.OriginService
{
    public class OriginService:IOriginService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;

        public OriginService(EcommecreDbContext ecommecreDbContext, IMapper mapper)
        {
            _context = ecommecreDbContext;
            _mapper = mapper;
        }
        public async Task<List<OriginAdmin>> GetCategoriesParentAsync()
        {

            var origins = await _context.Origins.ToListAsync();
         
            var originsAdmin =  _mapper.Map<List<Origin>, List<OriginAdmin>>(origins);
            return originsAdmin;
        }
    }
}
