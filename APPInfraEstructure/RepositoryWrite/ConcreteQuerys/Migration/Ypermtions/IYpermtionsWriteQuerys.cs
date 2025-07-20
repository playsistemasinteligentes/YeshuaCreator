using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYpermtionsQueryWrite 
     {
        public QueryModel InserirYpermtionsQuery(IYpermtionsEntity Ypermtions);
        public QueryModel UpdateYpermtionsQuery(IYpermtionsEntity Ypermtions);
        public QueryModel UpdateDescription(IYpermtionsEntity entity);
        public QueryModel DeleteYpermtionsQuery(IYpermtionsEntity Ypermtions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration