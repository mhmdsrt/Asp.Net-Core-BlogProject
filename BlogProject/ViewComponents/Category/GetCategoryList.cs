using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Category
{
	public class GetCategoryList:ViewComponent
	{
		private readonly ICategoryService _categoryService;
		public GetCategoryList(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		/*
		ViewComponent -> Sayfanın belirli bir bölümünü güncellemek için ViewComponent kullanmak daha mantıklıdır. 
		Ayrıca oluşturduğumuz ViewComponenti başka view sayfalarında da çağırıp kullabiliriz.

		Controller -> Sayfanın tamamını değiştirip başka bir sayfaya yönlendirmek gerekiyorsa controller kullanmak 
		 daha mantıklıdır. Sayfanın tamamını yönetir.

		Yani Controller sayfanın tamamını güncelliyor. Eğer biz bir sayfada sadece belirli alanları güncellemek istiyorsak
		bunlar ViewComponent olarak oluşturup kendine özel veri tabanı işlemlerini yaptırtıp ve kendilerine özel view'lerini oluşturabiliriz.
		Bu view'leride başka sayfa içerisinde çağırarak tüm sayfayı yenilemeden sayfanın belirlediğimiz her bir alanını özel olarak asenkron bir şekilde
		yötebiliriz. Ayrıca bu ViewComponentleri kullanabileceğimiz başka sayfaların view'kısmında  da çağırabiliriz.

✅ Controller, tüm sayfayı yönetir ve günceller.
✅ ViewComponent, sadece belirli bir bölümü yönetir ve günceller.
✅ ViewComponent'ler, kendine özel veritabanı işlemlerini yapabilir.
✅ ViewComponent'in kendi özel View'i olur ve bu View, başka sayfalar içinde çağrılabilir.
✅ Sayfanın tamamını yenilemeden sadece belirli bölümleri güncellemek için kullanılabilir.
✅ ViewComponent'ler asenkron çalıştırılabilir, böylece performans artar.
		 */
		public IViewComponentResult Invoke()
		{

			return View(_categoryService.GetAll());
		}
	}
}
