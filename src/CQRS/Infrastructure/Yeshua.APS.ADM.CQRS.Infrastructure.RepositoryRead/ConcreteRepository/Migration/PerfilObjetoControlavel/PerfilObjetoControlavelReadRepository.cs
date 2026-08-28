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
    public partial class PerfilObjetoControlavelReadRepository : IPerfilObjetoControlavelReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPerfilObjetoControlavelQueryRead _query;

        public PerfilObjetoControlavelReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPerfilObjetoControlavelQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PerfilObjetoControlavelDTO> getPerfilObjetoControlavel(ICommandRead command )
         {
            if (command is Command.Read.PerfilObjetoControlavelReadCommand c)
                return getPerfilObjetoControlavel(c );
            throw new NotImplementedException();
        }
        private DataPagination<PerfilObjetoControlavelDTO> getPerfilObjetoControlavel(Command.Read.PerfilObjetoControlavelReadCommand command )
        {
            var query = _query.PerfilObjetoControlavelQuery(command );

                var itens = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters);
                return new DataPagination<PerfilObjetoControlavelDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PerfilObjetoControlavelPER_IDDTO> getPerfilObjetoControlavelReadFKPER_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PerfilObjetoControlavelPER_IDDTO> lista;
            var query = _query.PerfilObjetoControlavelPER_IDQuery(command );

                lista = _unitOfWork.Query<PerfilObjetoControlavelPER_IDDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelPER_IDDTO>;
            return lista;
        }

        public IEnumerable<PerfilObjetoControlavelPER_IDDTO> getPerfilObjetoControlavelReadFKPER_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPerfilObjetoControlavelReadFKPER_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PerfilObjetoControlavelTenantIDDTO> getPerfilObjetoControlavelReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PerfilObjetoControlavelTenantIDDTO> lista;
            var query = _query.PerfilObjetoControlavelTenantIDQuery(command );

                lista = _unitOfWork.Query<PerfilObjetoControlavelTenantIDDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PerfilObjetoControlavelTenantIDDTO> getPerfilObjetoControlavelReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPerfilObjetoControlavelReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PerfilObjetoControlavelUserIdDTO> getPerfilObjetoControlavelReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PerfilObjetoControlavelUserIdDTO> lista;
            var query = _query.PerfilObjetoControlavelUserIdQuery(command );

                lista = _unitOfWork.Query<PerfilObjetoControlavelUserIdDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelUserIdDTO>;
            return lista;
        }

        public IEnumerable<PerfilObjetoControlavelUserIdDTO> getPerfilObjetoControlavelReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPerfilObjetoControlavelReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(int value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBJ_ID(string value )
        {
            var query = _query.ExistsByOBJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPEO_ACAO(string value )
        {
            var query = _query.ExistsByPEO_ACAOQuery(value );

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

        public PerfilObjetoControlavelDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilObjetoControlavelDTO FirstByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilObjetoControlavelDTO FirstByOBJ_ID(string value )
        {
            var query = _query.FirstByOBJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilObjetoControlavelDTO FirstByPEO_ACAO(string value )
        {
            var query = _query.FirstByPEO_ACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilObjetoControlavelDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilObjetoControlavelDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilObjetoControlavelDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilObjetoControlavelDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByOBJ_ID(string value )
        {
            var query = _query.FirstByOBJ_IDQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByPEO_ACAO(string value )
        {
            var query = _query.FirstByPEO_ACAOQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PerfilObjetoControlavelDTO>(query.Query,query.Parameters) as List<PerfilObjetoControlavelDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration