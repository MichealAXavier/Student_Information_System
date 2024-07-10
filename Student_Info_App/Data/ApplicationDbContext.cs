using Microsoft.EntityFrameworkCore;
using Student_Info_App.Models;

namespace Student_Info_App.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students {  get; set; }

    }
}
