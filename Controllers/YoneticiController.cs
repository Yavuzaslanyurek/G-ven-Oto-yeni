using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GuvenOto.Data;
using GuvenOto.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GuvenOto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YoneticiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YoneticiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- 1. ÖZELLİK YÖNETİMİ ---
        public IActionResult Ozellikler()
        {
            var Ozellikler = _context.Ozellikler.OrderBy(x => x.Category).ToList();
            return View(Ozellikler);
        }

        [HttpPost]
        public IActionResult AddFeature(Ozellik Ozellik)
        {
            if (Ozellik.InputType != FeatureType.Dropdown)
            {
                Ozellik.Options = null;
            }

            if (ModelState.IsValid)
            {
                _context.Ozellikler.Add(Ozellik);
                _context.SaveChanges();
            }
            return RedirectToAction("Ozellikler");
        }

        [HttpPost]
        public IActionResult DeleteFeature(int id)
        {
            var Ozellik = _context.Ozellikler.Find(id);
            if (Ozellik != null)
            {
                _context.Ozellikler.Remove(Ozellik);
                _context.SaveChanges();
            }
            return RedirectToAction("Ozellikler");
        }

        // --- 2. MARKA & MODEL YÖNETİMİ ---
        public IActionResult Markalar()
        {
            // Markaları ve onlara bağlı tüm hiyerarşiyi çekiyoruz
            var Markalar = _context.Markalar
                                 .Include(b => b.Models)
                                 .OrderBy(b => b.Name)
                                 .ToList();
            return View(Markalar);
        }

        [HttpPost]
        public IActionResult AddBrand(Marka Marka)
        {
            if (!string.IsNullOrEmpty(Marka.Name))
            {
                _context.Markalar.Add(Marka);
                _context.SaveChanges();
            }
            return RedirectToAction("Markalar");
        }

        [HttpPost]
        public IActionResult AddModel(AracModeli model)
        {
            // CRITICAL FIX: HTML formundan gelen 0 değerini null'a çekiyoruz.
            if (model.ParentModelId == 0)
            {
                model.ParentModelId = null;
            }

            if (model.MarkaId != 0 && !string.IsNullOrEmpty(model.Name))
            {
                _context.Models.Add(model);
                _context.SaveChanges();
            }
            return RedirectToAction("Markalar");
        }

        [HttpPost]
        public IActionResult DeleteBrand(int id)
        {
            var Marka = _context.Markalar.Include(b => b.Models).FirstOrDefault(x => x.Id == id);
            if (Marka != null)
            {
                _context.Markalar.Remove(Marka);
                _context.SaveChanges();
            }
            return RedirectToAction("Markalar");
        }

        [HttpPost]
        public IActionResult DeleteModel(int id)
        {
            var model = _context.Models.Find(id);
            if (model != null)
            {
                _context.Models.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction("Markalar");
        }

        // --- YARDIMCI METOT (AJAX/FETCH İÇİN) ---
        [HttpGet]
        public JsonResult GetModelsByBrand(int id)
        {
            // Markaya ait tüm modelleri getiriyoruz (AracModeli, Seri ve Paket dahil)
            var models = _context.Models
                .Where(m => m.MarkaId == id)
                .Select(m => new {
                    id = m.Id,
                    name = m.Name,
                    parentId = m.ParentModelId
                })
                .ToList();

            return Json(models);
        }
    }
}



