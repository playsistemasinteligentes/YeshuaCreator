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

    public interface IProfissionalQueryWrite 
     {
        public QueryModel InserirProfissionalQuery(IProfissionalEntity Profissional);
        public QueryModel UpdateProfissionalQuery(IProfissionalEntity Profissional);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateEspecialidadeId(int id, int value);
        QueryModel UpdateTelefone(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteProfissionalQuery(IProfissionalEntity Profissional);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration