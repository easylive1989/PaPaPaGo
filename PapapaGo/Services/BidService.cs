using System.Collections.Generic;
using System.Linq;
using PapapaGo.Models.Bidding;
using PapapaGo.Repositories;

namespace PapapaGo.Services
{
    public class BidService
    {
        private readonly IBiddingRepository _BiddingRepository;

        public BidService(IBiddingRepository biddingRepository)
        {
            _BiddingRepository = biddingRepository;
        }

        public bool BuyTicket(int id)
        {
            var ticketInfo = _BiddingRepository.GetBiddingsAsync(id).Result;
            ticketInfo.IsSoldout = true;
            return _BiddingRepository.UpdateBiddingAsync(ticketInfo).Result;
        }

        public List<Bidding> GetBidInfo()
        {
            return _BiddingRepository.GetBiddingsAsync(false).Result;
        }

        public List<Bidding> GetSoldOutBidInfo()
        {
            return _BiddingRepository.GetBiddingsAsync(true).Result;
        }
    }
}