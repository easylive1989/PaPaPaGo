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
            return View();
        }

        public ActionResult BookResult()
        {
            var service = new SearchService();
            ViewBag.id = service.GetTicket();

            return View();
        }
    }
}