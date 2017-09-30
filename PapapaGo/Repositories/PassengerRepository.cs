using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace PapapaGo.Repositories
{
    public class PassengerRepository : BaseRepository, IPassengerRepository
    {
        protected PassengerRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<Passenger>> GetAllPassengersAsync()
        {
            return (await GetListAsync<Passenger>("WHERE 1")).ToList();
        }

        public async Task<Passenger> GetPassengerAsync(string firstName, string lastName)
        {
            return (await GetListAsync<Passenger>("WHERE first_name = @firstName AND last_name = @lastName",
                new {firstName, lastName})).FirstOrDefault();
        }

        public async Task<Passenger> GetPassengerAsync(string postCode)
        {
            return (await GetListAsync<Passenger>("WHERE first_name = @firstName AND last_name = @lastName",
                new { postCode })).FirstOrDefault();
        }

        public async Task<int> CreatePassengerAsync(Passenger passenger)
        {
            return (await InsertAsync(passenger)).GetValueOrDefault();
        }
    }
}