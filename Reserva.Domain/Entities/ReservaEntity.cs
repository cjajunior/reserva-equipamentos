using System;
using Reserva.Domain.Entities;

namespace Reserva.Domain.Entities
{
    public class ReservaEntity
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public DateTime DataReserva { get; set; }

        public int EquipamentoId { get; set; }
        public Equipamento? Equipamento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
