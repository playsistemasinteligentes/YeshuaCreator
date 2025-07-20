using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IEspecialidadeQueryWrite 
     {
        public QueryModel InserirEspecialidadeQuery(IEspecialidadeEntity Especialidade);
        public QueryModel UpdateEspecialidadeQuery(IEspecialidadeEntity Especialidade);
        public QueryModel UpdateDescricao(IEspecialidadeEntity entity);
        public QueryModel DeleteEspecialidadeQuery(IEspecialidadeEntity Especialidade);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration