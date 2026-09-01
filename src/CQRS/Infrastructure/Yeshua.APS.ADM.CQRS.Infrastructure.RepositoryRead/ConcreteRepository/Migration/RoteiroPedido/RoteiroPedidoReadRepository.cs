// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class RoteiroPedidoReadRepository : IRoteiroPedidoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRoteiroPedidoQueryRead _query;

        public RoteiroPedidoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRoteiroPedidoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetRoteiroPedidoCustom(Command.Read.RoteiroPedidoReadCommand command, ref DataPagination<RoteiroPedidoDTO> result, ref bool handled);

        public DataPagination<RoteiroPedidoDTO> getRoteiroPedido(ICommandRead command )
         {
            if (command is Command.Read.RoteiroPedidoReadCommand c)
                return getRoteiroPedido(c );
            throw new NotImplementedException();
        }
        private DataPagination<RoteiroPedidoDTO> getRoteiroPedido(Command.Read.RoteiroPedidoReadCommand command )
        {
            DataPagination<RoteiroPedidoDTO> customResult = null;
            var customHandled = false;
            TryGetRoteiroPedidoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.RoteiroPedidoQuery(command );

                var itens = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters);
                return new DataPagination<RoteiroPedidoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RoteiroPedidoPedidoIdDTO> getRoteiroPedidoReadFKPedidoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroPedidoPedidoIdDTO> lista;
            var query = _query.RoteiroPedidoPedidoIdQuery(command );

                lista = _unitOfWork.Query<RoteiroPedidoPedidoIdDTO>(query.Query,query.Parameters) as List<RoteiroPedidoPedidoIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroPedidoPedidoIdDTO> getRoteiroPedidoReadFKPedidoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroPedidoReadFKPedidoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroPedidoMaquinaIdDTO> getRoteiroPedidoReadFKMaquinaId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroPedidoMaquinaIdDTO> lista;
            var query = _query.RoteiroPedidoMaquinaIdQuery(command );

                lista = _unitOfWork.Query<RoteiroPedidoMaquinaIdDTO>(query.Query,query.Parameters) as List<RoteiroPedidoMaquinaIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroPedidoMaquinaIdDTO> getRoteiroPedidoReadFKMaquinaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroPedidoReadFKMaquinaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroPedidoProdutoIdDTO> getRoteiroPedidoReadFKProdutoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroPedidoProdutoIdDTO> lista;
            var query = _query.RoteiroPedidoProdutoIdQuery(command );

                lista = _unitOfWork.Query<RoteiroPedidoProdutoIdDTO>(query.Query,query.Parameters) as List<RoteiroPedidoProdutoIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroPedidoProdutoIdDTO> getRoteiroPedidoReadFKProdutoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroPedidoReadFKProdutoId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPedidoId(string value )
        {
            var query = _query.ExistsByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMaquinaId(string value )
        {
            var query = _query.ExistsByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoId(string value )
        {
            var query = _query.ExistsByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySequenciaTransformacao(int value )
        {
            var query = _query.ExistsBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatusCadastro(string value )
        {
            var query = _query.ExistsByStatusCadastroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoPlanejamento(string value )
        {
            var query = _query.ExistsByTipoPlanejamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCalendarioId(int value )
        {
            var query = _query.ExistsByCalendarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHierarquiaSequenciaTransformacao(Decimal value )
        {
            var query = _query.ExistsByHierarquiaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProximaSequenciaTransformacao(int value )
        {
            var query = _query.ExistsByProximaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPerformance(Decimal value )
        {
            var query = _query.ExistsByPerformanceQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTempoSetup(Decimal value )
        {
            var query = _query.ExistsByTempoSetupQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTempoSetupAjuste(Decimal value )
        {
            var query = _query.ExistsByTempoSetupAjusteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPecasPorPulso(Decimal value )
        {
            var query = _query.ExistsByPecasPorPulsoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPrioridadeInformada(Decimal value )
        {
            var query = _query.ExistsByPrioridadeInformadaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperacoes(string value )
        {
            var query = _query.ExistsByOperacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByExcecaoOperacoes(string value )
        {
            var query = _query.ExistsByExcecaoOperacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLinhaDireta(string value )
        {
            var query = _query.ExistsByLinhaDiretaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAvaliaCusto(int value )
        {
            var query = _query.ExistsByAvaliaCustoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPercentualInicioPassoAnterior(Decimal value )
        {
            var query = _query.ExistsByPercentualInicioPassoAnteriorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMaquinaLarguraUtil(Decimal value )
        {
            var query = _query.ExistsByMaquinaLarguraUtilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupoTipo(Decimal value )
        {
            var query = _query.ExistsByGrupoTipoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupoPerformanceMetroLinear(Decimal value )
        {
            var query = _query.ExistsByGrupoPerformanceMetroLinearQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public RoteiroPedidoDTO FirstByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByStatusCadastro(string value )
        {
            var query = _query.FirstByStatusCadastroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByTipoPlanejamento(string value )
        {
            var query = _query.FirstByTipoPlanejamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByCalendarioId(int value )
        {
            var query = _query.FirstByCalendarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByHierarquiaSequenciaTransformacao(Decimal value )
        {
            var query = _query.FirstByHierarquiaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByProximaSequenciaTransformacao(int value )
        {
            var query = _query.FirstByProximaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByPerformance(Decimal value )
        {
            var query = _query.FirstByPerformanceQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByTempoSetup(Decimal value )
        {
            var query = _query.FirstByTempoSetupQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByTempoSetupAjuste(Decimal value )
        {
            var query = _query.FirstByTempoSetupAjusteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByPecasPorPulso(Decimal value )
        {
            var query = _query.FirstByPecasPorPulsoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByPrioridadeInformada(Decimal value )
        {
            var query = _query.FirstByPrioridadeInformadaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByOperacoes(string value )
        {
            var query = _query.FirstByOperacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByExcecaoOperacoes(string value )
        {
            var query = _query.FirstByExcecaoOperacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByLinhaDireta(string value )
        {
            var query = _query.FirstByLinhaDiretaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByAvaliaCusto(int value )
        {
            var query = _query.FirstByAvaliaCustoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByPercentualInicioPassoAnterior(Decimal value )
        {
            var query = _query.FirstByPercentualInicioPassoAnteriorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByMaquinaLarguraUtil(Decimal value )
        {
            var query = _query.FirstByMaquinaLarguraUtilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByGrupoTipo(Decimal value )
        {
            var query = _query.FirstByGrupoTipoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroPedidoDTO FirstByGrupoPerformanceMetroLinear(Decimal value )
        {
            var query = _query.FirstByGrupoPerformanceMetroLinearQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByStatusCadastro(string value )
        {
            var query = _query.FirstByStatusCadastroQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByTipoPlanejamento(string value )
        {
            var query = _query.FirstByTipoPlanejamentoQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByCalendarioId(int value )
        {
            var query = _query.FirstByCalendarioIdQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByHierarquiaSequenciaTransformacao(Decimal value )
        {
            var query = _query.FirstByHierarquiaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByProximaSequenciaTransformacao(int value )
        {
            var query = _query.FirstByProximaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByPerformance(Decimal value )
        {
            var query = _query.FirstByPerformanceQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByTempoSetup(Decimal value )
        {
            var query = _query.FirstByTempoSetupQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByTempoSetupAjuste(Decimal value )
        {
            var query = _query.FirstByTempoSetupAjusteQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByPecasPorPulso(Decimal value )
        {
            var query = _query.FirstByPecasPorPulsoQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByPrioridadeInformada(Decimal value )
        {
            var query = _query.FirstByPrioridadeInformadaQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByOperacoes(string value )
        {
            var query = _query.FirstByOperacoesQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByExcecaoOperacoes(string value )
        {
            var query = _query.FirstByExcecaoOperacoesQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByLinhaDireta(string value )
        {
            var query = _query.FirstByLinhaDiretaQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByAvaliaCusto(int value )
        {
            var query = _query.FirstByAvaliaCustoQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByPercentualInicioPassoAnterior(Decimal value )
        {
            var query = _query.FirstByPercentualInicioPassoAnteriorQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByMaquinaLarguraUtil(Decimal value )
        {
            var query = _query.FirstByMaquinaLarguraUtilQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByGrupoTipo(Decimal value )
        {
            var query = _query.FirstByGrupoTipoQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

        public IEnumerable<RoteiroPedidoDTO> GetAllByGrupoPerformanceMetroLinear(Decimal value )
        {
            var query = _query.FirstByGrupoPerformanceMetroLinearQuery(value );

                var result = _unitOfWork.Query<RoteiroPedidoDTO>(query.Query,query.Parameters) as List<RoteiroPedidoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration