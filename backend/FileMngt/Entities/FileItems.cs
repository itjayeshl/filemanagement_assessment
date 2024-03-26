using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileMngt.Entities
{
    public class FileItems
    {
        [Key]        
        public Guid FileItemID { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string FileName { get; set; }
        [Column(TypeName = "char(5)")]
        public string FileType { get; set; }
        public string? FileData { get; set; }
        public DateTime? Created { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? LastModifiedBy { get; set; }
    }
}
