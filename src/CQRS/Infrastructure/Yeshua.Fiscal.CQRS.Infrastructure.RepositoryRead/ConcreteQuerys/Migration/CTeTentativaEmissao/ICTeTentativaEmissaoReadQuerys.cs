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
    public interface ICTeTentativaEmissaoQueryRead 
    {
        public QueryModel CTeTentativaEmissaoQuery(Command.Read.CTeTentativaEmissaoReadCommand Command );
        public QueryModel CTeTentativaEmissaoCTeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeTentativaEmissaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeTentativaEmissaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsByNumeroQuery(int value );
        public QueryModel ExistsBySerieQuery(int value );
        public QueryModel ExistsByTentativaQuery(int value );
        public QueryModel ExistsByXmlAssinadoStorageKeyQuery(string value );
        public QueryModel ExistsByXmlProcStorageKeyQuery(string value );
        public QueryModel ExistsByXmlHashQuery(string value );
        public QueryModel ExistsByCodigoRetornoQuery(string value );
        public QueryModel ExistsByMensagemRetornoQuery(string value );
        public QueryModel ExistsByProtocoloAutorizacaoQuery(string value );
        public QueryModel ExistsByEnviadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByAutorizadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstByNumeroQuery(int value );
        public QueryModel FirstBySerieQuery(int value );
        public QueryModel FirstByTentativaQuery(int value );
        public QueryModel FirstByXmlAssinadoStorageKeyQuery(string value );
        public QueryModel FirstByXmlProcStorageKeyQuery(string value );
        public QueryModel FirstByXmlHashQuery(string value );
        public QueryModel FirstByCodigoRetornoQuery(string value );
        public QueryModel FirstByMensagemRetornoQuery(string value );
        public QueryModel FirstByProtocoloAutorizacaoQuery(string value );
        public QueryModel FirstByEnviadoEmUtcQuery(DateTime value );
        public QueryModel FirstByAutorizadoEmUtcQuery(DateTime value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration