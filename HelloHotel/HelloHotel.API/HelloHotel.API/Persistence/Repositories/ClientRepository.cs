﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Repositories;
using HelloHotel.API.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Persistence.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _context.Clients.ToListAsync();
        }
        
        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task<Client> FindByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }

        public void Remove(Client client)
        {
            _context.Clients.Remove(client);
        }
    }
}