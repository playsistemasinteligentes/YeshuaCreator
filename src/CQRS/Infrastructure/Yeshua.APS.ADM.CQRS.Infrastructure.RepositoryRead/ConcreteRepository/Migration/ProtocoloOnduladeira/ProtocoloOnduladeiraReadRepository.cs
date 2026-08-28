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
    public partial class ProtocoloOnduladeiraReadRepository : IProtocoloOnduladeiraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IProtocoloOnduladeiraQueryRead _query;

        public ProtocoloOnduladeiraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IProtocoloOnduladeiraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ProtocoloOnduladeiraDTO> getProtocoloOnduladeira(ICommandRead command )
         {
            if (command is Command.Read.ProtocoloOnduladeiraReadCommand c)
                return getProtocoloOnduladeira(c );
            throw new NotImplementedException();
        }
        private DataPagination<ProtocoloOnduladeiraDTO> getProtocoloOnduladeira(Command.Read.ProtocoloOnduladeiraReadCommand command )
        {
            var query = _query.ProtocoloOnduladeiraQuery(command );

                var itens = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters);
                return new DataPagination<ProtocoloOnduladeiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ProtocoloOnduladeiraTenantIDDTO> getProtocoloOnduladeiraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProtocoloOnduladeiraTenantIDDTO> lista;
            var query = _query.ProtocoloOnduladeiraTenantIDQuery(command );

                lista = _unitOfWork.Query<ProtocoloOnduladeiraTenantIDDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ProtocoloOnduladeiraTenantIDDTO> getProtocoloOnduladeiraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProtocoloOnduladeiraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProtocoloOnduladeiraUserIdDTO> getProtocoloOnduladeiraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProtocoloOnduladeiraUserIdDTO> lista;
            var query = _query.ProtocoloOnduladeiraUserIdQuery(command );

                lista = _unitOfWork.Query<ProtocoloOnduladeiraUserIdDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraUserIdDTO>;
            return lista;
        }

        public IEnumerable<ProtocoloOnduladeiraUserIdDTO> getProtocoloOnduladeiraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProtocoloOnduladeiraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPTO_ID(string value )
        {
            var query = _query.ExistsByPTO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPTO_CHAVE(string value )
        {
            var query = _query.ExistsByPTO_CHAVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPTO_COMANDO(string value )
        {
            var query = _query.ExistsByPTO_COMANDOQuery(value );

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

        public ProtocoloOnduladeiraDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByPTO_ID(string value )
        {
            var query = _query.FirstByPTO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByPTO_CHAVE(string value )
        {
            var query = _query.FirstByPTO_CHAVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByPTO_COMANDO(string value )
        {
            var query = _query.FirstByPTO_COMANDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProtocoloOnduladeiraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProtocoloOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByPTO_ID(string value )
        {
            var query = _query.FirstByPTO_IDQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByPTO_CHAVE(string value )
        {
            var query = _query.FirstByPTO_CHAVEQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByPTO_COMANDO(string value )
        {
            var query = _query.FirstByPTO_COMANDOQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ProtocoloOnduladeiraDTO>(query.Query,query.Parameters) as List<ProtocoloOnduladeiraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration