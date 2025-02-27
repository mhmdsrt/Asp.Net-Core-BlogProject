using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
	public class BlogDetailComment : ViewComponent
	{
		
		public IViewComponentResult Invoke(int id)
		{
			ViewBag.BlogID = id;
			return View();
		}
	}
}
