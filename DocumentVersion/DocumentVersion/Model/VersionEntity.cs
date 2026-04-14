using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentVersion.Model
{
    public class VersionEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public DocumentEntity Document { get; set; }
        public int VersionNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        [NotMapped]
        public bool IsCurrent { get; set; }
    }
}
