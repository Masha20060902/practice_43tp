using Microsoft.EntityFrameworkCore;
namespace Task
{
    public class DocumentRepository
    {
        private readonly DocsContext _context;
        public DocumentRepository(DocsContext context)
        {
            _context = context;
        }
        public Task<List<DocumentEntity>> GetAllAsync()
            => _context.Documents
                       .Include(d => d.Versions)
                       .ToListAsync();
        public async System.Threading.Tasks.Task AddAsync(DocumentEntity document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task UpdateAsync(DocumentEntity document)
        {
            _context.Documents.Update(document);
            await _context.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteAsync(DocumentEntity document)
        {
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
        }
    }
}
