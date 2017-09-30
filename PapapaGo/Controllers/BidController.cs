using System;
using System.Web.Mvc;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class BidController : Controller
    {
        // GET: Bid
        public ActionResult Index(string oriSelect, string desSelect, string username, string datetime, string fblink, string priceSelect)
        {
            var bidService = new BidService();
            var biddingTickets = bidService.GetBidInfo();
            return View(biddingTickets);
        }
    }
}