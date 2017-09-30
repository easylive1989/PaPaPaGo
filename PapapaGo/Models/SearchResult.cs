using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapapaGo.Models
{
   

public class Duration
{
    public int hour { get; set; }
    public int minutes { get; set; }
}

public class Available
{
    public int seats { get; set; }
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

public class SearchResponse : BaseResponse
    {
    public Railway railway { get; set; }
    public List<Solution> solutions { get; set; }
}
}
