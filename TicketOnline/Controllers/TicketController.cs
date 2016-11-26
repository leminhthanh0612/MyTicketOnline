using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketOnline.Models;

namespace TicketOnline.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book(string CoachId, string SeatIds)
        {
            TicketDataContext dc = new TicketDataContext();
            PassengerSessionModel passengerSession = PassengerSessionModel.FromSession(this.Session);
            Passenger passenger = new Passenger();
            if(passengerSession != null)
            {
                passenger.Email = passengerSession.Email;
                passenger.FirstName = passengerSession.FirstName;
                passenger.LastName = passengerSession.LastName;
                passenger.Phone = passengerSession.Phone;
                passenger.RegisterDate = DateTime.Now;
            }
            if (!String.IsNullOrEmpty(SeatIds))
            {
                string[] seatIdBooked = SeatIds.Split(',');
                foreach (string seatId in seatIdBooked)
                {
                    if (!String.IsNullOrWhiteSpace(seatId))
                    {
                        Ticket ticket = new Ticket();
                        Ticket ticketCheck = dc.Tickets.Where(q => q.CoachId == int.Parse(CoachId) && q.SeatId == int.Parse(seatId)).FirstOrDefault();
                        if (ticketCheck == null)
                        {
                            ticket.CoachId = int.Parse(CoachId);
                            ticket.SeatId = int.Parse(seatId);
                            ticket.Status = Status.Pendding.ToString();
                            passenger.Tickets.Add(ticket);
                        }
                        else
                        {
                            return View();
                        }
                        
                    }
                }
            }
            
           
            Coach coach = dc.Coaches.Where(q => q.Id == int.Parse(CoachId)).First();
            if (passenger != null && passenger.FirstName != null && passenger.Tickets.Count > 0)
            {
                dc.Passengers.InsertOnSubmit(passenger);
                dc.SubmitChanges();
                PassengerSessionModel.AbandonPassenger(this.Session);
            }
            ViewBag.Coach = coach;
            return View(passenger);
        }
    }
}