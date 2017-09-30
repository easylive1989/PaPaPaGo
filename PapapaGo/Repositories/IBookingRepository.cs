using System.Collections.Generic;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace PapapaGo.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingsAsync(string passport);

        Task<Booking> GetBookingAsync(string passport, string bookingCode);

        Task<Booking> GetBookkingAsync(string orderId);

        Task<int> CreateBookingAsync(Booking booking);
    }
}
