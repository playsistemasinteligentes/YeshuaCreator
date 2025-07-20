using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IPacienteQueryWrite 
     {
        public QueryModel InserirPacienteQuery(IPacienteEntity Paciente);
        public QueryModel UpdatePacienteQuery(IPacienteEntity Paciente);
        public QueryModel UpdateNome(IPacienteEntity entity);
        public QueryModel UpdateTelefone(IPacienteEntity entity);
        public QueryModel UpdateDataNascimento(IPacienteEntity entity);
        public QueryModel UpdateGenero(IPacienteEntity entity);
        public QueryModel UpdateEscolaridade(IPacienteEntity entity);
        public QueryModel UpdateProfissao(IPacienteEntity entity);
        public QueryModel UpdateEndereco(IPacienteEntity entity);
        public QueryModel UpdateNomeResponsavel(IPacienteEntity entity);
        public QueryModel UpdateTelefoneResponsavel(IPacienteEntity entity);
        public QueryModel UpdatePrincipaisQueixas(IPacienteEntity entity);
        public QueryModel UpdateObservacaoAdicional(IPacienteEntity entity);
        public QueryModel DeletePacienteQuery(IPacienteEntity Paciente);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration