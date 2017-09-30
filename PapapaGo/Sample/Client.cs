using System;
using System.Threading;
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

            var response = string.Empty;
            for (var second = 0; second < 60; second++)
            {
                var res = client.Get(request);
                if (!res.Content.Contains("not ready"))
                {
                    response = res.Content;
                    break;
                }
                Thread.Sleep(1000);
            }

            return response;
        }

        public string GetSearch(SearchRequest searchReqeust)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, searchReqeust);
            var signature = secure.Sign();

            var client = new RestClient(Config.GrailTravelHost);
            Console.WriteLine(searchReqeust.GetURL());
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
                StartStationCode = "ST_D8NNN9ZK",
                DestinationStationCode = "ST_EZVVG1X5",
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 2,
                NumberOfChildren = 0
            };
            return GetSearch(searchReqeust);
        }

        public string PostBook(string bookingID = "P_1FE6MA9")
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
        'gender': 'male',
      },
        {
        'last_name': 'zhang',
        'first_name': 'san',
        'birthdate': '1986-09-01',
        'passport': 'A123456',
        'email': 'x@a.cn',
        'phone': '15000367081',
        'gender': 'male',
      }
    ],
    'sections': [
      '_{0}_'
    ],
    'seat_reserved': true
  }
";

            var bookReqeust = JsonConvert.DeserializeObject<BookRequest>(sample.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("_{0}_", bookingID));

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

        public string PostConfirm(string onlineId = "OD_Q2M1KDZG3")
        {
            ConfirmRequest confirmReqeust = new ConfirmRequest
            {
                online_order_id = onlineId
            };
            return PostConfirm(confirmReqeust);
        }

        public string PostConfirm(ConfirmRequest confirmReqeust)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, confirmReqeust);
            var signature = secure.Sign();

            var client = new RestClient(Config.GrailTravelHost);
            Console.WriteLine(confirmReqeust.GetURL());
            var request = new RestRequest($"/api/v2/online_orders/{confirmReqeust.online_order_id}/online_confirmations", Method.POST);
            request.AddHeader("From", Config.ApiKey);
            request.AddHeader("Date", dateTime.ToString("r"));
            request.AddHeader("Authorization", signature);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(confirmReqeust);

            var response = client.Post(request);
            return response.Content;
        }
    }
}