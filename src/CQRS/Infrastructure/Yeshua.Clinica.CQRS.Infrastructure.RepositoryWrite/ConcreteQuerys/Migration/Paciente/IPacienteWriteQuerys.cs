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

    public interface IPacienteQueryWrite 
     {
        public QueryModel InserirPacienteQuery(IPacienteEntity Paciente);
        public QueryModel UpdatePacienteQuery(IPacienteEntity Paciente);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateTelefone(int id, string value);
        QueryModel UpdateDataNascimento(int id, DateTime value);
        QueryModel UpdateGenero(int id, int value);
        QueryModel UpdateEscolaridade(int id, string value);
        QueryModel UpdateProfissao(int id, string value);
        QueryModel UpdateEndereco(int id, string value);
        QueryModel UpdateNomeResponsavel(int id, string value);
        QueryModel UpdateTelefoneResponsavel(int id, string value);
        QueryModel UpdateObservacao(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeletePacienteQuery(IPacienteEntity Paciente);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration