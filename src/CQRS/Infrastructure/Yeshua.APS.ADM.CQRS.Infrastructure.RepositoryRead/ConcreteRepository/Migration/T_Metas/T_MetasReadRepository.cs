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
    public partial class T_MetasReadRepository : IT_MetasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_MetasQueryRead _query;

        public T_MetasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_MetasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<T_MetasDTO> getT_Metas(ICommandRead command )
         {
            if (command is Command.Read.T_MetasReadCommand c)
                return getT_Metas(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_MetasDTO> getT_Metas(Command.Read.T_MetasReadCommand command )
        {
            var query = _query.T_MetasQuery(command );

                var itens = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters);
                return new DataPagination<T_MetasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_MetasIND_IDDTO> getT_MetasReadFKIND_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_MetasIND_IDDTO> lista;
            var query = _query.T_MetasIND_IDQuery(command );

                lista = _unitOfWork.Query<T_MetasIND_IDDTO>(query.Query,query.Parameters) as List<T_MetasIND_IDDTO>;
            return lista;
        }

        public IEnumerable<T_MetasIND_IDDTO> getT_MetasReadFKIND_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_MetasReadFKIND_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_MetasTenantIDDTO> getT_MetasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_MetasTenantIDDTO> lista;
            var query = _query.T_MetasTenantIDQuery(command );

                lista = _unitOfWork.Query<T_MetasTenantIDDTO>(query.Query,query.Parameters) as List<T_MetasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_MetasTenantIDDTO> getT_MetasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_MetasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_MetasUserIdDTO> getT_MetasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_MetasUserIdDTO> lista;
            var query = _query.T_MetasUserIdQuery(command );

                lista = _unitOfWork.Query<T_MetasUserIdDTO>(query.Query,query.Parameters) as List<T_MetasUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_MetasUserIdDTO> getT_MetasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_MetasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByMET_ID(int value )
        {
            var query = _query.ExistsByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_DTINICIO(string value )
        {
            var query = _query.ExistsByMET_DTINICIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_DTFIM(string value )
        {
            var query = _query.ExistsByMET_DTFIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_ALVO(string value )
        {
            var query = _query.ExistsByMET_ALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_TIPOALVO(int value )
        {
            var query = _query.ExistsByMET_TIPOALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_RANGE01(Decimal value )
        {
            var query = _query.ExistsByMET_RANGE01Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_RANGE02(Decimal value )
        {
            var query = _query.ExistsByMET_RANGE02Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_RANGE03(Decimal value )
        {
            var query = _query.ExistsByMET_RANGE03Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_ID(int value )
        {
            var query = _query.ExistsByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFAT_ID(string value )
        {
            var query = _query.ExistsByFAT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_SUBDIMENSAO_ID(string value )
        {
            var query = _query.ExistsByDIM_SUBDIMENSAO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(string value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDOM_EMPRESA(string value )
        {
            var query = _query.ExistsByDOM_EMPRESAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDOM_FILIAL(string value )
        {
            var query = _query.ExistsByDOM_FILIALQuery(value );

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

        public T_MetasDTO FirstByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByMET_DTINICIO(string value )
        {
            var query = _query.FirstByMET_DTINICIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByMET_DTFIM(string value )
        {
            var query = _query.FirstByMET_DTFIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByMET_ALVO(string value )
        {
            var query = _query.FirstByMET_ALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByMET_TIPOALVO(int value )
        {
            var query = _query.FirstByMET_TIPOALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByMET_RANGE01(Decimal value )
        {
            var query = _query.FirstByMET_RANGE01Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByMET_RANGE02(Decimal value )
        {
            var query = _query.FirstByMET_RANGE02Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByMET_RANGE03(Decimal value )
        {
            var query = _query.FirstByMET_RANGE03Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByFAT_ID(string value )
        {
            var query = _query.FirstByFAT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByDIM_SUBDIMENSAO_ID(string value )
        {
            var query = _query.FirstByDIM_SUBDIMENSAO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByDOM_EMPRESA(string value )
        {
            var query = _query.FirstByDOM_EMPRESAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByDOM_FILIAL(string value )
        {
            var query = _query.FirstByDOM_FILIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MetasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MetasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_DTINICIO(string value )
        {
            var query = _query.FirstByMET_DTINICIOQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_DTFIM(string value )
        {
            var query = _query.FirstByMET_DTFIMQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_ALVO(string value )
        {
            var query = _query.FirstByMET_ALVOQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_TIPOALVO(int value )
        {
            var query = _query.FirstByMET_TIPOALVOQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_RANGE01(Decimal value )
        {
            var query = _query.FirstByMET_RANGE01Query(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_RANGE02(Decimal value )
        {
            var query = _query.FirstByMET_RANGE02Query(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByMET_RANGE03(Decimal value )
        {
            var query = _query.FirstByMET_RANGE03Query(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByFAT_ID(string value )
        {
            var query = _query.FirstByFAT_IDQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByDIM_SUBDIMENSAO_ID(string value )
        {
            var query = _query.FirstByDIM_SUBDIMENSAO_IDQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByDOM_EMPRESA(string value )
        {
            var query = _query.FirstByDOM_EMPRESAQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByDOM_FILIAL(string value )
        {
            var query = _query.FirstByDOM_FILIALQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

        public IEnumerable<T_MetasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_MetasDTO>(query.Query,query.Parameters) as List<T_MetasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration