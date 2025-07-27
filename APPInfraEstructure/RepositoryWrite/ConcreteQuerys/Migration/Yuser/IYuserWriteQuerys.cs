using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYuserQueryWrite 
     {
        public QueryModel InserirYuserQuery(IYuserEntity Yuser);
        public QueryModel UpdateYuserQuery(IYuserEntity Yuser);
        public QueryModel UpdateNome(IYuserEntity entity);
        public QueryModel UpdateEmail(IYuserEntity entity);
        public QueryModel UpdateSenha(IYuserEntity entity);
        public QueryModel UpdateTenantID(IYuserEntity entity);
        public QueryModel DeleteYuserQuery(IYuserEntity Yuser);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration