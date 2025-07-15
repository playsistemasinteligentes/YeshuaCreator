
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_TenantEntity : IY_TenantEntity
{
    public int? Id { get; set; }
    public int CnpjCpf { get; set; }
    public string Nome { get; set; }
    public int? UserIDAdmin { get; set; }
    private List<string> _erroMensagem = null;
 internal Y_TenantEntity(int? id, int cnpjcpf, string nome, int? useridadmin ){
 Id = id; 
 CnpjCpf = cnpjcpf; 
 Nome = nome; 
 UserIDAdmin = useridadmin; 
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