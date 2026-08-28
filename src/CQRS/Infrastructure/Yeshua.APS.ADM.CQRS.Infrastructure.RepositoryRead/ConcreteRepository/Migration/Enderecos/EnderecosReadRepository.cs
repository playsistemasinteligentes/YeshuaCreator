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
    public partial class EnderecosReadRepository : IEnderecosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEnderecosQueryRead _query;

        public EnderecosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEnderecosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<EnderecosDTO> getEnderecos(ICommandRead command )
         {
            if (command is Command.Read.EnderecosReadCommand c)
                return getEnderecos(c );
            throw new NotImplementedException();
        }
        private DataPagination<EnderecosDTO> getEnderecos(Command.Read.EnderecosReadCommand command )
        {
            var query = _query.EnderecosQuery(command );

                var itens = _unitOfWork.Query<EnderecosDTO>(query.Query,query.Parameters);
                return new DataPagination<EnderecosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EnderecosTenantIDDTO> getEnderecosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EnderecosTenantIDDTO> lista;
            var query = _query.EnderecosTenantIDQuery(command );

                lista = _unitOfWork.Query<EnderecosTenantIDDTO>(query.Query,query.Parameters) as List<EnderecosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EnderecosTenantIDDTO> getEnderecosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEnderecosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EnderecosUserIdDTO> getEnderecosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EnderecosUserIdDTO> lista;
            var query = _query.EnderecosUserIdQuery(command );

                lista = _unitOfWork.Query<EnderecosUserIdDTO>(query.Query,query.Parameters) as List<EnderecosUserIdDTO>;
            return lista;
        }

        public IEnumerable<EnderecosUserIdDTO> getEnderecosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEnderecosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByEND_ID(string value )
        {
            var query = _query.ExistsByEND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEND_GRUPO(string value )
        {
            var query = _query.ExistsByEND_GRUPOQuery(value );

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

        public EnderecosDTO FirstByEND_ID(string value )
        {
            var query = _query.FirstByEND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EnderecosDTO>(query.Query, query.Parameters);
                return result;
        }

        public EnderecosDTO FirstByEND_GRUPO(string value )
        {
            var query = _query.FirstByEND_GRUPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EnderecosDTO>(query.Query, query.Parameters);
                return result;
        }

        public EnderecosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EnderecosDTO>(query.Query, query.Parameters);
                return result;
        }

        public EnderecosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EnderecosDTO>(query.Query, query.Parameters);
                return result;
        }

        public EnderecosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EnderecosDTO>(query.Query, query.Parameters);
                return result;
        }

        public EnderecosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EnderecosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EnderecosDTO> GetAllByEND_ID(string value )
        {
            var query = _query.FirstByEND_IDQuery(value );

                var result = _unitOfWork.Query<EnderecosDTO>(query.Query,query.Parameters) as List<EnderecosDTO>;
                return result;
        }

        public IEnumerable<EnderecosDTO> GetAllByEND_GRUPO(string value )
        {
            var query = _query.FirstByEND_GRUPOQuery(value );

                var result = _unitOfWork.Query<EnderecosDTO>(query.Query,query.Parameters) as List<EnderecosDTO>;
                return result;
        }

        public IEnumerable<EnderecosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EnderecosDTO>(query.Query,query.Parameters) as List<EnderecosDTO>;
                return result;
        }

        public IEnumerable<EnderecosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EnderecosDTO>(query.Query,query.Parameters) as List<EnderecosDTO>;
                return result;
        }

        public IEnumerable<EnderecosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EnderecosDTO>(query.Query,query.Parameters) as List<EnderecosDTO>;
                return result;
        }

        public IEnumerable<EnderecosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EnderecosDTO>(query.Query,query.Parameters) as List<EnderecosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration