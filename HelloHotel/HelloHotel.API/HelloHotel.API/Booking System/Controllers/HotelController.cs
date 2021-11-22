using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Services;
using HelloHotel.API.Booking_System.Resources;
using HelloHotel.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloHotel.API.Booking_System.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Hotels")]
        public async Task<IEnumerable<HotelResources>> GetAllAsync()
        {
            var hotels = await _hotelService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelResources>>(hotels);
            return resources;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post a Hotel")]
        public async Task<IActionResult> PostAsync([FromBody] SaveHotelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);
            var result = await _hotelService.SaveAsync(hotel);

            if (!result.Success)
                return BadRequest(result.Message);

            var hotelResource = _mapper.Map<Hotel, HotelResources>(result.Resource);
            return Ok(hotelResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a Hotel")]
        public async Task<IActionResult> PutAsync(int id, SaveHotelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);
            var result = await _hotelService.UpdateAsync(id, hotel);

            if (!result.Success)
                return BadRequest(result.Message);

            var hotelResource = _mapper.Map<Hotel, HotelResources>(result.Resource);
            return Ok(hotelResource);
        }
        
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Hotel")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _hotelService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            var hotelResource = _mapper.Map<Hotel, HotelResources>(result.Resource);

            return Ok(hotelResource);
        }
    }
}