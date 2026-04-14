namespace DocumentVersion.Model
{
    public class DocumentEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        public ICollection<VersionEntity> Versions { get; set; } = new List<VersionEntity>();
    }
}
