using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
	public class ErrorPageController : Controller
	{
		[AllowAnonymous]
		public IActionResult Error(int code)
		{
			return View();
		}
	}
}
