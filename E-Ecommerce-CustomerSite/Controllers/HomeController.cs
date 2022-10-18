using E_Ecommerce_CustomerSite.Models;
using E_Ecommerce_CustomerSite.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Ecommerce_CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriesService _categoryService;

        public HomeController(ILogger<HomeController> logger, ICategoriesService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Category()
        {
            var catList =await _categoryService.GetAllCategories();
            return View(catList);
        }
    }
}