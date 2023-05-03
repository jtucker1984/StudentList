using Microsoft.EntityFrameworkCore;
using StudentList.Models.Domain;

namespace StudentList.Data
{
    public class MvcDemoDbContext : DbContext
    {
        public MvcDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
