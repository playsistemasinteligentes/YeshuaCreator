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
    public partial class T_IndicadoresReadRepository : IT_IndicadoresReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_IndicadoresQueryRead _query;

        public T_IndicadoresReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_IndicadoresQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_IndicadoresCustom(Command.Read.T_IndicadoresReadCommand command, ref DataPagination<T_IndicadoresDTO> result, ref bool handled);

        public DataPagination<T_IndicadoresDTO> getT_Indicadores(ICommandRead command )
         {
            if (command is Command.Read.T_IndicadoresReadCommand c)
                return getT_Indicadores(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_IndicadoresDTO> getT_Indicadores(Command.Read.T_IndicadoresReadCommand command )
        {
            DataPagination<T_IndicadoresDTO> customResult = null;
            var customHandled = false;
            TryGetT_IndicadoresCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_IndicadoresQuery(command );

                var itens = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters);
                return new DataPagination<T_IndicadoresDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_IndicadoresNEG_IDDTO> getT_IndicadoresReadFKNEG_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_IndicadoresNEG_IDDTO> lista;
            var query = _query.T_IndicadoresNEG_IDQuery(command );

                lista = _unitOfWork.Query<T_IndicadoresNEG_IDDTO>(query.Query,query.Parameters) as List<T_IndicadoresNEG_IDDTO>;
            return lista;
        }

        public IEnumerable<T_IndicadoresNEG_IDDTO> getT_IndicadoresReadFKNEG_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_IndicadoresReadFKNEG_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_IndicadoresTenantIDDTO> getT_IndicadoresReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_IndicadoresTenantIDDTO> lista;
            var query = _query.T_IndicadoresTenantIDQuery(command );

                lista = _unitOfWork.Query<T_IndicadoresTenantIDDTO>(query.Query,query.Parameters) as List<T_IndicadoresTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_IndicadoresTenantIDDTO> getT_IndicadoresReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_IndicadoresReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_IndicadoresUserIdDTO> getT_IndicadoresReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_IndicadoresUserIdDTO> lista;
            var query = _query.T_IndicadoresUserIdQuery(command );

                lista = _unitOfWork.Query<T_IndicadoresUserIdDTO>(query.Query,query.Parameters) as List<T_IndicadoresUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_IndicadoresUserIdDTO> getT_IndicadoresReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_IndicadoresReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_DESCRICAO(string value )
        {
            var query = _query.ExistsByIND_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNEG_ID(int value )
        {
            var query = _query.ExistsByNEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDESC_CALCULO(string value )
        {
            var query = _query.ExistsByDESC_CALCULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_TIPOCOMPARADOR(int value )
        {
            var query = _query.ExistsByIND_TIPOCOMPARADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_GRAFICO(int value )
        {
            var query = _query.ExistsByIND_GRAFICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_CONEXAO(string value )
        {
            var query = _query.ExistsByIND_CONEXAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_DTCRIACAO(DateTime value )
        {
            var query = _query.ExistsByIND_DTCRIACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRESPOSAVELIND(string value )
        {
            var query = _query.ExistsByRESPOSAVELINDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRESPOSAVELCARGA(string value )
        {
            var query = _query.ExistsByRESPOSAVELCARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPROCEXTRACAO(string value )
        {
            var query = _query.ExistsByPROCEXTRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(string value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_ID(string value )
        {
            var query = _query.ExistsByDIM_IDQuery(value );

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

        public T_IndicadoresDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByIND_DESCRICAO(string value )
        {
            var query = _query.FirstByIND_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByNEG_ID(int value )
        {
            var query = _query.FirstByNEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByDESC_CALCULO(string value )
        {
            var query = _query.FirstByDESC_CALCULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByIND_TIPOCOMPARADOR(int value )
        {
            var query = _query.FirstByIND_TIPOCOMPARADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByIND_GRAFICO(int value )
        {
            var query = _query.FirstByIND_GRAFICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByIND_CONEXAO(string value )
        {
            var query = _query.FirstByIND_CONEXAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByIND_DTCRIACAO(DateTime value )
        {
            var query = _query.FirstByIND_DTCRIACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByRESPOSAVELIND(string value )
        {
            var query = _query.FirstByRESPOSAVELINDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByRESPOSAVELCARGA(string value )
        {
            var query = _query.FirstByRESPOSAVELCARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByPROCEXTRACAO(string value )
        {
            var query = _query.FirstByPROCEXTRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByDIM_ID(string value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByDOM_EMPRESA(string value )
        {
            var query = _query.FirstByDOM_EMPRESAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByDOM_FILIAL(string value )
        {
            var query = _query.FirstByDOM_FILIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_IndicadoresDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_IndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByIND_DESCRICAO(string value )
        {
            var query = _query.FirstByIND_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByNEG_ID(int value )
        {
            var query = _query.FirstByNEG_IDQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByDESC_CALCULO(string value )
        {
            var query = _query.FirstByDESC_CALCULOQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByIND_TIPOCOMPARADOR(int value )
        {
            var query = _query.FirstByIND_TIPOCOMPARADORQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByIND_GRAFICO(int value )
        {
            var query = _query.FirstByIND_GRAFICOQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByIND_CONEXAO(string value )
        {
            var query = _query.FirstByIND_CONEXAOQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByIND_DTCRIACAO(DateTime value )
        {
            var query = _query.FirstByIND_DTCRIACAOQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByRESPOSAVELIND(string value )
        {
            var query = _query.FirstByRESPOSAVELINDQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByRESPOSAVELCARGA(string value )
        {
            var query = _query.FirstByRESPOSAVELCARGAQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByPROCEXTRACAO(string value )
        {
            var query = _query.FirstByPROCEXTRACAOQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByDIM_ID(string value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByDOM_EMPRESA(string value )
        {
            var query = _query.FirstByDOM_EMPRESAQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByDOM_FILIAL(string value )
        {
            var query = _query.FirstByDOM_FILIALQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

        public IEnumerable<T_IndicadoresDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_IndicadoresDTO>(query.Query,query.Parameters) as List<T_IndicadoresDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration