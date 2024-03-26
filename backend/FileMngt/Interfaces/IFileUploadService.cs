using FileMngt.Entities;

namespace FileMngt.Interfaces
{
    public interface IFileUploadService
    {
        Task<bool> UploadFile(IFormFile file);
        
    }
}
