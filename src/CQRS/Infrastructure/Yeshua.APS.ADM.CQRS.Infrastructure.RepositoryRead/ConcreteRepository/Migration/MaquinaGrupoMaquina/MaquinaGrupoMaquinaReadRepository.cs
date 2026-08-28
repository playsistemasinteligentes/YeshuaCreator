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
    public partial class MaquinaGrupoMaquinaReadRepository : IMaquinaGrupoMaquinaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMaquinaGrupoMaquinaQueryRead _query;

        public MaquinaGrupoMaquinaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMaquinaGrupoMaquinaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MaquinaGrupoMaquinaDTO> getMaquinaGrupoMaquina(ICommandRead command )
         {
            if (command is Command.Read.MaquinaGrupoMaquinaReadCommand c)
                return getMaquinaGrupoMaquina(c );
            throw new NotImplementedException();
        }
        private DataPagination<MaquinaGrupoMaquinaDTO> getMaquinaGrupoMaquina(Command.Read.MaquinaGrupoMaquinaReadCommand command )
        {
            var query = _query.MaquinaGrupoMaquinaQuery(command );

                var itens = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters);
                return new DataPagination<MaquinaGrupoMaquinaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MaquinaGrupoMaquinaTenantIDDTO> getMaquinaGrupoMaquinaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaGrupoMaquinaTenantIDDTO> lista;
            var query = _query.MaquinaGrupoMaquinaTenantIDQuery(command );

                lista = _unitOfWork.Query<MaquinaGrupoMaquinaTenantIDDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MaquinaGrupoMaquinaTenantIDDTO> getMaquinaGrupoMaquinaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaGrupoMaquinaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MaquinaGrupoMaquinaUserIdDTO> getMaquinaGrupoMaquinaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaGrupoMaquinaUserIdDTO> lista;
            var query = _query.MaquinaGrupoMaquinaUserIdQuery(command );

                lista = _unitOfWork.Query<MaquinaGrupoMaquinaUserIdDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaUserIdDTO>;
            return lista;
        }

        public IEnumerable<MaquinaGrupoMaquinaUserIdDTO> getMaquinaGrupoMaquinaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaGrupoMaquinaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGMA_ID(string value )
        {
            var query = _query.ExistsByGMA_IDQuery(value );

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

        public MaquinaGrupoMaquinaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaGrupoMaquinaDTO FirstByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaGrupoMaquinaDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaGrupoMaquinaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaGrupoMaquinaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaGrupoMaquinaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaGrupoMaquinaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MaquinaGrupoMaquinaDTO>(query.Query,query.Parameters) as List<MaquinaGrupoMaquinaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration