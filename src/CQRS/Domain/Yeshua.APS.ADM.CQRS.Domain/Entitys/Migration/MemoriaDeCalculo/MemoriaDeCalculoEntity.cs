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
                    public partial class MemoriaDeCalculoEntity : IMemoriaDeCalculoEntity
{
    public int? Id { get; set; }
    public int MEM_ID { get; set; }
    public int? ORC_ID { get; set; }
    public Decimal? MEM_VALOR { get; set; }
    public string MEM_DESCRICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MemoriaDeCalculoEntity(int? id, int mem_id, int? orc_id, Decimal? mem_valor, string mem_descricao ){
 Id = id; 
 MEM_ID = mem_id; 
 ORC_ID = orc_id; 
 MEM_VALOR = mem_valor; 
 MEM_DESCRICAO = mem_descricao; 
 Deleted = false; 
 Changed = DateTime.Now; 
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