
using S2022A5SG.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.Models
{
    public class ArtistWithDetailViewModel : ArtistBaseViewModel
    {
        public ArtistWithDetailViewModel()
        {
            Albums = new List<Album>();
            AlbumNames = new List<string>();
            BirthOrStartDate = DateTime.Now;
        }

        public IEnumerable<Album> Albums { get; set; }

        public string ArtistName { get; set; }

        public IEnumerable<string> AlbumNames { get; set; }

    }
}