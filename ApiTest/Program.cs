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
            var names = new [] {"Ethan Li", "Eviler", "Eric Lin", "Jean Lin", "Paul Wu", "James", "Kyo Lai", "Michelle Pig", "Leo Chiang", "Adriannie"};
            Task[] tasks = new Task[10];
            for (var i = 0; i < 10; i++)
            {
                var idx = i;
                tasks[idx] = Task.Factory.StartNew(() =>
                {
                    var service = new SearchService(new SearchModel
                    {
                        Name = names[idx],
                        Multiple = 5,
                        Link = "http://facebook.com",
                        Time = new DateTime(2017, 10, 18, 7, 30, 0)
                    });
                });
            }
            Task.WaitAll(tasks);
            Console.ReadLine();
        }
    }
}