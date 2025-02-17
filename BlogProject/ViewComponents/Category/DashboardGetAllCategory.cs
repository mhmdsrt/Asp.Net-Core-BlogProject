using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Category
{
	public class DashboardGetAllCategory : ViewComponent
	{
		private readonly ICategoryService _categoryService;
		public DashboardGetAllCategory(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_categoryService.GetAll());
		}
	}
}
