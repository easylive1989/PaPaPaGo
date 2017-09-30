using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapapaGo.Controllers
{
    public class CustomerController : Controller
    {
        // POST:
        // 訂票
        public ActionResult OrderTicket()
        {
            return View();
        }
    }
}