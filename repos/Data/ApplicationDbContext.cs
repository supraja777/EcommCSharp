using Microsoft.EntityFrameworkCore;
using repos.Models;
namespace repos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }

        public DbSet<Category> Categories { get; set; }
    }
}