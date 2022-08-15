using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.Models
{
    public class GenreBaseViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
    }
}