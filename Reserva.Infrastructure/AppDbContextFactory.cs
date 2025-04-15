using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Reserva.Infrastructure.Data;

namespace Reserva.Infrastructure
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS02;Database=ReservaDb;Trusted_Connection=True;Encrypt=False");


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}   
