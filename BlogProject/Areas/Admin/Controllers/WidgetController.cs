using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	public class WidgetController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
