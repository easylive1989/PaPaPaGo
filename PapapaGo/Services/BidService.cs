using System.Collections.Generic;
using PapapaGo.Models.Bidding;
using PapapaGo.Repositories;
using PapapaGo.Sample;

namespace PapapaGo.Services
{
    public class BidService
    {
        public List<Bidding> GetBidInfo()
        {
            var bidRepo = new BiddingRepository(Config.DbConntectionString);
            return new List<Bidding>();
        }
    }
}