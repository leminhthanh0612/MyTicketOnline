using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketOnline.Models
{
    public class PassengerViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Tên Ít nhất phải có {2} ký tự.", MinimumLength = 1)]
        [Display(Name ="Tên")]
        public string FirstName { get; set; }

        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Số điện thoại")]
        public Int16 Phone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}