
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ServicoEntity : IServicoEntity
{
    public int? Id { get; set; }
    public int? GrupoServicoId { get; set; }
    public string Nome { get; set; }
    public Decimal Valor { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ServicoEntity(int? id, int? gruposervicoid, string nome, Decimal valor ){
 Id = id; 
 GrupoServicoId = gruposervicoid; 
 Nome = nome; 
 Valor = valor; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome do Serviço deve ser informado.");
   if (Valor == null)
   this._erroMensagem.Add("Valor do Serviço deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration