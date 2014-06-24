using System;
using System.Collections.Generic;
using WorkOrderSite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkOrderSite.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [Display(Name = "Name of Location:")]
        [Required]
        [StringLength(20)]
        public string LocationName { get; set; }

        [Display(Name = "Location Address:")]
        [Required]
        [StringLength(40)]
        public string LocationAddress { get; set; }

        [Display(Name = "Zip Code:")]
        [Required]
        [StringLength(40)]
        public string LocationZip { get; set; }

        [Display(Name = "City:")]
        [Required]
        [StringLength(15)]
        public string LocationCity { get; set; }

        //[Display(Name = "Last Name")]
        //[Required]
        //[StringLength(10)]
        //public string LocationState { get; set; }
        
    }
}