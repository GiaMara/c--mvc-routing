using eRoutingSlip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace eRoutingSlip.Controllers
{
    public class MailerController : Controller
    {
        ERoutingSlipDB _db = new ERoutingSlipDB();

        // GET: Mailer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BeginMailProc(int id)
        {
            var model = _db.RoutingSlips.Find(id);

            //try
            //{
            //    //Configuring webMail class to send emails
            //    //gmail smtp server
            //    WebMail.SmtpServer = "smtp.gmail.com";
            //    //gmail port to send emails
            //    WebMail.SmtpPort = 587;
            //    WebMail.SmtpUseDefaultCredentials = true;
            //    //sending emails with secure protocol
            //    WebMail.EnableSsl = true;
            //    //EmailId used to send emails from application
            //    WebMail.UserName = "efilemailer@gmail.com";
            //    WebMail.Password = "efile123";

            //    //Sender email address.
            //    WebMail.From = "efilemailer@gmail.com";

            //    //Send email
            //    WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);
            //    ViewBag.Status = "Email Sent Successfully.";
            //}
            //catch (Exception)
            //{
            //    ViewBag.Status = "Problem while sending email, Please check details.";

            //}
            if (ModelState.IsValid)
            {
                return RedirectToAction("CreateLinkedList", "RoutingSlip", model.RoutingSlipID); //model 
            }
            return View(model);
        }
    }
}