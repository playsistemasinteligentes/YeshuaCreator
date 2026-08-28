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
    public partial class ImpressoraReadRepository : IImpressoraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IImpressoraQueryRead _query;

        public ImpressoraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IImpressoraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ImpressoraDTO> getImpressora(ICommandRead command )
         {
            if (command is Command.Read.ImpressoraReadCommand c)
                return getImpressora(c );
            throw new NotImplementedException();
        }
        private DataPagination<ImpressoraDTO> getImpressora(Command.Read.ImpressoraReadCommand command )
        {
            var query = _query.ImpressoraQuery(command );

                var itens = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters);
                return new DataPagination<ImpressoraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ImpressoraTenantIDDTO> getImpressoraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ImpressoraTenantIDDTO> lista;
            var query = _query.ImpressoraTenantIDQuery(command );

                lista = _unitOfWork.Query<ImpressoraTenantIDDTO>(query.Query,query.Parameters) as List<ImpressoraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ImpressoraTenantIDDTO> getImpressoraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getImpressoraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ImpressoraUserIdDTO> getImpressoraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ImpressoraUserIdDTO> lista;
            var query = _query.ImpressoraUserIdQuery(command );

                lista = _unitOfWork.Query<ImpressoraUserIdDTO>(query.Query,query.Parameters) as List<ImpressoraUserIdDTO>;
            return lista;
        }

        public IEnumerable<ImpressoraUserIdDTO> getImpressoraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getImpressoraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByIMP_ID(int value )
        {
            var query = _query.ExistsByIMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIMP_IP(string value )
        {
            var query = _query.ExistsByIMP_IPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIMP_NOME(string value )
        {
            var query = _query.ExistsByIMP_NOMEQuery(value );

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

        public ImpressoraDTO FirstByIMP_ID(int value )
        {
            var query = _query.FirstByIMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ImpressoraDTO FirstByIMP_IP(string value )
        {
            var query = _query.FirstByIMP_IPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ImpressoraDTO FirstByIMP_NOME(string value )
        {
            var query = _query.FirstByIMP_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ImpressoraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ImpressoraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ImpressoraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public ImpressoraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ImpressoraDTO> GetAllByIMP_ID(int value )
        {
            var query = _query.FirstByIMP_IDQuery(value );

                var result = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters) as List<ImpressoraDTO>;
                return result;
        }

        public IEnumerable<ImpressoraDTO> GetAllByIMP_IP(string value )
        {
            var query = _query.FirstByIMP_IPQuery(value );

                var result = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters) as List<ImpressoraDTO>;
                return result;
        }

        public IEnumerable<ImpressoraDTO> GetAllByIMP_NOME(string value )
        {
            var query = _query.FirstByIMP_NOMEQuery(value );

                var result = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters) as List<ImpressoraDTO>;
                return result;
        }

        public IEnumerable<ImpressoraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters) as List<ImpressoraDTO>;
                return result;
        }

        public IEnumerable<ImpressoraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters) as List<ImpressoraDTO>;
                return result;
        }

        public IEnumerable<ImpressoraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters) as List<ImpressoraDTO>;
                return result;
        }

        public IEnumerable<ImpressoraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ImpressoraDTO>(query.Query,query.Parameters) as List<ImpressoraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration