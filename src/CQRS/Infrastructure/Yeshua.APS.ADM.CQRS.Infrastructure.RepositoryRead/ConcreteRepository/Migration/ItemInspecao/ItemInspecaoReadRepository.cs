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
    public partial class ItemInspecaoReadRepository : IItemInspecaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItemInspecaoQueryRead _query;

        public ItemInspecaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItemInspecaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ItemInspecaoDTO> getItemInspecao(ICommandRead command )
         {
            if (command is Command.Read.ItemInspecaoReadCommand c)
                return getItemInspecao(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItemInspecaoDTO> getItemInspecao(Command.Read.ItemInspecaoReadCommand command )
        {
            var query = _query.ItemInspecaoQuery(command );

                var itens = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters);
                return new DataPagination<ItemInspecaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItemInspecaoTenantIDDTO> getItemInspecaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItemInspecaoTenantIDDTO> lista;
            var query = _query.ItemInspecaoTenantIDQuery(command );

                lista = _unitOfWork.Query<ItemInspecaoTenantIDDTO>(query.Query,query.Parameters) as List<ItemInspecaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItemInspecaoTenantIDDTO> getItemInspecaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItemInspecaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItemInspecaoUserIdDTO> getItemInspecaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItemInspecaoUserIdDTO> lista;
            var query = _query.ItemInspecaoUserIdQuery(command );

                lista = _unitOfWork.Query<ItemInspecaoUserIdDTO>(query.Query,query.Parameters) as List<ItemInspecaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItemInspecaoUserIdDTO> getItemInspecaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItemInspecaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITI_ID(int value )
        {
            var query = _query.ExistsByITI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITI_DESC(string value )
        {
            var query = _query.ExistsByITI_DESCQuery(value );

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

        public ItemInspecaoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemInspecaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemInspecaoDTO FirstByITI_ID(int value )
        {
            var query = _query.FirstByITI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemInspecaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemInspecaoDTO FirstByITI_DESC(string value )
        {
            var query = _query.FirstByITI_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemInspecaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemInspecaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemInspecaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemInspecaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemInspecaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemInspecaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemInspecaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemInspecaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemInspecaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItemInspecaoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters) as List<ItemInspecaoDTO>;
                return result;
        }

        public IEnumerable<ItemInspecaoDTO> GetAllByITI_ID(int value )
        {
            var query = _query.FirstByITI_IDQuery(value );

                var result = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters) as List<ItemInspecaoDTO>;
                return result;
        }

        public IEnumerable<ItemInspecaoDTO> GetAllByITI_DESC(string value )
        {
            var query = _query.FirstByITI_DESCQuery(value );

                var result = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters) as List<ItemInspecaoDTO>;
                return result;
        }

        public IEnumerable<ItemInspecaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters) as List<ItemInspecaoDTO>;
                return result;
        }

        public IEnumerable<ItemInspecaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters) as List<ItemInspecaoDTO>;
                return result;
        }

        public IEnumerable<ItemInspecaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters) as List<ItemInspecaoDTO>;
                return result;
        }

        public IEnumerable<ItemInspecaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItemInspecaoDTO>(query.Query,query.Parameters) as List<ItemInspecaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration