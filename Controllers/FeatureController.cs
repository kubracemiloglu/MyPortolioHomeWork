using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class FeatureController : AdminController
{
    public IActionResult Index() => View(context.features.OrderBy(x => x.FeatureId).ToList());

    [HttpGet]
    public IActionResult CreateFeature()
    {
        var existing = context.features.OrderBy(x => x.FeatureId).FirstOrDefault();
        if (existing != null) return RedirectToAction("UpdateFeature", new { id = existing.FeatureId });
        return View(new Feature {  });
    }
    [HttpPost]
    public IActionResult CreateFeature(Feature model)
    {
        if (context.features.Any()) return RedirectToAction("Index");
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.FeatureId = 0;
        context.features.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateFeature(int id)
    {
        var model = context.features.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateFeature(Feature model)
    {
        var existing = context.features.Find(model.FeatureId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Title = model.Title;
        existing.Description = model.Description;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteFeature(int id)
    {
        var model = context.features.Find(id);
        if (model == null) return NotFound();
        context.features.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(Feature model)
    {

    }

}
