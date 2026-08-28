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
    public partial class RegistrosOnduladeiraReadRepository : IRegistrosOnduladeiraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRegistrosOnduladeiraQueryRead _query;

        public RegistrosOnduladeiraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRegistrosOnduladeiraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RegistrosOnduladeiraDTO> getRegistrosOnduladeira(ICommandRead command )
         {
            if (command is Command.Read.RegistrosOnduladeiraReadCommand c)
                return getRegistrosOnduladeira(c );
            throw new NotImplementedException();
        }
        private DataPagination<RegistrosOnduladeiraDTO> getRegistrosOnduladeira(Command.Read.RegistrosOnduladeiraReadCommand command )
        {
            var query = _query.RegistrosOnduladeiraQuery(command );

                var itens = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters);
                return new DataPagination<RegistrosOnduladeiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RegistrosOnduladeiraTenantIDDTO> getRegistrosOnduladeiraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RegistrosOnduladeiraTenantIDDTO> lista;
            var query = _query.RegistrosOnduladeiraTenantIDQuery(command );

                lista = _unitOfWork.Query<RegistrosOnduladeiraTenantIDDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RegistrosOnduladeiraTenantIDDTO> getRegistrosOnduladeiraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRegistrosOnduladeiraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RegistrosOnduladeiraUserIdDTO> getRegistrosOnduladeiraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RegistrosOnduladeiraUserIdDTO> lista;
            var query = _query.RegistrosOnduladeiraUserIdQuery(command );

                lista = _unitOfWork.Query<RegistrosOnduladeiraUserIdDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraUserIdDTO>;
            return lista;
        }

        public IEnumerable<RegistrosOnduladeiraUserIdDTO> getRegistrosOnduladeiraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRegistrosOnduladeiraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREG_ID(int value )
        {
            var query = _query.ExistsByREG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREG_RESPOSTA(string value )
        {
            var query = _query.ExistsByREG_RESPOSTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREG_STATUS(string value )
        {
            var query = _query.ExistsByREG_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREG_DATA_INICIO(DateTime value )
        {
            var query = _query.ExistsByREG_DATA_INICIOQuery(value );

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

        public RegistrosOnduladeiraDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByREG_ID(int value )
        {
            var query = _query.FirstByREG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByREG_RESPOSTA(string value )
        {
            var query = _query.FirstByREG_RESPOSTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByREG_STATUS(string value )
        {
            var query = _query.FirstByREG_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByREG_DATA_INICIO(DateTime value )
        {
            var query = _query.FirstByREG_DATA_INICIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public RegistrosOnduladeiraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RegistrosOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_ID(int value )
        {
            var query = _query.FirstByREG_IDQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_RESPOSTA(string value )
        {
            var query = _query.FirstByREG_RESPOSTAQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_STATUS(string value )
        {
            var query = _query.FirstByREG_STATUSQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_DATA_INICIO(DateTime value )
        {
            var query = _query.FirstByREG_DATA_INICIOQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RegistrosOnduladeiraDTO>(query.Query,query.Parameters) as List<RegistrosOnduladeiraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration