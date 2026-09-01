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
    public partial class OpcaoPlanejamentoTransporteReadRepository : IOpcaoPlanejamentoTransporteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOpcaoPlanejamentoTransporteQueryRead _query;

        public OpcaoPlanejamentoTransporteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOpcaoPlanejamentoTransporteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetOpcaoPlanejamentoTransporteCustom(Command.Read.OpcaoPlanejamentoTransporteReadCommand command, ref DataPagination<OpcaoPlanejamentoTransporteDTO> result, ref bool handled);

        public DataPagination<OpcaoPlanejamentoTransporteDTO> getOpcaoPlanejamentoTransporte(ICommandRead command )
         {
            if (command is Command.Read.OpcaoPlanejamentoTransporteReadCommand c)
                return getOpcaoPlanejamentoTransporte(c );
            throw new NotImplementedException();
        }
        private DataPagination<OpcaoPlanejamentoTransporteDTO> getOpcaoPlanejamentoTransporte(Command.Read.OpcaoPlanejamentoTransporteReadCommand command )
        {
            DataPagination<OpcaoPlanejamentoTransporteDTO> customResult = null;
            var customHandled = false;
            TryGetOpcaoPlanejamentoTransporteCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.OpcaoPlanejamentoTransporteQuery(command );

                var itens = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters);
                return new DataPagination<OpcaoPlanejamentoTransporteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsByOpcaoId(string value )
        {
            var query = _query.ExistsByOpcaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupoDecisaoId(string value )
        {
            var query = _query.ExistsByGrupoDecisaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPeso(Decimal value )
        {
            var query = _query.ExistsByPesoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVolume(Decimal value )
        {
            var query = _query.ExistsByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCustoEstimado(Decimal value )
        {
            var query = _query.ExistsByCustoEstimadoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAderenciaCubagem(Decimal value )
        {
            var query = _query.ExistsByAderenciaCubagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAderenciaJanelaEntrega(Decimal value )
        {
            var query = _query.ExistsByAderenciaJanelaEntregaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRiscoResumo(string value )
        {
            var query = _query.ExistsByRiscoResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPedidosResumo(string value )
        {
            var query = _query.ExistsByPedidosResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOpcoesConflitantesResumo(string value )
        {
            var query = _query.ExistsByOpcoesConflitantesResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByOpcaoId(string value )
        {
            var query = _query.FirstByOpcaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByGrupoDecisaoId(string value )
        {
            var query = _query.FirstByGrupoDecisaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByPeso(Decimal value )
        {
            var query = _query.FirstByPesoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByCustoEstimado(Decimal value )
        {
            var query = _query.FirstByCustoEstimadoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByAderenciaCubagem(Decimal value )
        {
            var query = _query.FirstByAderenciaCubagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByAderenciaJanelaEntrega(Decimal value )
        {
            var query = _query.FirstByAderenciaJanelaEntregaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByRiscoResumo(string value )
        {
            var query = _query.FirstByRiscoResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByPedidosResumo(string value )
        {
            var query = _query.FirstByPedidosResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public OpcaoPlanejamentoTransporteDTO FirstByOpcoesConflitantesResumo(string value )
        {
            var query = _query.FirstByOpcoesConflitantesResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OpcaoPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByOpcaoId(string value )
        {
            var query = _query.FirstByOpcaoIdQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByGrupoDecisaoId(string value )
        {
            var query = _query.FirstByGrupoDecisaoIdQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByPeso(Decimal value )
        {
            var query = _query.FirstByPesoQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByCustoEstimado(Decimal value )
        {
            var query = _query.FirstByCustoEstimadoQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByAderenciaCubagem(Decimal value )
        {
            var query = _query.FirstByAderenciaCubagemQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByAderenciaJanelaEntrega(Decimal value )
        {
            var query = _query.FirstByAderenciaJanelaEntregaQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByRiscoResumo(string value )
        {
            var query = _query.FirstByRiscoResumoQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByPedidosResumo(string value )
        {
            var query = _query.FirstByPedidosResumoQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByOpcoesConflitantesResumo(string value )
        {
            var query = _query.FirstByOpcoesConflitantesResumoQuery(value );

                var result = _unitOfWork.Query<OpcaoPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<OpcaoPlanejamentoTransporteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration