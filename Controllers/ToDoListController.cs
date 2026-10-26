using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class ToDoListController : AdminController
{
    public IActionResult Index() => View(context.ToDoLists.OrderBy(x => x.ToDoListId).ToList());

    [HttpGet]
    public IActionResult CreateToDoList()
    {
        
        return View(new ToDoList { Date = DateTime.Today, ImageUrl = "la la-check" });
    }
    [HttpPost]
    public IActionResult CreateToDoList(ToDoList model)
    {
        
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        model.ToDoListId = 0;
        context.ToDoLists.Add(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt eklendi.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateToDoList(int id)
    {
        var model = context.ToDoLists.Find(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    public IActionResult UpdateToDoList(ToDoList model)
    {
        var existing = context.ToDoLists.Find(model.ToDoListId);
        if (existing == null) return NotFound();
        ValidateContent(model);
        if (!ModelState.IsValid) return View(model);
        existing.Title = model.Title;
        existing.ImageUrl = model.ImageUrl;
        existing.Date = model.Date;
        context.SaveChanges();
        TempData["Success"] = "Kayıt güncellendi.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteToDoList(int id)
    {
        var model = context.ToDoLists.Find(id);
        if (model == null) return NotFound();
        context.ToDoLists.Remove(model);
        context.SaveChanges();
        TempData["Success"] = "Kayıt silindi.";
        return RedirectToAction("Index");
    }
    private void ValidateContent(ToDoList model)
    {

    }

    [HttpPost]
    public IActionResult ChangeToDoListStatusToTrue(int id) => SetStatus(id, true);
    [HttpPost]
    public IActionResult ChangeToDoListStatusToFalse(int id) => SetStatus(id, false);
    private IActionResult SetStatus(int id, bool status)
    {
        var item = context.ToDoLists.Find(id);
        if (item == null) return NotFound();
        item.Status = status;
        context.SaveChanges();
        TempData["Success"] = "İşin durumu güncellendi.";
        return RedirectToAction("Index");
    }
}
