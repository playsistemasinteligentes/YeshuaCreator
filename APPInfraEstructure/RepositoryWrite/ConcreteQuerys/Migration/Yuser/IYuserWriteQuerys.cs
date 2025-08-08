using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyUserQueryWrite 
     {
        public QueryModel InseriryUserQuery(IyUserEntity yUser);
        public QueryModel UpdateyUserQuery(IyUserEntity yUser);
        public QueryModel UpdateNome(IyUserEntity entity);
        public QueryModel UpdateEmail(IyUserEntity entity);
        public QueryModel UpdateSenha(IyUserEntity entity);
        public QueryModel UpdateTenantID(IyUserEntity entity);
        public QueryModel UpdateDeleted(IyUserEntity entity);
        public QueryModel UpdateChanged(IyUserEntity entity);
        public QueryModel DeleteyUserQuery(IyUserEntity yUser);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration