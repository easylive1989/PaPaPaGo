using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Newtonsoft.Json;
using PapapaGo.Models.Search;
using PapapaGo.Sample;

namespace PapapaGo.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Book()
        {
            var client = new Client();
            ViewBag.Content = client.PostBook();
            return View();
        }

        // GET: Search
        public ActionResult Index()
        {
            var client = new Client();
            var key = client.GetSearch();
            //System.Threading.Thread.Sleep(3000);
            var result = string.Empty;
            for (var second = 0; second < 60; second++)
            {
                result = client.GetAsyncResult(key);
                if(!result.Contains("not ready"))
                    break;
                Thread.Sleep(1000);
            }
            if (!result.Contains("not ready"))
                return View();

            var searchResult = JsonConvert.DeserializeObject<List<SearchResponse>>(result).FirstOrDefault();

            return View(searchResult);
        }
    }
}