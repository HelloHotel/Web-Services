using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Hotel_System.Domain.Services;
using HelloHotel.API.Hotel_System.Resources;


using HelloHotel.API.Shared.Extensions;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloHotel.API.Hotel_System.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/employee/{employeeId}/events")]
    public class EmployeeEventsController
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EmployeeEventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get All Events by Employee", Tags = new [] {"Employees"})]
        public async Task<IEnumerable<EventResources>> GetAllByEmployeeIdAsync(int employeeId)
        {
            var events = await _eventService.ListByEmployeeIdAsync(employeeId);
            var resources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResources>>(events);
            return resources;
        }
    }
}