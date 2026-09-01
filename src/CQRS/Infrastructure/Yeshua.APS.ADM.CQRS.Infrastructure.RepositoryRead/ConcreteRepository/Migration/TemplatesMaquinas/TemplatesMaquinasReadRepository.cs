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
    public partial class TemplatesMaquinasReadRepository : ITemplatesMaquinasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITemplatesMaquinasQueryRead _query;

        public TemplatesMaquinasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITemplatesMaquinasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTemplatesMaquinasCustom(Command.Read.TemplatesMaquinasReadCommand command, ref DataPagination<TemplatesMaquinasDTO> result, ref bool handled);

        public DataPagination<TemplatesMaquinasDTO> getTemplatesMaquinas(ICommandRead command )
         {
            if (command is Command.Read.TemplatesMaquinasReadCommand c)
                return getTemplatesMaquinas(c );
            throw new NotImplementedException();
        }
        private DataPagination<TemplatesMaquinasDTO> getTemplatesMaquinas(Command.Read.TemplatesMaquinasReadCommand command )
        {
            DataPagination<TemplatesMaquinasDTO> customResult = null;
            var customHandled = false;
            TryGetTemplatesMaquinasCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TemplatesMaquinasQuery(command );

                var itens = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters);
                return new DataPagination<TemplatesMaquinasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TemplatesMaquinasTenantIDDTO> getTemplatesMaquinasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplatesMaquinasTenantIDDTO> lista;
            var query = _query.TemplatesMaquinasTenantIDQuery(command );

                lista = _unitOfWork.Query<TemplatesMaquinasTenantIDDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TemplatesMaquinasTenantIDDTO> getTemplatesMaquinasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplatesMaquinasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplatesMaquinasUserIdDTO> getTemplatesMaquinasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplatesMaquinasUserIdDTO> lista;
            var query = _query.TemplatesMaquinasUserIdQuery(command );

                lista = _unitOfWork.Query<TemplatesMaquinasUserIdDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasUserIdDTO>;
            return lista;
        }

        public IEnumerable<TemplatesMaquinasUserIdDTO> getTemplatesMaquinasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplatesMaquinasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

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

        public TemplatesMaquinasDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesMaquinasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesMaquinasDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesMaquinasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesMaquinasDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesMaquinasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesMaquinasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesMaquinasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesMaquinasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesMaquinasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesMaquinasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesMaquinasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesMaquinasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesMaquinasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TemplatesMaquinasDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasDTO>;
                return result;
        }

        public IEnumerable<TemplatesMaquinasDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasDTO>;
                return result;
        }

        public IEnumerable<TemplatesMaquinasDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasDTO>;
                return result;
        }

        public IEnumerable<TemplatesMaquinasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasDTO>;
                return result;
        }

        public IEnumerable<TemplatesMaquinasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasDTO>;
                return result;
        }

        public IEnumerable<TemplatesMaquinasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasDTO>;
                return result;
        }

        public IEnumerable<TemplatesMaquinasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TemplatesMaquinasDTO>(query.Query,query.Parameters) as List<TemplatesMaquinasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration