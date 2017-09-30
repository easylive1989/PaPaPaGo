using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PapapaGo.Models.Book;
using PapapaGo.Models.DTO;
using PapapaGo.Models.Search;
using PapapaGo.Repositories;
using PapapaGo.Sample;

namespace PapapaGo.Services
{
    public class SearchService
    {
        private SearchModel _model;
        private IBiddingRepository _repository;
        private ConfirmResponse _response;

        public SearchService(SearchModel model)
        {
            model.From = model.From ?? "ST_D8NNN9ZK";
            model.To = model.To ?? "ST_EZVVG1X5";
            _model = model;
            _repository = new BiddingRepository(Config.DbConntectionString);
        }

        public string GetTicket()
        {
            var bookId = GetBookingKey();
            var onlineOrderId = GetBookingResult(bookId);
            var confirmId = GetConfirmResult(onlineOrderId);
            var tickets = GetDownloadResult(confirmId);

            _repository.CreateBiddingAsync(new Models.Bidding.Bidding
            {
                Name = _model.Name,
                From = _model.From,
                To = _model.To,
                Amount = _response.order.tickets.First().price.cents,
                Multiple = _model.Multiple,
                CreatedTime = DateTime.Now,
                TicketJson = tickets,
                Link = _model.Link,
                BookingCode = _response.order.id
            });

            return tickets;
        }

        private string GetBookingKey()
        {
            var client = new Client();
            var key = client.GetSearch(new SearchRequest
            {
                StartTime = _model.Time,
                StartStationCode = _model.From,
                DestinationStationCode = _model.To,
                NumberOfAdult = 2,
                NumberOfChildren = 0
            });
            var result = client.GetAsyncResult(key);

            var searchResult = JsonConvert.DeserializeObject<List<SearchResponse>>(result).FirstOrDefault(x => x.railway.code == "FB");

            return searchResult.solutions[0].sections[0].offers[0].services[0].booking_code;
        }

        private string GetBookingResult(string bookingID)
        {
            var client = new Client();
            var key = client.PostBook(bookingID);
            var result = client.GetAsyncResult(key);
            var bookResult = JsonConvert.DeserializeObject<BookResponse>(result);
            return bookResult.id;
        }

        private string GetConfirmResult(string onlineId)
        {
            var client = new Client();
            var key = client.PostConfirm(onlineId);
            var result = client.GetAsyncResult(key);
            var confirmResponse = JsonConvert.DeserializeObject<ConfirmResponse>(result);
            _response = confirmResponse;
            return confirmResponse.order.id;
        }

        private string GetDownloadResult(string onlineId)
        {
            var client = new Client();
            var key = client.GetDownload(onlineId);
            return key;
        }
    }
}