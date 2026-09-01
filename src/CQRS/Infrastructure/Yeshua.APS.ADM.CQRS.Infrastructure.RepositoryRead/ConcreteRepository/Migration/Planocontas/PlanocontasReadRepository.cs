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
    public partial class PlanocontasReadRepository : IPlanocontasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPlanocontasQueryRead _query;

        public PlanocontasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPlanocontasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetPlanocontasCustom(Command.Read.PlanocontasReadCommand command, ref DataPagination<PlanocontasDTO> result, ref bool handled);

        public DataPagination<PlanocontasDTO> getPlanocontas(ICommandRead command )
         {
            if (command is Command.Read.PlanocontasReadCommand c)
                return getPlanocontas(c );
            throw new NotImplementedException();
        }
        private DataPagination<PlanocontasDTO> getPlanocontas(Command.Read.PlanocontasReadCommand command )
        {
            DataPagination<PlanocontasDTO> customResult = null;
            var customHandled = false;
            TryGetPlanocontasCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.PlanocontasQuery(command );

                var itens = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters);
                return new DataPagination<PlanocontasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PlanocontasTenantIDDTO> getPlanocontasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanocontasTenantIDDTO> lista;
            var query = _query.PlanocontasTenantIDQuery(command );

                lista = _unitOfWork.Query<PlanocontasTenantIDDTO>(query.Query,query.Parameters) as List<PlanocontasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PlanocontasTenantIDDTO> getPlanocontasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanocontasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PlanocontasUserIdDTO> getPlanocontasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanocontasUserIdDTO> lista;
            var query = _query.PlanocontasUserIdQuery(command );

                lista = _unitOfWork.Query<PlanocontasUserIdDTO>(query.Query,query.Parameters) as List<PlanocontasUserIdDTO>;
            return lista;
        }

        public IEnumerable<PlanocontasUserIdDTO> getPlanocontasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanocontasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPLA_ID(int value )
        {
            var query = _query.ExistsByPLA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_CODIGO(string value )
        {
            var query = _query.ExistsByPLA_CODIGOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_DESCRICAO(string value )
        {
            var query = _query.ExistsByPLA_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_TIPO(int value )
        {
            var query = _query.ExistsByPLA_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_NATUREZA(string value )
        {
            var query = _query.ExistsByPLA_NATUREZAQuery(value );

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

        public PlanocontasDTO FirstByPLA_ID(int value )
        {
            var query = _query.FirstByPLA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByPLA_CODIGO(string value )
        {
            var query = _query.FirstByPLA_CODIGOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByPLA_DESCRICAO(string value )
        {
            var query = _query.FirstByPLA_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByPLA_TIPO(int value )
        {
            var query = _query.FirstByPLA_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByPLA_NATUREZA(string value )
        {
            var query = _query.FirstByPLA_NATUREZAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanocontasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanocontasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByPLA_ID(int value )
        {
            var query = _query.FirstByPLA_IDQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByPLA_CODIGO(string value )
        {
            var query = _query.FirstByPLA_CODIGOQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByPLA_DESCRICAO(string value )
        {
            var query = _query.FirstByPLA_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByPLA_TIPO(int value )
        {
            var query = _query.FirstByPLA_TIPOQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByPLA_NATUREZA(string value )
        {
            var query = _query.FirstByPLA_NATUREZAQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

        public IEnumerable<PlanocontasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PlanocontasDTO>(query.Query,query.Parameters) as List<PlanocontasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration