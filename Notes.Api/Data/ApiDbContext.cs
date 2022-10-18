using Microsoft.EntityFrameworkCore;
using Notes.Api.Entity;

namespace Notes.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}
