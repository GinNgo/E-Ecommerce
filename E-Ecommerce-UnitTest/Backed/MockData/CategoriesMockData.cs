using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_UnitTest.Backed.MockData
{
    public class CategoriesMockData
    {
        public static List<CategoriesDto> GetCategories() {
            return new List<CategoriesDto>() { 
                new CategoriesDto{ 
                CategoryId= 1,
                CategoryName = "cat1",
                CategoryDescription ="",
                ParentId= 0,
                },
                  new CategoriesDto{
                CategoryId= 2,
                CategoryName = "cat2",  CategoryDescription ="",
                ParentId= 0,
             
                },
                    new CategoriesDto{
                CategoryId= 3,
                CategoryName = "cat3",  CategoryDescription ="",
                ParentId= 0,
              
                }
            }; 
        }
    }
}
