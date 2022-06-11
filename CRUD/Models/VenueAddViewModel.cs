using Assign1.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assign1.GetAllGetOne
{
    public class VenueAddViewModel
    {
        [Required]
        [StringLength(80)]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [StringLength(70)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(40)]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(60)]        
        public string Website { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Opening Date")]
        public DateTime? OpenDate { get; set; }
    }
}