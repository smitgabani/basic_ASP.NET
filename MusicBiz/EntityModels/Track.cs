using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.EntityModels
{
    public class Track
    { 
        public Track() {
            Albums = new List<Album>();
        }
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Clerk { get; set; }

        [Required, StringLength(200)]
        public string Composers { get; set; }

        [Required, StringLength(200)]
        public string Genre { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }        

        public ICollection<Album> Albums { get; set; }

    }
}