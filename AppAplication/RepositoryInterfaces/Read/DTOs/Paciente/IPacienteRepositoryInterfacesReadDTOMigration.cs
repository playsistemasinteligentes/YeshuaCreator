using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Paciente
{
    public struct PacienteDTO
    {
    public int Id { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeReduzido { get; set; }
    }
}
