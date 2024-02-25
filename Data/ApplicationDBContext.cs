using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;

namespace WebAppMVC.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }
    }
}
