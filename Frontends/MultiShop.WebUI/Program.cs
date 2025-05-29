using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

//Yeni Eklenenler
//JWT ile ilgili ayarlar
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme,
    opt =>
    {
        opt.LoginPath = "/Login/Index"; // Giriþ sayfasý
        opt.LogoutPath = "/Login/LogOut/";// Çýkýþ sayfasý
        opt.AccessDeniedPath = "/Pages/AccessDenied/";
        opt.Cookie.HttpOnly = true;// https'e gerek olmadan cookie'yi kullanabilmek için
        opt.Cookie.SameSite = SameSiteMode.Strict; // Çerezlerin ayný site içinde kullanýlmasýný saðlar
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Çerezlerin güvenliðini saðlar, eðer istek https ise çerez de https olarak gönderilir
        opt.Cookie.Name = "MultiShopJwt"; // Çerez adý
    });

builder.Services.AddHttpContextAccessor(); // HttpContext eriþimi için eklenmiþtir

builder.Services.AddScoped<ILoginService, LoginService>(); // LoginService'i DI konteynerine ekler

builder.Services.AddHttpClient();
//Yeni Eklenenler

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication(); // JWT ile kimlik doðrulama iþlemi için eklenmiþtir
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
