using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExistingDatabase.Models;
using ExistingDatabase.ViewModels;

namespace ExistingDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly coreDBEntities db = new coreDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var query = "Select Rank, Count(*) as RankCount from Website group by rank";
            IEnumerable<CryptoWebsite> data = db.Database.SqlQuery<CryptoWebsite>(query);

            return View(data.ToList());

           // return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var query = "SELECT Website.WebsiteName, Crypto.CryptoName FROM Website INNER JOIN Crypto ON Website.Id = Crypto.Id;";

            //var query = "Select * from Crypto";

            IEnumerable<CryptoWebsite> data = db.Database.SqlQuery<CryptoWebsite>(query);

            return View(data.ToList());

            //return View();
        }
    }
}