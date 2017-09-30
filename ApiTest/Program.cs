using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace ApiTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new Client();
            var result = client.GetSearch();
            Console.WriteLine(result);
            Console.WriteLine(client.GetAsyncResult(result));

            result = client.PostConfirm();
            Console.WriteLine(result);
            Console.WriteLine(client.GetAsyncResult(result));

            Console.ReadLine();
        }
    }
}