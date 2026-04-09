using GuvenOto.Models;
using System.Threading.Tasks;

namespace GuvenOto.Repositories
{
    public interface IListingRepository : IRepository<Ilan>
    {
        Task<Ilan?> GetListingWithDetailsAsync(int id);
        IQueryable<Ilan> GetListingsWithIncludesQuery();
    }
}

