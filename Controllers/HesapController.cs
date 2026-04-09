using Microsoft.AspNetCore.Mvc;
using GuvenOto.Models;
using GuvenOto.Data;
using BCrypt.Net;
using System.Security.Claims; // Kimlik bilgileri için
using Microsoft.AspNetCore.Authentication; // Oturum açma için
using Microsoft.AspNetCore.Authentication.Cookies; // Cookie (Çerez) desteği için

namespace GuvenOto.Controllers
{
    public class HesapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HesapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- 1. KAYIT OLMA (REGISTER) ---
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Kullanici user)
        {
            // Şifreyi hashliyoruz
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "User"; // Standart kullanıcı

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        // --- 2. GİRİŞ YAPMA (LOGIN) ---
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Veritabanında bu email var mı?
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                // Girilen şifre ile veritabanındaki hashli şifre tutuyor mu?
                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (isPasswordCorrect)
                {
                    // Kullanıcının "Kimlik Kartını" hazırlıyoruz
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role) // Admin mi Kullanici mı buradan okunacak
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Tarayıcıya "Bu kullanıcıyı hatırla" diyoruz
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
            }

            // Hata varsa sayfada kal
            ViewBag.Error = "E-posta veya şifre hatalı!";
            return View();
        }

        // --- 3. ÇIKIŞ YAPMA (LOGOUT) ---
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}

