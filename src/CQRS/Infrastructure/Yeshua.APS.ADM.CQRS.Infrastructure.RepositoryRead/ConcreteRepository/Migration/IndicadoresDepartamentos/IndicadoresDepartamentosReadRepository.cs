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
    public partial class IndicadoresDepartamentosReadRepository : IIndicadoresDepartamentosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IIndicadoresDepartamentosQueryRead _query;

        public IndicadoresDepartamentosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IIndicadoresDepartamentosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetIndicadoresDepartamentosCustom(Command.Read.IndicadoresDepartamentosReadCommand command, ref DataPagination<IndicadoresDepartamentosDTO> result, ref bool handled);

        public DataPagination<IndicadoresDepartamentosDTO> getIndicadoresDepartamentos(ICommandRead command )
         {
            if (command is Command.Read.IndicadoresDepartamentosReadCommand c)
                return getIndicadoresDepartamentos(c );
            throw new NotImplementedException();
        }
        private DataPagination<IndicadoresDepartamentosDTO> getIndicadoresDepartamentos(Command.Read.IndicadoresDepartamentosReadCommand command )
        {
            DataPagination<IndicadoresDepartamentosDTO> customResult = null;
            var customHandled = false;
            TryGetIndicadoresDepartamentosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.IndicadoresDepartamentosQuery(command );

                var itens = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters);
                return new DataPagination<IndicadoresDepartamentosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<IndicadoresDepartamentosDEP_IDDTO> getIndicadoresDepartamentosReadFKDEP_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresDepartamentosDEP_IDDTO> lista;
            var query = _query.IndicadoresDepartamentosDEP_IDQuery(command );

                lista = _unitOfWork.Query<IndicadoresDepartamentosDEP_IDDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDEP_IDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresDepartamentosDEP_IDDTO> getIndicadoresDepartamentosReadFKDEP_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresDepartamentosReadFKDEP_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresDepartamentosIND_IDDTO> getIndicadoresDepartamentosReadFKIND_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresDepartamentosIND_IDDTO> lista;
            var query = _query.IndicadoresDepartamentosIND_IDQuery(command );

                lista = _unitOfWork.Query<IndicadoresDepartamentosIND_IDDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosIND_IDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresDepartamentosIND_IDDTO> getIndicadoresDepartamentosReadFKIND_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresDepartamentosReadFKIND_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresDepartamentosTenantIDDTO> getIndicadoresDepartamentosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresDepartamentosTenantIDDTO> lista;
            var query = _query.IndicadoresDepartamentosTenantIDQuery(command );

                lista = _unitOfWork.Query<IndicadoresDepartamentosTenantIDDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresDepartamentosTenantIDDTO> getIndicadoresDepartamentosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresDepartamentosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresDepartamentosUserIdDTO> getIndicadoresDepartamentosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresDepartamentosUserIdDTO> lista;
            var query = _query.IndicadoresDepartamentosUserIdQuery(command );

                lista = _unitOfWork.Query<IndicadoresDepartamentosUserIdDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosUserIdDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresDepartamentosUserIdDTO> getIndicadoresDepartamentosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresDepartamentosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByINDDEP_ID(int value )
        {
            var query = _query.ExistsByINDDEP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDEP_ID(int value )
        {
            var query = _query.ExistsByDEP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

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

        public IndicadoresDepartamentosDTO FirstByINDDEP_ID(int value )
        {
            var query = _query.FirstByINDDEP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDepartamentosDTO FirstByDEP_ID(int value )
        {
            var query = _query.FirstByDEP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDepartamentosDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDepartamentosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDepartamentosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDepartamentosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDepartamentosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByINDDEP_ID(int value )
        {
            var query = _query.FirstByINDDEP_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByDEP_ID(int value )
        {
            var query = _query.FirstByDEP_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<IndicadoresDepartamentosDTO>(query.Query,query.Parameters) as List<IndicadoresDepartamentosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration