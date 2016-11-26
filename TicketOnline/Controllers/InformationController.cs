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
            CoachViewModel resuftCoach = new CoachViewModel();
            if (model != null && !String.IsNullOrEmpty(model.FirstName))
            {
                PassengerSessionModel.FromSession(this.Session).getPassenger(model);
                TicketDataContext dc = new TicketDataContext();
                List<Coach> coaches = new List<Coach>();
                if(model.Hour != "-")
                {
                    coaches = dc.Coaches.Where(q => q.StartDate == Convert.ToDateTime(model.StartDate)).ToList();
                }
                else
                {
                    coaches = dc.Coaches.Where(q => q.StartDate == Convert.ToDateTime(model.StartDate) && q.StartHour == model.Hour).ToList();
                }
                
                foreach (Coach coach in coaches)
                {
                    resuftCoach.Name = coach.Name;
                    resuftCoach.NumberSeat = coach.NumberSeat;
                    resuftCoach.Router = coach.Router;
                    resuftCoach.StartDate = coach.StartDate;
                    resuftCoach.StartHour = coach.StartHour;
                    resuftCoach.Id = coach.Id;

                    for (int i = 0; i < resuftCoach.NumberSeat; i++)
                    {
                        TicketVewModel ticket = new TicketVewModel();
                        ticket.SeatId = i;
                        resuftCoach.Tickets.Add(ticket);
                    }

                    List<Ticket> tickets = dc.Tickets.Where(q => q.CoachId == resuftCoach.Id).ToList();
                    if (tickets.Count > 0)
                    {
                        foreach (Ticket ticket in tickets)
                        {
                            resuftCoach.Tickets[ticket.SeatId].Status = ticket.Status;
                        }
                    }
                    break;
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(resuftCoach);
        }
    }
}