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
    public partial class RotaPontosMapaReadRepository : IRotaPontosMapaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRotaPontosMapaQueryRead _query;

        public RotaPontosMapaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRotaPontosMapaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetRotaPontosMapaCustom(Command.Read.RotaPontosMapaReadCommand command, ref DataPagination<RotaPontosMapaDTO> result, ref bool handled);

        public DataPagination<RotaPontosMapaDTO> getRotaPontosMapa(ICommandRead command )
         {
            if (command is Command.Read.RotaPontosMapaReadCommand c)
                return getRotaPontosMapa(c );
            throw new NotImplementedException();
        }
        private DataPagination<RotaPontosMapaDTO> getRotaPontosMapa(Command.Read.RotaPontosMapaReadCommand command )
        {
            DataPagination<RotaPontosMapaDTO> customResult = null;
            var customHandled = false;
            TryGetRotaPontosMapaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.RotaPontosMapaQuery(command );

                var itens = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters);
                return new DataPagination<RotaPontosMapaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RotaPontosMapaPON_ID_DESTINODTO> getRotaPontosMapaReadFKPON_ID_DESTINO(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RotaPontosMapaPON_ID_DESTINODTO> lista;
            var query = _query.RotaPontosMapaPON_ID_DESTINOQuery(command );

                lista = _unitOfWork.Query<RotaPontosMapaPON_ID_DESTINODTO>(query.Query,query.Parameters) as List<RotaPontosMapaPON_ID_DESTINODTO>;
            return lista;
        }

        public IEnumerable<RotaPontosMapaPON_ID_DESTINODTO> getRotaPontosMapaReadFKPON_ID_DESTINO(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRotaPontosMapaReadFKPON_ID_DESTINO(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RotaPontosMapaTenantIDDTO> getRotaPontosMapaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RotaPontosMapaTenantIDDTO> lista;
            var query = _query.RotaPontosMapaTenantIDQuery(command );

                lista = _unitOfWork.Query<RotaPontosMapaTenantIDDTO>(query.Query,query.Parameters) as List<RotaPontosMapaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RotaPontosMapaTenantIDDTO> getRotaPontosMapaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRotaPontosMapaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RotaPontosMapaUserIdDTO> getRotaPontosMapaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RotaPontosMapaUserIdDTO> lista;
            var query = _query.RotaPontosMapaUserIdQuery(command );

                lista = _unitOfWork.Query<RotaPontosMapaUserIdDTO>(query.Query,query.Parameters) as List<RotaPontosMapaUserIdDTO>;
            return lista;
        }

        public IEnumerable<RotaPontosMapaUserIdDTO> getRotaPontosMapaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRotaPontosMapaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_ID(string value )
        {
            var query = _query.ExistsByROT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_ID_DESTINO(string value )
        {
            var query = _query.ExistsByPON_ID_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_ID_ORIGEM(string value )
        {
            var query = _query.ExistsByPON_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_CUSTO_TOTAL(Decimal value )
        {
            var query = _query.ExistsByROT_CUSTO_TOTALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_ID_ROTEIRO(string value )
        {
            var query = _query.ExistsByPON_ID_ROTEIROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_ORDEM_ROTEIRO(int value )
        {
            var query = _query.ExistsByROT_ORDEM_ROTEIROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_TIPO(string value )
        {
            var query = _query.ExistsByROT_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_DISTANCIA(Decimal value )
        {
            var query = _query.ExistsByROT_DISTANCIAQuery(value );

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

        public RotaPontosMapaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByROT_ID(string value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByPON_ID_DESTINO(string value )
        {
            var query = _query.FirstByPON_ID_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByPON_ID_ORIGEM(string value )
        {
            var query = _query.FirstByPON_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByROT_CUSTO_TOTAL(Decimal value )
        {
            var query = _query.FirstByROT_CUSTO_TOTALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByPON_ID_ROTEIRO(string value )
        {
            var query = _query.FirstByPON_ID_ROTEIROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByROT_ORDEM_ROTEIRO(int value )
        {
            var query = _query.FirstByROT_ORDEM_ROTEIROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByROT_TIPO(string value )
        {
            var query = _query.FirstByROT_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByROT_DISTANCIA(Decimal value )
        {
            var query = _query.FirstByROT_DISTANCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaPontosMapaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaPontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_ID(string value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByPON_ID_DESTINO(string value )
        {
            var query = _query.FirstByPON_ID_DESTINOQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByPON_ID_ORIGEM(string value )
        {
            var query = _query.FirstByPON_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_CUSTO_TOTAL(Decimal value )
        {
            var query = _query.FirstByROT_CUSTO_TOTALQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByPON_ID_ROTEIRO(string value )
        {
            var query = _query.FirstByPON_ID_ROTEIROQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_ORDEM_ROTEIRO(int value )
        {
            var query = _query.FirstByROT_ORDEM_ROTEIROQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_TIPO(string value )
        {
            var query = _query.FirstByROT_TIPOQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_DISTANCIA(Decimal value )
        {
            var query = _query.FirstByROT_DISTANCIAQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

        public IEnumerable<RotaPontosMapaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RotaPontosMapaDTO>(query.Query,query.Parameters) as List<RotaPontosMapaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration