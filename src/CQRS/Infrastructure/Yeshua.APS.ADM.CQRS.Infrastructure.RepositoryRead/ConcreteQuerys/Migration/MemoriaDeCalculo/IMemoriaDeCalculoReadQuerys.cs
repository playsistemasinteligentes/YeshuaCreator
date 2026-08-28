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
    public interface IMemoriaDeCalculoQueryRead 
    {
        public QueryModel MemoriaDeCalculoQuery(Command.Read.MemoriaDeCalculoReadCommand Command );
        public QueryModel MemoriaDeCalculoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MemoriaDeCalculoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMEM_IDQuery(int value );
        public QueryModel ExistsByORC_IDQuery(int value );
        public QueryModel ExistsByMEM_VALORQuery(Decimal value );
        public QueryModel ExistsByMEM_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMEM_IDQuery(int value );
        public QueryModel FirstByORC_IDQuery(int value );
        public QueryModel FirstByMEM_VALORQuery(Decimal value );
        public QueryModel FirstByMEM_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration