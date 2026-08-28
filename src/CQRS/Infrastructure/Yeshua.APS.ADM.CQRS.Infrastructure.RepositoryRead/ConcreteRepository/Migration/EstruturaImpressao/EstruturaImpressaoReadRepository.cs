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
    public partial class EstruturaImpressaoReadRepository : IEstruturaImpressaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEstruturaImpressaoQueryRead _query;

        public EstruturaImpressaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEstruturaImpressaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<EstruturaImpressaoDTO> getEstruturaImpressao(ICommandRead command )
         {
            if (command is Command.Read.EstruturaImpressaoReadCommand c)
                return getEstruturaImpressao(c );
            throw new NotImplementedException();
        }
        private DataPagination<EstruturaImpressaoDTO> getEstruturaImpressao(Command.Read.EstruturaImpressaoReadCommand command )
        {
            var query = _query.EstruturaImpressaoQuery(command );

                var itens = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters);
                return new DataPagination<EstruturaImpressaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EstruturaImpressaoCLI_IDDTO> getEstruturaImpressaoReadFKCLI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaImpressaoCLI_IDDTO> lista;
            var query = _query.EstruturaImpressaoCLI_IDQuery(command );

                lista = _unitOfWork.Query<EstruturaImpressaoCLI_IDDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoCLI_IDDTO>;
            return lista;
        }

        public IEnumerable<EstruturaImpressaoCLI_IDDTO> getEstruturaImpressaoReadFKCLI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaImpressaoReadFKCLI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EstruturaImpressaoTenantIDDTO> getEstruturaImpressaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaImpressaoTenantIDDTO> lista;
            var query = _query.EstruturaImpressaoTenantIDQuery(command );

                lista = _unitOfWork.Query<EstruturaImpressaoTenantIDDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EstruturaImpressaoTenantIDDTO> getEstruturaImpressaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaImpressaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EstruturaImpressaoUserIdDTO> getEstruturaImpressaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaImpressaoUserIdDTO> lista;
            var query = _query.EstruturaImpressaoUserIdQuery(command );

                lista = _unitOfWork.Query<EstruturaImpressaoUserIdDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<EstruturaImpressaoUserIdDTO> getEstruturaImpressaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaImpressaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByEST_ID(int value )
        {
            var query = _query.ExistsByEST_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHTML_ESTRUTURA(string value )
        {
            var query = _query.ExistsByHTML_ESTRUTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_DESCRICAO(string value )
        {
            var query = _query.ExistsByEST_DESCRICAOQuery(value );

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

        public EstruturaImpressaoDTO FirstByEST_ID(int value )
        {
            var query = _query.FirstByEST_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaImpressaoDTO FirstByHTML_ESTRUTURA(string value )
        {
            var query = _query.FirstByHTML_ESTRUTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaImpressaoDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaImpressaoDTO FirstByEST_DESCRICAO(string value )
        {
            var query = _query.FirstByEST_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaImpressaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaImpressaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaImpressaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaImpressaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaImpressaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByEST_ID(int value )
        {
            var query = _query.FirstByEST_IDQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByHTML_ESTRUTURA(string value )
        {
            var query = _query.FirstByHTML_ESTRUTURAQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByEST_DESCRICAO(string value )
        {
            var query = _query.FirstByEST_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

        public IEnumerable<EstruturaImpressaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EstruturaImpressaoDTO>(query.Query,query.Parameters) as List<EstruturaImpressaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration