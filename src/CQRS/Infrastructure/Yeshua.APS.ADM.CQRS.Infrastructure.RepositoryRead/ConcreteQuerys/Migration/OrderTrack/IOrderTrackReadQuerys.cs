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
    public interface IOrderTrackQueryRead 
    {
        public QueryModel OrderTrackQuery(Command.Read.OrderTrackReadCommand Command );
        public QueryModel OrderTrackORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OrderTrackTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OrderTrackUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByOTK_IDQuery(int value );
        public QueryModel ExistsByOTK_SEQUENCIAQuery(Decimal value );
        public QueryModel ExistsByOTK_VERSSAOQuery(int value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByOTK_EVENTOQuery(string value );
        public QueryModel ExistsByOTK_DATA_NECESSIDADE_DEQuery(DateTime value );
        public QueryModel ExistsByOTK_DATA_NECESSIDADE_ATEQuery(DateTime value );
        public QueryModel ExistsByOTK_DATA_PREVISTAQuery(DateTime value );
        public QueryModel ExistsByOTK_DATA_REALIZADAQuery(DateTime value );
        public QueryModel ExistsByFPR_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByOTK_IDQuery(int value );
        public QueryModel FirstByOTK_SEQUENCIAQuery(Decimal value );
        public QueryModel FirstByOTK_VERSSAOQuery(int value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByOTK_EVENTOQuery(string value );
        public QueryModel FirstByOTK_DATA_NECESSIDADE_DEQuery(DateTime value );
        public QueryModel FirstByOTK_DATA_NECESSIDADE_ATEQuery(DateTime value );
        public QueryModel FirstByOTK_DATA_PREVISTAQuery(DateTime value );
        public QueryModel FirstByOTK_DATA_REALIZADAQuery(DateTime value );
        public QueryModel FirstByFPR_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration