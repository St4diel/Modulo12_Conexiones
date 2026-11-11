using Microsoft.EntityFrameworkCore;

namespace M12_NotaseF
{
    public class NotasDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=notas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>( e => 
            {
                e.Property( x => x.Nombre).HasMaxLength(50).IsRequired();
                e.Property( x => x.Ciudad).HasMaxLength(30);
            });
        }
    }
}