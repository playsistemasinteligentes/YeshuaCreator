using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.DisponibilidadeAgenda
{
    public struct DisponibilidadeAgendaDTO
    {
    public int Id { get; set; }
    public int ProfissionalId { get; set; }
    public DateTime DataHora { get; set; }
    }
}
