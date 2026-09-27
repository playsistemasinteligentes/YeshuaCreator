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
                    public partial class LogsEntity : ILogsEntity
{
    public int? Id { get; set; }
    public string? LOG_CHAVE { get; set; }
    public string? LOG_CONTEXTO { get; set; }
    public string? LOG_CONTEUDO { get; set; }
    public int LOG_ID { get; set; }
    public DateTime? LOG_EMISSAO { get; set; }
    public string OperationalEntityId { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal LogsEntity(int? id, string? log_chave, string? log_contexto, string? log_conteudo, int log_id, DateTime? log_emissao ){
 Id = id; 
 LOG_CHAVE = log_chave; 
 LOG_CONTEXTO = log_contexto; 
 LOG_CONTEUDO = log_conteudo; 
 LOG_ID = log_id; 
 LOG_EMISSAO = log_emissao.HasValue && log_emissao.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : log_emissao; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
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