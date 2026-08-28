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
    public partial class ParametrosDeCustoReadRepository : IParametrosDeCustoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IParametrosDeCustoQueryRead _query;

        public ParametrosDeCustoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IParametrosDeCustoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ParametrosDeCustoDTO> getParametrosDeCusto(ICommandRead command )
         {
            if (command is Command.Read.ParametrosDeCustoReadCommand c)
                return getParametrosDeCusto(c );
            throw new NotImplementedException();
        }
        private DataPagination<ParametrosDeCustoDTO> getParametrosDeCusto(Command.Read.ParametrosDeCustoReadCommand command )
        {
            var query = _query.ParametrosDeCustoQuery(command );

                var itens = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters);
                return new DataPagination<ParametrosDeCustoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ParametrosDeCustoTenantIDDTO> getParametrosDeCustoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ParametrosDeCustoTenantIDDTO> lista;
            var query = _query.ParametrosDeCustoTenantIDQuery(command );

                lista = _unitOfWork.Query<ParametrosDeCustoTenantIDDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ParametrosDeCustoTenantIDDTO> getParametrosDeCustoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getParametrosDeCustoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ParametrosDeCustoUserIdDTO> getParametrosDeCustoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ParametrosDeCustoUserIdDTO> lista;
            var query = _query.ParametrosDeCustoUserIdQuery(command );

                lista = _unitOfWork.Query<ParametrosDeCustoUserIdDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoUserIdDTO>;
            return lista;
        }

        public IEnumerable<ParametrosDeCustoUserIdDTO> getParametrosDeCustoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getParametrosDeCustoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAR_ID(int value )
        {
            var query = _query.ExistsByPAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCUS_ID(string value )
        {
            var query = _query.ExistsByCUS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAR_VALOR(string value )
        {
            var query = _query.ExistsByPAR_VALORQuery(value );

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

        public ParametrosDeCustoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByPAR_ID(int value )
        {
            var query = _query.FirstByPAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByCUS_ID(string value )
        {
            var query = _query.FirstByCUS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByPAR_VALOR(string value )
        {
            var query = _query.FirstByPAR_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParametrosDeCustoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParametrosDeCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByPAR_ID(int value )
        {
            var query = _query.FirstByPAR_IDQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByCUS_ID(string value )
        {
            var query = _query.FirstByCUS_IDQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByPAR_VALOR(string value )
        {
            var query = _query.FirstByPAR_VALORQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

        public IEnumerable<ParametrosDeCustoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ParametrosDeCustoDTO>(query.Query,query.Parameters) as List<ParametrosDeCustoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration