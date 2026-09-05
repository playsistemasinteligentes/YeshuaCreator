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

    public interface ICTeDocumentoOriginarioQueryWrite 
     {
        public QueryModel InserirCTeDocumentoOriginarioQuery(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario);
        public QueryModel UpdateCTeDocumentoOriginarioQuery(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario);
        QueryModel UpdateCTeSolicitacaoFiscalId(int id, int value);
        QueryModel UpdateDocumentoFiscalOriginarioId(int id, int value);
        QueryModel UpdateTipoDocumento(int id, string value);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateNumero(int id, string value);
        QueryModel UpdateSerie(int id, string value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateDestinatarioDocumento(int id, string value);
        QueryModel UpdateValorDocumento(int id, Decimal value);
        QueryModel UpdatePesoBruto(int id, Decimal value);
        QueryModel UpdateSnapshotJson(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCTeDocumentoOriginarioQuery(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration