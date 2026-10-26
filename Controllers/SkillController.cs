using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class SkillController : AdminController
{
    public IActionResult Index() => View(context.skills.OrderBy(x => x.SkillId).ToList());

    [HttpGet]
    public IActionResult CreateSkill()
    {
        
        return View(new Skill {  });
    }
    [HttpPost]
    public IActionResult CreateSkill(Skill model)
    {
        
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.SkillId = 0;
        context.skills.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateSkill(int id)
    {
        var model = context.skills.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateSkill(Skill model)
    {
        var existing = context.skills.Find(model.SkillId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Title = model.Title;
        existing.Value = model.Value;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteSkill(int id)
    {
        var model = context.skills.Find(id);
        if (model == null) return NotFound();
        context.skills.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(Skill model)
    {

    }

}
