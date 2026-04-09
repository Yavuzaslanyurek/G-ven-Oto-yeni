using Microsoft.EntityFrameworkCore;
using GuvenOto.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // Giriş işlemleri için gerekli

var builder = WebApplication.CreateBuilder(args);

// 1. MVC Servislerini ekle
builder.Services.AddControllersWithViews();

// 2. Veritabanı Bağlantısı (İsim: ApplicationDbContext)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Giriş-Çıkış (Authentication) Ayarları - HAFTA 2 İÇİN YENİ
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Giriş yapmamışsa buraya atar
        options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisi yoksa buraya atar
        options.ExpireTimeSpan = TimeSpan.FromDays(7); // 7 gün boyunca oturumu hatırlar
    });

builder.Services.AddScoped(typeof(GuvenOto.Repositories.IRepository<>), typeof(GuvenOto.Repositories.Repository<>));
builder.Services.AddScoped<GuvenOto.Repositories.IListingRepository, GuvenOto.Repositories.ListingRepository>();
builder.Services.AddScoped<GuvenOto.Services.IListingService, GuvenOto.Services.ListingService>();
builder.Services.AddScoped<GuvenOto.Services.IMarketPricerService, GuvenOto.Services.MarketPricerService>();

var app = builder.Build();

// HTTP request pipeline ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 4. SIRALAMA ÇOK ÖNEMLİ: Önce Kimlik Kontrolü, Sonra Yetki Kontrolü
app.UseAuthentication(); // "Sen kimsin?"
app.UseAuthorization();  // "Buna yetkin var mı?"

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

