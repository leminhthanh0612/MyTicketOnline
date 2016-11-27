using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketOnline.Models
{
    public class PassengerViewModel
    {
       
        public string FirstName { get; set; }


        public string LastName { get; set; }

      
        public string Phone { get; set; }


        public string Email { get; set; }

       
        public string StartDate { get; set; }

        public string Hour { get; set; }


    }
}