using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Context;

namespace MyPortolioHomeWork.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();

        public IViewComponentResult Invoke()
        {
            var values = portfolioContext.experiences.ToList();
            return View(values);
        }
    }
}