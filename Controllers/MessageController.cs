using Microsoft.AspNetCore.Mvc;
namespace MyPortolioHomeWork.Controllers;

public class MessageController : AdminController
{
    public IActionResult Inbox(string? q)
    {
        var query = context.messages.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(x => x.NameSurname.Contains(q) || x.Subject.Contains(q) || x.MessageDetail.Contains(q));
        ViewBag.Query = q;
        return View(query.OrderByDescending(x => x.SendDate).ThenByDescending(x => x.MessageId).ToList());
    }
    [HttpPost]
    public IActionResult ChangeIsReadToTrue(int id) => SetRead(id, true);
    [HttpPost]
    public IActionResult ChangeIsReadToFalse(int id) => SetRead(id, false);
    private IActionResult SetRead(int id, bool read)
    {
        var message = context.messages.Find(id);
        if (message == null) return NotFound();
        message.IsRead = read;
        context.SaveChanges();
        TempData["Success"] = "Mesaj durumu güncellendi.";
        return RedirectToAction(nameof(Inbox));
    }
    [HttpPost]
    public IActionResult DeleteMessage(int id)
    {
        var message = context.messages.Find(id);
        if (message == null) return NotFound();
        context.messages.Remove(message);
        context.SaveChanges();
        TempData["Success"] = "Mesaj silindi.";
        return RedirectToAction(nameof(Inbox));
    }
    public IActionResult MessageDetail(int id)
    {
        var message = context.messages.Find(id);
        if (message == null) return NotFound();
        return View(message);
    }
}
