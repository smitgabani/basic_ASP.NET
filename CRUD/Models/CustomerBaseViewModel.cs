using Assign1.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assign1.GetAllGetOne
{
    public class CustomerBaseViewModel: CustomerAddViewModel
    {

        [Key]
        public int CustomerId { get; set; }            
    }
}