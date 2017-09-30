using System;
using Newtonsoft.Json;
using RestSharp;

namespace PapapaGo.Sample
{
    public class Client
    {
        public string GetAsyncResult(string async)
        {
            var aysncrequest = JsonConvert.DeserializeObject<AsyncRequest>(async);

            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, aysncrequest);
            var signature = secure.Sign();

            var client = new RestClient(Config.GrailTravelHost);

            var request = new RestRequest($"/api/v2/async_results/{aysncrequest.async_key}", Method.GET);
            request.AddHeader("From", Config.ApiKey);
            request.AddHeader("Date", dateTime.ToString("r"));
            request.AddHeader("Authorization", signature);

            var response = client.Get(request);
            return response.Content;
        }

        public string GetSearch(SearchRequest searchReqeust)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, searchReqeust);
            var signature = secure.Sign();

            var client = new RestClient(Config.GrailTravelHost);

            var request = new RestRequest($"/api/v2/online_solutions?{searchReqeust.GetURL()}", Method.GET);
            request.AddHeader("From", Config.ApiKey);
            request.AddHeader("Date", dateTime.ToString("r"));
            request.AddHeader("Authorization", signature);

            var response = client.Get(request);
            return response.Content;
        }

        public string GetSearch()
        {
            var searchReqeust = new SearchRequest
            {
                StartStationCode = "ST_EZVVG1X5",
                DestinationStationCode = "ST_D8NNN9ZK",
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 1,
                NumberOfChildren = 0
            };
            return GetSearch(searchReqeust);
        }

        public string PostBook()
        {
            var sample = @"
 {
    'contact': {
      'name': 'Liping',
      'email': 'lp@163.com',
      'phone': '10086',
      'address': 'beijing',
      'postcode': '100100'
    },
    'passengers': [
      {
        'last_name': 'zhang',
        'first_name': 'san',
        'birthdate': '1986-09-01',
        'passport': 'A123456',
        'email': 'x@a.cn',
        'phone': '15000367081',
        'gender': 'male'
      }
    ],
    'sections': [
      'P_4SDF5P'
    ],
    'seat_reserved': true
  }
";

            var bookReqeust = JsonConvert.DeserializeObject<BookRequest>(sample);

            return PostBook(bookReqeust);
        }

        public string PostBook(BookRequest bookRequest)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, bookRequest);
            var signature = secure.Sign();

            var client = new RestClient(Config.GrailTravelHost);

            var request = new RestRequest($"/api/v2/online_orders", Method.POST);
            request.AddHeader("From", Config.ApiKey);
            request.AddHeader("Date", dateTime.ToString("r"));
            request.AddHeader("Authorization", signature);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(bookRequest);

            var response = client.Post(request);
            return response.Content;
        }
    }
}