using eRoutingSlip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRoutingSlip.Controllers
{

    public class HomeController : Controller
    {
        ERoutingSlipDB _db = new ERoutingSlipDB();
        public ActionResult Index()
        {
            var currUser = System.Web.HttpContext.Current.User.Identity.Name;
            //var model = _db.LinkedListSignatures.Select(node => node.CurrentName == currUser);
            var model = _db.LinkedListSignatures.Where(node => node.CurrentName == currUser).ToList();

            return View(model);

            //var model = 
            //from d in _db.Divisions
            //orderby d.DivisionName ascending
            ////orderby d.RoutingSlips.Count() descending
            ////select d;
            //select new DivisionListViewModel
            //{
            //    ID = d.ID,
            //    DivisionName = d.DivisionName,
            //    DivisionHead = d.DivisionHead,
            //    RSCount = d.RoutingSlips.Count()
            //};
            //return View(model);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}