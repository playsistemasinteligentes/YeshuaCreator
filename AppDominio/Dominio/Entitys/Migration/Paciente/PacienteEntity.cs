
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Paciente
                {
                    public partial class PacienteEntity
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
 public PacienteEntity(int id, string nome, string telefone, DateTime datanascimento, int genero, string escolaridade, string profissao, string endereco, string nomeresponsavel, string telefoneresponsavel, string principaisqueixas, string observacaoadicional ){
 Id = id; 
 Nome = nome; 
 Telefone = telefone; 
 DataNascimento = datanascimento; 
 Genero = genero; 
 Escolaridade = escolaridade; 
 Profissao = profissao; 
 Endereco = endereco; 
 NomeResponsavel = nomeresponsavel; 
 TelefoneResponsavel = telefoneresponsavel; 
 PrincipaisQueixas = principaisqueixas; 
 ObservacaoAdicional = observacaoadicional; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }