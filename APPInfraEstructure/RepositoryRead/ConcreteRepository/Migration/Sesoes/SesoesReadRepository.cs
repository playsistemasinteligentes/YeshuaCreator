using Dapper;
using Output.Querys.Sesoes;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using Read.RepositoryInterfaces;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public class SesoesReadRepository : ISesoesReadRepository
    {
        protected readonly IDbConnection _connection;

        public SesoesReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<SesoesDTO> getSesoes(ICommandRead command)
         {
            if (command is Command.Commands.Read.SesoesReadCommand c)
                return getSesoes(c);
            throw new NotImplementedException();
        }
        private DataPagination<SesoesDTO> getSesoes(Command.Commands.Read.SesoesReadCommand command)
        {
            var query = new SesoesReadQuery().SesoesQuery(command);

                var itens = _connection.Query<SesoesDTO>(query.Query,query.Parameters);
                return new DataPagination<SesoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesPacienteIdDTO> lista;
            var query = new SesoesReadQuery().SesoesPacienteIdQuery(command);

                lista = _connection.Query<SesoesPacienteIdDTO>(query.Query,query.Parameters) as List<SesoesPacienteIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKPacienteId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesProfissionalIdDTO> lista;
            var query = new SesoesReadQuery().SesoesProfissionalIdQuery(command);

                lista = _connection.Query<SesoesProfissionalIdDTO>(query.Query,query.Parameters) as List<SesoesProfissionalIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKProfissionalId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesServicoIdDTO> lista;
            var query = new SesoesReadQuery().SesoesServicoIdQuery(command);

                lista = _connection.Query<SesoesServicoIdDTO>(query.Query,query.Parameters) as List<SesoesServicoIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKServicoId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesMovimentacaoFinanceiraIdDTO> lista;
            var query = new SesoesReadQuery().SesoesMovimentacaoFinanceiraIdQuery(command);

                lista = _connection.Query<SesoesMovimentacaoFinanceiraIdDTO>(query.Query,query.Parameters) as List<SesoesMovimentacaoFinanceiraIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKMovimentacaoFinanceiraId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = new SesoesReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPacienteId(int value)
        {
            var query = new SesoesReadQuery().ExistsByPacienteIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissionalId(int value)
        {
            var query = new SesoesReadQuery().ExistsByProfissionalIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByServicoId(int value)
        {
            var query = new SesoesReadQuery().ExistsByServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataInicio(DateTime value)
        {
            var query = new SesoesReadQuery().ExistsByDataInicioQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataFim(DateTime value)
        {
            var query = new SesoesReadQuery().ExistsByDataFimQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value)
        {
            var query = new SesoesReadQuery().ExistsByStatusQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMovimentacaoFinanceiraId(int value)
        {
            var query = new SesoesReadQuery().ExistsByMovimentacaoFinanceiraIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySinteseProntuario(string value)
        {
            var query = new SesoesReadQuery().ExistsBySinteseProntuarioQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQueixaPrincipal(string value)
        {
            var query = new SesoesReadQuery().ExistsByQueixaPrincipalQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMotivoConsultaAtual(string value)
        {
            var query = new SesoesReadQuery().ExistsByMotivoConsultaAtualQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySintomasRelatados(string value)
        {
            var query = new SesoesReadQuery().ExistsBySintomasRelatadosQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMudancasDesdeUltimaSessaao(int value)
        {
            var query = new SesoesReadQuery().ExistsByMudancasDesdeUltimaSessaaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByComportamentoObservado(string value)
        {
            var query = new SesoesReadQuery().ExistsByComportamentoObservadoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEstadoEmocionalGeral(string value)
        {
            var query = new SesoesReadQuery().ExistsByEstadoEmocionalGeralQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiscursoPensamentos(string value)
        {
            var query = new SesoesReadQuery().ExistsByDiscursoPensamentosQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTecnicasUtilizadas(string value)
        {
            var query = new SesoesReadQuery().ExistsByTecnicasUtilizadasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuestionamentosReflexoesAbordadas(string value)
        {
            var query = new SesoesReadQuery().ExistsByQuestionamentosReflexoesAbordadasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByExerciciosTarefasSugeridas(string value)
        {
            var query = new SesoesReadQuery().ExistsByExerciciosTarefasSugeridasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiagnoosticoHipoteseDiagnoostica(string value)
        {
            var query = new SesoesReadQuery().ExistsByDiagnoosticoHipoteseDiagnoosticaQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObjetivosCurtoPrazo(string value)
        {
            var query = new SesoesReadQuery().ExistsByObjetivosCurtoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObjetivosLongoPrazo(string value)
        {
            var query = new SesoesReadQuery().ExistsByObjetivosLongoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFrequenciaSugeridaSessooes(string value)
        {
            var query = new SesoesReadQuery().ExistsByFrequenciaSugeridaSessooesQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEncaminhamentoOutrosProfissionais(string value)
        {
            var query = new SesoesReadQuery().ExistsByEncaminhamentoOutrosProfissionaisQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByInformacoesRelevantesFuturasConsultas(string value)
        {
            var query = new SesoesReadQuery().ExistsByInformacoesRelevantesFuturasConsultasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFeedbackPacienteSobreProcessoTerapeeutico(string value)
        {
            var query = new SesoesReadQuery().ExistsByFeedbackPacienteSobreProcessoTerapeeuticoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public SesoesDTO FirstById(int value)
        {
            var query = new SesoesReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByPacienteId(int value)
        {
            var query = new SesoesReadQuery().FirstByPacienteIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByProfissionalId(int value)
        {
            var query = new SesoesReadQuery().FirstByProfissionalIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByServicoId(int value)
        {
            var query = new SesoesReadQuery().FirstByServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDataInicio(DateTime value)
        {
            var query = new SesoesReadQuery().FirstByDataInicioQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDataFim(DateTime value)
        {
            var query = new SesoesReadQuery().FirstByDataFimQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByStatus(int value)
        {
            var query = new SesoesReadQuery().FirstByStatusQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMovimentacaoFinanceiraId(int value)
        {
            var query = new SesoesReadQuery().FirstByMovimentacaoFinanceiraIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstBySinteseProntuario(string value)
        {
            var query = new SesoesReadQuery().FirstBySinteseProntuarioQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByQueixaPrincipal(string value)
        {
            var query = new SesoesReadQuery().FirstByQueixaPrincipalQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMotivoConsultaAtual(string value)
        {
            var query = new SesoesReadQuery().FirstByMotivoConsultaAtualQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstBySintomasRelatados(string value)
        {
            var query = new SesoesReadQuery().FirstBySintomasRelatadosQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMudancasDesdeUltimaSessaao(int value)
        {
            var query = new SesoesReadQuery().FirstByMudancasDesdeUltimaSessaaoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByComportamentoObservado(string value)
        {
            var query = new SesoesReadQuery().FirstByComportamentoObservadoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByEstadoEmocionalGeral(string value)
        {
            var query = new SesoesReadQuery().FirstByEstadoEmocionalGeralQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDiscursoPensamentos(string value)
        {
            var query = new SesoesReadQuery().FirstByDiscursoPensamentosQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByTecnicasUtilizadas(string value)
        {
            var query = new SesoesReadQuery().FirstByTecnicasUtilizadasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByQuestionamentosReflexoesAbordadas(string value)
        {
            var query = new SesoesReadQuery().FirstByQuestionamentosReflexoesAbordadasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByExerciciosTarefasSugeridas(string value)
        {
            var query = new SesoesReadQuery().FirstByExerciciosTarefasSugeridasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDiagnoosticoHipoteseDiagnoostica(string value)
        {
            var query = new SesoesReadQuery().FirstByDiagnoosticoHipoteseDiagnoosticaQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByObjetivosCurtoPrazo(string value)
        {
            var query = new SesoesReadQuery().FirstByObjetivosCurtoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByObjetivosLongoPrazo(string value)
        {
            var query = new SesoesReadQuery().FirstByObjetivosLongoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByFrequenciaSugeridaSessooes(string value)
        {
            var query = new SesoesReadQuery().FirstByFrequenciaSugeridaSessooesQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByEncaminhamentoOutrosProfissionais(string value)
        {
            var query = new SesoesReadQuery().FirstByEncaminhamentoOutrosProfissionaisQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByInformacoesRelevantesFuturasConsultas(string value)
        {
            var query = new SesoesReadQuery().FirstByInformacoesRelevantesFuturasConsultasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByFeedbackPacienteSobreProcessoTerapeeutico(string value)
        {
            var query = new SesoesReadQuery().FirstByFeedbackPacienteSobreProcessoTerapeeuticoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration