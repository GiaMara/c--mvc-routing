using eRoutingSlip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRoutingSlip.Controllers
{
    public class EmployeeController : Controller
    {

        ERoutingSlipDB _db = new ERoutingSlipDB();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult SetProfile(int id)
        {
            //return View();
            var model = _db.Employees.Find(id);
            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult SetProfile(Employee employee) //int id, FormCollection collection
        {
            employee.Email = System.Web.HttpContext.Current.User.Identity.Name; 
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", "Home", new { id = employee.EmployeeID });
            }
            return View(employee);
            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index", "Home");
            //}
            //catch
            //{
            //}
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
