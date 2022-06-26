

using S2022A2SAG.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class InvoiceLineBaseViewModel
    {
        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }

        public int TrackId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Track Track { get; set; }
    }
}