using System.Web.Mvc;
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

        public void BuyTicket(int id)
        {
            var isSuccess = _BidService.BuyTicket(id);

        }
    }
}