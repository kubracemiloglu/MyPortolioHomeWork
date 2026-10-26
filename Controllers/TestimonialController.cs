using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class TestimonialController : AdminController
{
    public IActionResult Index() => View(context.Testimonials.OrderBy(x => x.TestimonialId).ToList());

    [HttpGet]
    public IActionResult CreateTestimonial()
    {
        
        return View(new Testimonial {  });
    }
    [HttpPost]
    public IActionResult CreateTestimonial(Testimonial model)
    {
        
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.TestimonialId = 0;
        context.Testimonials.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateTestimonial(int id)
    {
        var model = context.Testimonials.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateTestimonial(Testimonial model)
    {
        var existing = context.Testimonials.Find(model.TestimonialId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.NameSurname = model.NameSurname;
        existing.Title = model.Title;
        existing.Description = model.Description;
        existing.ImageUrl = model.ImageUrl;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteTestimonial(int id)
    {
        var model = context.Testimonials.Find(id);
        if (model == null) return NotFound();
        context.Testimonials.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(Testimonial model)
    {
        if (!string.IsNullOrWhiteSpace(model.ImageUrl) && !ContentRules.IsImagePath(model.ImageUrl))
            ModelState.AddModelError("ImageUrl", "Görsel için yerel bir yol veya http/https bağlantısı girin.");
    }

}
