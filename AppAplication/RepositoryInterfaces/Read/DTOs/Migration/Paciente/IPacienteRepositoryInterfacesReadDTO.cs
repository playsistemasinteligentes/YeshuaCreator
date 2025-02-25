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
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Genero { get; set; }
    public string Escolaridade { get; set; }
    public string Profissao { get; set; }
    public string Endereco { get; set; }
    public string NomeResponsavel { get; set; }
    public string TelefoneResponsavel { get; set; }
    public string PrincipaisQueixas { get; set; }
    public string ObservacaoAdicional { get; set; }
    }
}
