using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<ClientResponse> SaveAsync(Client client);
        Task<ClientResponse> UpdateAsync(int id, Client client);
        Task<ClientResponse> DeleteAsync(int id);
    }
}