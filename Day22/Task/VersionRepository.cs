using Microsoft.EntityFrameworkCore;
namespace Task
{
    public class VersionRepository
    {

        private readonly DocsContext _context;

        public VersionRepository(DocsContext context)
        {
            _context = context;
        }
        public Task<List<VersionEntity>> GetAllAsync()
            => _context.Versions.ToListAsync();

        public async System.Threading.Tasks.Task AddAsync(VersionEntity version)
        {
            await _context.Versions.AddAsync(version);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(VersionEntity version)
        {
            _context.Versions.Update(version);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(VersionEntity version)
        {
            _context.Versions.Remove(version);
            await _context.SaveChangesAsync();
        }
    }
}