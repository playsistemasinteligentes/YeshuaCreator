using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface ISesoesQueryWrite 
     {
        public QueryModel InserirSesoesQuery(ISesoesEntity Sesoes);
        public QueryModel UpdateSesoesQuery(ISesoesEntity Sesoes);
        public QueryModel UpdateServicoId(ISesoesEntity entity);
        public QueryModel UpdateProfissionalId(ISesoesEntity entity);
        public QueryModel UpdatePacienteId(ISesoesEntity entity);
        public QueryModel UpdateDataInicio(ISesoesEntity entity);
        public QueryModel UpdateDataFim(ISesoesEntity entity);
        public QueryModel UpdateStatus(ISesoesEntity entity);
        public QueryModel UpdateMovimentacaoFinanceiraId(ISesoesEntity entity);
        public QueryModel UpdateProntuario(ISesoesEntity entity);
        public QueryModel UpdateQueixaPrincipal(ISesoesEntity entity);
        public QueryModel UpdateRegistroDocumental(ISesoesEntity entity);
        public QueryModel UpdateSintomasRelatados(ISesoesEntity entity);
        public QueryModel UpdateMudancasDesdeUltimaSessaao(ISesoesEntity entity);
        public QueryModel UpdateComportamentoObservado(ISesoesEntity entity);
        public QueryModel UpdateEstadoEmocionalGeral(ISesoesEntity entity);
        public QueryModel UpdateDiscursoPensamentos(ISesoesEntity entity);
        public QueryModel UpdateUsoMedicacao(ISesoesEntity entity);
        public QueryModel UpdateTecnicasUtilizadas(ISesoesEntity entity);
        public QueryModel UpdateQuestionamentosReflexoesAbordadas(ISesoesEntity entity);
        public QueryModel UpdateExerciciosTarefasSugeridas(ISesoesEntity entity);
        public QueryModel UpdateDiagnoosticoHipoteseDiagnoostica(ISesoesEntity entity);
        public QueryModel UpdateObjetivosCurtoPrazo(ISesoesEntity entity);
        public QueryModel UpdateObjetivosLongoPrazo(ISesoesEntity entity);
        public QueryModel UpdateFrequenciaSugeridaSessooes(ISesoesEntity entity);
        public QueryModel UpdateEncaminhamentoOutrosProfissionais(ISesoesEntity entity);
        public QueryModel UpdateInformacoesRelevantesFuturasConsultas(ISesoesEntity entity);
        public QueryModel UpdateFeedbackPacienteSobreProcessoTerapeeutico(ISesoesEntity entity);
        public QueryModel UpdateTenantID(ISesoesEntity entity);
        public QueryModel UpdateDeleted(ISesoesEntity entity);
        public QueryModel UpdateChanged(ISesoesEntity entity);
        public QueryModel UpdateUserId(ISesoesEntity entity);
        public QueryModel DeleteSesoesQuery(ISesoesEntity Sesoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration