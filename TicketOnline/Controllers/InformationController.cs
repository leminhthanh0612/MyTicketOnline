using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketOnline.Models;

namespace TicketOnline.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInformation(PassengerViewModel model)
        {

            return View();
        }
    }
}