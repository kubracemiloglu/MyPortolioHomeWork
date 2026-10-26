using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Context;

namespace MyPortolioHomeWork.ViewComponents
{
    public class _StatisticComponentPartial : ViewComponent
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();

        public IViewComponentResult Invoke()
        {
            ViewBag.skillCount = portfolioContext.skills.Count();
            ViewBag.experienceCount = portfolioContext.experiences.Count();
            ViewBag.portfolioCount = portfolioContext.portfolios.Count();
            ViewBag.testimonialCount = portfolioContext.Testimonials.Count();
            return View();
        }
    }
}