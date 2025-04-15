using Microsoft.EntityFrameworkCore;
using Reserva.Domain.Entities;
using Reserva.Infrastructure.Data;


namespace Reserva.Infrastructure;

 public class ReservaService
{
    private readonly AppDbContext _context;

    public ReservaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReservaEntity>> ListarAsync()
    {
        return await _context.Reservas
            .Include(r => r.Equipamento)
            .OrderByDescending(r => r.DataReserva)
            .ToListAsync();
    }

    public async Task AdicionarAsync(ReservaEntity reserva)
{
    _context.Reservas.Add(reserva);
    await _context.SaveChangesAsync();
}


    public async Task RemoverAsync(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva is not null)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
    
}