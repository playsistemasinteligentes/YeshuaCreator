using Shered.DB;
namespace IQuery.Read
{
    public interface IyTenantQueryRead 
    {
        public QueryModel yTenantQuery(Command.Read.yTenantReadCommand Command , bool TakeOffId = false);
        public QueryModel ExistsByIdQuery(int value , bool TakeOffId = false);
        public QueryModel ExistsByCnpjCpfQuery(string value , bool TakeOffId = false);
        public QueryModel ExistsByNomeQuery(string value , bool TakeOffId = false);
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffId = false);
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffId = false);
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffId = false);
        public QueryModel FirstByIdQuery(int value , bool TakeOffId = false);
        public QueryModel FirstByCnpjCpfQuery(string value , bool TakeOffId = false);
        public QueryModel FirstByNomeQuery(string value , bool TakeOffId = false);
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffId = false);
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffId = false);
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffId = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration