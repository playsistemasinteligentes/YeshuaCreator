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

    public interface INFeProdutoSnapshotQueryWrite 
     {
        public QueryModel InserirNFeProdutoSnapshotQuery(INFeProdutoSnapshotEntity NFeProdutoSnapshot);
        public QueryModel UpdateNFeProdutoSnapshotQuery(INFeProdutoSnapshotEntity NFeProdutoSnapshot);
        QueryModel UpdateDocumentoFiscalOriginarioId(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateCargaId(int id, string value);
        QueryModel UpdatePedidoId(int id, string value);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateDestinatarioDocumento(int id, string value);
        QueryModel UpdateUFOrigem(int id, string value);
        QueryModel UpdateUFDestino(int id, string value);
        QueryModel UpdateMunicipioOrigemCodigoIbge(int id, string value);
        QueryModel UpdateMunicipioDestinoCodigoIbge(int id, string value);
        QueryModel UpdateValorDocumento(int id, Decimal value);
        QueryModel UpdatePesoBruto(int id, Decimal value);
        QueryModel UpdateVolume(int id, Decimal value);
        QueryModel UpdateXmlStorageKey(int id, string value);
        QueryModel UpdateSnapshotJson(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteNFeProdutoSnapshotQuery(INFeProdutoSnapshotEntity NFeProdutoSnapshot);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration