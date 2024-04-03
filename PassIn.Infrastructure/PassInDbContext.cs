using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;
public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\dev\\C#\\RocketSeat\\NLW-Unite\\PassInDb.db");
    }    
    
}
