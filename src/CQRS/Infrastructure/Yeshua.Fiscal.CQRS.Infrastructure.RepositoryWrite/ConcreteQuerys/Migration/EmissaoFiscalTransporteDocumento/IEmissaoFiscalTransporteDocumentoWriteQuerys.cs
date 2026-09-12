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

    public interface IEmissaoFiscalTransporteDocumentoQueryWrite 
     {
        public QueryModel InserirEmissaoFiscalTransporteDocumentoQuery(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento);
        public QueryModel UpdateEmissaoFiscalTransporteDocumentoQuery(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento);
        QueryModel UpdateEmissaoFiscalTransporteId(int id, int value);
        QueryModel UpdateDocumentoFiscalId(int id, int value);
        QueryModel UpdateDocumentoFiscalOriginarioId(int id, int value);
        QueryModel UpdateNFeProdutoSnapshotId(int id, int value);
        QueryModel UpdateProdutoFiscal(int id, int value);
        QueryModel UpdatePapel(int id, int value);
        QueryModel UpdateTipoEvento(int id, string value);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateXmlStorageKey(int id, string value);
        QueryModel UpdatePdfStorageKey(int id, string value);
        QueryModel UpdateProtocolo(int id, string value);
        QueryModel UpdateCodigoRetorno(int id, string value);
        QueryModel UpdateMensagemRetorno(int id, string value);
        QueryModel UpdateCriadoEmUtc(int id, DateTime value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteEmissaoFiscalTransporteDocumentoQuery(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration