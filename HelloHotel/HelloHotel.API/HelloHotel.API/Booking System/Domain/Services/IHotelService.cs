using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Services.Communication;

namespace HelloHotel.API.Booking_System.Domain.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> ListAsync();
        Task<HotelResponse> SaveAsync(Hotel hotel);
        Task<HotelResponse> UpdateAsync(int id, Hotel hotel);
        Task<HotelResponse> DeleteAsync(int id);
    }
}