using Microsoft.AspNetCore.Mvc;

namespace MyPortolioHomeWork.ViewComponents.LayoutViewComponents
{
    public class _LayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
