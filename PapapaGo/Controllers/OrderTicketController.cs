using System.Web.Mvc;
using Newtonsoft.Json;
using PapapaGo.Models.Book;
using PapapaGo.Sample;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class OrderTicketController : Controller
    {
        // GET: OrderTicket
        public ActionResult Index()
        {
            //var client = new Client();
            //var resp = client.PostBook();
            //resp = client.GetAsyncResult(resp);
            //var bookReqeust = JsonConvert.DeserializeObject<BookResponse>(resp.Replace("\n", string.Empty));
            //ViewBag.Price = bookReqeust.tickets[0].price.cents;
            return View();
        }

        public bool Book()
        {
            var service = new SearchService();
            var key = service.GetBookingKey();
            //var client = new Client();
            //var resp = client.PostBook();
            //resp = client.GetAsyncResult(resp);
            //var bookReqeust = JsonConvert.DeserializeObject<BookResponse>(resp);
            //ViewBag.Price = bookReqeust.tickets[0].price.cents;
            return true;
        }
    }
}