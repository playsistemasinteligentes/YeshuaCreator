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
                    public interface IDocumentoFiscalOriginarioEntity
{
    int? Id { get; set; }
    int? DocumentoFiscalId { get; set; }
    string CorrelationId { get; set; }
    string SourceApplication { get; set; }
    string SourceModule { get; set; }
    string SourceMessageId { get; set; }
    string TipoDocumento { get; set; }
    string ChaveAcesso { get; set; }
    string Numero { get; set; }
    string Serie { get; set; }
    string EmitenteDocumento { get; set; }
    string DestinatarioDocumento { get; set; }
    Decimal? ValorDocumento { get; set; }
    Decimal? PesoBruto { get; set; }
    Decimal? Volume { get; set; }
    string SnapshotJson { get; set; }
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