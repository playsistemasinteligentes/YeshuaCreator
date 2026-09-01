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
    public partial class SegmentosProdutosReadRepository : ISegmentosProdutosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ISegmentosProdutosQueryRead _query;

        public SegmentosProdutosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ISegmentosProdutosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetSegmentosProdutosCustom(Command.Read.SegmentosProdutosReadCommand command, ref DataPagination<SegmentosProdutosDTO> result, ref bool handled);

        public DataPagination<SegmentosProdutosDTO> getSegmentosProdutos(ICommandRead command )
         {
            if (command is Command.Read.SegmentosProdutosReadCommand c)
                return getSegmentosProdutos(c );
            throw new NotImplementedException();
        }
        private DataPagination<SegmentosProdutosDTO> getSegmentosProdutos(Command.Read.SegmentosProdutosReadCommand command )
        {
            DataPagination<SegmentosProdutosDTO> customResult = null;
            var customHandled = false;
            TryGetSegmentosProdutosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.SegmentosProdutosQuery(command );

                var itens = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters);
                return new DataPagination<SegmentosProdutosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<SegmentosProdutosTenantIDDTO> getSegmentosProdutosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SegmentosProdutosTenantIDDTO> lista;
            var query = _query.SegmentosProdutosTenantIDQuery(command );

                lista = _unitOfWork.Query<SegmentosProdutosTenantIDDTO>(query.Query,query.Parameters) as List<SegmentosProdutosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<SegmentosProdutosTenantIDDTO> getSegmentosProdutosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSegmentosProdutosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SegmentosProdutosUserIdDTO> getSegmentosProdutosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SegmentosProdutosUserIdDTO> lista;
            var query = _query.SegmentosProdutosUserIdQuery(command );

                lista = _unitOfWork.Query<SegmentosProdutosUserIdDTO>(query.Query,query.Parameters) as List<SegmentosProdutosUserIdDTO>;
            return lista;
        }

        public IEnumerable<SegmentosProdutosUserIdDTO> getSegmentosProdutosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSegmentosProdutosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRS_ID(string value )
        {
            var query = _query.ExistsByGRS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEG_ID(string value )
        {
            var query = _query.ExistsBySEG_IDQuery(value );

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

        public SegmentosProdutosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentosProdutosDTO FirstByGRS_ID(string value )
        {
            var query = _query.FirstByGRS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentosProdutosDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentosProdutosDTO FirstBySEG_ID(string value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentosProdutosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentosProdutosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentosProdutosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentosProdutosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentosProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllByGRS_ID(string value )
        {
            var query = _query.FirstByGRS_IDQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllBySEG_ID(string value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

        public IEnumerable<SegmentosProdutosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<SegmentosProdutosDTO>(query.Query,query.Parameters) as List<SegmentosProdutosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration