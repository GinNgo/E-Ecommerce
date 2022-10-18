using E_Ecommerce_CustomerSite.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoriesService _categoryService;
        public CategoriesViewComponent(ICategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =await _categoryService.GetAllCategories();
            return View("Categories",categories);
        }
    }
}
