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
    public partial class EstradasReadRepository : IEstradasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEstradasQueryRead _query;

        public EstradasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEstradasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetEstradasCustom(Command.Read.EstradasReadCommand command, ref DataPagination<EstradasDTO> result, ref bool handled);

        public DataPagination<EstradasDTO> getEstradas(ICommandRead command )
         {
            if (command is Command.Read.EstradasReadCommand c)
                return getEstradas(c );
            throw new NotImplementedException();
        }
        private DataPagination<EstradasDTO> getEstradas(Command.Read.EstradasReadCommand command )
        {
            DataPagination<EstradasDTO> customResult = null;
            var customHandled = false;
            TryGetEstradasCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.EstradasQuery(command );

                var itens = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters);
                return new DataPagination<EstradasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EstradasTenantIDDTO> getEstradasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstradasTenantIDDTO> lista;
            var query = _query.EstradasTenantIDQuery(command );

                lista = _unitOfWork.Query<EstradasTenantIDDTO>(query.Query,query.Parameters) as List<EstradasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EstradasTenantIDDTO> getEstradasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstradasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EstradasUserIdDTO> getEstradasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstradasUserIdDTO> lista;
            var query = _query.EstradasUserIdQuery(command );

                lista = _unitOfWork.Query<EstradasUserIdDTO>(query.Query,query.Parameters) as List<EstradasUserIdDTO>;
            return lista;
        }

        public IEnumerable<EstradasUserIdDTO> getEstradasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstradasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_ID(int value )
        {
            var query = _query.ExistsByEST_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_DESCRICAO(string value )
        {
            var query = _query.ExistsByEST_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_ID_LIGACAO_PONTO_A(int value )
        {
            var query = _query.ExistsByEST_ID_LIGACAO_PONTO_AQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_ID_LIGACAO_PONTO_B(int value )
        {
            var query = _query.ExistsByEST_ID_LIGACAO_PONTO_BQuery(value );

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

        public EstradasDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByEST_ID(int value )
        {
            var query = _query.FirstByEST_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByEST_DESCRICAO(string value )
        {
            var query = _query.FirstByEST_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByEST_ID_LIGACAO_PONTO_A(int value )
        {
            var query = _query.FirstByEST_ID_LIGACAO_PONTO_AQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByEST_ID_LIGACAO_PONTO_B(int value )
        {
            var query = _query.FirstByEST_ID_LIGACAO_PONTO_BQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstradasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstradasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByEST_ID(int value )
        {
            var query = _query.FirstByEST_IDQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByEST_DESCRICAO(string value )
        {
            var query = _query.FirstByEST_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByEST_ID_LIGACAO_PONTO_A(int value )
        {
            var query = _query.FirstByEST_ID_LIGACAO_PONTO_AQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByEST_ID_LIGACAO_PONTO_B(int value )
        {
            var query = _query.FirstByEST_ID_LIGACAO_PONTO_BQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

        public IEnumerable<EstradasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EstradasDTO>(query.Query,query.Parameters) as List<EstradasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration