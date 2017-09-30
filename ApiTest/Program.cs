using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PapapaGo.Sample;
using PapapaGo.Services;

namespace ApiTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var service = new SearchService();
            Console.WriteLine(service.GetTicket());

            Console.ReadLine();
        }
    }
}