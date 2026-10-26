using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class ExperienceController : AdminController
{
    public IActionResult ExperienceList() => View(context.experiences.OrderBy(x => x.ExperienceId).ToList());

    [HttpGet]
    public IActionResult CreateExperience()
    {
        
        return View(new Experience {  });
    }
    [HttpPost]
    public IActionResult CreateExperience(Experience model)
    {
        
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.ExperienceId = 0;
        context.experiences.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("ExperienceList");
    }
    [HttpGet]
    public IActionResult UpdateExperience(int id)
    {
        var model = context.experiences.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateExperience(Experience model)
    {
        var existing = context.experiences.Find(model.ExperienceId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Head = model.Head;
        existing.Title = model.Title;
        existing.Date = model.Date;
        existing.Description = model.Description;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("ExperienceList");
    }
    [HttpPost]
    public IActionResult DeleteExperience(int id)
    {
        var model = context.experiences.Find(id);
        if (model == null) return NotFound();
        context.experiences.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("ExperienceList");
    }
    private void ValidateContent(Experience model)
    {

    }

}
