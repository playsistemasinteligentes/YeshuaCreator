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
    public partial class UnidadeMedidaReadRepository : IUnidadeMedidaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUnidadeMedidaQueryRead _query;

        public UnidadeMedidaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUnidadeMedidaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<UnidadeMedidaDTO> getUnidadeMedida(ICommandRead command )
         {
            if (command is Command.Read.UnidadeMedidaReadCommand c)
                return getUnidadeMedida(c );
            throw new NotImplementedException();
        }
        private DataPagination<UnidadeMedidaDTO> getUnidadeMedida(Command.Read.UnidadeMedidaReadCommand command )
        {
            var query = _query.UnidadeMedidaQuery(command );

                var itens = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters);
                return new DataPagination<UnidadeMedidaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<UnidadeMedidaTenantIDDTO> getUnidadeMedidaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UnidadeMedidaTenantIDDTO> lista;
            var query = _query.UnidadeMedidaTenantIDQuery(command );

                lista = _unitOfWork.Query<UnidadeMedidaTenantIDDTO>(query.Query,query.Parameters) as List<UnidadeMedidaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<UnidadeMedidaTenantIDDTO> getUnidadeMedidaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUnidadeMedidaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UnidadeMedidaUserIdDTO> getUnidadeMedidaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UnidadeMedidaUserIdDTO> lista;
            var query = _query.UnidadeMedidaUserIdQuery(command );

                lista = _unitOfWork.Query<UnidadeMedidaUserIdDTO>(query.Query,query.Parameters) as List<UnidadeMedidaUserIdDTO>;
            return lista;
        }

        public IEnumerable<UnidadeMedidaUserIdDTO> getUnidadeMedidaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUnidadeMedidaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByUNI_ID(string value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_DESCRICAO(string value )
        {
            var query = _query.ExistsByUNI_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ESCALA_TEMPO(string value )
        {
            var query = _query.ExistsByUNI_ESCALA_TEMPOQuery(value );

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

        public UnidadeMedidaDTO FirstByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeMedidaDTO FirstByUNI_DESCRICAO(string value )
        {
            var query = _query.FirstByUNI_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeMedidaDTO FirstByUNI_ESCALA_TEMPO(string value )
        {
            var query = _query.FirstByUNI_ESCALA_TEMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeMedidaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeMedidaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeMedidaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeMedidaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<UnidadeMedidaDTO> GetAllByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters) as List<UnidadeMedidaDTO>;
                return result;
        }

        public IEnumerable<UnidadeMedidaDTO> GetAllByUNI_DESCRICAO(string value )
        {
            var query = _query.FirstByUNI_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters) as List<UnidadeMedidaDTO>;
                return result;
        }

        public IEnumerable<UnidadeMedidaDTO> GetAllByUNI_ESCALA_TEMPO(string value )
        {
            var query = _query.FirstByUNI_ESCALA_TEMPOQuery(value );

                var result = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters) as List<UnidadeMedidaDTO>;
                return result;
        }

        public IEnumerable<UnidadeMedidaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters) as List<UnidadeMedidaDTO>;
                return result;
        }

        public IEnumerable<UnidadeMedidaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters) as List<UnidadeMedidaDTO>;
                return result;
        }

        public IEnumerable<UnidadeMedidaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters) as List<UnidadeMedidaDTO>;
                return result;
        }

        public IEnumerable<UnidadeMedidaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<UnidadeMedidaDTO>(query.Query,query.Parameters) as List<UnidadeMedidaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration