using Reserva.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Reserva.Infrastructure.Data;

namespace Reserva.Infrastructure
{

    public class EquipamentoService
    {
        private readonly AppDbContext _context;

        public EquipamentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipamento>> ListarAsync()
        {
            return await _context.Equipamentos.ToListAsync();
        }

       public async Task<bool> RemoverAsync(int id)
{
    // Verifica se o equipamento está vinculado a alguma reserva
    bool temReservas = await _context.Reservas.AnyAsync(r => r.EquipamentoId == id);

    if (temReservas)
        throw new Exception("Este equipamento está associado a uma ou mais reservas e não pode ser removido.");

    var equipamento = await _context.Equipamentos.FindAsync(id);
    if (equipamento == null)
        return false;

    _context.Equipamentos.Remove(equipamento);
    await _context.SaveChangesAsync();
    return true;
}
       public async Task AdicionarAsync(Equipamento equipamento)
{
    _context.Equipamentos.Add(equipamento);
    await _context.SaveChangesAsync();
}
public async Task AtualizarAsync(Equipamento equipamento)
{
    var equipamentoExistente = await _context.Equipamentos.FindAsync(equipamento.Id);

    if (equipamentoExistente is null)
        throw new Exception("Equipamento não encontrado");

    equipamentoExistente.Nome = equipamento.Nome;
    equipamentoExistente.Tipo = equipamento.Tipo;
    equipamentoExistente.Disponivel = equipamento.Disponivel;

    await _context.SaveChangesAsync();
}
public async Task<List<Equipamento>> ListarDisponiveisAsync()
{
    return await _context.Equipamentos
        .Where(e => e.Disponivel)
        .ToListAsync();
}




    }

}
