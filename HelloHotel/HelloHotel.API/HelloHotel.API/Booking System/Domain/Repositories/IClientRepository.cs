using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Models;

namespace HelloHotel.API.Booking_System.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        Task AddAsync(Client client);
        Task<Client> FindByIdAsync(int id);
        void Update(Client client);
        void Remove(Client client);
    }
}