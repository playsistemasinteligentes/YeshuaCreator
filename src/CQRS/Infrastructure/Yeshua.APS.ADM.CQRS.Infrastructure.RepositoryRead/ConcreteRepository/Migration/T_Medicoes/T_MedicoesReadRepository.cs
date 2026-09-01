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
    public partial class T_MedicoesReadRepository : IT_MedicoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_MedicoesQueryRead _query;

        public T_MedicoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_MedicoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_MedicoesCustom(Command.Read.T_MedicoesReadCommand command, ref DataPagination<T_MedicoesDTO> result, ref bool handled);

        public DataPagination<T_MedicoesDTO> getT_Medicoes(ICommandRead command )
         {
            if (command is Command.Read.T_MedicoesReadCommand c)
                return getT_Medicoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_MedicoesDTO> getT_Medicoes(Command.Read.T_MedicoesReadCommand command )
        {
            DataPagination<T_MedicoesDTO> customResult = null;
            var customHandled = false;
            TryGetT_MedicoesCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_MedicoesQuery(command );

                var itens = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters);
                return new DataPagination<T_MedicoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_MedicoesTenantIDDTO> getT_MedicoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_MedicoesTenantIDDTO> lista;
            var query = _query.T_MedicoesTenantIDQuery(command );

                lista = _unitOfWork.Query<T_MedicoesTenantIDDTO>(query.Query,query.Parameters) as List<T_MedicoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_MedicoesTenantIDDTO> getT_MedicoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_MedicoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_MedicoesUserIdDTO> getT_MedicoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_MedicoesUserIdDTO> lista;
            var query = _query.T_MedicoesUserIdQuery(command );

                lista = _unitOfWork.Query<T_MedicoesUserIdDTO>(query.Query,query.Parameters) as List<T_MedicoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_MedicoesUserIdDTO> getT_MedicoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_MedicoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMED_ID(int value )
        {
            var query = _query.ExistsByMED_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_ID(int value )
        {
            var query = _query.ExistsByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ID(int value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMED_DATA(DateTime value )
        {
            var query = _query.ExistsByMED_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMED_VALOR(string value )
        {
            var query = _query.ExistsByMED_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMED_AC_ANO(string value )
        {
            var query = _query.ExistsByMED_AC_ANOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMED_DATAMEDICAO(string value )
        {
            var query = _query.ExistsByMED_DATAMEDICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMED_PONDERACAO(Decimal value )
        {
            var query = _query.ExistsByMED_PONDERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_ID(string value )
        {
            var query = _query.ExistsByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_DESCRICAO(string value )
        {
            var query = _query.ExistsByDIM_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_SUBDIMENSAO_ID(string value )
        {
            var query = _query.ExistsByDIM_SUBDIMENSAO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_SUB_DESCRICAO(string value )
        {
            var query = _query.ExistsByDIM_SUB_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(string value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_DESCRICAO(string value )
        {
            var query = _query.ExistsByPER_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFAT_ID(string value )
        {
            var query = _query.ExistsByFAT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFAT_DESCRICAO(string value )
        {
            var query = _query.ExistsByFAT_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMED_SQL(string value )
        {
            var query = _query.ExistsByMED_SQLQuery(value );

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

        public bool ExistsByMED_VALOR_DISPER(string value )
        {
            var query = _query.ExistsByMED_VALOR_DISPERQuery(value );

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

        public T_MedicoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_ID(int value )
        {
            var query = _query.FirstByMED_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_DATA(DateTime value )
        {
            var query = _query.FirstByMED_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_VALOR(string value )
        {
            var query = _query.FirstByMED_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_AC_ANO(string value )
        {
            var query = _query.FirstByMED_AC_ANOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_DATAMEDICAO(string value )
        {
            var query = _query.FirstByMED_DATAMEDICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_PONDERACAO(Decimal value )
        {
            var query = _query.FirstByMED_PONDERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByDIM_ID(string value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByDIM_DESCRICAO(string value )
        {
            var query = _query.FirstByDIM_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByDIM_SUBDIMENSAO_ID(string value )
        {
            var query = _query.FirstByDIM_SUBDIMENSAO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByDIM_SUB_DESCRICAO(string value )
        {
            var query = _query.FirstByDIM_SUB_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByPER_DESCRICAO(string value )
        {
            var query = _query.FirstByPER_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByFAT_ID(string value )
        {
            var query = _query.FirstByFAT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByFAT_DESCRICAO(string value )
        {
            var query = _query.FirstByFAT_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_SQL(string value )
        {
            var query = _query.FirstByMED_SQLQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByDOM_EMPRESA(string value )
        {
            var query = _query.FirstByDOM_EMPRESAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByDOM_FILIAL(string value )
        {
            var query = _query.FirstByDOM_FILIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByMED_VALOR_DISPER(string value )
        {
            var query = _query.FirstByMED_VALOR_DISPERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MedicoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_ID(int value )
        {
            var query = _query.FirstByMED_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_DATA(DateTime value )
        {
            var query = _query.FirstByMED_DATAQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_VALOR(string value )
        {
            var query = _query.FirstByMED_VALORQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_AC_ANO(string value )
        {
            var query = _query.FirstByMED_AC_ANOQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_DATAMEDICAO(string value )
        {
            var query = _query.FirstByMED_DATAMEDICAOQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_PONDERACAO(Decimal value )
        {
            var query = _query.FirstByMED_PONDERACAOQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByDIM_ID(string value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByDIM_DESCRICAO(string value )
        {
            var query = _query.FirstByDIM_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByDIM_SUBDIMENSAO_ID(string value )
        {
            var query = _query.FirstByDIM_SUBDIMENSAO_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByDIM_SUB_DESCRICAO(string value )
        {
            var query = _query.FirstByDIM_SUB_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByPER_DESCRICAO(string value )
        {
            var query = _query.FirstByPER_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByFAT_ID(string value )
        {
            var query = _query.FirstByFAT_IDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByFAT_DESCRICAO(string value )
        {
            var query = _query.FirstByFAT_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_SQL(string value )
        {
            var query = _query.FirstByMED_SQLQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByDOM_EMPRESA(string value )
        {
            var query = _query.FirstByDOM_EMPRESAQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByDOM_FILIAL(string value )
        {
            var query = _query.FirstByDOM_FILIALQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByMED_VALOR_DISPER(string value )
        {
            var query = _query.FirstByMED_VALOR_DISPERQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

        public IEnumerable<T_MedicoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_MedicoesDTO>(query.Query,query.Parameters) as List<T_MedicoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration