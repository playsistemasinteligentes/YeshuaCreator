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
    public partial class yTenantModuleReadRepository : IyTenantModuleReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyTenantModuleQueryRead _query;

        public yTenantModuleReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyTenantModuleQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetyTenantModuleCustom(Command.Read.yTenantModuleReadCommand command, ref DataPagination<yTenantModuleDTO> result, ref bool handled);

        public DataPagination<yTenantModuleDTO> getyTenantModule(ICommandRead command )
         {
            if (command is Command.Read.yTenantModuleReadCommand c)
                return getyTenantModule(c );
            throw new NotImplementedException();
        }
        private DataPagination<yTenantModuleDTO> getyTenantModule(Command.Read.yTenantModuleReadCommand command )
        {
            var customResult = new DataPagination<yTenantModuleDTO>();
            var customHandled = false;
            TryGetyTenantModuleCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.yTenantModuleQuery(command );

                var itens = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters);
                return new DataPagination<yTenantModuleDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yTenantModuleModuleIdDTO> getyTenantModuleReadFKModuleId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yTenantModuleModuleIdQuery(command );

                var lista = _unitOfWork.Query<yTenantModuleModuleIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yTenantModuleModuleIdDTO> getyTenantModuleReadFKModuleId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyTenantModuleReadFKModuleId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yTenantModuleTenantIDDTO> getyTenantModuleReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yTenantModuleTenantIDQuery(command );

                var lista = _unitOfWork.Query<yTenantModuleTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yTenantModuleTenantIDDTO> getyTenantModuleReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyTenantModuleReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yTenantModuleUserIdDTO> getyTenantModuleReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yTenantModuleUserIdQuery(command );

                var lista = _unitOfWork.Query<yTenantModuleUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yTenantModuleUserIdDTO> getyTenantModuleReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyTenantModuleReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByModuleId(string value )
        {
            var query = _query.ExistsByModuleIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidUntil(DateTime value )
        {
            var query = _query.ExistsByValidUntilQuery(value );

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

        public yTenantModuleDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantModuleDTO FirstByModuleId(string value )
        {
            var query = _query.FirstByModuleIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantModuleDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantModuleDTO FirstByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantModuleDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantModuleDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantModuleDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yTenantModuleDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantModuleDTO> GetAllByModuleId(string value )
        {
            var query = _query.FirstByModuleIdQuery(value );

                var result = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantModuleDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantModuleDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantModuleDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantModuleDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantModuleDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<yTenantModuleDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration