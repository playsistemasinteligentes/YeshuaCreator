using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Agendamentos
{
    public struct AgendamentosDTO
    {
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public int ProfissionalId { get; set; }
    public int ServicoId { get; set; }
    public DateTime DataHora { get; set; }
    public string Status { get; set; }
    }
}
