using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure
{
    public class PassInDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\karo1\\OneDrive\\Documentos\\NLW\\NLW-_UNITE\\PassInDb.db");
        }
    }
}
