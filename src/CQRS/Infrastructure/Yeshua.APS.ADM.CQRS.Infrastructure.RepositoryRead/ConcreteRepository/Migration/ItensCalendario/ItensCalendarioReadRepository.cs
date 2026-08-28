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
    public partial class ItensCalendarioReadRepository : IItensCalendarioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItensCalendarioQueryRead _query;

        public ItensCalendarioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItensCalendarioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ItensCalendarioDTO> getItensCalendario(ICommandRead command )
         {
            if (command is Command.Read.ItensCalendarioReadCommand c)
                return getItensCalendario(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItensCalendarioDTO> getItensCalendario(Command.Read.ItensCalendarioReadCommand command )
        {
            var query = _query.ItensCalendarioQuery(command );

                var itens = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters);
                return new DataPagination<ItensCalendarioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItensCalendarioURM_IDDTO> getItensCalendarioReadFKURM_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensCalendarioURM_IDDTO> lista;
            var query = _query.ItensCalendarioURM_IDQuery(command );

                lista = _unitOfWork.Query<ItensCalendarioURM_IDDTO>(query.Query,query.Parameters) as List<ItensCalendarioURM_IDDTO>;
            return lista;
        }

        public IEnumerable<ItensCalendarioURM_IDDTO> getItensCalendarioReadFKURM_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensCalendarioReadFKURM_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensCalendarioURN_IDDTO> getItensCalendarioReadFKURN_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensCalendarioURN_IDDTO> lista;
            var query = _query.ItensCalendarioURN_IDQuery(command );

                lista = _unitOfWork.Query<ItensCalendarioURN_IDDTO>(query.Query,query.Parameters) as List<ItensCalendarioURN_IDDTO>;
            return lista;
        }

        public IEnumerable<ItensCalendarioURN_IDDTO> getItensCalendarioReadFKURN_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensCalendarioReadFKURN_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensCalendarioCAL_IDDTO> getItensCalendarioReadFKCAL_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensCalendarioCAL_IDDTO> lista;
            var query = _query.ItensCalendarioCAL_IDQuery(command );

                lista = _unitOfWork.Query<ItensCalendarioCAL_IDDTO>(query.Query,query.Parameters) as List<ItensCalendarioCAL_IDDTO>;
            return lista;
        }

        public IEnumerable<ItensCalendarioCAL_IDDTO> getItensCalendarioReadFKCAL_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensCalendarioReadFKCAL_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensCalendarioTenantIDDTO> getItensCalendarioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensCalendarioTenantIDDTO> lista;
            var query = _query.ItensCalendarioTenantIDQuery(command );

                lista = _unitOfWork.Query<ItensCalendarioTenantIDDTO>(query.Query,query.Parameters) as List<ItensCalendarioTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItensCalendarioTenantIDDTO> getItensCalendarioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensCalendarioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensCalendarioUserIdDTO> getItensCalendarioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensCalendarioUserIdDTO> lista;
            var query = _query.ItensCalendarioUserIdQuery(command );

                lista = _unitOfWork.Query<ItensCalendarioUserIdDTO>(query.Query,query.Parameters) as List<ItensCalendarioUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItensCalendarioUserIdDTO> getItensCalendarioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensCalendarioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByICA_ID(int value )
        {
            var query = _query.ExistsByICA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByICA_DATA_DE(DateTime value )
        {
            var query = _query.ExistsByICA_DATA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByICA_DATA_ATE(DateTime value )
        {
            var query = _query.ExistsByICA_DATA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByICA_OBSERVACAO(string value )
        {
            var query = _query.ExistsByICA_OBSERVACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByICA_TIPO(int value )
        {
            var query = _query.ExistsByICA_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByURM_ID(string value )
        {
            var query = _query.ExistsByURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByURN_ID(string value )
        {
            var query = _query.ExistsByURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAL_ID(int value )
        {
            var query = _query.ExistsByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByICA_LIMPESA_MAQUINA(int value )
        {
            var query = _query.ExistsByICA_LIMPESA_MAQUINAQuery(value );

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

        public ItensCalendarioDTO FirstByICA_ID(int value )
        {
            var query = _query.FirstByICA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByICA_DATA_DE(DateTime value )
        {
            var query = _query.FirstByICA_DATA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByICA_DATA_ATE(DateTime value )
        {
            var query = _query.FirstByICA_DATA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByICA_OBSERVACAO(string value )
        {
            var query = _query.FirstByICA_OBSERVACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByICA_TIPO(int value )
        {
            var query = _query.FirstByICA_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByURM_ID(string value )
        {
            var query = _query.FirstByURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByURN_ID(string value )
        {
            var query = _query.FirstByURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByICA_LIMPESA_MAQUINA(int value )
        {
            var query = _query.FirstByICA_LIMPESA_MAQUINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensCalendarioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensCalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByICA_ID(int value )
        {
            var query = _query.FirstByICA_IDQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByICA_DATA_DE(DateTime value )
        {
            var query = _query.FirstByICA_DATA_DEQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByICA_DATA_ATE(DateTime value )
        {
            var query = _query.FirstByICA_DATA_ATEQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByICA_OBSERVACAO(string value )
        {
            var query = _query.FirstByICA_OBSERVACAOQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByICA_TIPO(int value )
        {
            var query = _query.FirstByICA_TIPOQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByURM_ID(string value )
        {
            var query = _query.FirstByURM_IDQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByURN_ID(string value )
        {
            var query = _query.FirstByURN_IDQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByICA_LIMPESA_MAQUINA(int value )
        {
            var query = _query.FirstByICA_LIMPESA_MAQUINAQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

        public IEnumerable<ItensCalendarioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItensCalendarioDTO>(query.Query,query.Parameters) as List<ItensCalendarioDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration