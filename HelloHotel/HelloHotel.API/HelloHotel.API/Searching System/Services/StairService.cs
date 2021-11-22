using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Searching_System.Domain.Models;
using HelloHotel.API.Searching_System.Domain.Repositories;
using HelloHotel.API.Searching_System.Domain.Services;
using HelloHotel.API.Searching_System.Domain.Services.Communication;

namespace HelloHotel.API.Searching_System.Services
{
    public class StairService : IStairService
    {
        private readonly IStairRepository _stairRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StairService(IStairRepository stairRepository, IUnitOfWork unitOfWork)
        {
            _stairRepository = stairRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Stair>> ListAsync()
        {
            return await _stairRepository.ListAsync();
        }

        public async Task<StairResponse> SaveAsync(Stair stair)
        {
            try
            {
                await _stairRepository.AddAsync(stair);
                await _unitOfWork.CompleteAsync();
                return new StairResponse(stair);
            }
            catch (Exception e)
            {
                return new StairResponse($"An error occurred while saving Stair: {e.Message}");
            }
        }

        public async Task<StairResponse> UpdateAsync(int id, Stair stair)
        {
            var existingCategory = await _stairRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new StairResponse("Stair not found.");

            existingCategory.StairNumber = stair.StairNumber;

            try
            {
                _stairRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new StairResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new StairResponse($"An error occurred wile updating the stair: {e.Message}");
            }
        }

        public async Task<StairResponse> DeleteAsync(int id)
        {
            var existingCategory = await _stairRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new StairResponse("Stair not found.");

            try
            {
                _stairRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new StairResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new StairResponse($"An error occurred wile deleting the stair: {e.Message}");
            }
        }
    }
}