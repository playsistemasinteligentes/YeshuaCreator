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
    public partial class CenarioPlanejamentoTransporteReadRepository : ICenarioPlanejamentoTransporteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICenarioPlanejamentoTransporteQueryRead _query;

        public CenarioPlanejamentoTransporteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICenarioPlanejamentoTransporteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CenarioPlanejamentoTransporteDTO> getCenarioPlanejamentoTransporte(ICommandRead command )
         {
            if (command is Command.Read.CenarioPlanejamentoTransporteReadCommand c)
                return getCenarioPlanejamentoTransporte(c );
            throw new NotImplementedException();
        }
        private DataPagination<CenarioPlanejamentoTransporteDTO> getCenarioPlanejamentoTransporte(Command.Read.CenarioPlanejamentoTransporteReadCommand command )
        {
            var query = _query.CenarioPlanejamentoTransporteQuery(command );

                var itens = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters);
                return new DataPagination<CenarioPlanejamentoTransporteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsByCenarioId(string value )
        {
            var query = _query.ExistsByCenarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObjetivo(string value )
        {
            var query = _query.ExistsByObjetivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidadeCargas(int value )
        {
            var query = _query.ExistsByQuantidadeCargasQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidadePedidosNaoAtendidos(int value )
        {
            var query = _query.ExistsByQuantidadePedidosNaoAtendidosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCustoTotal(Decimal value )
        {
            var query = _query.ExistsByCustoTotalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAderenciaCubagem(Decimal value )
        {
            var query = _query.ExistsByAderenciaCubagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAtrasoPrevisto(Decimal value )
        {
            var query = _query.ExistsByAtrasoPrevistoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAlertasResumo(string value )
        {
            var query = _query.ExistsByAlertasResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public CenarioPlanejamentoTransporteDTO FirstByCenarioId(string value )
        {
            var query = _query.FirstByCenarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByObjetivo(string value )
        {
            var query = _query.FirstByObjetivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByQuantidadeCargas(int value )
        {
            var query = _query.FirstByQuantidadeCargasQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByQuantidadePedidosNaoAtendidos(int value )
        {
            var query = _query.FirstByQuantidadePedidosNaoAtendidosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByCustoTotal(Decimal value )
        {
            var query = _query.FirstByCustoTotalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByAderenciaCubagem(Decimal value )
        {
            var query = _query.FirstByAderenciaCubagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByAtrasoPrevisto(Decimal value )
        {
            var query = _query.FirstByAtrasoPrevistoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public CenarioPlanejamentoTransporteDTO FirstByAlertasResumo(string value )
        {
            var query = _query.FirstByAlertasResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CenarioPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByCenarioId(string value )
        {
            var query = _query.FirstByCenarioIdQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByObjetivo(string value )
        {
            var query = _query.FirstByObjetivoQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByQuantidadeCargas(int value )
        {
            var query = _query.FirstByQuantidadeCargasQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByQuantidadePedidosNaoAtendidos(int value )
        {
            var query = _query.FirstByQuantidadePedidosNaoAtendidosQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByCustoTotal(Decimal value )
        {
            var query = _query.FirstByCustoTotalQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByAderenciaCubagem(Decimal value )
        {
            var query = _query.FirstByAderenciaCubagemQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByAtrasoPrevisto(Decimal value )
        {
            var query = _query.FirstByAtrasoPrevistoQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByAlertasResumo(string value )
        {
            var query = _query.FirstByAlertasResumoQuery(value );

                var result = _unitOfWork.Query<CenarioPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<CenarioPlanejamentoTransporteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration