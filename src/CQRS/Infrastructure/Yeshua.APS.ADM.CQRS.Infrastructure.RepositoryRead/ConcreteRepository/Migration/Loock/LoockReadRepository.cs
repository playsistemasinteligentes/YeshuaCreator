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
    public partial class LoockReadRepository : ILoockReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ILoockQueryRead _query;

        public LoockReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ILoockQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<LoockDTO> getLoock(ICommandRead command )
         {
            if (command is Command.Read.LoockReadCommand c)
                return getLoock(c );
            throw new NotImplementedException();
        }
        private DataPagination<LoockDTO> getLoock(Command.Read.LoockReadCommand command )
        {
            var query = _query.LoockQuery(command );

                var itens = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters);
                return new DataPagination<LoockDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<LoockTenantIDDTO> getLoockReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LoockTenantIDDTO> lista;
            var query = _query.LoockTenantIDQuery(command );

                lista = _unitOfWork.Query<LoockTenantIDDTO>(query.Query,query.Parameters) as List<LoockTenantIDDTO>;
            return lista;
        }

        public IEnumerable<LoockTenantIDDTO> getLoockReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLoockReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<LoockUserIdDTO> getLoockReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LoockUserIdDTO> lista;
            var query = _query.LoockUserIdQuery(command );

                lista = _unitOfWork.Query<LoockUserIdDTO>(query.Query,query.Parameters) as List<LoockUserIdDTO>;
            return lista;
        }

        public IEnumerable<LoockUserIdDTO> getLoockReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLoockReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOO_ID(string value )
        {
            var query = _query.ExistsByLOO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOO_DESCRICAO(string value )
        {
            var query = _query.ExistsByLOO_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOO_CONTEUDO(string value )
        {
            var query = _query.ExistsByLOO_CONTEUDOQuery(value );

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

        public LoockDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoockDTO FirstByLOO_ID(string value )
        {
            var query = _query.FirstByLOO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoockDTO FirstByLOO_DESCRICAO(string value )
        {
            var query = _query.FirstByLOO_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoockDTO FirstByLOO_CONTEUDO(string value )
        {
            var query = _query.FirstByLOO_CONTEUDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoockDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoockDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoockDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoockDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoockDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<LoockDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

        public IEnumerable<LoockDTO> GetAllByLOO_ID(string value )
        {
            var query = _query.FirstByLOO_IDQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

        public IEnumerable<LoockDTO> GetAllByLOO_DESCRICAO(string value )
        {
            var query = _query.FirstByLOO_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

        public IEnumerable<LoockDTO> GetAllByLOO_CONTEUDO(string value )
        {
            var query = _query.FirstByLOO_CONTEUDOQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

        public IEnumerable<LoockDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

        public IEnumerable<LoockDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

        public IEnumerable<LoockDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

        public IEnumerable<LoockDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<LoockDTO>(query.Query,query.Parameters) as List<LoockDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration