using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PapapaGo.Models.DTO;
using PapapaGo.Services;

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

        public ActionResult BidResult(string oriSelect, string desSelect, string username, DateTime datetime, string fblink, int priceSelect)
        {
            var searchModel = new SearchModel();
            searchModel.From = oriSelect;
            searchModel.To = desSelect;
            searchModel.Name = username;
            searchModel.Time = datetime;
            searchModel.Link = fblink;
            searchModel.Multiple = priceSelect;
            var service = new SearchService(searchModel);
            ViewBag.Id = service.GetTicket();
            return View();
        }

        public ActionResult BookResult(string oriSelect, string desSelect, string username, DateTime datetime, string fblink, int priceSelect)
        {
            var searchModel = new SearchModel();
            searchModel.From = oriSelect;
            searchModel.To = desSelect;
            searchModel.Name = username;
            searchModel.Time = datetime;
            searchModel.Link = fblink;
            searchModel.Multiple = priceSelect;
            var service = new SearchService(searchModel);
            ViewBag.Id = service.GetTicket();
            return View();
        }
    }
}