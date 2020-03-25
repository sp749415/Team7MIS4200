using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team7MIS4200.Models
{
    public class employeeInfo
    {
        [Key]
        public Guid employeeID { get; set; }

        [Display(Name = "Student Full Name")]
        public string fullName
        {
            get { return lastName + ", " + firstName; }
        }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string lastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required (ex)jdoe@email.com")]
        public string email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpressionAttribute(@"\d{ 3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone Numbers must be in the format xxx-xxx-xxxx")]
        [Required(ErrorMessage = "Phone number is required")]
        public string phone { get; set; }

        public enum businessUnit
        {
            Boston = 1,
            Charlotte = 2,
            Chicago = 3,
            Cincinatti = 4,
            Cleveland = 5,
            Columbus = 6,
            India = 7,
            Indianapolis = 8,

        }
    }
}