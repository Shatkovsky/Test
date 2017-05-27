
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Models.ShopDBEntities db = new Models.ShopDBEntities();
        public ActionResult Index()
        {
            var Items = db.Cars;
            return View(Items);
        }

        public ActionResult CarPage(int item_id)
        {
            var Item = db.Cars.FirstOrDefault(x => x.Id == item_id);
            if (Item == null)
            {
                return Content("<h1>Page not found. Incorrect input data</h1>");
            }
            return View(Item);
        }

        [ChildActionOnly]
        public ActionResult Nav()
        {
            var items = db.Cars;
            string str = "";
            foreach (var item in items)
            {
                str += "<li><a href='/Home/CarPage/?item_id=" + item.Id + "' title='" + item.Title + "'>" + item.Title + "</a></li>";
            }
            return Content(str);
        }

        [HttpGet]
        public ActionResult Form(int item_id = 0)
        {
            ViewBag.Item = item_id;
            return PartialView();
        }

        [ChildActionOnly]
        public string FormOptions(int item_id = 0)
        {
            var Items = db.Cars;
            string str = "";
            foreach (var item in Items)
            {
                if (item.Id == item_id)
                {
                    str += "<option value=" + item.Id + " selected>" + item.Title + "</option>";
                }
                else
                {
                    str += "<option value=" + item.Id + ">" + item.Title + "</option>";
                }
            }
            return str;
        }

        [HttpPost]
        public string Form(string Name, string Tel, int Car)
        {
            string outStr = "";
            Order order = new Order
            {
                UserName = Name,
                UserTel = Tel,
                CarId = Car,
                Status = "Created"
            };
            db.Orders.Add(order);
            db.SaveChanges();
            outStr = "Your request for buy new car " + db.Cars.FirstOrDefault(x => x.Id == Car).Title + " created!";
            return outStr;
        }
    }
}
