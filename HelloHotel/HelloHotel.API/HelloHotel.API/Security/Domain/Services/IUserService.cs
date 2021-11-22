using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Security.Domain.Entities;
using HelloHotel.API.Security.Domain.Services.Communication;

namespace HelloHotel.API.Security.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(int id);
        Task RegisterAsync(RegisterRequest request);
        Task UpdateAsync(int id, UpdateRequest request);
        Task DeleteAsync(int id);


    }
}