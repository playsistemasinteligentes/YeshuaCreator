using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Profissional
{
    public struct ProfissionalDTO
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int EspecialidadeId { get; set; }
    public string Telefone { get; set; }
    }
}
