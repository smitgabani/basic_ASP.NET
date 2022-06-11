using Assign1.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assign1.GetAllGetOne
{
    public class VenueEditFormViewModel
    {
        [Key]
        public int VenueId { get; set; }
        [Display(Name = "Company")]
        public string Company { get; set; }
        [Display(Name = "Sign up password")]

        public string SignUpPassword { get; set; }
        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }
        public int Capacity { get; set; }              
        public string Address { get; set; }        
        public string City { get; set; }       
        public string State { get; set; }        
        public string Country { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }        
        public string Phone { get; set; }        
        public string Fax { get; set; }        
        public string Email { get; set; }        
        public string Website { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OpenDate { get; set; }

    }
}