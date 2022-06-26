
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class InvoiceLineWithDetailViewModel : InvoiceLineBaseViewModel
    {

        [Required]
        [StringLength(200)]
        public string TrackName { get; set; }

        [StringLength(220)]
        public string TrackComposer { get; set; }

        [Required]
        [StringLength(160)]
        public string TrackAlbumTitle { get; set; }

        [StringLength(120)]
        public string TrackAlbumArtistName { get; set; }

        [StringLength(120)]
        public string TrackMediaTypeName { get; set; }

    }
}