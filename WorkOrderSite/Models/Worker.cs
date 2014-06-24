using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorkOrderSite.Models;

namespace WorkOrderSite.Models
{
    public class Worker
    {
       
        public int WorkerID { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        public string WorkerLastName { get; set; }

        [Required]
        [StringLength(20)]
        public string WorkerFirstName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]           
        public string WorkerEmail { get; set; }

        [Required(ErrorMessage="Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string WorkerPhone { get; set; }

        

    
    }
}