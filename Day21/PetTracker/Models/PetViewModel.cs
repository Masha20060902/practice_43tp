using System.ComponentModel.DataAnnotations;

namespace PetTracker.Models
{
    public class PetViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string? Notes { get; set; }
    }
}
