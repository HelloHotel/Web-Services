using System.Threading.Tasks;
using HelloHotel.API.Searching_System.Domain.Repositories;
using HelloHotel.API.Shared.Persistence.Context;

namespace HelloHotel.API.Searching_System.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}