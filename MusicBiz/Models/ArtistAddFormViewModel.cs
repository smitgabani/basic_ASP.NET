using S2022A5SG.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S2022A5SG.Models
{
    public class ArtistAddFormViewModel
    {
        public ArtistAddFormViewModel()
        {
            BirthOrStartDate = DateTime.Now;
            Albums = new List<Album>();
        }

        [Required, StringLength(50)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        [Display(Name = "If applicable, Artist Birth Name")]
        public string BirthName { get; set; }

        [Display(Name = "Birth date, or start date"), Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }

        public string Executive { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Artist's primary genre")]
        public SelectList ArtistGenreList { get; set; }

        [Required, Display(Name = "Artist Photo URL")]
        public string UrlArtist { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}