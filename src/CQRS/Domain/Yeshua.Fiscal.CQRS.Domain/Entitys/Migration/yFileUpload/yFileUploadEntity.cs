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
                    public partial class yFileUploadEntity : IyFileUploadEntity
{
    public int? Id { get; set; }
    public string Type { get; set; }
    public int Status { get; set; }
    public string FilePath { get; set; }
    public long? FileSize { get; set; }
    public string EntityType { get; set; }
    public string EntityId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal yFileUploadEntity(int? id, string type, int status, string filepath, long? filesize, string entitytype, string entityid, DateTime createdat, DateTime? completedat ){
 Id = id; 
 Type = type; 
 Status = status; 
 FilePath = filepath; 
 FileSize = filesize; 
 EntityType = entitytype; 
 EntityId = entityid; 
 CreatedAt = (createdat < (new DateTime(1800, 1, 1))) ? DateTime.Now : createdat; 
 CompletedAt = (completedat < (new DateTime(1800, 1, 1))) ? DateTime.Now : completedat; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Type))
   this._erroMensagem.Add("Tipo do Arquivo deve ser informado.");
   if(CreatedAt == null || CreatedAt < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado em deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration