using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface ISesoesQueryWrite 
     {
        public QueryModel InserirSesoesQuery(ISesoesEntity Sesoes);
        public QueryModel UpdateSesoesQuery(ISesoesEntity Sesoes);
        QueryModel UpdatePacienteId(int id, int value);
        QueryModel UpdateDataInicio(int id, DateTime value);
        QueryModel UpdateDataFim(int id, DateTime value);
        QueryModel UpdateStatusAgendamento(int id, int value);
        QueryModel UpdateStatusProntuario(int id, int value);
        QueryModel UpdateProntuario(int id, string value);
        QueryModel UpdateQueixaPrincipal(int id, string value);
        QueryModel UpdateRegistroDocumental(int id, string value);
        QueryModel UpdateSintomasRelatados(int id, string value);
        QueryModel UpdateMudancasDesdeUltimaSessaao(int id, int value);
        QueryModel UpdateComportamentoObservado(int id, string value);
        QueryModel UpdateEstadoEmocionalGeral(int id, string value);
        QueryModel UpdateDiscursoPensamentos(int id, string value);
        QueryModel UpdateUsoMedicacao(int id, string value);
        QueryModel UpdateTecnicasUtilizadas(int id, string value);
        QueryModel UpdateQuestionamentosReflexoesAbordadas(int id, string value);
        QueryModel UpdateExerciciosTarefasSugeridas(int id, string value);
        QueryModel UpdateDiagnoosticoHipoteseDiagnoostica(int id, string value);
        QueryModel UpdateObjetivosCurtoPrazo(int id, string value);
        QueryModel UpdateObjetivosLongoPrazo(int id, string value);
        QueryModel UpdateFrequenciaSugeridaSessooes(int id, string value);
        QueryModel UpdateEncaminhamentoOutrosProfissionais(int id, string value);
        QueryModel UpdateInformacoesRelevantesFuturasConsultas(int id, string value);
        QueryModel UpdateFeedbackPacienteSobreProcessoTerapeeutico(int id, string value);
        QueryModel UpdateServicoId(int id, int value);
        QueryModel UpdateMovimentacaoFinanceiraId(int id, int value);
        QueryModel UpdateProfissionalId(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteSesoesQuery(ISesoesEntity Sesoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration