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
    public partial class Unidade_UnidadeReadRepository : IUnidade_UnidadeReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUnidade_UnidadeQueryRead _query;

        public Unidade_UnidadeReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUnidade_UnidadeQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetUnidade_UnidadeCustom(Command.Read.Unidade_UnidadeReadCommand command, ref DataPagination<Unidade_UnidadeDTO> result, ref bool handled);

        public DataPagination<Unidade_UnidadeDTO> getUnidade_Unidade(ICommandRead command )
         {
            if (command is Command.Read.Unidade_UnidadeReadCommand c)
                return getUnidade_Unidade(c );
            throw new NotImplementedException();
        }
        private DataPagination<Unidade_UnidadeDTO> getUnidade_Unidade(Command.Read.Unidade_UnidadeReadCommand command )
        {
            DataPagination<Unidade_UnidadeDTO> customResult = null;
            var customHandled = false;
            TryGetUnidade_UnidadeCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.Unidade_UnidadeQuery(command );

                var itens = _unitOfWork.Query<Unidade_UnidadeDTO>(query.Query,query.Parameters);
                return new DataPagination<Unidade_UnidadeDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<Unidade_UnidadeTenantIDDTO> getUnidade_UnidadeReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<Unidade_UnidadeTenantIDDTO> lista;
            var query = _query.Unidade_UnidadeTenantIDQuery(command );

                lista = _unitOfWork.Query<Unidade_UnidadeTenantIDDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeTenantIDDTO>;
            return lista;
        }

        public IEnumerable<Unidade_UnidadeTenantIDDTO> getUnidade_UnidadeReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUnidade_UnidadeReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<Unidade_UnidadeUserIdDTO> getUnidade_UnidadeReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<Unidade_UnidadeUserIdDTO> lista;
            var query = _query.Unidade_UnidadeUserIdQuery(command );

                lista = _unitOfWork.Query<Unidade_UnidadeUserIdDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeUserIdDTO>;
            return lista;
        }

        public IEnumerable<Unidade_UnidadeUserIdDTO> getUnidade_UnidadeReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUnidade_UnidadeReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByUNI_ID(int value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_DESCRICAO(string value )
        {
            var query = _query.ExistsByUNI_DESCRICAOQuery(value );

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

        public Unidade_UnidadeDTO FirstByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<Unidade_UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public Unidade_UnidadeDTO FirstByUNI_DESCRICAO(string value )
        {
            var query = _query.FirstByUNI_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<Unidade_UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public Unidade_UnidadeDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<Unidade_UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public Unidade_UnidadeDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<Unidade_UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public Unidade_UnidadeDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<Unidade_UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public Unidade_UnidadeDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<Unidade_UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<Unidade_UnidadeDTO> GetAllByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<Unidade_UnidadeDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeDTO>;
                return result;
        }

        public IEnumerable<Unidade_UnidadeDTO> GetAllByUNI_DESCRICAO(string value )
        {
            var query = _query.FirstByUNI_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<Unidade_UnidadeDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeDTO>;
                return result;
        }

        public IEnumerable<Unidade_UnidadeDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<Unidade_UnidadeDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeDTO>;
                return result;
        }

        public IEnumerable<Unidade_UnidadeDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<Unidade_UnidadeDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeDTO>;
                return result;
        }

        public IEnumerable<Unidade_UnidadeDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<Unidade_UnidadeDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeDTO>;
                return result;
        }

        public IEnumerable<Unidade_UnidadeDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<Unidade_UnidadeDTO>(query.Query,query.Parameters) as List<Unidade_UnidadeDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration