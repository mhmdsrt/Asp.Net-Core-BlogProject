using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Abstract;

namespace BlogProject.Controllers
{
	/* if blogları şunun için kullanılır.
    ✅ Hatalı durumlar en başta kontrol edilir ve hata mesajı döndürülerek işlem kesilir.
    ✅ Kodun geri kalan kısmı sadece başarılı senaryo için çalışır.
	 */
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly IWriterService _writerService;
		public RegisterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer entity) // Validate -> Doğrula, Validator -> Doğrulayıcı, ValidationResult -> Doğrulama Sonuçları
		{
			WriterValidator writerValidator = new WriterValidator();
			ValidationResult validationResult = writerValidator.Validate(entity);

			entity.WriterStatus = true;
			entity.WriterImage = "defaultProfile.png";
			if (!validationResult.IsValid) // Eğer Doğrulama Sonuçları geçerli değilse, IsValid -> geçerli
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage); // Eğer doğrulanma yapılmadıysa her hatanın ilgili property'si ile mesajını göster.

				}
				return View();
			}

			_writerService.Insert(entity);
			return RedirectToAction("Index", "Writer");
		}




	}
}
