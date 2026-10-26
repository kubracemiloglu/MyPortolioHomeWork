using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.Models;
namespace MyPortolioHomeWork.Controllers;
public class SearchController : AdminController
{
    public IActionResult Index(string? q)
    {
        q = q?.Trim();
        ViewBag.Query = q;
        var results = new List<SearchResult>();
        if (string.IsNullOrWhiteSpace(q) || q.Length > 200) return View(results);
        results.AddRange(context.abouts.Where(x => x.Title.Contains(q) || x.SubDescription.Contains(q) || x.Detail.Contains(q)).OrderBy(x => x.AboutId).Take(20).Select(x => new SearchResult("Hakkımda", x.Title, "/About/UpdateAbout/" + x.AboutId)).ToList());
        results.AddRange(context.features.Where(x => x.Title.Contains(q) || x.Description.Contains(q)).OrderBy(x => x.FeatureId).Take(20).Select(x => new SearchResult("Öne Çıkan Alan", x.Title, "/Feature/UpdateFeature/" + x.FeatureId)).ToList());
        results.AddRange(context.contacts.Where(x => x.Title.Contains(q) || x.Description.Contains(q) || x.Phone1.Contains(q) || x.Phone2.Contains(q) || x.Email1.Contains(q) || x.Email2.Contains(q) || x.Address.Contains(q)).OrderBy(x => x.ContactId).Take(20).Select(x => new SearchResult("İletişim Bilgileri", x.Title, "/Contact/UpdateContact/" + x.ContactId)).ToList());
        results.AddRange(context.portfolios.Where(x => x.Title.Contains(q) || x.SubTitle.Contains(q) || x.ImageUrl.Contains(q) || x.Url.Contains(q) || x.Description.Contains(q)).OrderBy(x => x.PortfolioId).Take(20).Select(x => new SearchResult("Portfolyo", x.Title, "/Portfolio/UpdatePortfolio/" + x.PortfolioId)).ToList());
        results.AddRange(context.skills.Where(x => x.Title.Contains(q)).OrderBy(x => x.SkillId).Take(20).Select(x => new SearchResult("Yeteneklerim", x.Title, "/Skill/UpdateSkill/" + x.SkillId)).ToList());
        results.AddRange(context.Testimonials.Where(x => x.NameSurname.Contains(q) || x.Title.Contains(q) || x.Description.Contains(q) || x.ImageUrl.Contains(q)).OrderBy(x => x.TestimonialId).Take(20).Select(x => new SearchResult("Referanslarım", x.NameSurname, "/Testimonial/UpdateTestimonial/" + x.TestimonialId)).ToList());
        results.AddRange(context.socialMedias.Where(x => x.Title.Contains(q) || x.Url.Contains(q) || x.Icon.Contains(q)).OrderBy(x => x.SocialMediaId).Take(20).Select(x => new SearchResult("Sosyal Medya", x.Title, "/SocialMedia/UpdateSocialMedia/" + x.SocialMediaId)).ToList());
        results.AddRange(context.experiences.Where(x => x.Head.Contains(q) || x.Title.Contains(q) || x.Date.Contains(q) || x.Description.Contains(q)).OrderBy(x => x.ExperienceId).Take(20).Select(x => new SearchResult("Deneyimler", x.Head, "/Experience/UpdateExperience/" + x.ExperienceId)).ToList());
        results.AddRange(context.ToDoLists.Where(x => x.Title.Contains(q) || x.ImageUrl.Contains(q)).OrderBy(x => x.ToDoListId).Take(20).Select(x => new SearchResult("Yapılacaklar", x.Title, "/ToDoList/UpdateToDoList/" + x.ToDoListId)).ToList());
        results.AddRange(context.messages.Where(x => x.NameSurname.Contains(q) || x.Subject.Contains(q) || x.MessageDetail.Contains(q)).OrderByDescending(x => x.SendDate).Take(20).Select(x => new SearchResult("Mesajlar", x.Subject, "/Message/MessageDetail/" + x.MessageId)).ToList());
        return View(results);
    }
}
