using Microsoft.AspNetCore.Mvc;
using MyPortolioHomeWork.DAL.Context;

namespace MyPortolioHomeWork.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial:ViewComponent
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.toDoListCount = context.ToDoLists.Where(x => x.Status == false).Count();
			ViewBag.unreadMessageCount = context.messages.Count(x => !x.IsRead);
			var values = context.ToDoLists.Where(x => x.Status == false).OrderBy(x => x.Date).Take(5).ToList();
			return View(values);
		}
	}
}
