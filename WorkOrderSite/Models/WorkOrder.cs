using System;
using System.Collections.Generic;
using WorkOrderSite.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkOrderSite.Models
{

    public enum WorkOrderPriority
    {

        Low, Medium, High
    }
    public class WorkOrder
    {

        public int WorkOrderID { get; set; }
        public int LocationID { get; set; }
        public int WorkerID { get; set; }
        public int PrimaryContactID { get; set; }

        [Display(Name = "Title:")]
        [Required]
        [StringLength(40)]
        public string WorkOrderTitle { get; set; }

        [Display(Name = "Description:")]
        [Required]
        [StringLength(255)]
        public string WorkOrderDescription { get; set; }


        public WorkOrderPriority? WorkOrderPriority { get; set; }

        [Required]
        [Display(Name = "Date Requested:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WorkOrderRequestDate { get; set; }

        [Required]
        [Display(Name = "Required completion date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WorkOrderRequiredDate { get; set; }

        [Required]
        [Display(Name = "Date Completed:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WorkOrderCompletedDate { get; set; }


        [Display(Name = "Description of the resolution:")]
        [Required]
        [StringLength(255)]
        public string Resolution { get; set; }

        //public virtual Location Location { get; set; }
        //public virtual Worker Worker { get; set; }
        //public virtual PrimaryContact PrimaryContact { get; set; }

    }
}