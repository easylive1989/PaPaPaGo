using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PapapaGo.Sample
{
    public class AsyncRequest : RequestBase
    {
        public string async { private get; set; }

        [JsonProperty("async_key")]
        public string async_key
        {
            get
            {
                return async;
            }
        }
    }

    public class SearchRequest : RequestBase
    {
        [JsonProperty("to")]
        public string DestinationStationCode { get; set; }

        [JsonProperty("adult")]
        public int NumberOfAdult { get; set; }

        [JsonProperty("child")]
        public int NumberOfChildren { get; set; }

        [JsonProperty("from")]
        public string StartStationCode { get; set; }

        public DateTime StartTime { get; set; }

        [JsonProperty("date")]
        public string StartTimeString
        {
            get
            {
                return this.StartTime.ToString("yyyy-MM-dd HH:mm");
            }
        }
    }
}