using System;
using System.Web.Mvc;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class BidController : Controller
    {
        private BidService _BidService = new BidService();

        // GET: Bid
        public ActionResult Index(string oriSelect, string desSelect, string username, string datetime, string fblink, string priceSelect)
        {
            var biddingTickets = _BidService.GetBidInfo();
            return View(biddingTickets);
        }

        public ActionResult BuyTicket(int id)
        {
            var isSuccess = _BidService.BuyTicket(id);
            var biddingTickets = _BidService.GetBidInfo();
            return View("Index", biddingTickets);
        }
    }
}