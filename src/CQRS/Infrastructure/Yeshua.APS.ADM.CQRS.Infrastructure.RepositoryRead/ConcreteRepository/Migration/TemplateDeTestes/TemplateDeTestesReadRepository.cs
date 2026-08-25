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
    public partial class TemplateDeTestesReadRepository : ITemplateDeTestesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITemplateDeTestesQueryRead _query;

        public TemplateDeTestesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITemplateDeTestesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TemplateDeTestesDTO> getTemplateDeTestes(ICommandRead command )
         {
            if (command is Command.Read.TemplateDeTestesReadCommand c)
                return getTemplateDeTestes(c );
            throw new NotImplementedException();
        }
        private DataPagination<TemplateDeTestesDTO> getTemplateDeTestes(Command.Read.TemplateDeTestesReadCommand command )
        {
            var query = _query.TemplateDeTestesQuery(command );

                var itens = _unitOfWork.Query<TemplateDeTestesDTO>(query.Query,query.Parameters);
                return new DataPagination<TemplateDeTestesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TemplateDeTestesTenantIDDTO> getTemplateDeTestesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateDeTestesTenantIDDTO> lista;
            var query = _query.TemplateDeTestesTenantIDQuery(command );

                lista = _unitOfWork.Query<TemplateDeTestesTenantIDDTO>(query.Query,query.Parameters) as List<TemplateDeTestesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TemplateDeTestesTenantIDDTO> getTemplateDeTestesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateDeTestesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplateDeTestesUserIdDTO> getTemplateDeTestesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplateDeTestesUserIdDTO> lista;
            var query = _query.TemplateDeTestesUserIdQuery(command );

                lista = _unitOfWork.Query<TemplateDeTestesUserIdDTO>(query.Query,query.Parameters) as List<TemplateDeTestesUserIdDTO>;
            return lista;
        }

        public IEnumerable<TemplateDeTestesUserIdDTO> getTemplateDeTestesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplateDeTestesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

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

        public TemplateDeTestesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateDeTestesDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateDeTestesDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateDeTestesDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateDeTestesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateDeTestesDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateDeTestesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateDeTestesDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateDeTestesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateDeTestesDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplateDeTestesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplateDeTestesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TemplateDeTestesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TemplateDeTestesDTO>(query.Query,query.Parameters) as List<TemplateDeTestesDTO>;
                return result;
        }

        public IEnumerable<TemplateDeTestesDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<TemplateDeTestesDTO>(query.Query,query.Parameters) as List<TemplateDeTestesDTO>;
                return result;
        }

        public IEnumerable<TemplateDeTestesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TemplateDeTestesDTO>(query.Query,query.Parameters) as List<TemplateDeTestesDTO>;
                return result;
        }

        public IEnumerable<TemplateDeTestesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TemplateDeTestesDTO>(query.Query,query.Parameters) as List<TemplateDeTestesDTO>;
                return result;
        }

        public IEnumerable<TemplateDeTestesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TemplateDeTestesDTO>(query.Query,query.Parameters) as List<TemplateDeTestesDTO>;
                return result;
        }

        public IEnumerable<TemplateDeTestesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TemplateDeTestesDTO>(query.Query,query.Parameters) as List<TemplateDeTestesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration