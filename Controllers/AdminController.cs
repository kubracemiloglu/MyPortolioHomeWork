using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Context;
namespace MyPortolioHomeWork.Controllers;
[Authorize]
public abstract class AdminController : Controller
{
    protected readonly MyPortfolioContext context = new();
    protected override void Dispose(bool disposing)
    {
        if (disposing) context.Dispose();
        base.Dispose(disposing);
    }
}
