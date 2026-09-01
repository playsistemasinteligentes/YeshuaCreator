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
    public partial class CabvisaoReadRepository : ICabvisaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICabvisaoQueryRead _query;

        public CabvisaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICabvisaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCabvisaoCustom(Command.Read.CabvisaoReadCommand command, ref DataPagination<CabvisaoDTO> result, ref bool handled);

        public DataPagination<CabvisaoDTO> getCabvisao(ICommandRead command )
         {
            if (command is Command.Read.CabvisaoReadCommand c)
                return getCabvisao(c );
            throw new NotImplementedException();
        }
        private DataPagination<CabvisaoDTO> getCabvisao(Command.Read.CabvisaoReadCommand command )
        {
            DataPagination<CabvisaoDTO> customResult = null;
            var customHandled = false;
            TryGetCabvisaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CabvisaoQuery(command );

                var itens = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters);
                return new DataPagination<CabvisaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CabvisaoUSE_IDDTO> getCabvisaoReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CabvisaoUSE_IDDTO> lista;
            var query = _query.CabvisaoUSE_IDQuery(command );

                lista = _unitOfWork.Query<CabvisaoUSE_IDDTO>(query.Query,query.Parameters) as List<CabvisaoUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<CabvisaoUSE_IDDTO> getCabvisaoReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCabvisaoReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CabvisaoTenantIDDTO> getCabvisaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CabvisaoTenantIDDTO> lista;
            var query = _query.CabvisaoTenantIDQuery(command );

                lista = _unitOfWork.Query<CabvisaoTenantIDDTO>(query.Query,query.Parameters) as List<CabvisaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CabvisaoTenantIDDTO> getCabvisaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCabvisaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CabvisaoUserIdDTO> getCabvisaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CabvisaoUserIdDTO> lista;
            var query = _query.CabvisaoUserIdQuery(command );

                lista = _unitOfWork.Query<CabvisaoUserIdDTO>(query.Query,query.Parameters) as List<CabvisaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<CabvisaoUserIdDTO> getCabvisaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCabvisaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByCAB_ID(int value )
        {
            var query = _query.ExistsByCAB_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAB_DESC(string value )
        {
            var query = _query.ExistsByCAB_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAB_STATUS(int value )
        {
            var query = _query.ExistsByCAB_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

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

        public CabvisaoDTO FirstByCAB_ID(int value )
        {
            var query = _query.FirstByCAB_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CabvisaoDTO FirstByCAB_DESC(string value )
        {
            var query = _query.FirstByCAB_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CabvisaoDTO FirstByCAB_STATUS(int value )
        {
            var query = _query.FirstByCAB_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CabvisaoDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CabvisaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CabvisaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CabvisaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CabvisaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CabvisaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByCAB_ID(int value )
        {
            var query = _query.FirstByCAB_IDQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByCAB_DESC(string value )
        {
            var query = _query.FirstByCAB_DESCQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByCAB_STATUS(int value )
        {
            var query = _query.FirstByCAB_STATUSQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

        public IEnumerable<CabvisaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CabvisaoDTO>(query.Query,query.Parameters) as List<CabvisaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration