using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GuvenOto.Models;
using GuvenOto.Services;
using GuvenOto.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace GuvenOto.Controllers
{
    [Authorize]
    public class IlanController : Controller
    {
        private readonly IListingService _listingService;
        private readonly IRepository<Marka> _brandRepo;
        private readonly IRepository<AracModeli> _modelRepo;
        private readonly IRepository<Sehir> _cityRepo;
        private readonly IRepository<Ilce> _districtRepo;
        private readonly IRepository<Ozellik> _featureRepo;
        private readonly IRepository<Bolge> _regionRepo;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IRepository<Ilan> _ilanRepo;

        public IlanController(
            IListingService listingService,
            IRepository<Marka> brandRepo,
            IRepository<AracModeli> modelRepo,
            IRepository<Sehir> cityRepo,
            IRepository<Ilce> districtRepo,
            IRepository<Ozellik> featureRepo,
            IRepository<Bolge> regionRepo,
            IRepository<Ilan> ilanRepo,
            IWebHostEnvironment hostEnvironment)
        {
            _listingService = listingService;
            _brandRepo = brandRepo;
            _modelRepo = modelRepo;
            _cityRepo = cityRepo;
            _districtRepo = districtRepo;
            _featureRepo = featureRepo;
            _regionRepo = regionRepo;
            _ilanRepo = ilanRepo;
            _hostEnvironment = hostEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            // HATA VEREN "IlanOzellikDegeri" SATIRI BURADAN KALDIRILDI.
            // Sayfanın açılmasını engelleyen engel kalktı.
            var ilan = await _ilanRepo.Query()
                .Include(x => x.AracModeli).ThenInclude(m => m.Marka)
                .Include(x => x.Sehir)
                .Include(x => x.Ilce)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ilan == null) return NotFound();

            return View(ilan);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int[] regionIds, int? MarkaId, int? AracModeliId, int? cityId, decimal? minPrice, decimal? maxPrice, int? minKm, int? maxKm, int? minYear, int? maxYear)
        {
            ViewBag.Markalar = await _brandRepo.Query().OrderBy(x => x.Name).ToListAsync();
            ViewBag.Sehirler = await _cityRepo.Query().OrderBy(x => x.Name).ToListAsync();
            ViewBag.Bolgeler = await _regionRepo.Query().Include(b => b.Sehirler).OrderBy(x => x.Name).ToListAsync();
            ViewBag.Ozellikler = await _featureRepo.Query().OrderBy(x => x.Category).ToListAsync();

            var ilanlar = await _listingService.GetFilteredListingsAsync(MarkaId, AracModeliId, cityId, minPrice, maxPrice, minKm, maxKm, minYear, maxYear);

            if (regionIds != null && regionIds.Any())
                ilanlar = ilanlar.Where(x => x.Sehir != null && regionIds.Contains(x.Sehir.RegionId)).ToList();

            return View(ilanlar);
        }

        public async Task<IActionResult> MyListings()
        {
            var myItems = await _ilanRepo.Query()
                .Include(x => x.AracModeli).ThenInclude(m => m.Marka)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
            return View(myItems);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Sehirler = await _cityRepo.Query().OrderBy(x => x.Name).ToListAsync();
            ViewBag.Markalar = await _brandRepo.Query().OrderBy(x => x.Name).ToListAsync();
            ViewBag.Ozellikler = await _featureRepo.Query().OrderBy(x => x.Category).ThenBy(x => x.Name).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ilan ilan, IFormFile? mainImage)
        {
            ilan.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (mainImage != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(mainImage.FileName);
                    string path = Path.Combine(_hostEnvironment.WebRootPath, "uploads", fileName);
                    if (!Directory.Exists(Path.Combine(_hostEnvironment.WebRootPath, "uploads")))
                        Directory.CreateDirectory(Path.Combine(_hostEnvironment.WebRootPath, "uploads"));
                    using (var stream = new FileStream(path, FileMode.Create)) { await mainImage.CopyToAsync(stream); }
                    ilan.MainImageUrl = "/uploads/" + fileName;
                }
                await _listingService.AddListingAsync(ilan, new int[0], new Dictionary<int, string>());
                return RedirectToAction(nameof(MyListings));
            }
            return View(ilan);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonResult> GetIlceler(int cityId) =>
            Json(await _districtRepo.Query().Where(x => x.CityId == cityId).Select(x => new { id = x.Id, name = x.Name }).ToListAsync());

        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonResult> GetModels(int MarkaId) =>
            Json(await _modelRepo.Query().Where(m => m.MarkaId == MarkaId).Select(m => new { id = m.Id, name = m.Name }).ToListAsync());
    }
}