using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
	public class CommentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}
