using System.Threading;
using System.Web.Mvc;
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
            ViewBag.Content = result;

            return View();
        }


    }
}