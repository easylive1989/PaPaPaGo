using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace ApiTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new Client();
            var bookResult = client.PostBook();
            Console.WriteLine(bookResult);
            Console.WriteLine(client.GetAsyncResult(bookResult));

            Console.ReadLine();
        }
    }
}