using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PapapaGo.Models.Bidding;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class BidController : Controller
    {
        private BidService _BidService = new BidService();

        // GET: Bid
        public ActionResult Index()
        {
            var biddingTickets = _BidService.GetBidInfo();
            return View(biddingTickets);
        }

        public ActionResult BuyTicket(int id)
        {
            _BidService.BuyTicket(id);
            var biddingTickets = _BidService.GetBidInfo();
            return View("Index",biddingTickets);
        }
    }
}