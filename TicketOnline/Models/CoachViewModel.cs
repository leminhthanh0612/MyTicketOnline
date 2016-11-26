using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketOnline.Models
{
    public class CoachViewModel
    {
        public   int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public string Router { get; set; }

        public int NumberSeat { get; set; }

        public DateTime StartDate { get; set; }

        public string StartHour { get; set; }

        public List<TicketVewModel> Tickets {get; set;}

        public CoachViewModel()
        {
            this.Tickets = new List<TicketVewModel>();
        }
    }
}