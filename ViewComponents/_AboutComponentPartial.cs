using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Context;

namespace MyPortolioHomeWork.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle=portfolioContext.abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription = portfolioContext.abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail = portfolioContext.abouts.Select(x => x.Detail).FirstOrDefault();
            return View();
        }
    }
}
