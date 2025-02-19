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

   Context sýnýfý tipinde nesneye ihtiyaç duyulan heryerde enjeckte edilir. 
 */

builder.Services.AddDbContext<Context>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // appsettings.json dosyasýndaki "DefaultConnection" baðlantý dizesini alýyoruz.



/*
  Dependecy Injection yapýsý sayesinde IAboutRepository isteyen her yere AboutRepository nesnesini otomatik olarak enjekte edicek(vericek).
 
 "AddScoped" ile her HTTP isteði için yeni bir nesne oluþturur ve ayný istekde tekrar kullanýlýr,
  Daha sonra istek bittiðinde DbContext kapatýlýr ve bellek temizlenir.

  Veritabaný baðlantýlarý aðýr iþlemlerdir. Bir isteðe özel baðlantý açýp geri kapatmalýyýz Scope da tam bunu yapar.

 AddScoped -> Her HTTP isteði için yeni bir nesne oluþturup ayný istekde tekrar kullanýr
 AddTransient -> Her çaðrýldýðýnda yeni bir nesne oluþtururç. Hafif ve kýsa süreli iþlemlere uygundur. Örneðin : EmailService, SMSService gibi kýsa süreli iþlemler.
 AddSingleton -> Uygulama boyunca ayný nesneyi kullanýr. Statik (deðiþmeyen) servisler için uygundur. Örneðin : CacheService, LoggingService, ConfigurationService gibi deðiþmeyen hizmetler.
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


// Authentication -> Kimlik Doðrulama
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) // Varsayýlan olarak Cookie(Çerez) tabanlý kimlik doðrulamayý kullan.
	.AddCookie(config =>
	{
		config.LoginPath = "/Login/Index"; // Kimlik doðrulama baþarýsýz olduðu zaman yönlendirilecek URL.
	});


builder.Services.AddMvc(config => // Authorization -> Yetkikendirme, Policy -> Politika ,Authenticated -> Kimliði Doðrulanmýþ, Require -> Gerekli Kýlmak
{  //  Politika -> türkçede kurallar koymak ve uygulamak için yapýlan faaliyetler demektir.
	var policy = new AuthorizationPolicyBuilder() // AuthorizationPolicyBuilder -> Yetkilendirme Politika Oluþturucusu
	.RequireAuthenticatedUser()  // RequireAuthenticatedUser -> Kimliði Doðrulanmýþ Kullýcýyý Gerekli Kýl
	.Build(); // Build -> Oluþtur.

	config.Filters.Add(new AuthorizeFilter(policy)); // Authorize -> Yetki vermek.
													 // Bu yapý sayesinden tüm MVC hizmetlerine Yetkilendiriþmiþ kiþi tarafýndan giriþ yapmayý zorunlu kýlýyoruz.(Proje Seviyesinde)
													 // Yani gidip tek tek [Authorize] yazmamýza gerek kalmýyor. Projenin geneline [Authorize] uyguluyor.
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
   hata kodu {0} yerine gelecek deðerdir çrneðin 404,500 gibi.

   ?code={0} ifadesi þunu yapar: "code" ismiden bir parametre ekler ve "{0}" deðeri yerine ise gerçek HTTP hata kodunu yazar.
 */




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
