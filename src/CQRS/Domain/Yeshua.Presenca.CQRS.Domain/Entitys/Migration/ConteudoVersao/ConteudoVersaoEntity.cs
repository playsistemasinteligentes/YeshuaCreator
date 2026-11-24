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
                    public partial class ConteudoVersaoEntity : IConteudoVersaoEntity
{
    public string? Id { get; set; }
    public string? IdentidadeId { get; set; }
    public string? PautaId { get; set; }
    public int? Numero { get; set; }
    public string? Hash { get; set; }
    public string? Estado { get; set; }
    public string? Snapshot { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal ConteudoVersaoEntity(string? id, string? identidadeid, string? pautaid, int? numero, string? hash, string? estado, string? snapshot ){
 Id = id; 
 IdentidadeId = identidadeid; 
 PautaId = pautaid; 
 Numero = numero; 
 Hash = hash; 
 Estado = estado; 
 Snapshot = snapshot; 
 Deleted = false; 
 Changed = DateTime.Now; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration