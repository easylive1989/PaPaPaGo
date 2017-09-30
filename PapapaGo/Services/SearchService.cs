using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PapapaGo.Models.Book;
using PapapaGo.Models.Search;
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

        public string GetBookingResult(string bookingID)
        {
            var client = new Client();
            var key = client.PostBook(bookingID);
            var result = client.GetAsyncResult(key);
            var bookResult = JsonConvert.DeserializeObject<BookResponse>(result);
            return bookResult.id;
        }

        public string GetConfirmResult(string onlineId)
        {
            var client = new Client();
            var key = client.PostConfirm(onlineId);
            var result = client.GetAsyncResult(key);
            var confirmResponse = JsonConvert.DeserializeObject<ConfirmResponse>(result);
            return confirmResponse.id;
        }

        public string GetDownloadResult(string onlineId)
        {
            return onlineId;

            //var client = new Client();
            //var key = client.GetDownload(onlineId);
            //var result = client.GetAsyncResult(key);
            //return onlineId;
        }

        public string GetTicket()
        {
            var bookId = GetBookingKey();
            var onlineOrderId = GetBookingResult(bookId);
            var confirmId = GetConfirmResult(onlineOrderId);
            return GetDownloadResult(confirmId);
        }
    }
}