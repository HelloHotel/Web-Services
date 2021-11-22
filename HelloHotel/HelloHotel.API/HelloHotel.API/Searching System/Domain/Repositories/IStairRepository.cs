using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Searching_System.Domain.Models;

namespace HelloHotel.API.Searching_System.Domain.Repositories
{
    public interface IStairRepository
    {
        Task<IEnumerable<Stair>> ListAsync();
        Task AddAsync(Stair stair);
        Task<Stair> FindByIdAsync(int id);
        void Update(Stair stair);
        void Remove(Stair stair);
    }
}