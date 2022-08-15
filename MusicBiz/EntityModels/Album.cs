using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.EntityModels
{
    public class Album
    {
        public Album()
        {
            ReleaseDate = DateTime.Now;
            Artists = new List<Artist>();
            Tracks = new List<Track>();
        }

        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Coordinator { get; set; }

        [Required, StringLength(200)]
        public string Genre { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string UrlAlbum { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}