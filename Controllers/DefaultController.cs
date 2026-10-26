using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Context;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;

namespace MyPortolioHomeWork.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index() => View();

    [HttpPost, RequestSizeLimit(20000)]
    [Microsoft.AspNetCore.RateLimiting.EnableRateLimiting("contact")]
    public IActionResult SendMessage(ContactMessageModel model)
    {
        if (!string.IsNullOrWhiteSpace(model.Company)) return BadRequest("Mesaj gönderilemedi.");
        if (!ModelState.IsValid)
        {
            var error = string.Join(" ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") return BadRequest(error);
            TempData["ContactError"] = error;
            return Redirect(Url.Action(nameof(Index)) + "#contact");
        }
        using var context = new MyPortfolioContext();
        context.messages.Add(new Message {
            NameSurname = model.ContactName.Trim(), Email = model.ContactEmail.Trim(),
            Subject = model.ContactSubject.Trim(), MessageDetail = model.ContactMessage.Trim(),
            SendDate = DateTime.Now, IsRead = false
        });
        context.SaveChanges();
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") return Content("OK");
        TempData["ContactSuccess"] = "Mesajın alındı, teşekkür ederim.";
        return Redirect(Url.Action(nameof(Index)) + "#contact");
    }
}
