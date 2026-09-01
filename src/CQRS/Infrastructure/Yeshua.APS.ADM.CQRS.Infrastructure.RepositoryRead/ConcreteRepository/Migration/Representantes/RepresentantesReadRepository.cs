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
    public partial class RepresentantesReadRepository : IRepresentantesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRepresentantesQueryRead _query;

        public RepresentantesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRepresentantesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetRepresentantesCustom(Command.Read.RepresentantesReadCommand command, ref DataPagination<RepresentantesDTO> result, ref bool handled);

        public DataPagination<RepresentantesDTO> getRepresentantes(ICommandRead command )
         {
            if (command is Command.Read.RepresentantesReadCommand c)
                return getRepresentantes(c );
            throw new NotImplementedException();
        }
        private DataPagination<RepresentantesDTO> getRepresentantes(Command.Read.RepresentantesReadCommand command )
        {
            DataPagination<RepresentantesDTO> customResult = null;
            var customHandled = false;
            TryGetRepresentantesCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.RepresentantesQuery(command );

                var itens = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters);
                return new DataPagination<RepresentantesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RepresentantesTenantIDDTO> getRepresentantesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RepresentantesTenantIDDTO> lista;
            var query = _query.RepresentantesTenantIDQuery(command );

                lista = _unitOfWork.Query<RepresentantesTenantIDDTO>(query.Query,query.Parameters) as List<RepresentantesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RepresentantesTenantIDDTO> getRepresentantesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRepresentantesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RepresentantesUserIdDTO> getRepresentantesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RepresentantesUserIdDTO> lista;
            var query = _query.RepresentantesUserIdQuery(command );

                lista = _unitOfWork.Query<RepresentantesUserIdDTO>(query.Query,query.Parameters) as List<RepresentantesUserIdDTO>;
            return lista;
        }

        public IEnumerable<RepresentantesUserIdDTO> getRepresentantesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRepresentantesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREP_ID(int value )
        {
            var query = _query.ExistsByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREP_NOME(string value )
        {
            var query = _query.ExistsByREP_NOMEQuery(value );

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

        public RepresentantesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RepresentantesDTO>(query.Query, query.Parameters);
                return result;
        }

        public RepresentantesDTO FirstByREP_ID(int value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RepresentantesDTO>(query.Query, query.Parameters);
                return result;
        }

        public RepresentantesDTO FirstByREP_NOME(string value )
        {
            var query = _query.FirstByREP_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RepresentantesDTO>(query.Query, query.Parameters);
                return result;
        }

        public RepresentantesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RepresentantesDTO>(query.Query, query.Parameters);
                return result;
        }

        public RepresentantesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RepresentantesDTO>(query.Query, query.Parameters);
                return result;
        }

        public RepresentantesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RepresentantesDTO>(query.Query, query.Parameters);
                return result;
        }

        public RepresentantesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RepresentantesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RepresentantesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters) as List<RepresentantesDTO>;
                return result;
        }

        public IEnumerable<RepresentantesDTO> GetAllByREP_ID(int value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters) as List<RepresentantesDTO>;
                return result;
        }

        public IEnumerable<RepresentantesDTO> GetAllByREP_NOME(string value )
        {
            var query = _query.FirstByREP_NOMEQuery(value );

                var result = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters) as List<RepresentantesDTO>;
                return result;
        }

        public IEnumerable<RepresentantesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters) as List<RepresentantesDTO>;
                return result;
        }

        public IEnumerable<RepresentantesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters) as List<RepresentantesDTO>;
                return result;
        }

        public IEnumerable<RepresentantesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters) as List<RepresentantesDTO>;
                return result;
        }

        public IEnumerable<RepresentantesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RepresentantesDTO>(query.Query,query.Parameters) as List<RepresentantesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration