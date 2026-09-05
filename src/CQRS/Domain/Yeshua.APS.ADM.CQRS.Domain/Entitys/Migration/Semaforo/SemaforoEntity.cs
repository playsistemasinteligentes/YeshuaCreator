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
                    public partial class SemaforoEntity : ISemaforoEntity
{
    public int? Id { get; set; }
    public string SEM_ID { get; set; }
    public string SEM_STATUS { get; set; }
    public string SEM_ORIGEM { get; set; }
    public DateTime? SEM_EMISSAO { get; set; }
    public string SEM_ID_CONEXAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal SemaforoEntity(int? id, string sem_id, string sem_status, string sem_origem, DateTime? sem_emissao, string sem_id_conexao ){
 Id = id; 
 SEM_ID = sem_id; 
 SEM_STATUS = sem_status; 
 SEM_ORIGEM = sem_origem; 
 SEM_EMISSAO = (sem_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : sem_emissao; 
 SEM_ID_CONEXAO = sem_id_conexao; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(SEM_ID))
   this._erroMensagem.Add("SEM ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration