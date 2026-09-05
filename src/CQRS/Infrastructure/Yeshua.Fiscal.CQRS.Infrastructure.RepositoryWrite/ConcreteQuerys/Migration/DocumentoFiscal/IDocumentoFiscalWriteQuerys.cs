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

    public interface IDocumentoFiscalQueryWrite 
     {
        public QueryModel InserirDocumentoFiscalQuery(IDocumentoFiscalEntity DocumentoFiscal);
        public QueryModel UpdateDocumentoFiscalQuery(IDocumentoFiscalEntity DocumentoFiscal);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateProdutoFiscal(int id, int value);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateSerie(int id, int value);
        QueryModel UpdateNumero(int id, int value);
        QueryModel UpdateAmbiente(int id, int value);
        QueryModel UpdateUFEmitente(int id, string value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateDestinatarioDocumento(int id, string value);
        QueryModel UpdateXmlStorageKey(int id, string value);
        QueryModel UpdateXmlHash(int id, string value);
        QueryModel UpdateProtocoloAutorizacao(int id, string value);
        QueryModel UpdateCodigoRetorno(int id, string value);
        QueryModel UpdateMensagemRetorno(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteDocumentoFiscalQuery(IDocumentoFiscalEntity DocumentoFiscal);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration