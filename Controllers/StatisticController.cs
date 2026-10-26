using Microsoft.AspNetCore.Mvc;
namespace MyPortolioHomeWork.Controllers;
public class StatisticController : AdminController
{
    public IActionResult Index()
    {
        ViewBag.SkillCount = context.skills.Count();
        ViewBag.MessageCount = context.messages.Count();
        ViewBag.UnreadCount = context.messages.Count(x => !x.IsRead);
        ViewBag.ReadCount = context.messages.Count(x => x.IsRead);
        ViewBag.ExperienceCount = context.experiences.Count();
        ViewBag.PortfolioCount = context.portfolios.Count();
        ViewBag.TestimonialCount = context.Testimonials.Count();
        ViewBag.SocialMediaCount = context.socialMedias.Count();
        ViewBag.PendingCount = context.ToDoLists.Count(x => !x.Status);
        ViewBag.CompletedCount = context.ToDoLists.Count(x => x.Status);
        ViewBag.AboutCount = context.abouts.Count();
        ViewBag.ContactCount = context.contacts.Count();
        return View();
    }
}
