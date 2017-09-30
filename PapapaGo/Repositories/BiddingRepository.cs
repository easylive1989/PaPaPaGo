using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PapapaGo.Models.Bidding;

namespace PapapaGo.Repositories
{
    public class BiddingRepository : BaseRepository, IBiddingRepository
    {
        public BiddingRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<Bidding>> GetBiddingsAsync()
        {
            return (await GetListAsync<Bidding>("WHERE 1")).ToList();
        }

        public async Task<List<Bidding>> GetBiddingsAsync(string name)
        {
            return (await GetListAsync<Bidding>("WHERE Name = @name", new {name})).ToList();
        }

        public async Task<int> CreateBiddingAsync(Bidding bidding)
        {
            return (await InsertAsync(bidding)).GetValueOrDefault();
        }
    }
}