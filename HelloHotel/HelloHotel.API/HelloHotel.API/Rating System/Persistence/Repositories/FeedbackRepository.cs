using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Rating_System.Domain.Models;
using HelloHotel.API.Rating_System.Domain.Repositories;
using HelloHotel.API.Shared.Persistence.Context;
using HelloHotel.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Rating_System.Persistence.Repositories
{
    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Feedback>> ListAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
        }

        public async Task<Feedback> FindByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public void Update(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
        }

        public void Remove(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
        }
    }
}