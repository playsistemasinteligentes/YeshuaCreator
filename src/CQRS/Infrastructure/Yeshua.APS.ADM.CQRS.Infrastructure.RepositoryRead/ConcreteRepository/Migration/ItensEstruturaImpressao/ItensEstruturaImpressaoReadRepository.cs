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
    public partial class ItensEstruturaImpressaoReadRepository : IItensEstruturaImpressaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItensEstruturaImpressaoQueryRead _query;

        public ItensEstruturaImpressaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItensEstruturaImpressaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetItensEstruturaImpressaoCustom(Command.Read.ItensEstruturaImpressaoReadCommand command, ref DataPagination<ItensEstruturaImpressaoDTO> result, ref bool handled);

        public DataPagination<ItensEstruturaImpressaoDTO> getItensEstruturaImpressao(ICommandRead command )
         {
            if (command is Command.Read.ItensEstruturaImpressaoReadCommand c)
                return getItensEstruturaImpressao(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItensEstruturaImpressaoDTO> getItensEstruturaImpressao(Command.Read.ItensEstruturaImpressaoReadCommand command )
        {
            DataPagination<ItensEstruturaImpressaoDTO> customResult = null;
            var customHandled = false;
            TryGetItensEstruturaImpressaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ItensEstruturaImpressaoQuery(command );

                var itens = _unitOfWork.Query<ItensEstruturaImpressaoDTO>(query.Query,query.Parameters);
                return new DataPagination<ItensEstruturaImpressaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItensEstruturaImpressaoTenantIDDTO> getItensEstruturaImpressaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensEstruturaImpressaoTenantIDDTO> lista;
            var query = _query.ItensEstruturaImpressaoTenantIDQuery(command );

                lista = _unitOfWork.Query<ItensEstruturaImpressaoTenantIDDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItensEstruturaImpressaoTenantIDDTO> getItensEstruturaImpressaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensEstruturaImpressaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensEstruturaImpressaoUserIdDTO> getItensEstruturaImpressaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensEstruturaImpressaoUserIdDTO> lista;
            var query = _query.ItensEstruturaImpressaoUserIdQuery(command );

                lista = _unitOfWork.Query<ItensEstruturaImpressaoUserIdDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItensEstruturaImpressaoUserIdDTO> getItensEstruturaImpressaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensEstruturaImpressaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIES_CUSTOM_FONT_SIZE(int value )
        {
            var query = _query.ExistsByIES_CUSTOM_FONT_SIZEQuery(value );

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

        public ItensEstruturaImpressaoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensEstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensEstruturaImpressaoDTO FirstByIES_CUSTOM_FONT_SIZE(int value )
        {
            var query = _query.FirstByIES_CUSTOM_FONT_SIZEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensEstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensEstruturaImpressaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensEstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensEstruturaImpressaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensEstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensEstruturaImpressaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensEstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensEstruturaImpressaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensEstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ItensEstruturaImpressaoDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByIES_CUSTOM_FONT_SIZE(int value )
        {
            var query = _query.FirstByIES_CUSTOM_FONT_SIZEQuery(value );

                var result = _unitOfWork.Query<ItensEstruturaImpressaoDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItensEstruturaImpressaoDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItensEstruturaImpressaoDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItensEstruturaImpressaoDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItensEstruturaImpressaoDTO>(query.Query,query.Parameters) as List<ItensEstruturaImpressaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration