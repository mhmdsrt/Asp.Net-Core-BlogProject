using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Category
{
	public class UserLayoutHeaderCategoryList : ViewComponent
	{
		private readonly ICategoryService _categoryService;
		public UserLayoutHeaderCategoryList(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_categoryService.GetAll());
		}
	}
}
