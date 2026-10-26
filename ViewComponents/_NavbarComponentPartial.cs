using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Context;

namespace MyPortolioHomeWork.ViewComponents
{
    public class _NavbarComponentPartial: ViewComponent
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();

        public IViewComponentResult Invoke()
        {
            ViewBag.hasTestimonials = portfolioContext.Testimonials.Any();
            return View();
        }
    }
}
