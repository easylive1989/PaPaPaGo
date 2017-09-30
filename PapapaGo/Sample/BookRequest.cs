using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    public class Contact
    {
        public string address { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string postcode { get; set; }
    }

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
}