using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Atendimento
{
    public struct AtendimentoDTO
    {
    public int Id { get; set; }
    public int Status { get; set; }
    public DateTime UltimaInteracao { get; set; }
    }
}
