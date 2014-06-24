using System;
using System.Collections.Generic;
using WorkOrderSite.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WorkOrderSite.Models
{
    public class PrimaryContact
    {
        
        public int PrimaryContactID { get; set; }

        [Display(Name = "Primary Contact First Name:")]
        [Required]
        [StringLength(20)]
        public string PrimaryContactFName{ get; set; }

        [Display(Name = "Primary Contact Last Name:")]
        [Required]
        [StringLength(20)]
        public string PrimaryContactLName { get; set; }

        [Display(Name = "Primary Contact Phone Number:")]
        [Required(ErrorMessage = "Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PrimaryContactPhoneNumber { get; set; }

        [Display(Name = "Primary Contact Email:")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]    
        public string PrimaryContactEmail { get; set; }
    }
}