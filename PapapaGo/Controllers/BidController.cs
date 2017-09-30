using System.Web.Mvc;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class BidController : Controller
    {
        // GET: Bid
        public ActionResult Index()
        {
            var bidService = new BidService();
            var biddingTickets = bidService.GetBidInfo();
            return View(biddingTickets);
        }
    }
}