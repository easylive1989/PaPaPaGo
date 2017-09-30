using System;
using System.Collections.Generic;

namespace PapapaGo.Models.Search
{
    public class Railway
    {
        public string code { get; set; }
    }

    public class From
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class To
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Duration
    {
        public int hour { get; set; }
        public int minutes { get; set; }
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
