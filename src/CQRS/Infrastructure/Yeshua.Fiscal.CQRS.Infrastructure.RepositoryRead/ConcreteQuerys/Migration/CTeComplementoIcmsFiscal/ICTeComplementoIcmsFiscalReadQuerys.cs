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
    public interface ICTeComplementoIcmsFiscalQueryRead 
    {
        public QueryModel CTeComplementoIcmsFiscalQuery(Command.Read.CTeComplementoIcmsFiscalReadCommand Command );
        public QueryModel CTeComplementoIcmsFiscalCTeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeComplementoIcmsFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeComplementoIcmsFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByValorPrestacaoComplementarQuery(Decimal value );
        public QueryModel ExistsByCSTQuery(string value );
        public QueryModel ExistsByValorBaseCalculoQuery(Decimal value );
        public QueryModel ExistsByAliquotaICMSQuery(Decimal value );
        public QueryModel ExistsByValorICMSQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByValorPrestacaoComplementarQuery(Decimal value );
        public QueryModel FirstByCSTQuery(string value );
        public QueryModel FirstByValorBaseCalculoQuery(Decimal value );
        public QueryModel FirstByAliquotaICMSQuery(Decimal value );
        public QueryModel FirstByValorICMSQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration