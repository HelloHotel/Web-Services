using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Repositories;
using HelloHotel.API.Domain.Services;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _clientRepository.ListAsync();
        }

        public async Task<ClientResponse> SaveAsync(Client client)
        {
            try
            {
                await _clientRepository.AddAsync(client);
                return new ClientResponse(client);
            }
            catch(Exception e)
            {
                return new ClientResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<ClientResponse> UpdateAsync(int id, Client client)
        {
            var existingCategory = await _clientRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ClientResponse("Category not found.");
            
            existingCategory.Name = client.Name;

            try
            {
                _clientRepository.Update(existingCategory);


                return new ClientResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error ocurred wile updating the category: {e.Message}");
            }
        }

        public async Task<ClientResponse> DeleteAsync(int id)
        {
            var existingCategory = await _clientRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ClientResponse("Employee not found");

            try
            {
                _clientRepository.Remove(existingCategory);

                return new ClientResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while deleting the employee:{e.Message}");
            }
        }
    }
}