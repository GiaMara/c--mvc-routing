using eRoutingSlip.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace eRoutingSlip.Controllers
{
    [Authorize]
    public class RoutingSlipController : Controller
    {

        ERoutingSlipDB _db = new ERoutingSlipDB();
        ApplicationUser userdb = new ApplicationUser();
        // GET: RoutingSlip
        public ActionResult Index()
        {
            var model = _db.RoutingSlips.ToList();

            return View(model);
        }

        public ActionResult EmailSearch()
        {
            return View();
        }

        public JsonResult GetSearchValue(string search)
        {
            ERoutingSlipDBEntities db = new ERoutingSlipDBEntities();
            List<EmailModel> allsearch = db.AspNetUsers.Where(x => x.Email.Contains(search)).Select(x => new EmailModel
            {
                Id = x.Id,
                Email = x.Email
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Summary()
        {
            var model = from r in _db.RoutingSlips
                        select new RoutingSlipSignatureViewModel
                        {
                            RoutingSlipID = r.RoutingSlipID,
                            DocumentName = r.DocumentName,
                            CurrentName = r.LinkedListSignature.CurrentName
                        };
            return View(model);
        }


        // GET: RoutingSlip/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.RoutingSlips.Find(id);
            return View(model);
        }

        // GET: RoutingSlip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoutingSlip/Create
        [HttpPost]
        public ActionResult Create(RoutingSlip routingslip)
        {
            var email = routingslip.RequestingEmployee;
            Employee currUser = _db.Employees.SingleOrDefault(user => user.Email == email);
            routingslip.DivisionID = currUser.DivisionId;
            if (ModelState.IsValid)
            {
                _db.RoutingSlips.Add(routingslip);
                _db.SaveChanges();
                return RedirectToAction("CreateLinkedList", new { id = routingslip.RoutingSlipID });
            }
            return View(routingslip);
        }

        public ActionResult GetRequests()
        {
            
            var currUser = System.Web.HttpContext.Current.User.Identity.Name;


            var model = _db.LinkedListSignatures.Where(node => node.CurrentName == currUser).ToList();
            var rs = _db.RoutingSlips.ToList();
            var result = rs.Where(a => model.Any(x => x.RoutingSlipID == a.RoutingSlipID));


            return View(result);

        }


        public ActionResult UserRequests()
        {

            var currUser = System.Web.HttpContext.Current.User.Identity.Name;
            var model = _db.RoutingSlips.Where(node => node.RequestingEmployee == currUser).ToList();
            return View(model);

        }

        public ActionResult CreateLinkedList(int id)
        {
            var model = _db.RoutingSlips.Find(id);


            Signature Initiator = new Signature
            {
                SignatureName = model.RequestingEmployee,
                DateRouted = model.DateSubmitted,
                Status = "Originator",
                RoutingSlipID = id,
            };

            LinkedListSignature lls = new LinkedListSignature
            {
                RoutingSlipID = id
            };
            LinkedListSignatureNode headll = new LinkedListSignatureNode
            {
                Data = Initiator,
                RoutingSlipID = id
            };
            List<LinkedListSignatureNode> llsn = new List<LinkedListSignatureNode>
            {
                headll
            };
            LinkedListSignatureNode current = new LinkedListSignatureNode();
            current = headll;

            //var count = 2;
            if (model.ForwardTo.Contains(","))
            {

                model.ForwardTo = model.ForwardTo.Substring(0, model.ForwardTo.Length - 1);
                string[] namesArray = model.ForwardTo.Split(',');
                List<string> namesList = new List<string>(namesArray.Length);

                for (var i = 0; i < namesArray.Length; i++)
                {

                    namesArray[i] = namesArray[i].Trim();

                    Signature s = new Signature
                    {
                        SignatureName = namesArray[i],
                        Status = "N/A",
                        RoutingSlipID = id,
                        //        //SignatureID = count++,
                    };
                    LinkedListSignatureNode sNode = new LinkedListSignatureNode
                    {
                        Data = s,
                        RoutingSlipID = id

                    };
                    if (i == 0)
                    {

                        lls.CurrentName = sNode.Data.SignatureName;
                    }

                    llsn.Add(sNode);

                }
            }
            else
            {

                Signature s = new Signature
                {
                    SignatureName = model.ForwardTo,
                    Status = "N/A",
                    RoutingSlipID = id,
                };
                LinkedListSignatureNode sNode = new LinkedListSignatureNode
                {
                    Data = s,
                    RoutingSlipID = id

                };


                //current.Next = sNode;
                llsn.Add(current);
                //sNode.Prev = current;

                current = sNode;
                llsn.Add(sNode);
                lls.CurrentName = sNode.Data.SignatureName;
            }

            lls.LLSNodes = llsn;
            model.LinkedListSignature = lls;

            if (ModelState.IsValid)
            {
                _db.SaveChanges();
                return RedirectToAction("SetPrevNext", model.RoutingSlipID); //model 
            }
            return View(model);
        }

        public ActionResult SetPrevNext(int id)
        {

            var modelA = _db.RoutingSlips.Find(id);
            var model = _db.LinkedListSignatureNodes;
            var count = 0;
            LinkedListSignatureNode current = new LinkedListSignatureNode();
            var queryModel = from n in model
                             where n.RoutingSlipID == modelA.RoutingSlipID
                             orderby n.ID ascending
                             select n;
            foreach (LinkedListSignatureNode l in queryModel)
            {

                if (count == 0)
                {
                    l.PrevSNode = null;
                    l.NextSNode = null;
                    current = l;
                    count++;
                }
                else
                {
                    l.PrevSNode = current;
                    current.NextSNode = l;
                    current = l;
                    current.NextSNode = null;
                    count++;
                }

            }
            if (ModelState.IsValid)
            {
                _db.SaveChanges();
                //return View(queryModel); //commented out 5.5
                //return RedirectToAction("Index");
                return RedirectToAction("Details", "RoutingSlip", new { id = modelA.RoutingSlipID });
            }
            return View(modelA);

        }

        public ActionResult DeleteLinkedList(int id)
        {
            LinkedListSignature model = _db.LinkedListSignatures.Find(id);

            _db.LinkedListSignatures.Remove(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: RoutingSlip/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.RoutingSlips.Find(id);
            return View(model);
        }

        // POST: RoutingSlip/Edit/5
        [HttpPost]
        public ActionResult Edit(RoutingSlip routingslip)
        {

            if (ModelState.IsValid)
            {
                _db.Entry(routingslip).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = routingslip.RoutingSlipID });
            }
            return View(routingslip);
        }


        // GET: RoutingSlip/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            RoutingSlip routingslip = _db.RoutingSlips.Find(id);
            return View(routingslip);
        }


        // POST: /RoutingSlip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoutingSlip routingslip = _db.RoutingSlips.Find(id);

            _db.RoutingSlips.Remove(routingslip);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}

