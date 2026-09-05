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
    public interface IDocumentoFiscalQueryRead 
    {
        public QueryModel DocumentoFiscalQuery(Command.Read.DocumentoFiscalReadCommand Command );
        public QueryModel DocumentoFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel DocumentoFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByProdutoFiscalQuery(int value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsBySerieQuery(int value );
        public QueryModel ExistsByNumeroQuery(int value );
        public QueryModel ExistsByAmbienteQuery(int value );
        public QueryModel ExistsByUFEmitenteQuery(string value );
        public QueryModel ExistsByEmitenteDocumentoQuery(string value );
        public QueryModel ExistsByDestinatarioDocumentoQuery(string value );
        public QueryModel ExistsByXmlStorageKeyQuery(string value );
        public QueryModel ExistsByXmlHashQuery(string value );
        public QueryModel ExistsByProtocoloAutorizacaoQuery(string value );
        public QueryModel ExistsByCodigoRetornoQuery(string value );
        public QueryModel ExistsByMensagemRetornoQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByProdutoFiscalQuery(int value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstBySerieQuery(int value );
        public QueryModel FirstByNumeroQuery(int value );
        public QueryModel FirstByAmbienteQuery(int value );
        public QueryModel FirstByUFEmitenteQuery(string value );
        public QueryModel FirstByEmitenteDocumentoQuery(string value );
        public QueryModel FirstByDestinatarioDocumentoQuery(string value );
        public QueryModel FirstByXmlStorageKeyQuery(string value );
        public QueryModel FirstByXmlHashQuery(string value );
        public QueryModel FirstByProtocoloAutorizacaoQuery(string value );
        public QueryModel FirstByCodigoRetornoQuery(string value );
        public QueryModel FirstByMensagemRetornoQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration