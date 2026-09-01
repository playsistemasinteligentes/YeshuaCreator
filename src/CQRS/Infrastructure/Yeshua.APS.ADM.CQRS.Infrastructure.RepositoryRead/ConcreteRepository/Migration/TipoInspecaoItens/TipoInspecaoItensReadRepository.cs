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
    public partial class TipoInspecaoItensReadRepository : ITipoInspecaoItensReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoInspecaoItensQueryRead _query;

        public TipoInspecaoItensReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoInspecaoItensQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoInspecaoItensCustom(Command.Read.TipoInspecaoItensReadCommand command, ref DataPagination<TipoInspecaoItensDTO> result, ref bool handled);

        public DataPagination<TipoInspecaoItensDTO> getTipoInspecaoItens(ICommandRead command )
         {
            if (command is Command.Read.TipoInspecaoItensReadCommand c)
                return getTipoInspecaoItens(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoInspecaoItensDTO> getTipoInspecaoItens(Command.Read.TipoInspecaoItensReadCommand command )
        {
            DataPagination<TipoInspecaoItensDTO> customResult = null;
            var customHandled = false;
            TryGetTipoInspecaoItensCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoInspecaoItensQuery(command );

                var itens = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoInspecaoItensDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoInspecaoItensTenantIDDTO> getTipoInspecaoItensReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoInspecaoItensTenantIDDTO> lista;
            var query = _query.TipoInspecaoItensTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoInspecaoItensTenantIDDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoInspecaoItensTenantIDDTO> getTipoInspecaoItensReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoInspecaoItensReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoInspecaoItensUserIdDTO> getTipoInspecaoItensReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoInspecaoItensUserIdDTO> lista;
            var query = _query.TipoInspecaoItensUserIdQuery(command );

                lista = _unitOfWork.Query<TipoInspecaoItensUserIdDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoInspecaoItensUserIdDTO> getTipoInspecaoItensReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoInspecaoItensReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTII_ID(int value )
        {
            var query = _query.ExistsByTII_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_ID(int value )
        {
            var query = _query.ExistsByTIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITI_ID(int value )
        {
            var query = _query.ExistsByITI_IDQuery(value );

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

        public TipoInspecaoItensDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoItensDTO FirstByTII_ID(int value )
        {
            var query = _query.FirstByTII_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoItensDTO FirstByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoItensDTO FirstByITI_ID(int value )
        {
            var query = _query.FirstByITI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoItensDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoItensDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoItensDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoItensDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoItensDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllByTII_ID(int value )
        {
            var query = _query.FirstByTII_IDQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllByITI_ID(int value )
        {
            var query = _query.FirstByITI_IDQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoItensDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoItensDTO>(query.Query,query.Parameters) as List<TipoInspecaoItensDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration