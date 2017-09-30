using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using PapapaGo.Models.Book;

namespace PapapaGo.Sample
{
    public class ConfirmResponse
    {
        public string id { get; set; }
        public Order order { get; set; }
        public DateTime created_at { get; set; }
        public TicketPrice ticket_price { get; set; }
        public PaymentPrice payment_price { get; set; }
        public RtpPrice rtp_price { get; set; }
        public ChargingPrice charging_price { get; set; }
        public RebateAmount rebate_amount { get; set; }
        public List<object> records { get; set; }
    }
    public class Order
    {
        public string id { get; set; }
        public Railway railway { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public DateTime departure { get; set; }
        public DateTime created_at { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Ticket> tickets { get; set; }
        public string PNR { get; set; }
    }

}