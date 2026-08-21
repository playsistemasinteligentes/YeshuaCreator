// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IEspecialidadeQueryWrite 
     {
        public QueryModel InserirEspecialidadeQuery(IEspecialidadeEntity Especialidade);
        public QueryModel UpdateEspecialidadeQuery(IEspecialidadeEntity Especialidade);
        QueryModel UpdateDescricao(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteEspecialidadeQuery(IEspecialidadeEntity Especialidade);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration