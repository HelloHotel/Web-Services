using System.Threading.Tasks;
using HelloHotel.API.Persistence.Context;
using HelloHotel.API.Searching_System.Domain.Repositories;

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