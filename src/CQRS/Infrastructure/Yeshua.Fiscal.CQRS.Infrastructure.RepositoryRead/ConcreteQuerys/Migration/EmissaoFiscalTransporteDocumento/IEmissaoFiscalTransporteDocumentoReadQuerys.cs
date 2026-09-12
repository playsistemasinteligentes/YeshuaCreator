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
    public interface IEmissaoFiscalTransporteDocumentoQueryRead 
    {
        public QueryModel EmissaoFiscalTransporteDocumentoQuery(Command.Read.EmissaoFiscalTransporteDocumentoReadCommand Command );
        public QueryModel EmissaoFiscalTransporteDocumentoEmissaoFiscalTransporteIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EmissaoFiscalTransporteDocumentoDocumentoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EmissaoFiscalTransporteDocumentoDocumentoFiscalOriginarioIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EmissaoFiscalTransporteDocumentoNFeProdutoSnapshotIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EmissaoFiscalTransporteDocumentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EmissaoFiscalTransporteDocumentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByEmissaoFiscalTransporteIdQuery(int value );
        public QueryModel ExistsByDocumentoFiscalIdQuery(int value );
        public QueryModel ExistsByDocumentoFiscalOriginarioIdQuery(int value );
        public QueryModel ExistsByNFeProdutoSnapshotIdQuery(int value );
        public QueryModel ExistsByProdutoFiscalQuery(int value );
        public QueryModel ExistsByPapelQuery(int value );
        public QueryModel ExistsByTipoEventoQuery(string value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsByXmlStorageKeyQuery(string value );
        public QueryModel ExistsByPdfStorageKeyQuery(string value );
        public QueryModel ExistsByProtocoloQuery(string value );
        public QueryModel ExistsByCodigoRetornoQuery(string value );
        public QueryModel ExistsByMensagemRetornoQuery(string value );
        public QueryModel ExistsByCriadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByEmissaoFiscalTransporteIdQuery(int value );
        public QueryModel FirstByDocumentoFiscalIdQuery(int value );
        public QueryModel FirstByDocumentoFiscalOriginarioIdQuery(int value );
        public QueryModel FirstByNFeProdutoSnapshotIdQuery(int value );
        public QueryModel FirstByProdutoFiscalQuery(int value );
        public QueryModel FirstByPapelQuery(int value );
        public QueryModel FirstByTipoEventoQuery(string value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstByXmlStorageKeyQuery(string value );
        public QueryModel FirstByPdfStorageKeyQuery(string value );
        public QueryModel FirstByProtocoloQuery(string value );
        public QueryModel FirstByCodigoRetornoQuery(string value );
        public QueryModel FirstByMensagemRetornoQuery(string value );
        public QueryModel FirstByCriadoEmUtcQuery(DateTime value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration