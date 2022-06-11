using Assign1.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assign1.GetAllGetOne
{
    public class CustomerEditContactViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        [Required]
        [StringLength(60)]
        public string Email { get; set; }
    }
}