
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class PlanoContaEntity : IPlanoContaEntity
{
    public int? Id { get; set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public int Tipo { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal PlanoContaEntity(int? id, string codigo, string nome, int tipo ){
 Id = id; 
 Codigo = codigo; 
 Nome = nome; 
 Tipo = tipo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Codigo))
   this._erroMensagem.Add("Código da Conta deve ser informado.");
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome da Conta deve ser informado.");
   if (Tipo == null)
   this._erroMensagem.Add("Tipo da Conta deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration