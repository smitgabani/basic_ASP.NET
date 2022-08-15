
using System.ComponentModel.DataAnnotations;

namespace S2022A5SG.EntityModels
{
    public class Genre
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }
    }
}