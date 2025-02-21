using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.Controllers
{

	[AllowAnonymous] // Allow -> İzin Vermek. Anonymous -> Anonim, AllowAnonymous -> Kimliği Belirsizlere izin ver

	public class LoginController : Controller 
	{
		private readonly Context _context;
		public LoginController(Context context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		// User.Identity.Name ile sisteme başarılı giriş yapmış kullanıcının "ClaimTypes.Name" için oluşturduğumuz değerini alıyoruz biz aşağıda buna mail vermişiz 
		public async Task<IActionResult> Index(Writer entity)   // Index sayfası varsayılan sayfadır yani Index Action'u varsayılan Action'dur.  Task -> Görev
		{
			// FirstOrDefault() -> Belirli filtreleme yaparak belirlik bir koşula uyan ilk değeri getirir eğer yoksa null dönder
			// Find() -> Parametre olarak Primary Key (id numarası) alır ve id numarasına göre arama yapar.
			var user = _context.Writers.Where(x => x.WriterMail == entity.WriterMail & x.WriterPassword == entity.WriterPassword).FirstOrDefault();
			if (user == null)
			{
				return View();
			}
			// Claim -> Hak,talep  
			var claims = new List<Claim>() // Claims listesi kullanıcının sahip olduğu hakları(yetkilerini) ve rolünü gösterir. 
			{
				new Claim(ClaimTypes.Name,entity.WriterMail)
				
			};
			// "Cookies"parametresi Authentication Type oluyor.(Kimlik doğrulama tipi), Bu parametreyi kullacının hangi yöntemle giriş yaptığını belirtmek için kullanıyoruz.
			//  Eğer bu parametre yerine "a" gibi bir ifade yazsaydık kimlik doğrulama türünü kullancağımız yer olursa orda saçma olabilirdi çünkü bu parametre kimlik doğrulama türünü gösteriyor.
			var claimsIdenity = new ClaimsIdentity(claims,"Cookies");

			// Principal -> Yetkili kişi, Ana kullanıcı.
			var claimsPrincipal = new ClaimsPrincipal(claimsIdenity); //  Kimiliği doğrulanmış kullanıcıyı temsil etmek için kullanılır. Bir veya daha fazla claimsIdentity içerebilir.

			// Sign In -> Oturum aç
			// SignInAsync() metodu çağrıldığında Asp.net Core tarayıcıya bir Auyhentication Cookie(Kimlik Doğrulama Çerezi) gönderir ve bu Cookie(Çerez) tarayıcıda kaydedilir ve sayfalarda dolaşırken tekrar giriş yapmasına gerek kalmaz.
			await HttpContext.SignInAsync(claimsPrincipal); //  Parametredeki kullanıcının oturum açmasını sağlar. 
			return RedirectToAction("Index","Writer");
		}
	}
}
