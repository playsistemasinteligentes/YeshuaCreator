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
    public partial class TabelaReadRepository : ITabelaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITabelaQueryRead _query;

        public TabelaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITabelaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTabelaCustom(Command.Read.TabelaReadCommand command, ref DataPagination<TabelaDTO> result, ref bool handled);

        public DataPagination<TabelaDTO> getTabela(ICommandRead command )
         {
            if (command is Command.Read.TabelaReadCommand c)
                return getTabela(c );
            throw new NotImplementedException();
        }
        private DataPagination<TabelaDTO> getTabela(Command.Read.TabelaReadCommand command )
        {
            DataPagination<TabelaDTO> customResult = null;
            var customHandled = false;
            TryGetTabelaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TabelaQuery(command );

                var itens = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters);
                return new DataPagination<TabelaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TabelaTenantIDDTO> getTabelaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TabelaTenantIDDTO> lista;
            var query = _query.TabelaTenantIDQuery(command );

                lista = _unitOfWork.Query<TabelaTenantIDDTO>(query.Query,query.Parameters) as List<TabelaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TabelaTenantIDDTO> getTabelaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTabelaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TabelaUserIdDTO> getTabelaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TabelaUserIdDTO> lista;
            var query = _query.TabelaUserIdQuery(command );

                lista = _unitOfWork.Query<TabelaUserIdDTO>(query.Query,query.Parameters) as List<TabelaUserIdDTO>;
            return lista;
        }

        public IEnumerable<TabelaUserIdDTO> getTabelaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTabelaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByID_TABELA(int value )
        {
            var query = _query.ExistsByID_TABELAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCODIGO(string value )
        {
            var query = _query.ExistsByCODIGOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNOME(string value )
        {
            var query = _query.ExistsByNOMEQuery(value );

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

        public TabelaDTO FirstByID_TABELA(int value )
        {
            var query = _query.FirstByID_TABELAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TabelaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TabelaDTO FirstByCODIGO(string value )
        {
            var query = _query.FirstByCODIGOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TabelaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TabelaDTO FirstByNOME(string value )
        {
            var query = _query.FirstByNOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TabelaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TabelaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TabelaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TabelaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TabelaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TabelaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TabelaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TabelaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TabelaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TabelaDTO> GetAllByID_TABELA(int value )
        {
            var query = _query.FirstByID_TABELAQuery(value );

                var result = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters) as List<TabelaDTO>;
                return result;
        }

        public IEnumerable<TabelaDTO> GetAllByCODIGO(string value )
        {
            var query = _query.FirstByCODIGOQuery(value );

                var result = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters) as List<TabelaDTO>;
                return result;
        }

        public IEnumerable<TabelaDTO> GetAllByNOME(string value )
        {
            var query = _query.FirstByNOMEQuery(value );

                var result = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters) as List<TabelaDTO>;
                return result;
        }

        public IEnumerable<TabelaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters) as List<TabelaDTO>;
                return result;
        }

        public IEnumerable<TabelaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters) as List<TabelaDTO>;
                return result;
        }

        public IEnumerable<TabelaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters) as List<TabelaDTO>;
                return result;
        }

        public IEnumerable<TabelaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TabelaDTO>(query.Query,query.Parameters) as List<TabelaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration