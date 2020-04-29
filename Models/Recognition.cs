using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team7MIS4200.Models
{
    public class Recognition
    {
        [Key]
        public int recId { get; set; }

        [Display(Name= "Core Value Recognized")]
        [Required]
        public CoreValue award { get; set; }

        [Display(Name = "Message")]
        [Required]
        public string message  { get; set; }

        public enum CoreValue
        {
            Commit_to_delivery_exellence = 1,
            Embrace_integrity_and_openness = 2,
            Practice_responsible_stewardship = 3,
            Invest_in_exceptional_culture = 4,
            Ignite_passion_for_the_greater_good = 5,
            Strive_to_innovate = 6,
            Live_a_balanced_life = 7

        }

        [Display(Name = "When Created")]
        public DateTime whenCreated { get; set; }
        public Recognition()
        {
            whenCreated = DateTime.Now;
        }

        // the next two properties link the employeeInfo to the Recognition
        [Display(Name = "Recognized Employee")]
        public Guid employeeID { get; set; }
        public virtual employeeInfo EmployeeInfo { get; set; }

    }
}