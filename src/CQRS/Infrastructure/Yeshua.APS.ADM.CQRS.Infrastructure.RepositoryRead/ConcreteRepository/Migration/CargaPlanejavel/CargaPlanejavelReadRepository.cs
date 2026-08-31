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
    public partial class CargaPlanejavelReadRepository : ICargaPlanejavelReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICargaPlanejavelQueryRead _query;

        public CargaPlanejavelReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICargaPlanejavelQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CargaPlanejavelDTO> getCargaPlanejavel(ICommandRead command )
         {
            if (command is Command.Read.CargaPlanejavelReadCommand c)
                return getCargaPlanejavel(c );
            throw new NotImplementedException();
        }
        private DataPagination<CargaPlanejavelDTO> getCargaPlanejavel(Command.Read.CargaPlanejavelReadCommand command )
        {
            var query = _query.CargaPlanejavelQuery(command );

                var itens = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters);
                return new DataPagination<CargaPlanejavelDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsByCargaId(string value )
        {
            var query = _query.ExistsByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTransportadoraId(string value )
        {
            var query = _query.ExistsByTransportadoraIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVeiculoId(string value )
        {
            var query = _query.ExistsByVeiculoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoVeiculoId(int value )
        {
            var query = _query.ExistsByTipoVeiculoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPesoTeorico(Decimal value )
        {
            var query = _query.ExistsByPesoTeoricoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVolumeTeorico(Decimal value )
        {
            var query = _query.ExistsByVolumeTeoricoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByInicioJanelaEmbarque(DateTime value )
        {
            var query = _query.ExistsByInicioJanelaEmbarqueQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFimJanelaEmbarque(DateTime value )
        {
            var query = _query.ExistsByFimJanelaEmbarqueQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmbarqueAlvo(DateTime value )
        {
            var query = _query.ExistsByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidadePedidos(int value )
        {
            var query = _query.ExistsByQuantidadePedidosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAlertasResumo(string value )
        {
            var query = _query.ExistsByAlertasResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public CargaPlanejavelDTO FirstByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByTransportadoraId(string value )
        {
            var query = _query.FirstByTransportadoraIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByVeiculoId(string value )
        {
            var query = _query.FirstByVeiculoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByTipoVeiculoId(int value )
        {
            var query = _query.FirstByTipoVeiculoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByPesoTeorico(Decimal value )
        {
            var query = _query.FirstByPesoTeoricoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByVolumeTeorico(Decimal value )
        {
            var query = _query.FirstByVolumeTeoricoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByInicioJanelaEmbarque(DateTime value )
        {
            var query = _query.FirstByInicioJanelaEmbarqueQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByFimJanelaEmbarque(DateTime value )
        {
            var query = _query.FirstByFimJanelaEmbarqueQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByEmbarqueAlvo(DateTime value )
        {
            var query = _query.FirstByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByQuantidadePedidos(int value )
        {
            var query = _query.FirstByQuantidadePedidosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPlanejavelDTO FirstByAlertasResumo(string value )
        {
            var query = _query.FirstByAlertasResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByTransportadoraId(string value )
        {
            var query = _query.FirstByTransportadoraIdQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByVeiculoId(string value )
        {
            var query = _query.FirstByVeiculoIdQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByTipoVeiculoId(int value )
        {
            var query = _query.FirstByTipoVeiculoIdQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByPesoTeorico(Decimal value )
        {
            var query = _query.FirstByPesoTeoricoQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByVolumeTeorico(Decimal value )
        {
            var query = _query.FirstByVolumeTeoricoQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByInicioJanelaEmbarque(DateTime value )
        {
            var query = _query.FirstByInicioJanelaEmbarqueQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByFimJanelaEmbarque(DateTime value )
        {
            var query = _query.FirstByFimJanelaEmbarqueQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByEmbarqueAlvo(DateTime value )
        {
            var query = _query.FirstByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByQuantidadePedidos(int value )
        {
            var query = _query.FirstByQuantidadePedidosQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

        public IEnumerable<CargaPlanejavelDTO> GetAllByAlertasResumo(string value )
        {
            var query = _query.FirstByAlertasResumoQuery(value );

                var result = _unitOfWork.Query<CargaPlanejavelDTO>(query.Query,query.Parameters) as List<CargaPlanejavelDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration