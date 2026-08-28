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
    public partial class InpecaoVisualReadRepository : IInpecaoVisualReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IInpecaoVisualQueryRead _query;

        public InpecaoVisualReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IInpecaoVisualQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<InpecaoVisualDTO> getInpecaoVisual(ICommandRead command )
         {
            if (command is Command.Read.InpecaoVisualReadCommand c)
                return getInpecaoVisual(c );
            throw new NotImplementedException();
        }
        private DataPagination<InpecaoVisualDTO> getInpecaoVisual(Command.Read.InpecaoVisualReadCommand command )
        {
            var query = _query.InpecaoVisualQuery(command );

                var itens = _unitOfWork.Query<InpecaoVisualDTO>(query.Query,query.Parameters);
                return new DataPagination<InpecaoVisualDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<InpecaoVisualTenantIDDTO> getInpecaoVisualReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InpecaoVisualTenantIDDTO> lista;
            var query = _query.InpecaoVisualTenantIDQuery(command );

                lista = _unitOfWork.Query<InpecaoVisualTenantIDDTO>(query.Query,query.Parameters) as List<InpecaoVisualTenantIDDTO>;
            return lista;
        }

        public IEnumerable<InpecaoVisualTenantIDDTO> getInpecaoVisualReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInpecaoVisualReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<InpecaoVisualUserIdDTO> getInpecaoVisualReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InpecaoVisualUserIdDTO> lista;
            var query = _query.InpecaoVisualUserIdQuery(command );

                lista = _unitOfWork.Query<InpecaoVisualUserIdDTO>(query.Query,query.Parameters) as List<InpecaoVisualUserIdDTO>;
            return lista;
        }

        public IEnumerable<InpecaoVisualUserIdDTO> getInpecaoVisualReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInpecaoVisualReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_ID(int value )
        {
            var query = _query.ExistsByIPV_IDQuery(value );

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

        public InpecaoVisualDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InpecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InpecaoVisualDTO FirstByIPV_ID(int value )
        {
            var query = _query.FirstByIPV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InpecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InpecaoVisualDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InpecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InpecaoVisualDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InpecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InpecaoVisualDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InpecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InpecaoVisualDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InpecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<InpecaoVisualDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<InpecaoVisualDTO>(query.Query,query.Parameters) as List<InpecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InpecaoVisualDTO> GetAllByIPV_ID(int value )
        {
            var query = _query.FirstByIPV_IDQuery(value );

                var result = _unitOfWork.Query<InpecaoVisualDTO>(query.Query,query.Parameters) as List<InpecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InpecaoVisualDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<InpecaoVisualDTO>(query.Query,query.Parameters) as List<InpecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InpecaoVisualDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<InpecaoVisualDTO>(query.Query,query.Parameters) as List<InpecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InpecaoVisualDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<InpecaoVisualDTO>(query.Query,query.Parameters) as List<InpecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InpecaoVisualDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<InpecaoVisualDTO>(query.Query,query.Parameters) as List<InpecaoVisualDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration