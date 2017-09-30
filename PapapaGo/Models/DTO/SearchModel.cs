using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapapaGo.Models.DTO
{
    public class SearchModel
    {
        public decimal Amount { get; set; }
        public string From { get; set; }
        public string Link { get; set; }
        public int Multiple { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string To { get; set; }
    }
}