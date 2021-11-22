using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Rating_System.Domain.Models;

namespace HelloHotel.API.Rating_System.Domain.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> ListAsync();
        Task AddAsync(Feedback feedback);
        Task<Feedback> FindByIdAsync(int id);
        void Update(Feedback feedback);
        void Remove(Feedback feedback);
    }
}