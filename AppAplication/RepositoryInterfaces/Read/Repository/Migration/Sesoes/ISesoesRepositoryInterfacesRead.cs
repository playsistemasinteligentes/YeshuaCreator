using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.RepositoryInterfaces
{
    public interface ISesoesReadRepository
    {
        public DataPagination<SesoesDTO> getSesoes(ICommandRead command);
        public SesoesDTO getById();
        public IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(object command);
        public IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(object command);
        public IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(object command);
        public IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(object command);
        public bool ExistsById(int value);
        public bool ExistsByPacienteId(int value);
        public bool ExistsByProfissionalId(int value);
        public bool ExistsByServicoId(int value);
        public bool ExistsByDataInicio(DateTime value);
        public bool ExistsByDataFim(DateTime value);
        public bool ExistsByStatus(int value);
        public bool ExistsByMovimentacaoFinanceiraId(int value);
        public bool ExistsBySinteseProntuario(string value);
        public bool ExistsByQueixaPrincipal(string value);
        public bool ExistsByMotivoConsultaAtual(string value);
        public bool ExistsBySintomasRelatados(string value);
        public bool ExistsByMudancasDesdeUltimaSessaao(int value);
        public bool ExistsByComportamentoObservado(string value);
        public bool ExistsByEstadoEmocionalGeral(string value);
        public bool ExistsByDiscursoPensamentos(string value);
        public bool ExistsByTecnicasUtilizadas(string value);
        public bool ExistsByQuestionamentosReflexoesAbordadas(string value);
        public bool ExistsByExerciciosTarefasSugeridas(string value);
        public bool ExistsByDiagnoosticoHipoteseDiagnoostica(string value);
        public bool ExistsByObjetivosCurtoPrazo(string value);
        public bool ExistsByObjetivosLongoPrazo(string value);
        public bool ExistsByFrequenciaSugeridaSessooes(string value);
        public bool ExistsByEncaminhamentoOutrosProfissionais(string value);
        public bool ExistsByInformacoesRelevantesFuturasConsultas(string value);
        public bool ExistsByFeedbackPacienteSobreProcessoTerapeeutico(string value);
        public SesoesDTO FirstById(int value);
        public SesoesDTO FirstByPacienteId(int value);
        public SesoesDTO FirstByProfissionalId(int value);
        public SesoesDTO FirstByServicoId(int value);
        public SesoesDTO FirstByDataInicio(DateTime value);
        public SesoesDTO FirstByDataFim(DateTime value);
        public SesoesDTO FirstByStatus(int value);
        public SesoesDTO FirstByMovimentacaoFinanceiraId(int value);
        public SesoesDTO FirstBySinteseProntuario(string value);
        public SesoesDTO FirstByQueixaPrincipal(string value);
        public SesoesDTO FirstByMotivoConsultaAtual(string value);
        public SesoesDTO FirstBySintomasRelatados(string value);
        public SesoesDTO FirstByMudancasDesdeUltimaSessaao(int value);
        public SesoesDTO FirstByComportamentoObservado(string value);
        public SesoesDTO FirstByEstadoEmocionalGeral(string value);
        public SesoesDTO FirstByDiscursoPensamentos(string value);
        public SesoesDTO FirstByTecnicasUtilizadas(string value);
        public SesoesDTO FirstByQuestionamentosReflexoesAbordadas(string value);
        public SesoesDTO FirstByExerciciosTarefasSugeridas(string value);
        public SesoesDTO FirstByDiagnoosticoHipoteseDiagnoostica(string value);
        public SesoesDTO FirstByObjetivosCurtoPrazo(string value);
        public SesoesDTO FirstByObjetivosLongoPrazo(string value);
        public SesoesDTO FirstByFrequenciaSugeridaSessooes(string value);
        public SesoesDTO FirstByEncaminhamentoOutrosProfissionais(string value);
        public SesoesDTO FirstByInformacoesRelevantesFuturasConsultas(string value);
        public SesoesDTO FirstByFeedbackPacienteSobreProcessoTerapeeutico(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration