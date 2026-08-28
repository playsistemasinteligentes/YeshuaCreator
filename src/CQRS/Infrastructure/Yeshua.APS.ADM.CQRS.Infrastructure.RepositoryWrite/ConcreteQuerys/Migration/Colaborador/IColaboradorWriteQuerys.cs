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

    public interface IColaboradorQueryWrite 
     {
        public QueryModel InserirColaboradorQuery(IColaboradorEntity Colaborador);
        public QueryModel UpdateColaboradorQuery(IColaboradorEntity Colaborador);
        QueryModel UpdateCOL_NOME(string col_cpf, string value);
        QueryModel UpdateCOL_NASCIMENTO(string col_cpf, DateTime value);
        QueryModel UpdateCOL_EMAIL(string col_cpf, string value);
        QueryModel UpdateCOL_MATRICULA(string col_cpf, string value);
        QueryModel UpdateTURM_id(string col_cpf, string value);
        QueryModel UpdateTenantID(string col_cpf, int value);
        QueryModel UpdateDeleted(string col_cpf, bool value);
        QueryModel UpdateChanged(string col_cpf, DateTime value);
        QueryModel UpdateUserId(string col_cpf, int value);
        public QueryModel DeleteColaboradorQuery(IColaboradorEntity Colaborador);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration