using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class PortfolioController : AdminController
{
    public IActionResult Index() => View(context.portfolios.OrderBy(x => x.PortfolioId).ToList());

    [HttpGet]
    public IActionResult CreatePortfolio()
    {
        
        return View(new Portfolio {  });
    }
    [HttpPost]
    public IActionResult CreatePortfolio(Portfolio model)
    {
        
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.PortfolioId = 0;
        context.portfolios.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdatePortfolio(int id)
    {
        var model = context.portfolios.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdatePortfolio(Portfolio model)
    {
        var existing = context.portfolios.Find(model.PortfolioId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Title = model.Title;
        existing.SubTitle = model.SubTitle;
        existing.ImageUrl = model.ImageUrl;
        existing.Url = model.Url;
        existing.Description = model.Description;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeletePortfolio(int id)
    {
        var model = context.portfolios.Find(id);
        if (model == null) return NotFound();
        context.portfolios.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(Portfolio model)
    {
        if (!string.IsNullOrWhiteSpace(model.ImageUrl) && !ContentRules.IsImagePath(model.ImageUrl))
            ModelState.AddModelError("ImageUrl", "Görsel için yerel bir yol veya http/https bağlantısı girin.");
        if (!string.IsNullOrWhiteSpace(model.Url) && !ContentRules.IsWebUrl(model.Url))
            ModelState.AddModelError("Url", "Geçerli bir http/https bağlantısı girin.");
    }

}
