using System;
using System.Collections.Generic;
using Dapper;
using Newtonsoft.Json;

namespace PapapaGo.Models.Bidding
{
    [Table("bidding")]
    public class Bidding
    {
        private decimal _amount;

        public decimal Amount
        {
            get { return _amount / 100; }
            set => _amount = value;
        }

        public string BookingCode { get; set; }

        public DateTime CreatedTime { get; set; }

        [IgnoreUpdate]
        [IgnoreInsert]
        [IgnoreSelect]
        public decimal DisplayAmount
        {
            get
            {
                return Multiple * Amount;
            }
        }

        public string From { get; set; }

        [Key]
        public int Id { get; set; }

        public bool IsSoldout { get; set; }

        public string Link { get; set; }

        [IgnoreUpdate]
        [IgnoreInsert]
        [IgnoreSelect]
        public decimal MakeMoney
        {
            get
            {
                return (Multiple * Amount) / 10;
            }
        }

        public int Multiple { get; set; }
        public string Name { get; set; }
        public string TicketJson { get; set; }
        public Ticket Tickets => new Ticket { Links = JsonConvert.DeserializeObject<List<string>>(TicketJson) };
        public string To { get; set; }
        public string TrainTime { get; set; }
    }
}