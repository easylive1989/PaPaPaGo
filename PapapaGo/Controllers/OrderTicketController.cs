using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PapapaGo.Models;
using PapapaGo.Sample;

namespace PapapaGo.Controllers
{
    public class OrderTicketController : Controller
    {
        // GET: OrderTicket
        public ActionResult Index()
        {
            var client = new Client();
            var resp = client.PostBook();
            resp = client.GetAsyncResult(resp);
            var bookReqeust = JsonConvert.DeserializeObject<BookResponse>(resp);
            ViewBag.Price = bookReqeust.tickets[0].price.cents;
            return View();
        }
    }
}