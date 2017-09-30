using System;
using Dapper;
using Newtonsoft.Json;

namespace PapapaGo.Models.Bidding
{
    [Table("bidding")]
    public class Bidding
    {
        public int Amount { get; set; }
        public string BookingCode { get; set; }
        public DateTime CreatedTime { get; set; }

        [IgnoreUpdate]
        [IgnoreInsert]
        public int DisplayAmount
        {
            get
            {
                return Multiple * Amount;
            }
        }

        public string From { get; set; }
        public int Id { get; set; }
        public bool IsSoldout { get; set; }
        public string Link { get; set; }
        public int Multiple { get; set; }
        public string Name { get; set; }
        public string TicketJson { get; set; }
        public Ticket Tickets => JsonConvert.DeserializeObject<Ticket>(TicketJson.Replace("\n", string.Empty));
        public string To { get; set; }
    }
}