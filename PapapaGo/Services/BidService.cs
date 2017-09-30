using System.Collections.Generic;
using PapapaGo.Models.Bidding;
using PapapaGo.Repositories;
using PapapaGo.Sample;
using System.Linq;

namespace PapapaGo.Services
{
    public class BidService
    {
        private readonly BiddingRepository _BiddingRepository = new BiddingRepository(Config.DbConntectionString);
        public List<Bidding> GetBidInfo()
        {
            return _BiddingRepository.GetBiddingsAsync(false).Result;
        }

        public bool BuyTicket(int id)
        {
            var ticketInfo = _BiddingRepository.GetBiddingsAsync(id).Result;
            ticketInfo.IsSoldout = true;
            return _BiddingRepository.UpdateBiddingAsync(ticketInfo).Result;
        }
    }
}