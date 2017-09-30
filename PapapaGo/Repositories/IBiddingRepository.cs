using System.Collections.Generic;
using System.Threading.Tasks;
using PapapaGo.Models.Bidding;

namespace PapapaGo.Repositories
{
    public interface IBiddingRepository
    {
        Task<List<Bidding>> GetBiddingsAsync(string name);

        Task<int> CreateBiddingAsync(Bidding bidding);
    }
}
