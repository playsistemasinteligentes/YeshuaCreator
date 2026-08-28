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
    public partial class MesesReadRepository : IMesesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMesesQueryRead _query;

        public MesesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMesesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MesesDTO> getMeses(ICommandRead command )
         {
            if (command is Command.Read.MesesReadCommand c)
                return getMeses(c );
            throw new NotImplementedException();
        }
        private DataPagination<MesesDTO> getMeses(Command.Read.MesesReadCommand command )
        {
            var query = _query.MesesQuery(command );

                var itens = _unitOfWork.Query<MesesDTO>(query.Query,query.Parameters);
                return new DataPagination<MesesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MesesTenantIDDTO> getMesesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MesesTenantIDDTO> lista;
            var query = _query.MesesTenantIDQuery(command );

                lista = _unitOfWork.Query<MesesTenantIDDTO>(query.Query,query.Parameters) as List<MesesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MesesTenantIDDTO> getMesesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMesesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MesesUserIdDTO> getMesesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MesesUserIdDTO> lista;
            var query = _query.MesesUserIdQuery(command );

                lista = _unitOfWork.Query<MesesUserIdDTO>(query.Query,query.Parameters) as List<MesesUserIdDTO>;
            return lista;
        }

        public IEnumerable<MesesUserIdDTO> getMesesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMesesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByMES(string value )
        {
            var query = _query.ExistsByMESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByfator(int value )
        {
            var query = _query.ExistsByfatorQuery(value );

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

        public MesesDTO FirstByMES(string value )
        {
            var query = _query.FirstByMESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MesesDTO>(query.Query, query.Parameters);
                return result;
        }

        public MesesDTO FirstByfator(int value )
        {
            var query = _query.FirstByfatorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MesesDTO>(query.Query, query.Parameters);
                return result;
        }

        public MesesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MesesDTO>(query.Query, query.Parameters);
                return result;
        }

        public MesesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MesesDTO>(query.Query, query.Parameters);
                return result;
        }

        public MesesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MesesDTO>(query.Query, query.Parameters);
                return result;
        }

        public MesesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MesesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MesesDTO> GetAllByMES(string value )
        {
            var query = _query.FirstByMESQuery(value );

                var result = _unitOfWork.Query<MesesDTO>(query.Query,query.Parameters) as List<MesesDTO>;
                return result;
        }

        public IEnumerable<MesesDTO> GetAllByfator(int value )
        {
            var query = _query.FirstByfatorQuery(value );

                var result = _unitOfWork.Query<MesesDTO>(query.Query,query.Parameters) as List<MesesDTO>;
                return result;
        }

        public IEnumerable<MesesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MesesDTO>(query.Query,query.Parameters) as List<MesesDTO>;
                return result;
        }

        public IEnumerable<MesesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MesesDTO>(query.Query,query.Parameters) as List<MesesDTO>;
                return result;
        }

        public IEnumerable<MesesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MesesDTO>(query.Query,query.Parameters) as List<MesesDTO>;
                return result;
        }

        public IEnumerable<MesesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MesesDTO>(query.Query,query.Parameters) as List<MesesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration