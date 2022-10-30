using E_Ecommerce_CustomerSite.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Pages.Shared.Components.CategoriesHome
{
    public class CategoriesHomeViewComponent : ViewComponent
    {
        private readonly ICategoriesService _categoryService;
        public CategoriesHomeViewComponent(ICategoriesService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllCategories();
            return View( categories);
        }
    }
}
