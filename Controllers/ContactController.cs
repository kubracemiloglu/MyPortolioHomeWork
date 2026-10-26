using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class ContactController : AdminController
{
    public IActionResult Index() => View(context.contacts.OrderBy(x => x.ContactId).ToList());

    [HttpGet]
    public IActionResult CreateContact()
    {
        var existing = context.contacts.OrderBy(x => x.ContactId).FirstOrDefault();
        if (existing != null) return RedirectToAction("UpdateContact", new { id = existing.ContactId });
        return View(new Contact {  });
    }
    [HttpPost]
    public IActionResult CreateContact(Contact model)
    {
        if (context.contacts.Any()) return RedirectToAction("Index");
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.ContactId = 0;
        context.contacts.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateContact(int id)
    {
        var model = context.contacts.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateContact(Contact model)
    {
        var existing = context.contacts.Find(model.ContactId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Title = model.Title;
        existing.Description = model.Description;
        existing.Phone1 = model.Phone1;
        existing.Phone2 = model.Phone2;
        existing.Email1 = model.Email1;
        existing.Email2 = model.Email2;
        existing.Address = model.Address;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteContact(int id)
    {
        var model = context.contacts.Find(id);
        if (model == null) return NotFound();
        context.contacts.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(Contact model)
    {
        if (!string.IsNullOrWhiteSpace(model.Email2) && !new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(model.Email2))
            ModelState.AddModelError("Email2", "Geçerli bir e-posta girin.");

    }

}
