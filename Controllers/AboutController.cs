using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class AboutController : AdminController
{
    public IActionResult Index() => View(context.abouts.OrderBy(x => x.AboutId).ToList());

    [HttpGet]
    public IActionResult CreateAbout()
    {
        var existing = context.abouts.OrderBy(x => x.AboutId).FirstOrDefault();
        if (existing != null) return RedirectToAction("UpdateAbout", new { id = existing.AboutId });
        return View(new About {  });
    }
    [HttpPost]
    public IActionResult CreateAbout(About model)
    {
        if (context.abouts.Any()) return RedirectToAction("Index");
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.AboutId = 0;
        context.abouts.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateAbout(int id)
    {
        var model = context.abouts.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateAbout(About model)
    {
        var existing = context.abouts.Find(model.AboutId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Title = model.Title;
        existing.SubDescription = model.SubDescription;
        existing.Detail = model.Detail;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteAbout(int id)
    {
        var model = context.abouts.Find(id);
        if (model == null) return NotFound();
        context.abouts.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(About model)
    {

    }

}
