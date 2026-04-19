
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ySagaEntity : IySagaEntity
{
    public int? Id { get; set; }
    public string SagaId { get; set; }
    public string Type { get; set; }
    public int Status { get; set; }
    public string KeyCurrentStep { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string EntityType { get; set; }
    public string EntityId { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ySagaEntity(int? id, string sagaid, string type, int status, string keycurrentstep, DateTime createdat, DateTime? completedat, string entitytype, string entityid ){
 Id = id; 
 SagaId = sagaid; 
 Type = type; 
 Status = status; 
 KeyCurrentStep = keycurrentstep; 
 CreatedAt = (createdat < (new DateTime(1800, 1, 1))) ? DateTime.Now : createdat; 
 CompletedAt = (completedat < (new DateTime(1800, 1, 1))) ? DateTime.Now : completedat; 
 EntityType = entitytype; 
 EntityId = entityid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Type))
   this._erroMensagem.Add("Type deve ser informado.");
   if (Status == null)
   this._erroMensagem.Add("Status deve ser informado.");
   if (CreatedAt == null || CreatedAt < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado em deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration