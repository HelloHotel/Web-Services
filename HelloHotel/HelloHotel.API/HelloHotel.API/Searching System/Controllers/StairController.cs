using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloHotel.API.Extensions;
using HelloHotel.API.Hotel_System.Resources;
using HelloHotel.API.Searching_System.Domain.Models;
using HelloHotel.API.Searching_System.Domain.Services;
using HelloHotel.API.Searching_System.Domain.Services.Communication;
using HelloHotel.API.Searching_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloHotel.API.Searching_System.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class StairController : ControllerBase
    {
        private readonly IStairService _stairService;
        private readonly IMapper _mapper;

        public StairController(IStairService stairService, IMapper mapper)
        {
            _stairService = stairService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get All Products", Tags = new[] {"Categories"})]
        public async Task<IEnumerable<StairResource>> GetAllAsync()
        {
            var stairs = await _stairService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Stair>, IEnumerable<StairResource>>(stairs);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStairResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var stair = _mapper.Map<SaveStairResource, Stair>(resource);
            var result = await _stairService.SaveAsync(stair);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Stair, StairResource>(result.Resource);
            return Ok(categoryResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStairResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var stair = _mapper.Map<SaveStairResource, Stair>(resource);
            var result = await _stairService.UpdateAsync(id, stair);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Stair, StairResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}