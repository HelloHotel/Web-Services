using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Searching_System.Domain.Models;
using HelloHotel.API.Searching_System.Domain.Services.Communication;

namespace HelloHotel.API.Searching_System.Domain.Services
{
    public interface IStairService
    {
        Task<IEnumerable<Stair>> ListAsync();
        Task<StairResponse> SaveAsync(Stair stair);
        Task<StairResponse> UpdateAsync(int id, Stair stair);
        Task<StairResponse> DeleteAsync(int id);
    }
}