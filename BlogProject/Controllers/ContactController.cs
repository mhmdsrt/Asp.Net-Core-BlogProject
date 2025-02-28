using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Contact entity) // Validate -> Doğrula, Validator -> Doğrulayıcı, ValidationResult -> Doğrulama Sonuçları
		{
			ContactValidator contactValidator = new ContactValidator();
			ValidationResult validationResult = contactValidator.Validate(entity);
			if (!validationResult.IsValid) // Eğer Doğrulama Sonuçları geçerli değilse, IsValid -> geçerli
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);  // Eğer doğrulanma yapılmadıysa her hatanın ilgili property'si ile mesajını göster.
				}
				return View();
			}
			entity.ContactStatus = true;
			entity.ContactCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			_contactService.Insert(entity);

			return RedirectToAction("Index", "Blog");
		}
		/* if blogları şunun için kullanılır.
       ✅ Hatalı durumlar en başta kontrol edilir ve hata mesajı döndürülerek işlem kesilir.
       ✅ Kodun geri kalan kısmı sadece başarılı senaryo için çalışır.
       */
	}
}
