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
    public partial class RoteiroReadRepository : IRoteiroReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRoteiroQueryRead _query;

        public RoteiroReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRoteiroQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RoteiroDTO> getRoteiro(ICommandRead command )
         {
            if (command is Command.Read.RoteiroReadCommand c)
                return getRoteiro(c );
            throw new NotImplementedException();
        }
        private DataPagination<RoteiroDTO> getRoteiro(Command.Read.RoteiroReadCommand command )
        {
            var query = _query.RoteiroQuery(command );

                var itens = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters);
                return new DataPagination<RoteiroDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RoteiroMaquinaIdDTO> getRoteiroReadFKMaquinaId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroMaquinaIdDTO> lista;
            var query = _query.RoteiroMaquinaIdQuery(command );

                lista = _unitOfWork.Query<RoteiroMaquinaIdDTO>(query.Query,query.Parameters) as List<RoteiroMaquinaIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroMaquinaIdDTO> getRoteiroReadFKMaquinaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKMaquinaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroProdutoIdDTO> getRoteiroReadFKProdutoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroProdutoIdDTO> lista;
            var query = _query.RoteiroProdutoIdQuery(command );

                lista = _unitOfWork.Query<RoteiroProdutoIdDTO>(query.Query,query.Parameters) as List<RoteiroProdutoIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroProdutoIdDTO> getRoteiroReadFKProdutoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKProdutoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroGrupoMaquinaIdDTO> getRoteiroReadFKGrupoMaquinaId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroGrupoMaquinaIdDTO> lista;
            var query = _query.RoteiroGrupoMaquinaIdQuery(command );

                lista = _unitOfWork.Query<RoteiroGrupoMaquinaIdDTO>(query.Query,query.Parameters) as List<RoteiroGrupoMaquinaIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroGrupoMaquinaIdDTO> getRoteiroReadFKGrupoMaquinaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKGrupoMaquinaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroTemplateDeTestesIdDTO> getRoteiroReadFKTemplateDeTestesId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroTemplateDeTestesIdDTO> lista;
            var query = _query.RoteiroTemplateDeTestesIdQuery(command );

                lista = _unitOfWork.Query<RoteiroTemplateDeTestesIdDTO>(query.Query,query.Parameters) as List<RoteiroTemplateDeTestesIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroTemplateDeTestesIdDTO> getRoteiroReadFKTemplateDeTestesId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKTemplateDeTestesId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroTenantIDDTO> getRoteiroReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroTenantIDDTO> lista;
            var query = _query.RoteiroTenantIDQuery(command );

                lista = _unitOfWork.Query<RoteiroTenantIDDTO>(query.Query,query.Parameters) as List<RoteiroTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RoteiroTenantIDDTO> getRoteiroReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroUserIdDTO> getRoteiroReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroUserIdDTO> lista;
            var query = _query.RoteiroUserIdQuery(command );

                lista = _unitOfWork.Query<RoteiroUserIdDTO>(query.Query,query.Parameters) as List<RoteiroUserIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroUserIdDTO> getRoteiroReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKUserId(c );
            }
            throw new NotImplementedException();
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

        public bool ExistsByGrupoMaquinaId(string value )
        {
            var query = _query.ExistsByGrupoMaquinaIdQuery(value );

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

        public bool ExistsByAcao(string value )
        {
            var query = _query.ExistsByAcaoQuery(value );

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

        public bool ExistsByProximaSequenciaTransformacao(int value )
        {
            var query = _query.ExistsByProximaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHierarquiaSequenciaTransformacao(Decimal value )
        {
            var query = _query.ExistsByHierarquiaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAvaliaCusto(int value )
        {
            var query = _query.ExistsByAvaliaCustoQuery(value );

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

        public bool ExistsByPercentualInicioPassoAnterior(Decimal value )
        {
            var query = _query.ExistsByPercentualInicioPassoAnteriorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLinhaDireta(string value )
        {
            var query = _query.ExistsByLinhaDiretaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTemplateDeTestesId(int value )
        {
            var query = _query.ExistsByTemplateDeTestesIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public RoteiroDTO FirstByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByGrupoMaquinaId(string value )
        {
            var query = _query.FirstByGrupoMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByPecasPorPulso(Decimal value )
        {
            var query = _query.FirstByPecasPorPulsoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByPrioridadeInformada(Decimal value )
        {
            var query = _query.FirstByPrioridadeInformadaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByAcao(string value )
        {
            var query = _query.FirstByAcaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByPerformance(Decimal value )
        {
            var query = _query.FirstByPerformanceQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByTempoSetup(Decimal value )
        {
            var query = _query.FirstByTempoSetupQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByTempoSetupAjuste(Decimal value )
        {
            var query = _query.FirstByTempoSetupAjusteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByProximaSequenciaTransformacao(int value )
        {
            var query = _query.FirstByProximaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByHierarquiaSequenciaTransformacao(Decimal value )
        {
            var query = _query.FirstByHierarquiaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByAvaliaCusto(int value )
        {
            var query = _query.FirstByAvaliaCustoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByOperacoes(string value )
        {
            var query = _query.FirstByOperacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByExcecaoOperacoes(string value )
        {
            var query = _query.FirstByExcecaoOperacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByPercentualInicioPassoAnterior(Decimal value )
        {
            var query = _query.FirstByPercentualInicioPassoAnteriorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByLinhaDireta(string value )
        {
            var query = _query.FirstByLinhaDiretaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByTemplateDeTestesId(int value )
        {
            var query = _query.FirstByTemplateDeTestesIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByGrupoMaquinaId(string value )
        {
            var query = _query.FirstByGrupoMaquinaIdQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByPecasPorPulso(Decimal value )
        {
            var query = _query.FirstByPecasPorPulsoQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByPrioridadeInformada(Decimal value )
        {
            var query = _query.FirstByPrioridadeInformadaQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByAcao(string value )
        {
            var query = _query.FirstByAcaoQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByPerformance(Decimal value )
        {
            var query = _query.FirstByPerformanceQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByTempoSetup(Decimal value )
        {
            var query = _query.FirstByTempoSetupQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByTempoSetupAjuste(Decimal value )
        {
            var query = _query.FirstByTempoSetupAjusteQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByProximaSequenciaTransformacao(int value )
        {
            var query = _query.FirstByProximaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByHierarquiaSequenciaTransformacao(Decimal value )
        {
            var query = _query.FirstByHierarquiaSequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByAvaliaCusto(int value )
        {
            var query = _query.FirstByAvaliaCustoQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByOperacoes(string value )
        {
            var query = _query.FirstByOperacoesQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByExcecaoOperacoes(string value )
        {
            var query = _query.FirstByExcecaoOperacoesQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByPercentualInicioPassoAnterior(Decimal value )
        {
            var query = _query.FirstByPercentualInicioPassoAnteriorQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByLinhaDireta(string value )
        {
            var query = _query.FirstByLinhaDiretaQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByTemplateDeTestesId(int value )
        {
            var query = _query.FirstByTemplateDeTestesIdQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration