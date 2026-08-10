using Shered.DB;
namespace IQuery.Read
{
    public interface ISesoesQueryRead 
    {
        public QueryModel SesoesQuery(Command.Read.SesoesReadCommand Command );
        public QueryModel SesoesPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SesoesServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SesoesMovimentacaoFinanceiraIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SesoesProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SesoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SesoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPacienteIdQuery(int value );
        public QueryModel ExistsByDataInicioQuery(DateTime value );
        public QueryModel ExistsByDataFimQuery(DateTime value );
        public QueryModel ExistsByStatusAgendamentoQuery(int value );
        public QueryModel ExistsByStatusProntuarioQuery(int value );
        public QueryModel ExistsByProntuarioQuery(string value );
        public QueryModel ExistsByQueixaPrincipalQuery(string value );
        public QueryModel ExistsByRegistroDocumentalQuery(string value );
        public QueryModel ExistsBySintomasRelatadosQuery(string value );
        public QueryModel ExistsByMudancasDesdeUltimaSessaaoQuery(int value );
        public QueryModel ExistsByComportamentoObservadoQuery(string value );
        public QueryModel ExistsByEstadoEmocionalGeralQuery(string value );
        public QueryModel ExistsByDiscursoPensamentosQuery(string value );
        public QueryModel ExistsByUsoMedicacaoQuery(string value );
        public QueryModel ExistsByTecnicasUtilizadasQuery(string value );
        public QueryModel ExistsByQuestionamentosReflexoesAbordadasQuery(string value );
        public QueryModel ExistsByExerciciosTarefasSugeridasQuery(string value );
        public QueryModel ExistsByDiagnoosticoHipoteseDiagnoosticaQuery(string value );
        public QueryModel ExistsByObjetivosCurtoPrazoQuery(string value );
        public QueryModel ExistsByObjetivosLongoPrazoQuery(string value );
        public QueryModel ExistsByFrequenciaSugeridaSessooesQuery(string value );
        public QueryModel ExistsByEncaminhamentoOutrosProfissionaisQuery(string value );
        public QueryModel ExistsByInformacoesRelevantesFuturasConsultasQuery(string value );
        public QueryModel ExistsByFeedbackPacienteSobreProcessoTerapeeuticoQuery(string value );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByServicoIdQuery(int value );
        public QueryModel ExistsByMovimentacaoFinanceiraIdQuery(int value );
        public QueryModel ExistsByProfissionalIdQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByPacienteIdQuery(int value );
        public QueryModel FirstByDataInicioQuery(DateTime value );
        public QueryModel FirstByDataFimQuery(DateTime value );
        public QueryModel FirstByStatusAgendamentoQuery(int value );
        public QueryModel FirstByStatusProntuarioQuery(int value );
        public QueryModel FirstByProntuarioQuery(string value );
        public QueryModel FirstByQueixaPrincipalQuery(string value );
        public QueryModel FirstByRegistroDocumentalQuery(string value );
        public QueryModel FirstBySintomasRelatadosQuery(string value );
        public QueryModel FirstByMudancasDesdeUltimaSessaaoQuery(int value );
        public QueryModel FirstByComportamentoObservadoQuery(string value );
        public QueryModel FirstByEstadoEmocionalGeralQuery(string value );
        public QueryModel FirstByDiscursoPensamentosQuery(string value );
        public QueryModel FirstByUsoMedicacaoQuery(string value );
        public QueryModel FirstByTecnicasUtilizadasQuery(string value );
        public QueryModel FirstByQuestionamentosReflexoesAbordadasQuery(string value );
        public QueryModel FirstByExerciciosTarefasSugeridasQuery(string value );
        public QueryModel FirstByDiagnoosticoHipoteseDiagnoosticaQuery(string value );
        public QueryModel FirstByObjetivosCurtoPrazoQuery(string value );
        public QueryModel FirstByObjetivosLongoPrazoQuery(string value );
        public QueryModel FirstByFrequenciaSugeridaSessooesQuery(string value );
        public QueryModel FirstByEncaminhamentoOutrosProfissionaisQuery(string value );
        public QueryModel FirstByInformacoesRelevantesFuturasConsultasQuery(string value );
        public QueryModel FirstByFeedbackPacienteSobreProcessoTerapeeuticoQuery(string value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByServicoIdQuery(int value );
        public QueryModel FirstByMovimentacaoFinanceiraIdQuery(int value );
        public QueryModel FirstByProfissionalIdQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration