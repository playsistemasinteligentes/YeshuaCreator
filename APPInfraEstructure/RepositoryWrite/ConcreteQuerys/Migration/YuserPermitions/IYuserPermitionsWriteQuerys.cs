using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYuserPermitionsQueryWrite 
     {
        public QueryModel InserirYuserPermitionsQuery(IYuserPermitionsEntity YuserPermitions);
        public QueryModel UpdateYuserPermitionsQuery(IYuserPermitionsEntity YuserPermitions);
        public QueryModel UpdatePermitionsId(IYuserPermitionsEntity entity);
        public QueryModel UpdateUserId(IYuserPermitionsEntity entity);
        public QueryModel DeleteYuserPermitionsQuery(IYuserPermitionsEntity YuserPermitions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration