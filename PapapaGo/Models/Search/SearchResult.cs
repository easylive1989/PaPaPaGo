using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapapaGo.Models.Search
{

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
    
    public class SearchResponse : BaseResponse
        {
        public Railway railway { get; set; }
        public List<Solution> solutions { get; set; }
    }
}
