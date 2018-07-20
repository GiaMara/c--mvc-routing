using eRoutingSlip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRoutingSlip.Controllers
{
    public class DetailsController : Controller
    {
        ERoutingSlipDB _db = new ERoutingSlipDB();

        public ActionResult OpenDocument(int id)
        {
            var model = _db.RoutingSlips.Find(id);
            var link = model.DocumentName;
            return Redirect(link);
        }

        //// GET: Details
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Details/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Details/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Details/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Details/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Details/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Details/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Details/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
