using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Services;
using HelloHotel.API.Booking_System.Resources;
using HelloHotel.API.Rating_System.Domain.Models;
using HelloHotel.API.Rating_System.Domain.Services;
using HelloHotel.API.Rating_System.Resources;
using HelloHotel.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloHotel.API.Rating_System.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackService feedback, IMapper mapper)
        {
            _feedbackService = feedback;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Get All the Feedback")]
        public async Task<IEnumerable<FeedbackResources>> GetAllAsync()
        {
            var feedbacks = await _feedbackService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Feedback>, IEnumerable<FeedbackResources>>(feedbacks);
            return resources;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post a Feedback")]
        public async Task<IActionResult> PostAsync([FromBody] SaveFeedbackResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var feedback = _mapper.Map<SaveFeedbackResource, Feedback>(resource);
            var result = await _feedbackService.SaveAsync(feedback);

            if (!result.Success)
                return BadRequest(result.Message);

            var feedbackResources = _mapper.Map<Feedback, FeedbackResources>(result.Resource);
            return Ok(feedbackResources);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a Feedback")]
        public async Task<IActionResult> PutAsync(int id, SaveFeedbackResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var feedback = _mapper.Map<SaveFeedbackResource, Feedback>(resource);
            var result = await _feedbackService.UpdateAsync(id, feedback);

            if (!result.Success)
                return BadRequest(result.Message);

            var feedbackResources = _mapper.Map<Feedback, FeedbackResources>(result.Resource);
            return Ok(feedbackResources);
        }
        
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Feedback")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _feedbackService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            var feedbackResources = _mapper.Map<Feedback, FeedbackResources>(result.Resource);

            return Ok(feedbackResources);
        }
    }
}