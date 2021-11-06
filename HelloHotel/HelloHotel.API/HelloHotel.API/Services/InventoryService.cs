using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Repositories;
using HelloHotel.API.Domain.Services;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> ListAsync()
        {
            return await _inventoryRepository.ListAsync();
        }

        public async Task<InventoryResponse> SaveAsync(Inventory inventory)
        {
            try
            {
                await _inventoryRepository.AddAsync(inventory);
                return new InventoryResponse(inventory);
            }
            catch(Exception e)
            {
                return new InventoryResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<InventoryResponse> UpdateAsync(int id, Inventory inventory)
        {
            var existingCategory = await _inventoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new InventoryResponse("Category not found.");
            
            existingCategory.Name = inventory.Name;

            try
            {
                _inventoryRepository.Update(existingCategory);


                return new InventoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new InventoryResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<InventoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _inventoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new InventoryResponse("Inventory not found");

            try
            {
                _inventoryRepository.Remove(existingCategory);

                return new InventoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new InventoryResponse($"An error occurred while deleting the employee:{e.Message}");
            }
        }
    }
}