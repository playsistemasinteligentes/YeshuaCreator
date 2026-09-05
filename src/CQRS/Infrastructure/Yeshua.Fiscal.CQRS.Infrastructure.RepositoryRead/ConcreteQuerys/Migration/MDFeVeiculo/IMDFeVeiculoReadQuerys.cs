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
    public interface IMDFeVeiculoQueryRead 
    {
        public QueryModel MDFeVeiculoQuery(Command.Read.MDFeVeiculoReadCommand Command );
        public QueryModel MDFeVeiculoMDFeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeVeiculoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeVeiculoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByPlacaQuery(string value );
        public QueryModel ExistsByRenavamQuery(string value );
        public QueryModel ExistsByTaraQuery(Decimal value );
        public QueryModel ExistsByCapacidadeKgQuery(Decimal value );
        public QueryModel ExistsByCapacidadeM3Query(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByPlacaQuery(string value );
        public QueryModel FirstByRenavamQuery(string value );
        public QueryModel FirstByTaraQuery(Decimal value );
        public QueryModel FirstByCapacidadeKgQuery(Decimal value );
        public QueryModel FirstByCapacidadeM3Query(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration