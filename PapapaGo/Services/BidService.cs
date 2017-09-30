using System.Collections.Generic;
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