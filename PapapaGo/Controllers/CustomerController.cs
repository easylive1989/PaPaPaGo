using System;
using System.Web.Mvc;
using PapapaGo.Models.DTO;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class CustomerController : Controller
    {
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

        /// <summary>
        /// 一般顧客訂票
        /// </summary>
        /// <param name="oriSelect"></param>
        /// <param name="desSelect"></param>
        /// <param name="username"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public ActionResult BookResult(string oriSelect, string desSelect, string username, DateTime datetime)
        {
            var searchModel = new SearchModel();
            searchModel.From = oriSelect;
            searchModel.To = desSelect;
            searchModel.Name = username;
            searchModel.Time = datetime;
            searchModel.Multiple = 1;
            var service = new SearchService(searchModel);
            ViewBag.Id = service.GetTicket();
            return View();
        }
    }
}