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
    public interface ITransportadoraQueryRead 
    {
        public QueryModel TransportadoraQuery(Command.Read.TransportadoraReadCommand Command );
        public QueryModel TransportadoraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TransportadoraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTRA_IDQuery(string value );
        public QueryModel ExistsByTRA_NOMEQuery(string value );
        public QueryModel ExistsByTRA_EMAILQuery(string value );
        public QueryModel ExistsByTRA_RESPONSAVELQuery(string value );
        public QueryModel ExistsByTRA_FONEQuery(string value );
        public QueryModel ExistsByTRA_ID_INTEGRACAOQuery(string value );
        public QueryModel ExistsByTRA_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTRA_IDQuery(string value );
        public QueryModel FirstByTRA_NOMEQuery(string value );
        public QueryModel FirstByTRA_EMAILQuery(string value );
        public QueryModel FirstByTRA_RESPONSAVELQuery(string value );
        public QueryModel FirstByTRA_FONEQuery(string value );
        public QueryModel FirstByTRA_ID_INTEGRACAOQuery(string value );
        public QueryModel FirstByTRA_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration