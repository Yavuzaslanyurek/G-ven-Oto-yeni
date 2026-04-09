using Microsoft.AspNetCore.Mvc;
using GuvenOto.Data;
using System.Linq;

namespace GuvenOto.Controllers
{
    public class KonumController : Controller
    {
        private readonly ApplicationDbContext _context;
        public KonumController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public JsonResult GetDistricts(int cityId)
        {
            var Ilceler = _context.Ilceler
                .Where(d => d.CityId == cityId)
                .OrderBy(d => d.Name)
                .Select(d => new { id = d.Id, name = d.Name })
                .ToList();
            return Json(Ilceler);
        }
    }
}


