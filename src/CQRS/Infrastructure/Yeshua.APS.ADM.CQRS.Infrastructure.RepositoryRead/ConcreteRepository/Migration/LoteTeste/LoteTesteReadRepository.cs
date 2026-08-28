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
    public partial class LoteTesteReadRepository : ILoteTesteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ILoteTesteQueryRead _query;

        public LoteTesteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ILoteTesteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<LoteTesteDTO> getLoteTeste(ICommandRead command )
         {
            if (command is Command.Read.LoteTesteReadCommand c)
                return getLoteTeste(c );
            throw new NotImplementedException();
        }
        private DataPagination<LoteTesteDTO> getLoteTeste(Command.Read.LoteTesteReadCommand command )
        {
            var query = _query.LoteTesteQuery(command );

                var itens = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters);
                return new DataPagination<LoteTesteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<LoteTesteTenantIDDTO> getLoteTesteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LoteTesteTenantIDDTO> lista;
            var query = _query.LoteTesteTenantIDQuery(command );

                lista = _unitOfWork.Query<LoteTesteTenantIDDTO>(query.Query,query.Parameters) as List<LoteTesteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<LoteTesteTenantIDDTO> getLoteTesteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLoteTesteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<LoteTesteUserIdDTO> getLoteTesteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LoteTesteUserIdDTO> lista;
            var query = _query.LoteTesteUserIdQuery(command );

                lista = _unitOfWork.Query<LoteTesteUserIdDTO>(query.Query,query.Parameters) as List<LoteTesteUserIdDTO>;
            return lista;
        }

        public IEnumerable<LoteTesteUserIdDTO> getLoteTesteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLoteTesteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLT_ID(int value )
        {
            var query = _query.ExistsByLT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_ID(int value )
        {
            var query = _query.ExistsByTES_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRL_ID(int value )
        {
            var query = _query.ExistsByRL_IDQuery(value );

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

        public LoteTesteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoteTesteDTO FirstByLT_ID(int value )
        {
            var query = _query.FirstByLT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoteTesteDTO FirstByTES_ID(int value )
        {
            var query = _query.FirstByTES_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoteTesteDTO FirstByRL_ID(int value )
        {
            var query = _query.FirstByRL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoteTesteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoteTesteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoteTesteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public LoteTesteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LoteTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllByLT_ID(int value )
        {
            var query = _query.FirstByLT_IDQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllByTES_ID(int value )
        {
            var query = _query.FirstByTES_IDQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllByRL_ID(int value )
        {
            var query = _query.FirstByRL_IDQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

        public IEnumerable<LoteTesteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<LoteTesteDTO>(query.Query,query.Parameters) as List<LoteTesteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration