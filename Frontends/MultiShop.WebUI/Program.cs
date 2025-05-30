using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

//Yeni Eklenenler
//JWT ile ilgili ayarlar
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddCookie(JwtBearerDefaults.AuthenticationScheme,
    opt =>
    {
        opt.LoginPath = "/Login/Index"; // Giri� sayfas�
        opt.LogoutPath = "/Login/LogOut/"; // ��k�� sayfas�
        opt.AccessDeniedPath = "/Pages/AccessDenied/";
        opt.Cookie.HttpOnly = true; // https'e gerek olmadan cookie'yi kullanabilmek i�in
        opt.Cookie.SameSite = SameSiteMode.Strict; // �erezlerin ayn� site i�inde kullan�lmas�n� sa�lar
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // �erezlerin g�venli�ini sa�lar, e�er istek https ise �erez de https olarak g�nderilir
        opt.Cookie.Name = "MultiShopJwt"; // �erez ad�
    });

//Login i�lemi i�in eklendi
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/Index";
        opt.ExpireTimeSpan = TimeSpan.FromDays(10);
        opt.Cookie.Name = "MultiShopCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddHttpContextAccessor(); // HttpContext eri�imi i�in eklenmi�tir

builder.Services.AddScoped<ILoginService, LoginService>(); // LoginService'i DI konteynerine ekler
builder.Services.AddHttpClient<IIdentityService, IdentityService>(); //Login i�lemi i�in eklendi


builder.Services.AddHttpClient();
//Yeni Eklenenler

// Add services to the container.
builder.Services.AddControllersWithViews();

//Login i�lemi i�in
builder.Services.Configure<ClientSettings>(
    builder.Configuration.GetSection("ClientSettings"));
//Api Settings i�in
builder.Services.Configure<ServiceApiSettings>(
    builder.Configuration.GetSection("ServiceApiSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // JWT ile kimlik do�rulama i�lemi i�in eklenmi�tir
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
