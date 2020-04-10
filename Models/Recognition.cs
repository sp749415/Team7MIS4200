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

        [StringLength(500)]
        [Required]
        public string recognition  { get; set; }

        public enum CoreValue
        {
            corevalue = 1,
        }

        public DateTime whenCreated { get; set; }
        public Recognition()
        {
            whenCreated = DateTime.Now;
        }
        
    }
}