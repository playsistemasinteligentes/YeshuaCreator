using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
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
        protected readonly ICurrentUser _correntUser;
       protected readonly ISesoesQueryRead _query;

        public SesoesReadRepository(SqlFactory factory, ICurrentUser correntUser,ISesoesQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<SesoesDTO> getSesoes(ICommandRead command)
         {
            if (command is Command.Read.SesoesReadCommand c)
                return getSesoes(c);
            throw new NotImplementedException();
        }
        private DataPagination<SesoesDTO> getSesoes(Command.Read.SesoesReadCommand command)
        {
            var query = _query.SesoesQuery(command);

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
            var query = _query.SesoesPacienteIdQuery(command);

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
            var query = _query.SesoesProfissionalIdQuery(command);

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
            var query = _query.SesoesServicoIdQuery(command);

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
            var query = _query.SesoesMovimentacaoFinanceiraIdQuery(command);

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
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPacienteId(int value)
        {
            var query = _query.ExistsByPacienteIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissionalId(int value)
        {
            var query = _query.ExistsByProfissionalIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByServicoId(int value)
        {
            var query = _query.ExistsByServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataInicio(DateTime value)
        {
            var query = _query.ExistsByDataInicioQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataFim(DateTime value)
        {
            var query = _query.ExistsByDataFimQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value)
        {
            var query = _query.ExistsByStatusQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMovimentacaoFinanceiraId(int value)
        {
            var query = _query.ExistsByMovimentacaoFinanceiraIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySinteseProntuario(string value)
        {
            var query = _query.ExistsBySinteseProntuarioQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQueixaPrincipal(string value)
        {
            var query = _query.ExistsByQueixaPrincipalQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMotivoConsultaAtual(string value)
        {
            var query = _query.ExistsByMotivoConsultaAtualQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySintomasRelatados(string value)
        {
            var query = _query.ExistsBySintomasRelatadosQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMudancasDesdeUltimaSessaao(int value)
        {
            var query = _query.ExistsByMudancasDesdeUltimaSessaaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByComportamentoObservado(string value)
        {
            var query = _query.ExistsByComportamentoObservadoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEstadoEmocionalGeral(string value)
        {
            var query = _query.ExistsByEstadoEmocionalGeralQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiscursoPensamentos(string value)
        {
            var query = _query.ExistsByDiscursoPensamentosQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTecnicasUtilizadas(string value)
        {
            var query = _query.ExistsByTecnicasUtilizadasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuestionamentosReflexoesAbordadas(string value)
        {
            var query = _query.ExistsByQuestionamentosReflexoesAbordadasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByExerciciosTarefasSugeridas(string value)
        {
            var query = _query.ExistsByExerciciosTarefasSugeridasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiagnoosticoHipoteseDiagnoostica(string value)
        {
            var query = _query.ExistsByDiagnoosticoHipoteseDiagnoosticaQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObjetivosCurtoPrazo(string value)
        {
            var query = _query.ExistsByObjetivosCurtoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObjetivosLongoPrazo(string value)
        {
            var query = _query.ExistsByObjetivosLongoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFrequenciaSugeridaSessooes(string value)
        {
            var query = _query.ExistsByFrequenciaSugeridaSessooesQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEncaminhamentoOutrosProfissionais(string value)
        {
            var query = _query.ExistsByEncaminhamentoOutrosProfissionaisQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByInformacoesRelevantesFuturasConsultas(string value)
        {
            var query = _query.ExistsByInformacoesRelevantesFuturasConsultasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFeedbackPacienteSobreProcessoTerapeeutico(string value)
        {
            var query = _query.ExistsByFeedbackPacienteSobreProcessoTerapeeuticoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public SesoesDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByPacienteId(int value)
        {
            var query = _query.FirstByPacienteIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByProfissionalId(int value)
        {
            var query = _query.FirstByProfissionalIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByServicoId(int value)
        {
            var query = _query.FirstByServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDataInicio(DateTime value)
        {
            var query = _query.FirstByDataInicioQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDataFim(DateTime value)
        {
            var query = _query.FirstByDataFimQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByStatus(int value)
        {
            var query = _query.FirstByStatusQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMovimentacaoFinanceiraId(int value)
        {
            var query = _query.FirstByMovimentacaoFinanceiraIdQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstBySinteseProntuario(string value)
        {
            var query = _query.FirstBySinteseProntuarioQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByQueixaPrincipal(string value)
        {
            var query = _query.FirstByQueixaPrincipalQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMotivoConsultaAtual(string value)
        {
            var query = _query.FirstByMotivoConsultaAtualQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstBySintomasRelatados(string value)
        {
            var query = _query.FirstBySintomasRelatadosQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMudancasDesdeUltimaSessaao(int value)
        {
            var query = _query.FirstByMudancasDesdeUltimaSessaaoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByComportamentoObservado(string value)
        {
            var query = _query.FirstByComportamentoObservadoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByEstadoEmocionalGeral(string value)
        {
            var query = _query.FirstByEstadoEmocionalGeralQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDiscursoPensamentos(string value)
        {
            var query = _query.FirstByDiscursoPensamentosQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByTecnicasUtilizadas(string value)
        {
            var query = _query.FirstByTecnicasUtilizadasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByQuestionamentosReflexoesAbordadas(string value)
        {
            var query = _query.FirstByQuestionamentosReflexoesAbordadasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByExerciciosTarefasSugeridas(string value)
        {
            var query = _query.FirstByExerciciosTarefasSugeridasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDiagnoosticoHipoteseDiagnoostica(string value)
        {
            var query = _query.FirstByDiagnoosticoHipoteseDiagnoosticaQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByObjetivosCurtoPrazo(string value)
        {
            var query = _query.FirstByObjetivosCurtoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByObjetivosLongoPrazo(string value)
        {
            var query = _query.FirstByObjetivosLongoPrazoQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByFrequenciaSugeridaSessooes(string value)
        {
            var query = _query.FirstByFrequenciaSugeridaSessooesQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByEncaminhamentoOutrosProfissionais(string value)
        {
            var query = _query.FirstByEncaminhamentoOutrosProfissionaisQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByInformacoesRelevantesFuturasConsultas(string value)
        {
            var query = _query.FirstByInformacoesRelevantesFuturasConsultasQuery(value);

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByFeedbackPacienteSobreProcessoTerapeeutico(string value)
        {
            var query = _query.FirstByFeedbackPacienteSobreProcessoTerapeeuticoQuery(value);

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