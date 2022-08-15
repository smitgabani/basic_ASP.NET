
using S2022A5SG.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S2022A5SG.Models
{
    public class AlbumAddViewModel 
    {
        [StringLength(40)]
        public string Coordinator { get; set; }

        [StringLength(30), Required]
        public string Genre { get; set; }

        [StringLength(40), Display(Name = "Album name"), Required]
        public string Name { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "URL to album image (cover art)"), Required]
        public string UrlAlbum { get; set; }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; } // 

        public IEnumerable<int> ArtistIds { get; set; }

        public IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<int> TrackIds { get; set; }

        public IEnumerable<Track> Tracks { get; set; }

        [Display(Name = "All Artists")]
        public MultiSelectList ArtistList { get; set; }

        [Display(Name = "All Tracks")]
        public MultiSelectList TrackList { get; set; }


        [Display(Name = "Album's Primary genre")]
        public SelectList AlbumGenreList { get; set; }

    }
}