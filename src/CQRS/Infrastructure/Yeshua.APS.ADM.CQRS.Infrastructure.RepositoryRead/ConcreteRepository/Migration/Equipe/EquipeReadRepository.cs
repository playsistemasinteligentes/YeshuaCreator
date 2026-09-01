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
    public partial class EquipeReadRepository : IEquipeReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEquipeQueryRead _query;

        public EquipeReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEquipeQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetEquipeCustom(Command.Read.EquipeReadCommand command, ref DataPagination<EquipeDTO> result, ref bool handled);

        public DataPagination<EquipeDTO> getEquipe(ICommandRead command )
         {
            if (command is Command.Read.EquipeReadCommand c)
                return getEquipe(c );
            throw new NotImplementedException();
        }
        private DataPagination<EquipeDTO> getEquipe(Command.Read.EquipeReadCommand command )
        {
            DataPagination<EquipeDTO> customResult = null;
            var customHandled = false;
            TryGetEquipeCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.EquipeQuery(command );

                var itens = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters);
                return new DataPagination<EquipeDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EquipeTenantIDDTO> getEquipeReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EquipeTenantIDDTO> lista;
            var query = _query.EquipeTenantIDQuery(command );

                lista = _unitOfWork.Query<EquipeTenantIDDTO>(query.Query,query.Parameters) as List<EquipeTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EquipeTenantIDDTO> getEquipeReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEquipeReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EquipeUserIdDTO> getEquipeReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EquipeUserIdDTO> lista;
            var query = _query.EquipeUserIdQuery(command );

                lista = _unitOfWork.Query<EquipeUserIdDTO>(query.Query,query.Parameters) as List<EquipeUserIdDTO>;
            return lista;
        }

        public IEnumerable<EquipeUserIdDTO> getEquipeReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEquipeReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEQU_ID(string value )
        {
            var query = _query.ExistsByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEQU_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.ExistsByEQU_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

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

        public EquipeDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EquipeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EquipeDTO FirstByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EquipeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EquipeDTO FirstByEQU_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.FirstByEQU_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EquipeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EquipeDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EquipeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EquipeDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EquipeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EquipeDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EquipeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EquipeDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EquipeDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EquipeDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters) as List<EquipeDTO>;
                return result;
        }

        public IEnumerable<EquipeDTO> GetAllByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters) as List<EquipeDTO>;
                return result;
        }

        public IEnumerable<EquipeDTO> GetAllByEQU_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.FirstByEQU_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters) as List<EquipeDTO>;
                return result;
        }

        public IEnumerable<EquipeDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters) as List<EquipeDTO>;
                return result;
        }

        public IEnumerable<EquipeDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters) as List<EquipeDTO>;
                return result;
        }

        public IEnumerable<EquipeDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters) as List<EquipeDTO>;
                return result;
        }

        public IEnumerable<EquipeDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EquipeDTO>(query.Query,query.Parameters) as List<EquipeDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration