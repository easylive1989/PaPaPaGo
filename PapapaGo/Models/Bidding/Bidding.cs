using System;
using System.Collections.Generic;
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
        [IgnoreSelect]
        public int DisplayAmount
        {
            get
            {
                return Multiple * Amount;
            }
        }

        [IgnoreUpdate]
        [IgnoreInsert]
        [IgnoreSelect]
        public decimal MakeMoney
        {
            get
            {
                return new decimal(Multiple * Amount) / 100;
            }
        }

        public string From { get; set; }

        [Key]
        public int Id { get; set; }

        public bool IsSoldout { get; set; }
        public string Link { get; set; }
        public int Multiple { get; set; }
        public string Name { get; set; }
        public string TicketJson { get; set; }
        public Ticket Tickets => new Ticket{Links = JsonConvert.DeserializeObject<List<string>>(TicketJson)};
        public string To { get; set; }
        public string TrainTime { get; set; }
    }
}