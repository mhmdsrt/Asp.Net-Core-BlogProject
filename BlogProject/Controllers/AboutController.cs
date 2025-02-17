using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
