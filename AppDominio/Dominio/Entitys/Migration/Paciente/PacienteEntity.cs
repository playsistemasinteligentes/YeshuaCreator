
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class PacienteEntity : IPacienteEntity
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime? DataNascimento { get; set; }
    public int? Genero { get; set; }
    public string Escolaridade { get; set; }
    public string Profissao { get; set; }
    public string Endereco { get; set; }
    public string NomeResponsavel { get; set; }
    public string TelefoneResponsavel { get; set; }
    public string PrincipaisQueixas { get; set; }
    public string ObservacaoAdicional { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal PacienteEntity(int? id, string nome, string telefone, DateTime? datanascimento, int? genero, string escolaridade, string profissao, string endereco, string nomeresponsavel, string telefoneresponsavel, string principaisqueixas, string observacaoadicional ){
 Id = id; 
 Nome = nome; 
 Telefone = telefone; 
 DataNascimento = (datanascimento < (new DateTime(1800, 1, 1))) ? DateTime.Now : datanascimento; 
 Genero = genero; 
 Escolaridade = escolaridade; 
 Profissao = profissao; 
 Endereco = endereco; 
 NomeResponsavel = nomeresponsavel; 
 TelefoneResponsavel = telefoneresponsavel; 
 PrincipaisQueixas = principaisqueixas; 
 ObservacaoAdicional = observacaoadicional; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome do Paciente deve ser informado.");
   if(string.IsNullOrEmpty(Telefone))
   this._erroMensagem.Add("Telefone de Contato deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration