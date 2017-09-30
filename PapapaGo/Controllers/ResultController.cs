using PapapaGo.Models.DTO;
using PapapaGo.Services;
using System.Web.Mvc;

namespace PapapaGo.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult BookResult()
        {
            var service = new SearchService(new SearchModel());
            ViewBag.id = service.GetTicket();

            return View();
        }
    }
}