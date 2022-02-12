using LecCRUDRelatedData01.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LecCRUDRelatedData01.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();
    public DbSet<Recommendation> Recommendations => Set<Recommendation>();
}

