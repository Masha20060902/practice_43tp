using System.ComponentModel.DataAnnotations;

namespace PetTracker.Models
{
    public class PetViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
