using Microsoft.EntityFrameworkCore;
using Reserva.Domain.Entities;


namespace Reserva.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReservaEntity> Reservas => Set<ReservaEntity>();
        public DbSet<Equipamento> Equipamentos => Set<Equipamento>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipamento>().ToTable("Equipamentos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<ReservaEntity>().ToTable("Reservas");

            modelBuilder.Entity<ReservaEntity>()
                .HasOne(r => r.Equipamento)
                .WithMany()
                .HasForeignKey(r => r.EquipamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReservaEntity>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasData(
    new Usuario { Id = 1, Nome = "Administrador" }
);

        }
    }
}
