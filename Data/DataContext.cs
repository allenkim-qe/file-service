using file_service.Models;
using Microsoft.EntityFrameworkCore;

namespace file_service.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }  
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}