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
    public partial class T_PREFERENCIASReadRepository : IT_PREFERENCIASReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_PREFERENCIASQueryRead _query;

        public T_PREFERENCIASReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_PREFERENCIASQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<T_PREFERENCIASDTO> getT_PREFERENCIAS(ICommandRead command )
         {
            if (command is Command.Read.T_PREFERENCIASReadCommand c)
                return getT_PREFERENCIAS(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_PREFERENCIASDTO> getT_PREFERENCIAS(Command.Read.T_PREFERENCIASReadCommand command )
        {
            var query = _query.T_PREFERENCIASQuery(command );

                var itens = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters);
                return new DataPagination<T_PREFERENCIASDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_PREFERENCIASTenantIDDTO> getT_PREFERENCIASReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_PREFERENCIASTenantIDDTO> lista;
            var query = _query.T_PREFERENCIASTenantIDQuery(command );

                lista = _unitOfWork.Query<T_PREFERENCIASTenantIDDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_PREFERENCIASTenantIDDTO> getT_PREFERENCIASReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_PREFERENCIASReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_PREFERENCIASUserIdDTO> getT_PREFERENCIASReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_PREFERENCIASUserIdDTO> lista;
            var query = _query.T_PREFERENCIASUserIdQuery(command );

                lista = _unitOfWork.Query<T_PREFERENCIASUserIdDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_PREFERENCIASUserIdDTO> getT_PREFERENCIASReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_PREFERENCIASReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRE_ID(int value )
        {
            var query = _query.ExistsByPRE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRE_DESCRICAO(string value )
        {
            var query = _query.ExistsByPRE_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRE_NAMESPACE(string value )
        {
            var query = _query.ExistsByPRE_NAMESPACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRE_TIPO(string value )
        {
            var query = _query.ExistsByPRE_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRE_VALOR(string value )
        {
            var query = _query.ExistsByPRE_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(int value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

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

        public T_PREFERENCIASDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByPRE_ID(int value )
        {
            var query = _query.FirstByPRE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByPRE_DESCRICAO(string value )
        {
            var query = _query.FirstByPRE_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByPRE_NAMESPACE(string value )
        {
            var query = _query.FirstByPRE_NAMESPACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByPRE_TIPO(string value )
        {
            var query = _query.FirstByPRE_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByPRE_VALOR(string value )
        {
            var query = _query.FirstByPRE_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_PREFERENCIASDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_PREFERENCIASDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_ID(int value )
        {
            var query = _query.FirstByPRE_IDQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_DESCRICAO(string value )
        {
            var query = _query.FirstByPRE_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_NAMESPACE(string value )
        {
            var query = _query.FirstByPRE_NAMESPACEQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_TIPO(string value )
        {
            var query = _query.FirstByPRE_TIPOQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_VALOR(string value )
        {
            var query = _query.FirstByPRE_VALORQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

        public IEnumerable<T_PREFERENCIASDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_PREFERENCIASDTO>(query.Query,query.Parameters) as List<T_PREFERENCIASDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration