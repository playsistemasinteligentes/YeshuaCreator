using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYperfilQueryWrite 
     {
        public QueryModel InserirYperfilQuery(IYperfilEntity Yperfil);
        public QueryModel UpdateYperfilQuery(IYperfilEntity Yperfil);
        public QueryModel UpdateDescription(IYperfilEntity entity);
        public QueryModel DeleteYperfilQuery(IYperfilEntity Yperfil);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration