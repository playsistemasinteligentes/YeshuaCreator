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
                    public interface ICTeEntradaOficialEntity
{
    int? Id { get; set; }
    string CorrelationId { get; set; }
    string SourceApplication { get; set; }
    string SourceModule { get; set; }
    string SourceMessageId { get; set; }
    string MessageType { get; set; }
    string MessageVersion { get; set; }
    DateTime ReceivedAtUtc { get; set; }
    string PayloadHash { get; set; }
    string PayloadStorageKey { get; set; }
    int Status { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration