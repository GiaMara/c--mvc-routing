using eRoutingSlip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRoutingSlip.Controllers
{
    public class LinkedListSignatureNodeController : Controller
    {
        ERoutingSlipDB _db = new ERoutingSlipDB();

        // GET: LinkedListSignatureNode
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DeleteNode(int id)
        {
            var model = _db.LinkedListSignatureNodes.Find(id);

            var LLmodel = _db.LinkedListSignatureNodes;
            var LLmodelID = model.RoutingSlipID;

            foreach (LinkedListSignatureNode l in LLmodel)
            {
                if (l.RoutingSlipID == model.RoutingSlipID && l.ID == model.ID)
                {
                    if (model.NextSNode != null) // middle of the list
                    {
                        model.NextSNode.PrevSNode = model.PrevSNode;
                        model.PrevSNode.NextSNode = model.NextSNode;
                        LLmodel.Remove(model);
                    }
                    else
                    {
                        LLmodel.Remove(model);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _db.SaveChanges();

                return RedirectToAction("Details", new { id = LLmodelID });
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult Details(int id)
        {
            var LLmodel = _db.LinkedListSignatureNodes;
            var query = from n in LLmodel
                        where n.RoutingSlipID == id
                        select n;
            if (ModelState.IsValid)
            {

                return View(query);
            }
            else
            {
                return View(LLmodel);
            }
        }

        // GET: LinkedListSignatureNode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LinkedListSignatureNode/Create
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

        // GET: LinkedListSignatureNode/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LinkedListSignatureNode/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LinkedListSignatureNode/Delete/5
        public ActionResult Delete(int id)
        {
            LinkedListSignatureNode llsn = _db.LinkedListSignatureNodes.Find(id);
            if (llsn == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("DeleteNode", new { id = llsn.ID });
        }


        public ActionResult CreateNode(int id)
        {
            var model = _db.LinkedListSignatureNodes.Find(id);
            LinkedListSignatureNode newNode = new LinkedListSignatureNode();
            newNode.RoutingSlipID = model.RoutingSlipID;
            if (model.NextSNode == null)
            {
                model.NextSNode = newNode;
            }
            else // middle node
            {
                model.NextSNode.PrevSNode = newNode;
                model.NextSNode = newNode;
                newNode.PrevSNode = model;
                newNode.NextSNode = model.NextSNode;
            }

            Signature newSignature = new Signature();
            newSignature.RoutingSlipID = model.RoutingSlipID;
            newSignature.Status = "N/A";
            newNode.Data = newSignature;
            _db.LinkedListSignatureNodes.Add(newNode);

            if (ModelState.IsValid)
            {

                //_db.SaveChanges();
                return RedirectToAction("CreateSignature", new { id = newNode.ID });
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult NewNode(int id, string n)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateSignature(int id)
        {
            var model = _db.LinkedListSignatureNodes.Find(id);
            return View(model);
        }

        //[HttpGet]
        //public ActionResult CreateSignature([Bind(Prefix = "id")] int linkId)
        //{
        //    var model = _db.LinkedListSignatureNodes.Find(linkId);
        //    if (model != null)
        //    {
        //        return View(model);
        //    }
        //    return HttpNotFound();
        //}

        [HttpPost]
        public ActionResult CreateSignature(LinkedListSignatureNode l)
        {

            if (ModelState.IsValid)
            {
                var modelID = l.RoutingSlipID;
                return RedirectToAction("Details", new { id = modelID });
            }
            else
            {
                return HttpNotFound();
            }

        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
