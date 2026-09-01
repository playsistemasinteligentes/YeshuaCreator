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
    public partial class yModuleReadRepository : IyModuleReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyModuleQueryRead _query;

        public yModuleReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyModuleQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<yModuleDTO> getyModule(ICommandRead command )
         {
            if (command is Command.Read.yModuleReadCommand c)
                return getyModule(c );
            throw new NotImplementedException();
        }
        private DataPagination<yModuleDTO> getyModule(Command.Read.yModuleReadCommand command )
        {
            var query = _query.yModuleQuery(command );

                var itens = _unitOfWork.Query<yModuleDTO>(query.Query,query.Parameters);
                return new DataPagination<yModuleDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(string value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value )
        {
            var query = _query.ExistsByDescriptionQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public yModuleDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yModuleDTO FirstByDescription(string value )
        {
            var query = _query.FirstByDescriptionQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yModuleDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<yModuleDTO>(query.Query,query.Parameters) as List<yModuleDTO>;
                return result;
        }

        public IEnumerable<yModuleDTO> GetAllByDescription(string value )
        {
            var query = _query.FirstByDescriptionQuery(value );

                var result = _unitOfWork.Query<yModuleDTO>(query.Query,query.Parameters) as List<yModuleDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration