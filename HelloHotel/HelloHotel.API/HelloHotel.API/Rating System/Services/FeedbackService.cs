using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Rating_System.Domain.Models;
using HelloHotel.API.Rating_System.Domain.Repositories;
using HelloHotel.API.Rating_System.Domain.Services;
using HelloHotel.API.Rating_System.Domain.Services.Communication;

namespace HelloHotel.API.Rating_System.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<Feedback>> ListAsync()
        {
            return await _feedbackRepository.ListAsync();
        }

        public async Task<FeedbackResponse> SaveAsync(Feedback feedback)
        {
            try
            {
                await _feedbackRepository.AddAsync(feedback);
                return new FeedbackResponse(feedback);
            }
            catch(Exception e)
            {
                return new FeedbackResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<FeedbackResponse> UpdateAsync(int id, Feedback feedback)
        {
            var existingCategory = await _feedbackRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new FeedbackResponse("Category not found.");
            
            existingCategory.Name = feedback.Name;

            try
            {
                _feedbackRepository.Update(existingCategory);


                return new FeedbackResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new FeedbackResponse($"An error ocurred wile updating the category: {e.Message}");
            }
        }

        public async Task<FeedbackResponse> DeleteAsync(int id)
        {
            var existingCategory = await _feedbackRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new FeedbackResponse("Feedback not found");

            try
            {
                _feedbackRepository.Remove(existingCategory);

                return new FeedbackResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new FeedbackResponse($"An error occurred while deleting the feedback:{e.Message}");
            }
        }
    }
}