// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IDocumentoFiscalOriginarioQueryWrite 
     {
        public QueryModel InserirDocumentoFiscalOriginarioQuery(IDocumentoFiscalOriginarioEntity DocumentoFiscalOriginario);
        public QueryModel UpdateDocumentoFiscalOriginarioQuery(IDocumentoFiscalOriginarioEntity DocumentoFiscalOriginario);
        QueryModel UpdateDocumentoFiscalId(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateSourceApplication(int id, string value);
        QueryModel UpdateSourceModule(int id, string value);
        QueryModel UpdateSourceMessageId(int id, string value);
        QueryModel UpdateTipoDocumento(int id, string value);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateNumero(int id, string value);
        QueryModel UpdateSerie(int id, string value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateDestinatarioDocumento(int id, string value);
        QueryModel UpdateValorDocumento(int id, Decimal value);
        QueryModel UpdatePesoBruto(int id, Decimal value);
        QueryModel UpdateVolume(int id, Decimal value);
        QueryModel UpdateSnapshotJson(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteDocumentoFiscalOriginarioQuery(IDocumentoFiscalOriginarioEntity DocumentoFiscalOriginario);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration