
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YtenantEntity : IYtenantEntity
{
    public int? Id { get; set; }
    public int CnpjCpf { get; set; }
    public string Nome { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal YtenantEntity(int? id, int cnpjcpf, string nome, int? userid ){
 Id = id; 
 CnpjCpf = cnpjcpf; 
 Nome = nome; 
 UserId = userid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (CnpjCpf == null)
   this._erroMensagem.Add("Cnpj/Cpf deve ser informado.");
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration