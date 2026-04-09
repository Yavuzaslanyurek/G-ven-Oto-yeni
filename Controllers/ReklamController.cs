using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering; // SelectList için gerekli
using GuvenOto.Data;
using GuvenOto.Models;
using Microsoft.EntityFrameworkCore;

namespace GuvenOto.Controllers
{
    public class ReklamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReklamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- 1. İLANLARI LİSTELEME ---
        [AllowAnonymous]
        public IActionResult Index()
        {
            var arabalar = _context.Arabalar.Include(c => c.Marka).Include(c => c.Model).ToList();
            return View(arabalar);
        }

        // --- 2. YENİ İLAN VERME (SAYFAYI AÇMA) ---
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            // Veritabanındaki markaları çekip sayfaya gönderiyoruz
            ViewBag.Markalar = new SelectList(_context.Markalar.ToList(), "Id", "Name");
            return View();
        }

        // --- 3. YENİ İLAN VERME (KAYDETME) ---
        [Authorize]
        [HttpPost]
        public IActionResult Create(Araba araba)
        {
            if (ModelState.IsValid)
            {
                _context.Arabalar.Add(araba);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Markalar = new SelectList(_context.Markalar.ToList(), "Id", "Name");
            return View(araba);
        }

        // Seçilen markaya göre modelleri getiren küçük bir yardımcı (AJAX için)
        public JsonResult GetModels(int MarkaId)
        {
            var models = _context.Models.Where(m => m.MarkaId == MarkaId).ToList();
            return Json(models);
        }
    }
}



