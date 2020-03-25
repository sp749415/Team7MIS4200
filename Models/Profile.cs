using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team7MIS4200.Models
{
    public class Profile
    {
        public Guid profileID { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }
    }
}