using FileMngt.Controllers;
using FileMngt.Entities;
using FileMngt.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileMngt.Services
{    
    public class FileUploadLocalService : IFileUploadService
    {
        private readonly ApplicationDBContext _dbContext;
        public FileUploadLocalService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
           
        }
        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    
                    _dbContext.FileItems.Add(new FileItems() { FileName = file.FileName ,FileType=file.ContentType,CreatedBy="User"});
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
        
    }
}
