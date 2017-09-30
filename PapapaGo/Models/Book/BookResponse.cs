﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapapaGo.Models.Book
{
    public class BookResponse : BaseResponse
    {
        public string id { get; set; }
        public Railway railway { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public DateTime departure { get; set; }
        public int created_at { get; set; }
        public TicketPrice ticket_price { get; set; }
        public PaymentPrice payment_price { get; set; }
        public RtpPrice rtp_price { get; set; }
        public ChargingPrice charging_price { get; set; }
        public RebateAmount rebate_amount { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Ticket> tickets { get; set; }
        public List<Record> records { get; set; }
    }

    public class Railway
    {
        public string code { get; set; }
    }

    public class From
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class To
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class TicketPrice
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class PaymentPrice
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class RtpPrice
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class ChargingPrice
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class RebateAmount
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class Passenger
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
    }

    public class From2
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class To2
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Price
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class Ticket
    {
        public string id { get; set; }
        public From2 from { get; set; }
        public To2 to { get; set; }
        public Price price { get; set; }
    }

    public class Amount
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class Record
    {
        public string id { get; set; }
        public Amount amount { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string target { get; set; }
    }
}