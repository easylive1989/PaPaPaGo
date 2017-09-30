using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace PapapaGo.Repositories
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        protected BookingRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<Booking>> GetBookingsAsync(string passport)
        {
            return (await GetListAsync<Booking>("WHERE passport = @passport", new {passport})).ToList();
        }

        public async Task<Booking> GetBookingAsync(string passport, string bookingCode)
        {
            return (await GetListAsync<Booking>("WHERE booking_code = @bookingCode AND passport = @passport",
                new {bookingCode, passport})).FirstOrDefault();
        }

        public async Task<Booking> GetBookingAsync(string orderId)
        {
            return (await GetListAsync<Booking>("WHERE order_id = @orderId", new {orderId})).FirstOrDefault();
        }

        public async Task<int> CreateBookingAsync(Booking booking)
        {
            return (await InsertAsync(booking)).GetValueOrDefault();
        }
    }
}