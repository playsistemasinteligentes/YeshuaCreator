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
    public partial class CTeRomaneioConsolidadoReadRepository : ICTeRomaneioConsolidadoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeRomaneioConsolidadoQueryRead _query;

        public CTeRomaneioConsolidadoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeRomaneioConsolidadoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCTeRomaneioConsolidadoCustom(Command.Read.CTeRomaneioConsolidadoReadCommand command, ref DataPagination<CTeRomaneioConsolidadoDTO> result, ref bool handled);

        public DataPagination<CTeRomaneioConsolidadoDTO> getCTeRomaneioConsolidado(ICommandRead command )
         {
            if (command is Command.Read.CTeRomaneioConsolidadoReadCommand c)
                return getCTeRomaneioConsolidado(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeRomaneioConsolidadoDTO> getCTeRomaneioConsolidado(Command.Read.CTeRomaneioConsolidadoReadCommand command )
        {
            var customResult = new DataPagination<CTeRomaneioConsolidadoDTO>();
            var customHandled = false;
            TryGetCTeRomaneioConsolidadoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CTeRomaneioConsolidadoQuery(command );

                var itens = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeRomaneioConsolidadoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeRomaneioConsolidadoEntradaOficialIdDTO> getCTeRomaneioConsolidadoReadFKEntradaOficialId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeRomaneioConsolidadoEntradaOficialIdQuery(command );

                var lista = _unitOfWork.Query<CTeRomaneioConsolidadoEntradaOficialIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeRomaneioConsolidadoEntradaOficialIdDTO> getCTeRomaneioConsolidadoReadFKEntradaOficialId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeRomaneioConsolidadoReadFKEntradaOficialId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeRomaneioConsolidadoTenantIDDTO> getCTeRomaneioConsolidadoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeRomaneioConsolidadoTenantIDQuery(command );

                var lista = _unitOfWork.Query<CTeRomaneioConsolidadoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeRomaneioConsolidadoTenantIDDTO> getCTeRomaneioConsolidadoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeRomaneioConsolidadoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeRomaneioConsolidadoUserIdDTO> getCTeRomaneioConsolidadoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeRomaneioConsolidadoUserIdQuery(command );

                var lista = _unitOfWork.Query<CTeRomaneioConsolidadoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeRomaneioConsolidadoUserIdDTO> getCTeRomaneioConsolidadoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeRomaneioConsolidadoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEntradaOficialId(int value )
        {
            var query = _query.ExistsByEntradaOficialIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRomaneioId(string value )
        {
            var query = _query.ExistsByRomaneioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCargaId(string value )
        {
            var query = _query.ExistsByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByConsolidadoEmUtc(DateTime value )
        {
            var query = _query.ExistsByConsolidadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFInicio(string value )
        {
            var query = _query.ExistsByUFInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFFim(string value )
        {
            var query = _query.ExistsByUFFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.ExistsByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.ExistsByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmitenteDocumento(string value )
        {
            var query = _query.ExistsByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTomadorDocumento(string value )
        {
            var query = _query.ExistsByTomadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRotaSnapshotJson(string value )
        {
            var query = _query.ExistsByRotaSnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCargaSnapshotJson(string value )
        {
            var query = _query.ExistsByCargaSnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPreferenciasFiscaisJson(string value )
        {
            var query = _query.ExistsByPreferenciasFiscaisJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public CTeRomaneioConsolidadoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByEntradaOficialId(int value )
        {
            var query = _query.FirstByEntradaOficialIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByRomaneioId(string value )
        {
            var query = _query.FirstByRomaneioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByConsolidadoEmUtc(DateTime value )
        {
            var query = _query.FirstByConsolidadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByRotaSnapshotJson(string value )
        {
            var query = _query.FirstByRotaSnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByCargaSnapshotJson(string value )
        {
            var query = _query.FirstByCargaSnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByPreferenciasFiscaisJson(string value )
        {
            var query = _query.FirstByPreferenciasFiscaisJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeRomaneioConsolidadoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeRomaneioConsolidadoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByEntradaOficialId(int value )
        {
            var query = _query.FirstByEntradaOficialIdQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByRomaneioId(string value )
        {
            var query = _query.FirstByRomaneioIdQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByConsolidadoEmUtc(DateTime value )
        {
            var query = _query.FirstByConsolidadoEmUtcQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByRotaSnapshotJson(string value )
        {
            var query = _query.FirstByRotaSnapshotJsonQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByCargaSnapshotJson(string value )
        {
            var query = _query.FirstByCargaSnapshotJsonQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByPreferenciasFiscaisJson(string value )
        {
            var query = _query.FirstByPreferenciasFiscaisJsonQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeRomaneioConsolidadoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration