using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyPerfilQueryWrite 
     {
        public QueryModel InseriryPerfilQuery(IyPerfilEntity yPerfil);
        public QueryModel UpdateyPerfilQuery(IyPerfilEntity yPerfil);
        public QueryModel UpdateDescription(IyPerfilEntity entity);
        public QueryModel UpdateTenantID(IyPerfilEntity entity);
        public QueryModel UpdateDeleted(IyPerfilEntity entity);
        public QueryModel UpdateChanged(IyPerfilEntity entity);
        public QueryModel UpdateUserId(IyPerfilEntity entity);
        public QueryModel DeleteyPerfilQuery(IyPerfilEntity yPerfil);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration