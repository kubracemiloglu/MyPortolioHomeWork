using Microsoft.AspNetCore.Mvc;
namespace MyPortolioHomeWork.Controllers;
public class LayoutController : AdminController
{
    public IActionResult Index() => RedirectToAction("Index", "Statistic");
}
