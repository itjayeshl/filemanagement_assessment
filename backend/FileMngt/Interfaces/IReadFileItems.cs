using FileMngt.Entities;

namespace FileMngt.Interfaces
{
    public interface IReadFileItems
    {
        Task<IEnumerable<FileItems>> GetFiles();
        Task<FileItems> GetFileById(Guid fileitemid);
    }
}
