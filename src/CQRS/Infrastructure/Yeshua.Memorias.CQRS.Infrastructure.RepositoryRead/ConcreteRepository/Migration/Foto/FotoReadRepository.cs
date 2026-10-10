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
    public partial class FotoReadRepository : IFotoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IFotoQueryRead _query;

        public FotoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IFotoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetFotoCustom(Command.Read.FotoReadCommand command, ref DataPagination<FotoDTO> result, ref bool handled);

        public DataPagination<FotoDTO> getFoto(ICommandRead command )
         {
            if (command is Command.Read.FotoReadCommand c)
                return getFoto(c );
            throw new NotImplementedException();
        }
        private DataPagination<FotoDTO> getFoto(Command.Read.FotoReadCommand command )
        {
            var customResult = new DataPagination<FotoDTO>();
            var customHandled = false;
            TryGetFotoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.FotoQuery(command );

                var itens = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters);
                return new DataPagination<FotoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<FotoTenantIDDTO> getFotoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.FotoTenantIDQuery(command );

                var lista = _unitOfWork.Query<FotoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<FotoTenantIDDTO> getFotoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFotoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FotoUserIdDTO> getFotoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.FotoUserIdQuery(command );

                var lista = _unitOfWork.Query<FotoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<FotoUserIdDTO> getFotoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFotoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStorageKey(string value )
        {
            var query = _query.ExistsByStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNomeOriginal(string value )
        {
            var query = _query.ExistsByNomeOriginalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByContentType(string value )
        {
            var query = _query.ExistsByContentTypeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHashArquivo(string value )
        {
            var query = _query.ExistsByHashArquivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCapturadaEmUtc(DateTime value )
        {
            var query = _query.ExistsByCapturadaEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLargura(int value )
        {
            var query = _query.ExistsByLarguraQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAltura(int value )
        {
            var query = _query.ExistsByAlturaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperationalEntityId(string value )
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value );

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

        public FotoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByStorageKey(string value )
        {
            var query = _query.FirstByStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByNomeOriginal(string value )
        {
            var query = _query.FirstByNomeOriginalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByContentType(string value )
        {
            var query = _query.FirstByContentTypeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByHashArquivo(string value )
        {
            var query = _query.FirstByHashArquivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByCapturadaEmUtc(DateTime value )
        {
            var query = _query.FirstByCapturadaEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByLargura(int value )
        {
            var query = _query.FirstByLarguraQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByAltura(int value )
        {
            var query = _query.FirstByAlturaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FotoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<FotoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByStorageKey(string value )
        {
            var query = _query.FirstByStorageKeyQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByNomeOriginal(string value )
        {
            var query = _query.FirstByNomeOriginalQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByContentType(string value )
        {
            var query = _query.FirstByContentTypeQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByHashArquivo(string value )
        {
            var query = _query.FirstByHashArquivoQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByCapturadaEmUtc(DateTime value )
        {
            var query = _query.FirstByCapturadaEmUtcQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByLargura(int value )
        {
            var query = _query.FirstByLarguraQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByAltura(int value )
        {
            var query = _query.FirstByAlturaQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<FotoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<FotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration