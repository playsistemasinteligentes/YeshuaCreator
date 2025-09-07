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
        protected readonly ICurrentUser _currentUser;
       protected readonly ISesoesQueryRead _query;

        public SesoesReadRepository(SqlFactory factory, ICurrentUser currentUser,ISesoesQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<SesoesDTO> getSesoes(ICommandRead command )
         {
            if (command is Command.Read.SesoesReadCommand c)
                return getSesoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<SesoesDTO> getSesoes(Command.Read.SesoesReadCommand command )
        {
            var query = _query.SesoesQuery(command );

                var itens = _connection.Query<SesoesDTO>(query.Query,query.Parameters);
                return new DataPagination<SesoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SesoesPacienteIdDTO> lista;
            var query = _query.SesoesPacienteIdQuery(command );

                lista = _connection.Query<SesoesPacienteIdDTO>(query.Query,query.Parameters) as List<SesoesPacienteIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKPacienteId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SesoesMovimentacaoFinanceiraIdDTO> lista;
            var query = _query.SesoesMovimentacaoFinanceiraIdQuery(command );

                lista = _connection.Query<SesoesMovimentacaoFinanceiraIdDTO>(query.Query,query.Parameters) as List<SesoesMovimentacaoFinanceiraIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKMovimentacaoFinanceiraId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SesoesServicoIdDTO> lista;
            var query = _query.SesoesServicoIdQuery(command );

                lista = _connection.Query<SesoesServicoIdDTO>(query.Query,query.Parameters) as List<SesoesServicoIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKServicoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SesoesProfissionalIdDTO> lista;
            var query = _query.SesoesProfissionalIdQuery(command );

                lista = _connection.Query<SesoesProfissionalIdDTO>(query.Query,query.Parameters) as List<SesoesProfissionalIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKProfissionalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesTenantIDDTO> getSesoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SesoesTenantIDDTO> lista;
            var query = _query.SesoesTenantIDQuery(command );

                lista = _connection.Query<SesoesTenantIDDTO>(query.Query,query.Parameters) as List<SesoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<SesoesTenantIDDTO> getSesoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesUserIdDTO> getSesoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SesoesUserIdDTO> lista;
            var query = _query.SesoesUserIdQuery(command );

                lista = _connection.Query<SesoesUserIdDTO>(query.Query,query.Parameters) as List<SesoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<SesoesUserIdDTO> getSesoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPacienteId(int value )
        {
            var query = _query.ExistsByPacienteIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataInicio(DateTime value )
        {
            var query = _query.ExistsByDataInicioQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataFim(DateTime value )
        {
            var query = _query.ExistsByDataFimQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMovimentacaoFinanceiraId(int value )
        {
            var query = _query.ExistsByMovimentacaoFinanceiraIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProntuario(string value )
        {
            var query = _query.ExistsByProntuarioQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQueixaPrincipal(string value )
        {
            var query = _query.ExistsByQueixaPrincipalQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRegistroDocumental(string value )
        {
            var query = _query.ExistsByRegistroDocumentalQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySintomasRelatados(string value )
        {
            var query = _query.ExistsBySintomasRelatadosQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMudancasDesdeUltimaSessaao(int value )
        {
            var query = _query.ExistsByMudancasDesdeUltimaSessaaoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByComportamentoObservado(string value )
        {
            var query = _query.ExistsByComportamentoObservadoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEstadoEmocionalGeral(string value )
        {
            var query = _query.ExistsByEstadoEmocionalGeralQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiscursoPensamentos(string value )
        {
            var query = _query.ExistsByDiscursoPensamentosQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUsoMedicacao(string value )
        {
            var query = _query.ExistsByUsoMedicacaoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTecnicasUtilizadas(string value )
        {
            var query = _query.ExistsByTecnicasUtilizadasQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuestionamentosReflexoesAbordadas(string value )
        {
            var query = _query.ExistsByQuestionamentosReflexoesAbordadasQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByExerciciosTarefasSugeridas(string value )
        {
            var query = _query.ExistsByExerciciosTarefasSugeridasQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiagnoosticoHipoteseDiagnoostica(string value )
        {
            var query = _query.ExistsByDiagnoosticoHipoteseDiagnoosticaQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObjetivosCurtoPrazo(string value )
        {
            var query = _query.ExistsByObjetivosCurtoPrazoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObjetivosLongoPrazo(string value )
        {
            var query = _query.ExistsByObjetivosLongoPrazoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFrequenciaSugeridaSessooes(string value )
        {
            var query = _query.ExistsByFrequenciaSugeridaSessooesQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEncaminhamentoOutrosProfissionais(string value )
        {
            var query = _query.ExistsByEncaminhamentoOutrosProfissionaisQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByInformacoesRelevantesFuturasConsultas(string value )
        {
            var query = _query.ExistsByInformacoesRelevantesFuturasConsultasQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFeedbackPacienteSobreProcessoTerapeeutico(string value )
        {
            var query = _query.ExistsByFeedbackPacienteSobreProcessoTerapeeuticoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByServicoId(int value )
        {
            var query = _query.ExistsByServicoIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissionalId(int value )
        {
            var query = _query.ExistsByProfissionalIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public SesoesDTO FirstByPacienteId(int value )
        {
            var query = _query.FirstByPacienteIdQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDataInicio(DateTime value )
        {
            var query = _query.FirstByDataInicioQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDataFim(DateTime value )
        {
            var query = _query.FirstByDataFimQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMovimentacaoFinanceiraId(int value )
        {
            var query = _query.FirstByMovimentacaoFinanceiraIdQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByProntuario(string value )
        {
            var query = _query.FirstByProntuarioQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByQueixaPrincipal(string value )
        {
            var query = _query.FirstByQueixaPrincipalQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByRegistroDocumental(string value )
        {
            var query = _query.FirstByRegistroDocumentalQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstBySintomasRelatados(string value )
        {
            var query = _query.FirstBySintomasRelatadosQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByMudancasDesdeUltimaSessaao(int value )
        {
            var query = _query.FirstByMudancasDesdeUltimaSessaaoQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByComportamentoObservado(string value )
        {
            var query = _query.FirstByComportamentoObservadoQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByEstadoEmocionalGeral(string value )
        {
            var query = _query.FirstByEstadoEmocionalGeralQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDiscursoPensamentos(string value )
        {
            var query = _query.FirstByDiscursoPensamentosQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByUsoMedicacao(string value )
        {
            var query = _query.FirstByUsoMedicacaoQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByTecnicasUtilizadas(string value )
        {
            var query = _query.FirstByTecnicasUtilizadasQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByQuestionamentosReflexoesAbordadas(string value )
        {
            var query = _query.FirstByQuestionamentosReflexoesAbordadasQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByExerciciosTarefasSugeridas(string value )
        {
            var query = _query.FirstByExerciciosTarefasSugeridasQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDiagnoosticoHipoteseDiagnoostica(string value )
        {
            var query = _query.FirstByDiagnoosticoHipoteseDiagnoosticaQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByObjetivosCurtoPrazo(string value )
        {
            var query = _query.FirstByObjetivosCurtoPrazoQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByObjetivosLongoPrazo(string value )
        {
            var query = _query.FirstByObjetivosLongoPrazoQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByFrequenciaSugeridaSessooes(string value )
        {
            var query = _query.FirstByFrequenciaSugeridaSessooesQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByEncaminhamentoOutrosProfissionais(string value )
        {
            var query = _query.FirstByEncaminhamentoOutrosProfissionaisQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByInformacoesRelevantesFuturasConsultas(string value )
        {
            var query = _query.FirstByInformacoesRelevantesFuturasConsultasQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByFeedbackPacienteSobreProcessoTerapeeutico(string value )
        {
            var query = _query.FirstByFeedbackPacienteSobreProcessoTerapeeuticoQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByServicoId(int value )
        {
            var query = _query.FirstByServicoIdQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByProfissionalId(int value )
        {
            var query = _query.FirstByProfissionalIdQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public SesoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<SesoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByPacienteId(int value )
        {
            var query = _query.FirstByPacienteIdQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByDataInicio(DateTime value )
        {
            var query = _query.FirstByDataInicioQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByDataFim(DateTime value )
        {
            var query = _query.FirstByDataFimQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByMovimentacaoFinanceiraId(int value )
        {
            var query = _query.FirstByMovimentacaoFinanceiraIdQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByProntuario(string value )
        {
            var query = _query.FirstByProntuarioQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByQueixaPrincipal(string value )
        {
            var query = _query.FirstByQueixaPrincipalQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByRegistroDocumental(string value )
        {
            var query = _query.FirstByRegistroDocumentalQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllBySintomasRelatados(string value )
        {
            var query = _query.FirstBySintomasRelatadosQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByMudancasDesdeUltimaSessaao(int value )
        {
            var query = _query.FirstByMudancasDesdeUltimaSessaaoQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByComportamentoObservado(string value )
        {
            var query = _query.FirstByComportamentoObservadoQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByEstadoEmocionalGeral(string value )
        {
            var query = _query.FirstByEstadoEmocionalGeralQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByDiscursoPensamentos(string value )
        {
            var query = _query.FirstByDiscursoPensamentosQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByUsoMedicacao(string value )
        {
            var query = _query.FirstByUsoMedicacaoQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByTecnicasUtilizadas(string value )
        {
            var query = _query.FirstByTecnicasUtilizadasQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByQuestionamentosReflexoesAbordadas(string value )
        {
            var query = _query.FirstByQuestionamentosReflexoesAbordadasQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByExerciciosTarefasSugeridas(string value )
        {
            var query = _query.FirstByExerciciosTarefasSugeridasQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByDiagnoosticoHipoteseDiagnoostica(string value )
        {
            var query = _query.FirstByDiagnoosticoHipoteseDiagnoosticaQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByObjetivosCurtoPrazo(string value )
        {
            var query = _query.FirstByObjetivosCurtoPrazoQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByObjetivosLongoPrazo(string value )
        {
            var query = _query.FirstByObjetivosLongoPrazoQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByFrequenciaSugeridaSessooes(string value )
        {
            var query = _query.FirstByFrequenciaSugeridaSessooesQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByEncaminhamentoOutrosProfissionais(string value )
        {
            var query = _query.FirstByEncaminhamentoOutrosProfissionaisQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByInformacoesRelevantesFuturasConsultas(string value )
        {
            var query = _query.FirstByInformacoesRelevantesFuturasConsultasQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByFeedbackPacienteSobreProcessoTerapeeutico(string value )
        {
            var query = _query.FirstByFeedbackPacienteSobreProcessoTerapeeuticoQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByServicoId(int value )
        {
            var query = _query.FirstByServicoIdQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByProfissionalId(int value )
        {
            var query = _query.FirstByProfissionalIdQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public IEnumerable<SesoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
                return result;
        }

        public DataPagination<SesoesStandardDTO> GetSesoesGeral(ICommandRead command )
        {
            var query = _query.SesoesGeralQuery();

                var itens = _connection.Query<SesoesStandardDTO>(query.Query,query.Parameters);
                return new DataPagination<SesoesStandardDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }


        public DataPagination<SesoesStandardDTO> GetSesoesHoje(ICommandRead command )
        {
            var query = _query.SesoesHojeQuery();

                var itens = _connection.Query<SesoesStandardDTO>(query.Query,query.Parameters);
                return new DataPagination<SesoesStandardDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }


        public DataPagination<SesoesStandardDTO> GetSesoesSemana(ICommandRead command )
        {
            var query = _query.SesoesSemanaQuery();

                var itens = _connection.Query<SesoesStandardDTO>(query.Query,query.Parameters);
                return new DataPagination<SesoesStandardDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }


        public DataPagination<SesoesStandardDTO> GetSesoesMes(ICommandRead command )
        {
            var query = _query.SesoesMesQuery();

                var itens = _connection.Query<SesoesStandardDTO>(query.Query,query.Parameters);
                return new DataPagination<SesoesStandardDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }


    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration