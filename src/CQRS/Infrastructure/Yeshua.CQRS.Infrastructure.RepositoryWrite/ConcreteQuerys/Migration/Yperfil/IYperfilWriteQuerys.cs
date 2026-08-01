using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyPerfilQueryWrite 
     {
        public QueryModel InseriryPerfilQuery(IyPerfilEntity yPerfil);
        public QueryModel UpdateyPerfilQuery(IyPerfilEntity yPerfil);
        QueryModel UpdateDescription(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteyPerfilQuery(IyPerfilEntity yPerfil);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration