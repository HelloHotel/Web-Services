using HelloHotel.API.Shared.Domain.Services.Communication;
using HelloHotel.API.Rating_System.Domain.Models;

namespace HelloHotel.API.Rating_System.Domain.Services.Communication
{
    public class FeedbackResponse : BaseResponse<Feedback>
    {
        public FeedbackResponse(string message) : base(message)
        {
        }

        public FeedbackResponse(Feedback resource) : base(resource)
        {
        }
    }
}