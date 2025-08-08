using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IProfissionalQueryWrite 
     {
        public QueryModel InserirProfissionalQuery(IProfissionalEntity Profissional);
        public QueryModel UpdateProfissionalQuery(IProfissionalEntity Profissional);
        public QueryModel UpdateNome(IProfissionalEntity entity);
        public QueryModel UpdateEspecialidadeId(IProfissionalEntity entity);
        public QueryModel UpdateTelefone(IProfissionalEntity entity);
        public QueryModel UpdateTenantID(IProfissionalEntity entity);
        public QueryModel UpdateDeleted(IProfissionalEntity entity);
        public QueryModel UpdateChanged(IProfissionalEntity entity);
        public QueryModel UpdateUserId(IProfissionalEntity entity);
        public QueryModel DeleteProfissionalQuery(IProfissionalEntity Profissional);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration