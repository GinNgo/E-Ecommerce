
using E_Ecommerce_Backend.Controllers;
using E_Ecommerce_Backend.Services.CategoryService;
using E_Ecommerce_Shared.DTO.Categories;
using E_Ecommerce_UnitTest.Backed.MockData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_UnitTest.Backed.Controller
{
    public class TestCategoryController
    {
        [Fact]
        public async Task GetCategoryAsync()
        {
            //Arrange
            var categoryService = new Mock<ICategoriesService>();
            categoryService.Setup(sv=>sv.GetCategoriesAsync()).ReturnsAsync(CategoriesMockData.GetCategories());
            var res = new CategoriesController(categoryService.Object);
            //Act
            var result = await res.GetCategoriesAsync();
            //Assert
           
            Assert.Equal(CategoriesMockData.GetCategories(), result.Value);
        }

    }
}
