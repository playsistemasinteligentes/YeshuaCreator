
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ClinicaEntity : IClinicaEntity
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    private List<string> _erroMensagem = null;
 internal ClinicaEntity(int? id, string nome, string endereco, string telefone ){
 Id = id; 
 Nome = nome; 
 Endereco = endereco; 
 Telefone = telefone; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome da Clínica deve ser informado.");
   if(string.IsNullOrEmpty(Endereco))
   this._erroMensagem.Add("Endereço da Clínica deve ser informado.");
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