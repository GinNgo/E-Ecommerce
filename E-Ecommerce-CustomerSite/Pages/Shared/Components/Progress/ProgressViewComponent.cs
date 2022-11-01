using E_Ecommerce_CustomerSite.Models;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Pages.Shared.Components.Rating
{
    public class ProgressViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(ScoreProgressViewModel progressViewModel)
        {
            if (progressViewModel.countTotal == 0) progressViewModel.countTotal = 1;


            return View(progressViewModel);
        }
    }
}
