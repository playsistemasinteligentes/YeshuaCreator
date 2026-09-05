// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface INFeProdutoSnapshotQueryRead 
    {
        public QueryModel NFeProdutoSnapshotQuery(Command.Read.NFeProdutoSnapshotReadCommand Command );
        public QueryModel NFeProdutoSnapshotDocumentoFiscalOriginarioIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel NFeProdutoSnapshotTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel NFeProdutoSnapshotUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByDocumentoFiscalOriginarioIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByCargaIdQuery(string value );
        public QueryModel ExistsByPedidoIdQuery(string value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsByEmitenteDocumentoQuery(string value );
        public QueryModel ExistsByDestinatarioDocumentoQuery(string value );
        public QueryModel ExistsByUFOrigemQuery(string value );
        public QueryModel ExistsByUFDestinoQuery(string value );
        public QueryModel ExistsByMunicipioOrigemCodigoIbgeQuery(string value );
        public QueryModel ExistsByMunicipioDestinoCodigoIbgeQuery(string value );
        public QueryModel ExistsByValorDocumentoQuery(Decimal value );
        public QueryModel ExistsByPesoBrutoQuery(Decimal value );
        public QueryModel ExistsByVolumeQuery(Decimal value );
        public QueryModel ExistsByXmlStorageKeyQuery(string value );
        public QueryModel ExistsBySnapshotJsonQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByDocumentoFiscalOriginarioIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByCargaIdQuery(string value );
        public QueryModel FirstByPedidoIdQuery(string value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstByEmitenteDocumentoQuery(string value );
        public QueryModel FirstByDestinatarioDocumentoQuery(string value );
        public QueryModel FirstByUFOrigemQuery(string value );
        public QueryModel FirstByUFDestinoQuery(string value );
        public QueryModel FirstByMunicipioOrigemCodigoIbgeQuery(string value );
        public QueryModel FirstByMunicipioDestinoCodigoIbgeQuery(string value );
        public QueryModel FirstByValorDocumentoQuery(Decimal value );
        public QueryModel FirstByPesoBrutoQuery(Decimal value );
        public QueryModel FirstByVolumeQuery(Decimal value );
        public QueryModel FirstByXmlStorageKeyQuery(string value );
        public QueryModel FirstBySnapshotJsonQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration