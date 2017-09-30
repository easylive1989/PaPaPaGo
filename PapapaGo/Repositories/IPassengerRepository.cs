using System.Collections.Generic;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace PapapaGo.Repositories
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetAllPassengersAsync();

        Task<Passenger> GetPassengerAsync(string firstName, string lastName);

        Task<Passenger> GetPassengerAsync(string postCode);

        Task<int> CreatePassengerAsync(Passenger passenger);

    }
}
