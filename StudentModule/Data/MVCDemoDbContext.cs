using Microsoft.EntityFrameworkCore;
using StudentModule.Models.Domain;

namespace StudentModule.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        //Create Property
        public DbSet<Student> Students { get; set; }
    }
}
