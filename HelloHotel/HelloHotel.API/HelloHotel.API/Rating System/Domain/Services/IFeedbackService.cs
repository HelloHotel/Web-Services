using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Rating_System.Domain.Models;
using HelloHotel.API.Rating_System.Domain.Services.Communication;

namespace HelloHotel.API.Rating_System.Domain.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> ListAsync();
        Task<FeedbackResponse> SaveAsync(Feedback feedback);
        Task<FeedbackResponse> UpdateAsync(int id, Feedback feedback);
        Task<FeedbackResponse> DeleteAsync(int id);
    }
}