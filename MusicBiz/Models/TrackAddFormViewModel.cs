using S2022A5SG.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace S2022A5SG.Models
{
    public class TrackAddFormViewModel
    {
        public TrackAddFormViewModel()
        {
            Albums = new List<Album>();
        }

        [StringLength(40)]
        public string Clerk { get; set; }

        [StringLength(50), Display(Name = "Composer name (comma-separated)"), Required]
        public string Composers { get; set; }

        [StringLength(30)]
        public string Genre { get; set; }

        [Required, StringLength(40), Display(Name = "Track name")]
        public string Name { get; set; }

        [Display(Name = "Track genre")]
        public SelectList TrackGenreList { get; set; }

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }

        public IEnumerable<Album> Albums { get; set; }

        [Required]
        [Display(Name = "Track audio"), DataType(DataType.Upload)]
        public HttpPostedFileBase AudioUpload { get; set; }
    }
}