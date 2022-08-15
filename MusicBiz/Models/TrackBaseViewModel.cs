using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.Models
{
    public class TrackBaseViewModel
    {        
        [Key]
        public int Id{ get; set; }

        [StringLength(40)]
        [Display(Name = "Clerk who helps with album tasks")]
        public string Clerk { get; set; } 

        [Display(Name = "Composer name (comma-separated)")]
        public string Composers { get; set; } 

        [StringLength(30)]
        [Display(Name = "Track genre")]
        public string Genre { get; set; } 

        [Required, StringLength(60), Display(Name = "Track name")]
        public string Name { get; set; }

        public int AlbumId;
    }
}