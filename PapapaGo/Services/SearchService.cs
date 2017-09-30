using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PapapaGo.Models;
using PapapaGo.Sample;

namespace PapapaGo.Services
{
    public class SearchService
    {
        public string GetBookingKey()
        {
            var client = new Client();
            var key = client.GetSearch();
            var result = client.GetAsyncResult(key);

            var searchResult = JsonConvert.DeserializeObject<List<SearchResponse>>(result).FirstOrDefault();
            return searchResult.solutions[0].sections[0].offers[0].services[0].booking_code;
        }
    }
}