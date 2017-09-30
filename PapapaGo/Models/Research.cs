using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapapaGo.Models
{
    class SearchResult
    {

    }
    public class Railway
    {
        public string code { get; set; }
    }

    public class From
    {
        public string RailwayCode { get; set; }
        public string RailwayName { get; set; }
    }

    public class To
    {
        public string RailwayCode { get; set; }
        public string RailwayName { get; set; }
    }

    public class Duration
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }

    public class Available
    {
        public int seats { get; set; }
    }

    public class Price
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class Service
    {
        public string code { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public Available available { get; set; }
        public Price price { get; set; }
        public string booking_code { get; set; }
    }

    public class Offer
    {
        public string code { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public List<Service> services { get; set; }
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

    public class Train
    {
        public string number { get; set; }
        public string type { get; set; }
        public From2 from { get; set; }
        public To2 to { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
    }

    public class Section
    {
        public List<Offer> offers { get; set; }
        public List<Train> trains { get; set; }
    }

    public class Solution
    {
        public From from { get; set; }
        public To to { get; set; }
        public DateTime departure { get; set; }
        public Duration duration { get; set; }
        public int transfer_times { get; set; }
        public List<Section> sections { get; set; }
    }

    public class RootObject
    {
        public Railway railway { get; set; }
        public List<Solution> solutions { get; set; }
    }
}
