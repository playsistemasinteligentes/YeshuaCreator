using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYpserPermitionsQueryWrite 
     {
        public QueryModel InserirYpserPermitionsQuery(IYpserPermitionsEntity YpserPermitions);
        public QueryModel UpdateYpserPermitionsQuery(IYpserPermitionsEntity YpserPermitions);
        public QueryModel UpdateUserId(IYpserPermitionsEntity entity);
        public QueryModel UpdatePermitionsId(IYpserPermitionsEntity entity);
        public QueryModel DeleteYpserPermitionsQuery(IYpserPermitionsEntity YpserPermitions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration