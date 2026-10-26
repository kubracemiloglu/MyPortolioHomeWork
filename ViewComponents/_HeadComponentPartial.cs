using Microsoft.AspNetCore.Mvc;

namespace MyPortolioHomeWork.ViewComponents
{
    public class _HeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
