using Microsoft.EntityFrameworkCore;

namespace FileMngt.Entities
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the contex
            base.OnConfiguring(optionsBuilder);
        }
        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model            
            modelBuilder.Entity<FileItems>().ToTable("FileItems");
        }
        public DbSet<FileItems> FileItems { get; set; }
    }
}
