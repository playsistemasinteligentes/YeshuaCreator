// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class RevisaoRegistroSessaoEntity : IRevisaoRegistroSessaoEntity
{
    public int? Id { get; set; }
    public int SessaoId { get; set; }
    public int Versao { get; set; }
    public int AutorUserId { get; set; }
    public DateTime RevisadoEm { get; set; }
    public string? Motivo { get; set; }
    public string Registro { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal RevisaoRegistroSessaoEntity(int? id, int sessaoid, int versao, int autoruserid, DateTime revisadoem, string? motivo, string registro ){
 Id = id; 
 SessaoId = sessaoid; 
 Versao = versao; 
 AutorUserId = autoruserid; 
 RevisadoEm = (revisadoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : revisadoem; 
 Motivo = motivo; 
 Registro = registro; 
 Deleted = false; 
 Changed = DateTime.Now; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(RevisadoEm < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Revisado em deve ser informado.");
   if(string.IsNullOrEmpty(Registro))
   this._erroMensagem.Add("Registro revisado deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration