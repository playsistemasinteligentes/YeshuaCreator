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
    public partial class MaquinaReadRepository : IMaquinaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMaquinaQueryRead _query;

        public MaquinaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMaquinaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MaquinaDTO> getMaquina(ICommandRead command )
         {
            if (command is Command.Read.MaquinaReadCommand c)
                return getMaquina(c );
            throw new NotImplementedException();
        }
        private DataPagination<MaquinaDTO> getMaquina(Command.Read.MaquinaReadCommand command )
        {
            var query = _query.MaquinaQuery(command );

                var itens = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters);
                return new DataPagination<MaquinaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MaquinaTenantIDDTO> getMaquinaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaTenantIDDTO> lista;
            var query = _query.MaquinaTenantIDQuery(command );

                lista = _unitOfWork.Query<MaquinaTenantIDDTO>(query.Query,query.Parameters) as List<MaquinaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MaquinaTenantIDDTO> getMaquinaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MaquinaUserIdDTO> getMaquinaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaUserIdDTO> lista;
            var query = _query.MaquinaUserIdQuery(command );

                lista = _unitOfWork.Query<MaquinaUserIdDTO>(query.Query,query.Parameters) as List<MaquinaUserIdDTO>;
            return lista;
        }

        public IEnumerable<MaquinaUserIdDTO> getMaquinaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(string value )
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

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public MaquinaDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration