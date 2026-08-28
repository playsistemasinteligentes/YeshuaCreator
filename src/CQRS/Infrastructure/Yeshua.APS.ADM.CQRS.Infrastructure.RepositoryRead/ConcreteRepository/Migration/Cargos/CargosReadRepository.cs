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
    public partial class CargosReadRepository : ICargosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICargosQueryRead _query;

        public CargosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICargosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CargosDTO> getCargos(ICommandRead command )
         {
            if (command is Command.Read.CargosReadCommand c)
                return getCargos(c );
            throw new NotImplementedException();
        }
        private DataPagination<CargosDTO> getCargos(Command.Read.CargosReadCommand command )
        {
            var query = _query.CargosQuery(command );

                var itens = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters);
                return new DataPagination<CargosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CargosTenantIDDTO> getCargosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CargosTenantIDDTO> lista;
            var query = _query.CargosTenantIDQuery(command );

                lista = _unitOfWork.Query<CargosTenantIDDTO>(query.Query,query.Parameters) as List<CargosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CargosTenantIDDTO> getCargosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCargosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CargosUserIdDTO> getCargosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CargosUserIdDTO> lista;
            var query = _query.CargosUserIdQuery(command );

                lista = _unitOfWork.Query<CargosUserIdDTO>(query.Query,query.Parameters) as List<CargosUserIdDTO>;
            return lista;
        }

        public IEnumerable<CargosUserIdDTO> getCargosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCargosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRGO_ID(string value )
        {
            var query = _query.ExistsByRGO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRGO_DESCRICAO(string value )
        {
            var query = _query.ExistsByRGO_DESCRICAOQuery(value );

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

        public CargosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargosDTO FirstByRGO_ID(string value )
        {
            var query = _query.FirstByRGO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargosDTO FirstByRGO_DESCRICAO(string value )
        {
            var query = _query.FirstByRGO_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CargosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters) as List<CargosDTO>;
                return result;
        }

        public IEnumerable<CargosDTO> GetAllByRGO_ID(string value )
        {
            var query = _query.FirstByRGO_IDQuery(value );

                var result = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters) as List<CargosDTO>;
                return result;
        }

        public IEnumerable<CargosDTO> GetAllByRGO_DESCRICAO(string value )
        {
            var query = _query.FirstByRGO_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters) as List<CargosDTO>;
                return result;
        }

        public IEnumerable<CargosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters) as List<CargosDTO>;
                return result;
        }

        public IEnumerable<CargosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters) as List<CargosDTO>;
                return result;
        }

        public IEnumerable<CargosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters) as List<CargosDTO>;
                return result;
        }

        public IEnumerable<CargosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CargosDTO>(query.Query,query.Parameters) as List<CargosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration