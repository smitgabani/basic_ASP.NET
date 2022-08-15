
using System;
using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.Models
{
    public class AlbumBaseViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Coordinator { get; set; } 

        [StringLength(30)]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; } 

        [StringLength(40)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Album cover art")]
        public string UrlAlbum { get; set; }
    }
}