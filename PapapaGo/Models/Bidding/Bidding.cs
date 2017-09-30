using System;
using Dapper;
using Newtonsoft.Json;

namespace PapapaGo.Models.Bidding
{
    [Table("bidding")]
    public class Bidding
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Amount { get; set; }
        public int Multiple { get; set; }
        public string BookingCode { get; set; }
        public string Link { get; set; }
        public string TicketJson { get; set; }
        public string TrainTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsSoldout { get; set; }

        public Ticket Tickets => JsonConvert.DeserializeObject<Ticket>(TicketJson.Replace("\n", string.Empty));
    }
}