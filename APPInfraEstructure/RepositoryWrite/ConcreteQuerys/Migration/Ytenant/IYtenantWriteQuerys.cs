using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYtenantQueryWrite 
     {
        public QueryModel InserirYtenantQuery(IYtenantEntity Ytenant);
        public QueryModel UpdateYtenantQuery(IYtenantEntity Ytenant);
        public QueryModel UpdateCnpjCpf(IYtenantEntity entity);
        public QueryModel UpdateNome(IYtenantEntity entity);
        public QueryModel UpdateUserId(IYtenantEntity entity);
        public QueryModel DeleteYtenantQuery(IYtenantEntity Ytenant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration