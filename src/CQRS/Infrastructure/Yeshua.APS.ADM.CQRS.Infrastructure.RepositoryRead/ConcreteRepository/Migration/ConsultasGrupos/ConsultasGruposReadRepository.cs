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
    public partial class ConsultasGruposReadRepository : IConsultasGruposReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IConsultasGruposQueryRead _query;

        public ConsultasGruposReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IConsultasGruposQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetConsultasGruposCustom(Command.Read.ConsultasGruposReadCommand command, ref DataPagination<ConsultasGruposDTO> result, ref bool handled);

        public DataPagination<ConsultasGruposDTO> getConsultasGrupos(ICommandRead command )
         {
            if (command is Command.Read.ConsultasGruposReadCommand c)
                return getConsultasGrupos(c );
            throw new NotImplementedException();
        }
        private DataPagination<ConsultasGruposDTO> getConsultasGrupos(Command.Read.ConsultasGruposReadCommand command )
        {
            DataPagination<ConsultasGruposDTO> customResult = null;
            var customHandled = false;
            TryGetConsultasGruposCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ConsultasGruposQuery(command );

                var itens = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters);
                return new DataPagination<ConsultasGruposDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ConsultasGruposTenantIDDTO> getConsultasGruposReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConsultasGruposTenantIDDTO> lista;
            var query = _query.ConsultasGruposTenantIDQuery(command );

                lista = _unitOfWork.Query<ConsultasGruposTenantIDDTO>(query.Query,query.Parameters) as List<ConsultasGruposTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ConsultasGruposTenantIDDTO> getConsultasGruposReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConsultasGruposReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ConsultasGruposUserIdDTO> getConsultasGruposReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConsultasGruposUserIdDTO> lista;
            var query = _query.ConsultasGruposUserIdQuery(command );

                lista = _unitOfWork.Query<ConsultasGruposUserIdDTO>(query.Query,query.Parameters) as List<ConsultasGruposUserIdDTO>;
            return lista;
        }

        public IEnumerable<ConsultasGruposUserIdDTO> getConsultasGruposReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConsultasGruposReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_ID(int value )
        {
            var query = _query.ExistsByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRU_ID(int value )
        {
            var query = _query.ExistsByGRU_IDQuery(value );

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

        public ConsultasGruposDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasGruposDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasGruposDTO FirstByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasGruposDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasGruposDTO FirstByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasGruposDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasGruposDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasGruposDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasGruposDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasGruposDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasGruposDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasGruposDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasGruposDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasGruposDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ConsultasGruposDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters) as List<ConsultasGruposDTO>;
                return result;
        }

        public IEnumerable<ConsultasGruposDTO> GetAllByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters) as List<ConsultasGruposDTO>;
                return result;
        }

        public IEnumerable<ConsultasGruposDTO> GetAllByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters) as List<ConsultasGruposDTO>;
                return result;
        }

        public IEnumerable<ConsultasGruposDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters) as List<ConsultasGruposDTO>;
                return result;
        }

        public IEnumerable<ConsultasGruposDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters) as List<ConsultasGruposDTO>;
                return result;
        }

        public IEnumerable<ConsultasGruposDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters) as List<ConsultasGruposDTO>;
                return result;
        }

        public IEnumerable<ConsultasGruposDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ConsultasGruposDTO>(query.Query,query.Parameters) as List<ConsultasGruposDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration