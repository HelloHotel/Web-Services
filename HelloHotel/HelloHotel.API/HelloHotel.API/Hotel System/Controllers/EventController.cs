using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Hotel_System.Domain.Services;
using HelloHotel.API.Hotel_System.Resources;
using HelloHotel.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloHotel.API.Hotel_System.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EventResources>> GetAllAsync()
        {
            var events = await _eventService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Event>, IEnumerable<EventResources>>(events);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var @event = _mapper.Map<SaveEventResource, Event>(resource);
            var result = await _eventService.SaveAsync(@event);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Event, EventResources>(result.Resource);

            return Ok(eventResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            
            var @event = _mapper.Map<SaveEventResource, Event>(resource);
            var result = await _eventService.UpdateAsync(id, @event);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var eventResource = _mapper.Map<Event, EventResources>(result.Resource);

            return Ok(eventResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _eventService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            var eventResource = _mapper.Map<Event, EventResources>(result.Resource);

            return Ok(eventResource);
        }
    }
    
}