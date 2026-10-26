using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class SocialMediaController : AdminController
{
    public IActionResult Index() => View(context.socialMedias.OrderBy(x => x.SocialMediaId).ToList());

    [HttpGet]
    public IActionResult CreateSocialMedia()
    {
        
        return View(new SocialMedia {  });
    }
    [HttpPost]
    public IActionResult CreateSocialMedia(SocialMedia model)
    {
        
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.SocialMediaId = 0;
        context.socialMedias.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateSocialMedia(int id)
    {
        var model = context.socialMedias.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateSocialMedia(SocialMedia model)
    {
        var existing = context.socialMedias.Find(model.SocialMediaId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Title = model.Title;
        existing.Url = model.Url;
        existing.Icon = model.Icon;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteSocialMedia(int id)
    {
        var model = context.socialMedias.Find(id);
        if (model == null) return NotFound();
        context.socialMedias.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(SocialMedia model)
    {
        if (!string.IsNullOrWhiteSpace(model.Url) && !ContentRules.IsWebUrl(model.Url))
            ModelState.AddModelError("Url", "Geçerli bir http/https bağlantısı girin.");
    }

}
