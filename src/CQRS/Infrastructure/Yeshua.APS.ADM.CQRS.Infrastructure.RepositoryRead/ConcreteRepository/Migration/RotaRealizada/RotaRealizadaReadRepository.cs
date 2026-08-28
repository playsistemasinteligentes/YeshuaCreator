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
    public partial class RotaRealizadaReadRepository : IRotaRealizadaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRotaRealizadaQueryRead _query;

        public RotaRealizadaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRotaRealizadaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RotaRealizadaDTO> getRotaRealizada(ICommandRead command )
         {
            if (command is Command.Read.RotaRealizadaReadCommand c)
                return getRotaRealizada(c );
            throw new NotImplementedException();
        }
        private DataPagination<RotaRealizadaDTO> getRotaRealizada(Command.Read.RotaRealizadaReadCommand command )
        {
            var query = _query.RotaRealizadaQuery(command );

                var itens = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters);
                return new DataPagination<RotaRealizadaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RotaRealizadaTenantIDDTO> getRotaRealizadaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RotaRealizadaTenantIDDTO> lista;
            var query = _query.RotaRealizadaTenantIDQuery(command );

                lista = _unitOfWork.Query<RotaRealizadaTenantIDDTO>(query.Query,query.Parameters) as List<RotaRealizadaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RotaRealizadaTenantIDDTO> getRotaRealizadaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRotaRealizadaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RotaRealizadaUserIdDTO> getRotaRealizadaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RotaRealizadaUserIdDTO> lista;
            var query = _query.RotaRealizadaUserIdQuery(command );

                lista = _unitOfWork.Query<RotaRealizadaUserIdDTO>(query.Query,query.Parameters) as List<RotaRealizadaUserIdDTO>;
            return lista;
        }

        public IEnumerable<RotaRealizadaUserIdDTO> getRotaRealizadaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRotaRealizadaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByROT_ID(int value )
        {
            var query = _query.ExistsByROT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID(string value )
        {
            var query = _query.ExistsByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_DATA_HORA(DateTime value )
        {
            var query = _query.ExistsByROT_DATA_HORAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_LAT(Decimal value )
        {
            var query = _query.ExistsByROT_LATQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_LONG(Decimal value )
        {
            var query = _query.ExistsByROT_LONGQuery(value );

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

        public RotaRealizadaDTO FirstByROT_ID(int value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByROT_DATA_HORA(DateTime value )
        {
            var query = _query.FirstByROT_DATA_HORAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByROT_LAT(Decimal value )
        {
            var query = _query.FirstByROT_LATQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByROT_LONG(Decimal value )
        {
            var query = _query.FirstByROT_LONGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public RotaRealizadaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RotaRealizadaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByROT_ID(int value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByROT_DATA_HORA(DateTime value )
        {
            var query = _query.FirstByROT_DATA_HORAQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByROT_LAT(Decimal value )
        {
            var query = _query.FirstByROT_LATQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByROT_LONG(Decimal value )
        {
            var query = _query.FirstByROT_LONGQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

        public IEnumerable<RotaRealizadaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RotaRealizadaDTO>(query.Query,query.Parameters) as List<RotaRealizadaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration