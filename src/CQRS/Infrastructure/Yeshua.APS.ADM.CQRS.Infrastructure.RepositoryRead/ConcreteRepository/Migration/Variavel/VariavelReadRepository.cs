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
    public partial class VariavelReadRepository : IVariavelReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IVariavelQueryRead _query;

        public VariavelReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IVariavelQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<VariavelDTO> getVariavel(ICommandRead command )
         {
            if (command is Command.Read.VariavelReadCommand c)
                return getVariavel(c );
            throw new NotImplementedException();
        }
        private DataPagination<VariavelDTO> getVariavel(Command.Read.VariavelReadCommand command )
        {
            var query = _query.VariavelQuery(command );

                var itens = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters);
                return new DataPagination<VariavelDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<VariavelTenantIDDTO> getVariavelReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VariavelTenantIDDTO> lista;
            var query = _query.VariavelTenantIDQuery(command );

                lista = _unitOfWork.Query<VariavelTenantIDDTO>(query.Query,query.Parameters) as List<VariavelTenantIDDTO>;
            return lista;
        }

        public IEnumerable<VariavelTenantIDDTO> getVariavelReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVariavelReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VariavelUserIdDTO> getVariavelReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VariavelUserIdDTO> lista;
            var query = _query.VariavelUserIdQuery(command );

                lista = _unitOfWork.Query<VariavelUserIdDTO>(query.Query,query.Parameters) as List<VariavelUserIdDTO>;
            return lista;
        }

        public IEnumerable<VariavelUserIdDTO> getVariavelReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVariavelReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVAR_ID(int value )
        {
            var query = _query.ExistsByVAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVAR_DESCRICAO(string value )
        {
            var query = _query.ExistsByVAR_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_ID(int value )
        {
            var query = _query.ExistsByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVAR_MODO(int value )
        {
            var query = _query.ExistsByVAR_MODOQuery(value );

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

        public VariavelDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByVAR_ID(int value )
        {
            var query = _query.FirstByVAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByVAR_DESCRICAO(string value )
        {
            var query = _query.FirstByVAR_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByVAR_MODO(int value )
        {
            var query = _query.FirstByVAR_MODOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByVAR_ID(int value )
        {
            var query = _query.FirstByVAR_IDQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByVAR_DESCRICAO(string value )
        {
            var query = _query.FirstByVAR_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByVAR_MODO(int value )
        {
            var query = _query.FirstByVAR_MODOQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

        public IEnumerable<VariavelDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<VariavelDTO>(query.Query,query.Parameters) as List<VariavelDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration