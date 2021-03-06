
using HelloHotel.API.Shared.Persistence.Context;

namespace HelloHotel.API.Shared.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}