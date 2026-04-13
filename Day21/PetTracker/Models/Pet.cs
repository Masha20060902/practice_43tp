namespace PetTracker.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime Birthday { get; set; }
        public string? Notes { get; set; }
    }
}
