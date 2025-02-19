using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*
  "builder.Services.AddDbContext<Context>" ifadesi Context nesnesini DI(Dependecy Injection) Sistemine kaydeder.

   Context s�n�f� tipinde nesneye ihtiya� duyulan heryerde enjeckte edilir. 
 */

builder.Services.AddDbContext<Context>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // appsettings.json dosyas�ndaki "DefaultConnection" ba�lant� dizesini al�yoruz.



/*
  Dependecy Injection yap�s� sayesinde IAboutRepository isteyen her yere AboutRepository nesnesini otomatik olarak enjekte edicek(vericek).
 
 "AddScoped" ile her HTTP iste�i i�in yeni bir nesne olu�turur ve ayn� istekde tekrar kullan�l�r,
  Daha sonra istek bitti�inde DbContext kapat�l�r ve bellek temizlenir.

  Veritaban� ba�lant�lar� a��r i�lemlerdir. Bir iste�e �zel ba�lant� a��p geri kapatmal�y�z Scope da tam bunu yapar.

 AddScoped -> Her HTTP iste�i i�in yeni bir nesne olu�turup ayn� istekde tekrar kullan�r
 AddTransient -> Her �a�r�ld���nda yeni bir nesne olu�turur�. Hafif ve k�sa s�reli i�lemlere uygundur. �rne�in : EmailService, SMSService gibi k�sa s�reli i�lemler.
 AddSingleton -> Uygulama boyunca ayn� nesneyi kullan�r. Statik (de�i�meyen) servisler i�in uygundur. �rne�in : CacheService, LoggingService, ConfigurationService gibi de�i�meyen hizmetler.
 */
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IWriterRepository, WriterRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IWriterService, WriterService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IMessageService, MessageService>();



// Add services to the container.
builder.Services.AddControllersWithViews();


// Authentication -> Kimlik Do�rulama
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) // Varsay�lan olarak Cookie(�erez) tabanl� kimlik do�rulamay� kullan.
	.AddCookie(config =>
	{
		config.LoginPath = "/Login/Index"; // Kimlik do�rulama ba�ar�s�z oldu�u zaman y�nlendirilecek URL.
	});


builder.Services.AddMvc(config => // Authorization -> Yetkikendirme, Policy -> Politika ,Authenticated -> Kimli�i Do�rulanm��, Require -> Gerekli K�lmak
{  //  Politika -> t�rk�ede kurallar koymak ve uygulamak i�in yap�lan faaliyetler demektir.
	var policy = new AuthorizationPolicyBuilder() // AuthorizationPolicyBuilder -> Yetkilendirme Politika Olu�turucusu
	.RequireAuthenticatedUser()  // RequireAuthenticatedUser -> Kimli�i Do�rulanm�� Kull�c�y� Gerekli K�l
	.Build(); // Build -> Olu�tur.

	config.Filters.Add(new AuthorizeFilter(policy)); // Authorize -> Yetki vermek.
													 // Bu yap� sayesinden t�m MVC hizmetlerine Yetkilendiri�mi� ki�i taraf�ndan giri� yapmay� zorunlu k�l�yoruz.(Proje Seviyesinde)
													 // Yani gidip tek tek [Authorize] yazmam�za gerek kalm�yor. Projenin geneline [Authorize] uyguluyor.
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?code={0}"); // ErrorPage
/*
   hata kodu {0} yerine gelecek de�erdir �rne�in 404,500 gibi.

   ?code={0} ifadesi �unu yapar: "code" ismiden bir parametre ekler ve "{0}" de�eri yerine ise ger�ek HTTP hata kodunu yazar.
 */




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
