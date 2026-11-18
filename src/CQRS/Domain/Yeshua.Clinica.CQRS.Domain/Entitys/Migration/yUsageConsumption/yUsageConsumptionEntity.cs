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
                    public partial class yUsageConsumptionEntity : IyUsageConsumptionEntity
{
    public string? Id { get; set; }
    public string ResourceKey { get; set; }
    public string OperationId { get; set; }
    public Decimal Units { get; set; }
    public bool UsesPeriod { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal yUsageConsumptionEntity(string? id, string resourcekey, string operationid, Decimal units, bool usesperiod, int status ){
 Id = id;
 ResourceKey = resourcekey;
 OperationId = operationid;
 Units = units;
 UsesPeriod = usesperiod;
 Status = status;
 Deleted = false;
 Changed = DateTime.Now;
 OperationalEntityId = Guid.NewGuid().ToString("N");
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(ResourceKey))
   this._erroMensagem.Add("Recurso deve ser informado.");
   if(string.IsNullOrEmpty(OperationId))
   this._erroMensagem.Add("Operacao deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration