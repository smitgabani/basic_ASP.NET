using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.EntityModels
{
    public class Artist
    {
        public Artist()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
            Albums = new List<Album>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string BirthName { get; set; }

        [Required, StringLength(200)]
        public string Executive { get; set; }

        [Required, StringLength(200)]
        public string Genre { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string UrlArtist { get; set; }

        public DateTime BirthOrStartDate { get; set; }

        public ICollection<Album> Albums { get; set; }    
    }
}