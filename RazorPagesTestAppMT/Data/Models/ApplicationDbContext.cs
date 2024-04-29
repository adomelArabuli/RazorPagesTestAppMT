using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestAppMT.Data.Models.DbModels;

namespace RazorPagesTestAppMT.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
