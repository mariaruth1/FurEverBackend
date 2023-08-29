using FurEver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurEver.Infrastructure;

public class AppDbContext : IdentityDbContext<Furry, IdentityRole<Guid>, Guid>
{
    public DbSet<Gender> Genders { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
}