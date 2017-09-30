using System.Collections.Generic;
using Dapper;
using Newtonsoft.Json;

namespace PapapaGo.Sample
{
    public class BookRequest : RequestBase
    {
        public Contact contact { get; set; }

        public List<Passenger> passengers { get; set; }

        [JsonProperty("seat_reserved")]
        public bool seat_reserved { get; set; }

        public List<string> sections { get; set; }
    }

    [Table("contact")]
    public class Contact
    {
        public string address { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string postcode { get; set; }
    }

    [Table("passenger")]
    public class Passenger
    {
        public string birthdate { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }
        public string last_name { get; set; }
        public string passport { get; set; }
        public string phone { get; set; }
    }

    [Table("booking")]
    public class Booking
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }
        public string last_name { get; set; }
        public string passport { get; set; }
        public string booking_code { get; set; }
        public int booked_seats { get; set; }
    }
}