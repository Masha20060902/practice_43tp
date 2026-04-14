using DocumentVersion.Model;
using Microsoft.EntityFrameworkCore;
namespace DocumentVersion.Data
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
        public async Task AddAsync(DocumentEntity document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(DocumentEntity document)
        {
            _context.Documents.Update(document);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(DocumentEntity document)
        {
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
        }
    }
}
