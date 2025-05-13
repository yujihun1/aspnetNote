using aspnetNote.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetNote.DataContext
{
    public class AspnetNoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=QUESTHOUSE\SQLEXPRESS01;Database=aspnetNoteDb;User Id=sa;Password=sa1234;TrustServerCertificate=True;");
        }
    }
}
