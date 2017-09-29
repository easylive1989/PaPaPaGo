using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PapapaGo.Sample
{
    public class SearchRequest : RequestBase
    {
        [JsonProperty("d")]
        public string DestinationStationCode { get; set; }

        [JsonProperty("na")]
        public int NumberOfAdult { get; set; }

        [JsonProperty("nc")]
        public int NumberOfChildren { get; set; }

        [JsonProperty("s")]
        public string StartStationCode { get; set; }

        public DateTime StartTime { get; set; }

        [JsonProperty("dt")]
        public string StartTimeString
        {
            get
            {
                return this.StartTime.ToString("yyyy-MM-dd HH:mm");
            }
        }
    }
}