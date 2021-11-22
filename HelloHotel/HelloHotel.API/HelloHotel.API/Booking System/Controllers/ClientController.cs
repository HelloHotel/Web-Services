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
    
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Clients")]
        public async Task<IEnumerable<ClientResources>> GetAllAsync()
        {
            var clients = await _clientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResources>>(clients);
            return resources;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post a Client")]
        public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.SaveAsync(client);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = _mapper.Map<Client, ClientResources>(result.Resource);
            return Ok(clientResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a Client")]
        public async Task<IActionResult> PutAsync(int id, SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.UpdateAsync(id, client);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = _mapper.Map<Client, ClientResources>(result.Resource);
            return Ok(clientResource);
        }
        
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Client")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clientService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            var clientResource = _mapper.Map<Client, ClientResources>(result.Resource);

            return Ok(clientResource);
        }
    }
}