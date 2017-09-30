using System;

namespace PapapaGo.Models.Bidding
{
    public class Bidding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Amount { get; set; }
        public int Multiple { get; set; }
        public string BookingCode { get; set; }
        public string Link { get; set; }
        public string TicketJson { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}