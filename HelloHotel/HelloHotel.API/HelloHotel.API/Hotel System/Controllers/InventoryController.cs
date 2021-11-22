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
    [Route("/api/v1/[controller]")]
    
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Get All The Inventory")]
        public async Task<IEnumerable<InventoryResources>> GetAllAsync()
        {
            var inventories = await _inventoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryResources>>(inventories);
            return resources;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post a Inventory")]
        public async Task<IActionResult> PostAsync([FromBody] SaveInventoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var inventory = _mapper.Map<SaveInventoryResource, Inventory>(resource);
            var result = await _inventoryService.SaveAsync(inventory);

            if (!result.Success)
                return BadRequest(result.Message);

            var inventoryResource = _mapper.Map<Inventory, InventoryResources>(result.Resource);
            return Ok(inventoryResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a Inventory")]
        public async Task<IActionResult> PutAsync(int id, SaveInventoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var inventory = _mapper.Map<SaveInventoryResource, Inventory>(resource);
            var result = await _inventoryService.UpdateAsync(id, inventory);

            if (!result.Success)
                return BadRequest(result.Message);

            var inventoryResource = _mapper.Map<Inventory, InventoryResources>(result.Resource);
            return Ok(inventoryResource);
        }
        
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Inventory")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _inventoryService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            var inventoryResource = _mapper.Map<Inventory, InventoryResources>(result.Resource);

            return Ok(inventoryResource);
        }
    }
}