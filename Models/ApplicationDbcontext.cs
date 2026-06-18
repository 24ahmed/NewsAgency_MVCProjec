using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace News_Project.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
 

    }
}
