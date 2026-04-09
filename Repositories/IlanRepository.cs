using GuvenOto.Data;
using GuvenOto.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GuvenOto.Repositories
{
    public class ListingRepository : Repository<Ilan>, IListingRepository
    {
        private readonly ApplicationDbContext _context;

        public ListingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Ilan?> GetListingWithDetailsAsync(int id)
        {
            // 'Model' yerine 'AracModeli' kullanıldı. 
            // Ayrıca 'FeatureValues' içindeki 'Ozellik' isminin doğruluğundan emin olmalısın.
            return await _context.Ilanlar
                .Include(l => l.AracModeli).ThenInclude(m => m.Marka)
                .Include(l => l.IlanOzellikDegeri).ThenInclude(fv => fv.Ozellik) // Modelinde FeatureValues olduğu için burayı bağladım
                .Include(l => l.Sehir)
                .Include(l => l.Ilce)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public IQueryable<Ilan> GetListingsWithIncludesQuery()
        {
            // Sorgu motorunda da 'Model' yerine 'AracModeli' ismine geçildi.
            return _context.Ilanlar
                .Include(l => l.AracModeli).ThenInclude(m => m.Marka)
                .Include(l => l.Sehir)
                .Include(l => l.Ilce)
                .AsQueryable();
        }
    }
}


