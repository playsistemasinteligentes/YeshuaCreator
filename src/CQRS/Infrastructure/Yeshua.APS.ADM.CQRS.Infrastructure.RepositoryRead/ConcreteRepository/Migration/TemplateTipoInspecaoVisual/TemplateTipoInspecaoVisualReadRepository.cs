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
    public partial class TemplateTipoInspecaoVisualReadRepository : ITemplateTipoInspecaoVisualReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITemplateTipoInspecaoVisualQueryRead _query;

        public TemplateTipoInspecaoVisualReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITemplateTipoInspecaoVisualQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTemplateTipoInspecaoVisualCustom(Command.Read.TemplateTipoInspecaoVisualReadCommand command, ref DataPagination<TemplateTipoInspecaoVisualDTO> result, ref bool handled);

        public DataPagination<TemplateTipoInspecaoVisualDTO> getTemplateTipoInspecaoVisual(ICommandRead command )
         {
            if (command is Command.Read.TemplateTipoInspecaoVisualReadCommand c)
                return getTemplateTipoInspecaoVisual(c );
            throw new NotImplementedException();
        }
        private DataPagination<TemplateTipoInspecaoVisualDTO> getTemplateTipoInspecaoVisual(Command.Read.TemplateTipoInspecaoVisualReadCommand command )
        {
            DataPagination<TemplateTipoInspecaoVisualDTO> customResult = null;
            var customHandled = false;
            TryGetTemplateTipoInspecaoVisualCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TemplateTipoInspecaoVisualQuery(command );

                var itens = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters);
                return new DataPagination<TemplateTipoInspecaoVisualDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TemplateTipoInspecaoVisualTEM_IDDTO> getTemplateTipoInspecaoVisualReadFKTEM_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateTipoInspecaoVisualTEM_IDDTO> lista;
            var query = _query.TemplateTipoInspecaoVisualTEM_IDQuery(command );

                lista = _unitOfWork.Query<TemplateTipoInspecaoVisualTEM_IDDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualTEM_IDDTO>;
            return lista;
        }

        public IEnumerable<TemplateTipoInspecaoVisualTEM_IDDTO> getTemplateTipoInspecaoVisualReadFKTEM_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateTipoInspecaoVisualReadFKTEM_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplateTipoInspecaoVisualTenantIDDTO> getTemplateTipoInspecaoVisualReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateTipoInspecaoVisualTenantIDDTO> lista;
            var query = _query.TemplateTipoInspecaoVisualTenantIDQuery(command );

                lista = _unitOfWork.Query<TemplateTipoInspecaoVisualTenantIDDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TemplateTipoInspecaoVisualTenantIDDTO> getTemplateTipoInspecaoVisualReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateTipoInspecaoVisualReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplateTipoInspecaoVisualUserIdDTO> getTemplateTipoInspecaoVisualReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateTipoInspecaoVisualUserIdDTO> lista;
            var query = _query.TemplateTipoInspecaoVisualUserIdQuery(command );

                lista = _unitOfWork.Query<TemplateTipoInspecaoVisualUserIdDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualUserIdDTO>;
            return lista;
        }

        public IEnumerable<TemplateTipoInspecaoVisualUserIdDTO> getTemplateTipoInspecaoVisualReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateTipoInspecaoVisualReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByTTI_ID(int value )
        {
            var query = _query.ExistsByTTI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_ID(int value )
        {
            var query = _query.ExistsByTIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

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

        public TemplateTipoInspecaoVisualDTO FirstByTTI_ID(int value )
        {
            var query = _query.FirstByTTI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoInspecaoVisualDTO FirstByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoInspecaoVisualDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoInspecaoVisualDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoInspecaoVisualDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoInspecaoVisualDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoInspecaoVisualDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTTI_ID(int value )
        {
            var query = _query.FirstByTTI_IDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TemplateTipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TemplateTipoInspecaoVisualDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration