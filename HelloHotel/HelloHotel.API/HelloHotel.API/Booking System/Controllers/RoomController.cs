using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Services;
using HelloHotel.API.Booking_System.Resources;
using HelloHotel.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloHotel.API.Booking_System.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Get Rooms")]
        public async Task<IEnumerable<RoomResources>> GetAllAsync()
        {
            var rooms = await _roomService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomResources>>(rooms);
            return resources;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post a Room")]
        public async Task<IActionResult> PostAsync([FromBody] SaveRoomResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var room = _mapper.Map<SaveRoomResource, Room>(resource);
            var result = await _roomService.SaveAsync(room);

            if (!result.Success)
                return BadRequest(result.Message);

            var roomResource = _mapper.Map<Room, RoomResources>(result.Resource);
            return Ok(roomResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a Room")]
        public async Task<IActionResult> PutAsync(int id, SaveRoomResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var room = _mapper.Map<SaveRoomResource, Room>(resource);
            var result = await _roomService.UpdateAsync(id, room);

            if (!result.Success)
                return BadRequest(result.Message);

            var roomResource = _mapper.Map<Room, RoomResources>(result.Resource);
            return Ok(roomResource);
        }
        
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Room")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _roomService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            var roomResource = _mapper.Map<Room, RoomResources>(result.Resource);

            return Ok(roomResource);
        }
    }
}