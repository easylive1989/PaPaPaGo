using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PapapaGo.Factories;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class BidController : Controller
    {
        private readonly BidService _BidService = new BidService(RepositoryFactory.GetBiddingRepository());

        // GET: Bid
        public ActionResult Index(string oriSelect, string desSelect, string username, string datetime, string fblink, string priceSelect)
        {
            var biddingTickets = _BidService.GetBidInfo();
            return View(biddingTickets);
        }

        public string BuyTicket(int id)
        {
            var biddingTickets = _BidService.GetBidInfo();
            _BidService.BuyTicket(id);
            return biddingTickets.Where(x=>x.Id == id).Select(y=>y.Tickets.Links[1]).FirstOrDefault();
        }
    }
}