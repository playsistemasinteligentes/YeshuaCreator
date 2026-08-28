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
    public interface IAuditoriaQueryRead 
    {
        public QueryModel AuditoriaQuery(Command.Read.AuditoriaReadCommand Command );
        public QueryModel AuditoriaUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel AuditoriaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel AuditoriaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIDQuery(int value );
        public QueryModel ExistsByDATAQuery(DateTime value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByROTINAQuery(string value );
        public QueryModel ExistsByHISTORICOQuery(string value );
        public QueryModel ExistsByCHAVEQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIDQuery(int value );
        public QueryModel FirstByDATAQuery(DateTime value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByROTINAQuery(string value );
        public QueryModel FirstByHISTORICOQuery(string value );
        public QueryModel FirstByCHAVEQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration