using Microsoft.AspNetCore.Mvc;

namespace MyPortolioHomeWork.ViewComponents.LayoutViewComponents
{
    public class _LayoutScriptComponenetPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
