using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYperfilPermitionsQueryWrite 
     {
        public QueryModel InserirYperfilPermitionsQuery(IYperfilPermitionsEntity YperfilPermitions);
        public QueryModel UpdateYperfilPermitionsQuery(IYperfilPermitionsEntity YperfilPermitions);
        public QueryModel UpdatePerfilId(IYperfilPermitionsEntity entity);
        public QueryModel UpdatePermitionsId(IYperfilPermitionsEntity entity);
        public QueryModel DeleteYperfilPermitionsQuery(IYperfilPermitionsEntity YperfilPermitions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration