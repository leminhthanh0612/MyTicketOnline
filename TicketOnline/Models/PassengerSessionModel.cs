using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketOnline.Models
{
    public class PassengerSessionModel
    {
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Phone { get; set; }


        public string Email { get; set; }

        public PassengerSessionModel() { }

        public PassengerSessionModel(string firstName, string lastName, string phone, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Email = email;

        }

        public static PassengerSessionModel FromSession(HttpSessionStateBase pSession)
        {
            PassengerSessionModel passenger = pSession["Passenger"] as PassengerSessionModel;
            if(passenger == null)
            {
                passenger = new PassengerSessionModel();
                pSession["Passenger"] = passenger;
            }
            return passenger;
        }

        public void getPassenger(PassengerViewModel model)
        {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Phone = model.Phone;
            this.Email = model.Email;

        }

        public static void AbandonPassenger(HttpSessionStateBase pSession)
        {
            pSession["Passenger"] = null;
        }

    }
}