﻿using System;
using System.Web.Mvc;
using PapapaGo.Factories;
using PapapaGo.Services;

namespace PapapaGo.Controllers
{
    public class BidController : Controller
    {
        private readonly BidService _BidService = new BidService(RepositoryFactory.GetBiddingRepository());

        public ActionResult BuyTicket(int id)
        {
            var isSuccess = _BidService.BuyTicket(id);
            var biddingTickets = _BidService.GetBidInfo();
            return View("Index", biddingTickets);
        }

        // GET: Bid
        public ActionResult Index(string oriSelect, string desSelect, string username, string datetime, string fblink, string priceSelect)
        {
            var biddingTickets = _BidService.GetBidInfo();
            return View(biddingTickets);
        }

        public ActionResult SoldOutReport()
        {
            var biddingTickets = _BidService.GetSoldOutBidInfo();
            return View(biddingTickets);
        }
    }
}