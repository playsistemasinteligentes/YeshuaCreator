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
    public partial class TemplateTipoTesteReadRepository : ITemplateTipoTesteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITemplateTipoTesteQueryRead _query;

        public TemplateTipoTesteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITemplateTipoTesteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTemplateTipoTesteCustom(Command.Read.TemplateTipoTesteReadCommand command, ref DataPagination<TemplateTipoTesteDTO> result, ref bool handled);

        public DataPagination<TemplateTipoTesteDTO> getTemplateTipoTeste(ICommandRead command )
         {
            if (command is Command.Read.TemplateTipoTesteReadCommand c)
                return getTemplateTipoTeste(c );
            throw new NotImplementedException();
        }
        private DataPagination<TemplateTipoTesteDTO> getTemplateTipoTeste(Command.Read.TemplateTipoTesteReadCommand command )
        {
            DataPagination<TemplateTipoTesteDTO> customResult = null;
            var customHandled = false;
            TryGetTemplateTipoTesteCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TemplateTipoTesteQuery(command );

                var itens = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters);
                return new DataPagination<TemplateTipoTesteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TemplateTipoTesteTT_IDDTO> getTemplateTipoTesteReadFKTT_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateTipoTesteTT_IDDTO> lista;
            var query = _query.TemplateTipoTesteTT_IDQuery(command );

                lista = _unitOfWork.Query<TemplateTipoTesteTT_IDDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteTT_IDDTO>;
            return lista;
        }

        public IEnumerable<TemplateTipoTesteTT_IDDTO> getTemplateTipoTesteReadFKTT_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateTipoTesteReadFKTT_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplateTipoTesteTEM_IDDTO> getTemplateTipoTesteReadFKTEM_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateTipoTesteTEM_IDDTO> lista;
            var query = _query.TemplateTipoTesteTEM_IDQuery(command );

                lista = _unitOfWork.Query<TemplateTipoTesteTEM_IDDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteTEM_IDDTO>;
            return lista;
        }

        public IEnumerable<TemplateTipoTesteTEM_IDDTO> getTemplateTipoTesteReadFKTEM_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateTipoTesteReadFKTEM_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplateTipoTesteTenantIDDTO> getTemplateTipoTesteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateTipoTesteTenantIDDTO> lista;
            var query = _query.TemplateTipoTesteTenantIDQuery(command );

                lista = _unitOfWork.Query<TemplateTipoTesteTenantIDDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TemplateTipoTesteTenantIDDTO> getTemplateTipoTesteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateTipoTesteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplateTipoTesteUserIdDTO> getTemplateTipoTesteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateTipoTesteUserIdDTO> lista;
            var query = _query.TemplateTipoTesteUserIdQuery(command );

                lista = _unitOfWork.Query<TemplateTipoTesteUserIdDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteUserIdDTO>;
            return lista;
        }

        public IEnumerable<TemplateTipoTesteUserIdDTO> getTemplateTipoTesteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateTipoTesteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByTTT_ID(int value )
        {
            var query = _query.ExistsByTTT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_ID(int value )
        {
            var query = _query.ExistsByTT_IDQuery(value );

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

        public TemplateTipoTesteDTO FirstByTTT_ID(int value )
        {
            var query = _query.FirstByTTT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoTesteDTO FirstByTT_ID(int value )
        {
            var query = _query.FirstByTT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoTesteDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoTesteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoTesteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoTesteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateTipoTesteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateTipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TemplateTipoTesteDTO> GetAllByTTT_ID(int value )
        {
            var query = _query.FirstByTTT_IDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoTesteDTO> GetAllByTT_ID(int value )
        {
            var query = _query.FirstByTT_IDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoTesteDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoTesteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoTesteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoTesteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteDTO>;
                return result;
        }

        public IEnumerable<TemplateTipoTesteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TemplateTipoTesteDTO>(query.Query,query.Parameters) as List<TemplateTipoTesteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration