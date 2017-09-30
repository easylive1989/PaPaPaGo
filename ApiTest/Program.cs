using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PapapaGo.Models.DTO;
using PapapaGo.Sample;
using PapapaGo.Services;

namespace ApiTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var service = new SearchService(new SearchModel
            {
                Name = "XX",
                Multiple = 2,
                Link = "http://facebook.com",
                Time = new DateTime(2017, 10, 18, 7, 30, 0)
            });
            Console.WriteLine(service.GetTicket());

            Console.ReadLine();
        }
    }
}