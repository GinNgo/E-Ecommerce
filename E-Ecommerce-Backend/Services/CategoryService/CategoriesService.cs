using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


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
        public async Task<List<CategoriesDto>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoriesDto = _mapper.Map<List<Category>, List<CategoriesDto>>(categories);
            categoriesDto = SubCategories(categoriesDto);
            return categoriesDto;
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
            var categories = await _context.Categories.Where(e => e.ParentId > 0).ToListAsync();
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
    }
}
