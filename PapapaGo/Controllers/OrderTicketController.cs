using System.Web.Mvc;
using Newtonsoft.Json;
using PapapaGo.Models.Book;
using PapapaGo.Models.DTO;
using PapapaGo.Sample;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class OrderTicketController : Controller
    {
        public ActionResult BookResult()
        {
            var service = new SearchService(new SearchModel());
            ViewBag.id = service.GetTicket();

            return View();
        }

        // GET: OrderTicket
        public ActionResult Index()
        {
            return View();
        }
    }
}