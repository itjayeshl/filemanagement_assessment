using FileMngt.Entities;
using FileMngt.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileMngt.Services
{
    public class ReadFileItems :IReadFileItems
    {
        private readonly ApplicationDBContext _dbContext;
        public ReadFileItems(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<FileItems>> GetFiles()
        {
            return await _dbContext.FileItems.ToListAsync();
        }
        public async Task<FileItems> GetFileById(Guid fileitemid)
        {
            return await _dbContext.FileItems.FindAsync(fileitemid);
        }
    }
}
