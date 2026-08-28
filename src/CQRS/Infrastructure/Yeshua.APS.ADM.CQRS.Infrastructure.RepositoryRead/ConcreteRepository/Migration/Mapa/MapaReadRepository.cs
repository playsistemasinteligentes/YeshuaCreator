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
    public partial class MapaReadRepository : IMapaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMapaQueryRead _query;

        public MapaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMapaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MapaDTO> getMapa(ICommandRead command )
         {
            if (command is Command.Read.MapaReadCommand c)
                return getMapa(c );
            throw new NotImplementedException();
        }
        private DataPagination<MapaDTO> getMapa(Command.Read.MapaReadCommand command )
        {
            var query = _query.MapaQuery(command );

                var itens = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters);
                return new DataPagination<MapaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MapaPON_IDDTO> getMapaReadFKPON_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MapaPON_IDDTO> lista;
            var query = _query.MapaPON_IDQuery(command );

                lista = _unitOfWork.Query<MapaPON_IDDTO>(query.Query,query.Parameters) as List<MapaPON_IDDTO>;
            return lista;
        }

        public IEnumerable<MapaPON_IDDTO> getMapaReadFKPON_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMapaReadFKPON_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MapaTenantIDDTO> getMapaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MapaTenantIDDTO> lista;
            var query = _query.MapaTenantIDQuery(command );

                lista = _unitOfWork.Query<MapaTenantIDDTO>(query.Query,query.Parameters) as List<MapaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MapaTenantIDDTO> getMapaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMapaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MapaUserIdDTO> getMapaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MapaUserIdDTO> lista;
            var query = _query.MapaUserIdQuery(command );

                lista = _unitOfWork.Query<MapaUserIdDTO>(query.Query,query.Parameters) as List<MapaUserIdDTO>;
            return lista;
        }

        public IEnumerable<MapaUserIdDTO> getMapaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMapaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAP_ID(int value )
        {
            var query = _query.ExistsByMAP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_ID(string value )
        {
            var query = _query.ExistsByPON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_ID_VIZINHO(string value )
        {
            var query = _query.ExistsByPON_ID_VIZINHOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAP_DISTANCIA(Decimal value )
        {
            var query = _query.ExistsByMAP_DISTANCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAP_CUSTO_PEDAGIO_POR_EIXO(Decimal value )
        {
            var query = _query.ExistsByMAP_CUSTO_PEDAGIO_POR_EIXOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROD_ID(int value )
        {
            var query = _query.ExistsByROD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAP_ALTURA_ROD(Decimal value )
        {
            var query = _query.ExistsByMAP_ALTURA_RODQuery(value );

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

        public MapaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByMAP_ID(int value )
        {
            var query = _query.FirstByMAP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByPON_ID(string value )
        {
            var query = _query.FirstByPON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByPON_ID_VIZINHO(string value )
        {
            var query = _query.FirstByPON_ID_VIZINHOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByMAP_DISTANCIA(Decimal value )
        {
            var query = _query.FirstByMAP_DISTANCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByMAP_CUSTO_PEDAGIO_POR_EIXO(Decimal value )
        {
            var query = _query.FirstByMAP_CUSTO_PEDAGIO_POR_EIXOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByROD_ID(int value )
        {
            var query = _query.FirstByROD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByMAP_ALTURA_ROD(Decimal value )
        {
            var query = _query.FirstByMAP_ALTURA_RODQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MapaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MapaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByMAP_ID(int value )
        {
            var query = _query.FirstByMAP_IDQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByPON_ID(string value )
        {
            var query = _query.FirstByPON_IDQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByPON_ID_VIZINHO(string value )
        {
            var query = _query.FirstByPON_ID_VIZINHOQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByMAP_DISTANCIA(Decimal value )
        {
            var query = _query.FirstByMAP_DISTANCIAQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByMAP_CUSTO_PEDAGIO_POR_EIXO(Decimal value )
        {
            var query = _query.FirstByMAP_CUSTO_PEDAGIO_POR_EIXOQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByROD_ID(int value )
        {
            var query = _query.FirstByROD_IDQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByMAP_ALTURA_ROD(Decimal value )
        {
            var query = _query.FirstByMAP_ALTURA_RODQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

        public IEnumerable<MapaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MapaDTO>(query.Query,query.Parameters) as List<MapaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration