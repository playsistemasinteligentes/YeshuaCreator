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
    public partial class TargetProdutoReadRepository : ITargetProdutoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITargetProdutoQueryRead _query;

        public TargetProdutoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITargetProdutoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TargetProdutoDTO> getTargetProduto(ICommandRead command )
         {
            if (command is Command.Read.TargetProdutoReadCommand c)
                return getTargetProduto(c );
            throw new NotImplementedException();
        }
        private DataPagination<TargetProdutoDTO> getTargetProduto(Command.Read.TargetProdutoReadCommand command )
        {
            var query = _query.TargetProdutoQuery(command );

                var itens = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters);
                return new DataPagination<TargetProdutoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TargetProdutoMOV_IDDTO> getTargetProdutoReadFKMOV_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoMOV_IDDTO> lista;
            var query = _query.TargetProdutoMOV_IDQuery(command );

                lista = _unitOfWork.Query<TargetProdutoMOV_IDDTO>(query.Query,query.Parameters) as List<TargetProdutoMOV_IDDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoMOV_IDDTO> getTargetProdutoReadFKMOV_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKMOV_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoORD_IDDTO> getTargetProdutoReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoORD_IDDTO> lista;
            var query = _query.TargetProdutoORD_IDQuery(command );

                lista = _unitOfWork.Query<TargetProdutoORD_IDDTO>(query.Query,query.Parameters) as List<TargetProdutoORD_IDDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoORD_IDDTO> getTargetProdutoReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoUNI_IDDTO> getTargetProdutoReadFKUNI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoUNI_IDDTO> lista;
            var query = _query.TargetProdutoUNI_IDQuery(command );

                lista = _unitOfWork.Query<TargetProdutoUNI_IDDTO>(query.Query,query.Parameters) as List<TargetProdutoUNI_IDDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoUNI_IDDTO> getTargetProdutoReadFKUNI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKUNI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoTURM_IDDTO> getTargetProdutoReadFKTURM_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoTURM_IDDTO> lista;
            var query = _query.TargetProdutoTURM_IDQuery(command );

                lista = _unitOfWork.Query<TargetProdutoTURM_IDDTO>(query.Query,query.Parameters) as List<TargetProdutoTURM_IDDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoTURM_IDDTO> getTargetProdutoReadFKTURM_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKTURM_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoTURN_IDDTO> getTargetProdutoReadFKTURN_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoTURN_IDDTO> lista;
            var query = _query.TargetProdutoTURN_IDQuery(command );

                lista = _unitOfWork.Query<TargetProdutoTURN_IDDTO>(query.Query,query.Parameters) as List<TargetProdutoTURN_IDDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoTURN_IDDTO> getTargetProdutoReadFKTURN_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKTURN_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoUSE_IDDTO> getTargetProdutoReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoUSE_IDDTO> lista;
            var query = _query.TargetProdutoUSE_IDQuery(command );

                lista = _unitOfWork.Query<TargetProdutoUSE_IDDTO>(query.Query,query.Parameters) as List<TargetProdutoUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoUSE_IDDTO> getTargetProdutoReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoOCO_ID_PERFORMANCEDTO> getTargetProdutoReadFKOCO_ID_PERFORMANCE(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoOCO_ID_PERFORMANCEDTO> lista;
            var query = _query.TargetProdutoOCO_ID_PERFORMANCEQuery(command );

                lista = _unitOfWork.Query<TargetProdutoOCO_ID_PERFORMANCEDTO>(query.Query,query.Parameters) as List<TargetProdutoOCO_ID_PERFORMANCEDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoOCO_ID_PERFORMANCEDTO> getTargetProdutoReadFKOCO_ID_PERFORMANCE(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKOCO_ID_PERFORMANCE(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoTenantIDDTO> getTargetProdutoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoTenantIDDTO> lista;
            var query = _query.TargetProdutoTenantIDQuery(command );

                lista = _unitOfWork.Query<TargetProdutoTenantIDDTO>(query.Query,query.Parameters) as List<TargetProdutoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoTenantIDDTO> getTargetProdutoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TargetProdutoUserIdDTO> getTargetProdutoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TargetProdutoUserIdDTO> lista;
            var query = _query.TargetProdutoUserIdQuery(command );

                lista = _unitOfWork.Query<TargetProdutoUserIdDTO>(query.Query,query.Parameters) as List<TargetProdutoUserIdDTO>;
            return lista;
        }

        public IEnumerable<TargetProdutoUserIdDTO> getTargetProdutoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTargetProdutoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByTAR_ID(int value )
        {
            var query = _query.ExistsByTAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_ID(int value )
        {
            var query = _query.ExistsByMOV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ID(string value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_ID(string value )
        {
            var query = _query.ExistsByTURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_ID(string value )
        {
            var query = _query.ExistsByTURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_DIA_TURMA(string value )
        {
            var query = _query.ExistsByTAR_DIA_TURMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_META_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByTAR_META_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_REALIZADO_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByTAR_REALIZADO_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PERCENTUAL_REALIZADO_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByTAR_PERCENTUAL_REALIZADO_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PROXIMA_META_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByTAR_PROXIMA_META_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_META_TEMPO_SETUP(Decimal value )
        {
            var query = _query.ExistsByTAR_META_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_REALIZADO_TEMPO_SETUP(Decimal value )
        {
            var query = _query.ExistsByTAR_REALIZADO_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PROXIMA_META_TEMPO_SETUP(Decimal value )
        {
            var query = _query.ExistsByTAR_PROXIMA_META_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_META_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.ExistsByTAR_META_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_REALIZADO_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.ExistsByTAR_REALIZADO_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.ExistsByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID_PERFORMANCE(string value )
        {
            var query = _query.ExistsByOCO_ID_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_OBS_PERFORMANCE(string value )
        {
            var query = _query.ExistsByTAR_OBS_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID_SETUP(string value )
        {
            var query = _query.ExistsByOCO_ID_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_OBS_SETUP(string value )
        {
            var query = _query.ExistsByTAR_OBS_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID_SETUPA(string value )
        {
            var query = _query.ExistsByOCO_ID_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_OBS_SETUPA(string value )
        {
            var query = _query.ExistsByTAR_OBS_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_TIPO_FEEDBACK_PERFORMANCE(string value )
        {
            var query = _query.ExistsByTAR_TIPO_FEEDBACK_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_TIPO_FEEDBACK_SETUP(string value )
        {
            var query = _query.ExistsByTAR_TIPO_FEEDBACK_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_TIPO_FEEDBACK_SETUP_AJUSTE(string value )
        {
            var query = _query.ExistsByTAR_TIPO_FEEDBACK_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_QTD_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.ExistsByTAR_QTD_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_QTD(Decimal value )
        {
            var query = _query.ExistsByTAR_QTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(int value )
        {
            var query = _query.ExistsByTAR_PARAMETRO_TIME_WORK_STOP_MACHINEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(int value )
        {
            var query = _query.ExistsByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.ExistsByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PERFORMANCE_MAX_VERDE(Decimal value )
        {
            var query = _query.ExistsByTAR_PERFORMANCE_MAX_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PERFORMANCE_MIN_VERDE(Decimal value )
        {
            var query = _query.ExistsByTAR_PERFORMANCE_MIN_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_SETUP_MAX_VERDE(Decimal value )
        {
            var query = _query.ExistsByTAR_SETUP_MAX_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_SETUP_MIN_VERDE(Decimal value )
        {
            var query = _query.ExistsByTAR_SETUP_MIN_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_SETUPA_MAX_VERDE(Decimal value )
        {
            var query = _query.ExistsByTAR_SETUPA_MAX_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_SETUPA_MIN_VERDE(Decimal value )
        {
            var query = _query.ExistsByTAR_SETUPA_MIN_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_PERFORMANCE_MIN_AMARELO(Decimal value )
        {
            var query = _query.ExistsByTAR_PERFORMANCE_MIN_AMARELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_SETUP_MAX_AMARELO(Decimal value )
        {
            var query = _query.ExistsByTAR_SETUP_MAX_AMARELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_SETUPA_MAX_AMARELO(Decimal value )
        {
            var query = _query.ExistsByTAR_SETUPA_MAX_AMARELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_OBS_OP_PARCIAL(string value )
        {
            var query = _query.ExistsByTAR_OBS_OP_PARCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_OCO_ID_OP_PARCIAL(string value )
        {
            var query = _query.ExistsByTAR_OCO_ID_OP_PARCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_COR_PERFORMANCE(string value )
        {
            var query = _query.ExistsByTAR_COR_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_COR_SETUP_GERAL(string value )
        {
            var query = _query.ExistsByTAR_COR_SETUP_GERALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_COR_SETUP(string value )
        {
            var query = _query.ExistsByTAR_COR_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_COR_SETUPA(string value )
        {
            var query = _query.ExistsByTAR_COR_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_DIA_TURMA_D(DateTime value )
        {
            var query = _query.ExistsByTAR_DIA_TURMA_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFEE_QTD_PECAS_POR_PULSO(Decimal value )
        {
            var query = _query.ExistsByFEE_QTD_PECAS_POR_PULSOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_QTD_PERDAS(Decimal value )
        {
            var query = _query.ExistsByTAR_QTD_PERDASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_DATA_INICIAL(DateTime value )
        {
            var query = _query.ExistsByTAR_DATA_INICIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_DATA_FINAL(DateTime value )
        {
            var query = _query.ExistsByTAR_DATA_FINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_APROVADO(string value )
        {
            var query = _query.ExistsByTAR_APROVADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTAR_TEMPO_PRODUZINDO(int value )
        {
            var query = _query.ExistsByTAR_TEMPO_PRODUZINDOQuery(value );

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

        public TargetProdutoDTO FirstByTAR_ID(int value )
        {
            var query = _query.FirstByTAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByMOV_ID(int value )
        {
            var query = _query.FirstByMOV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTURN_ID(string value )
        {
            var query = _query.FirstByTURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_DIA_TURMA(string value )
        {
            var query = _query.FirstByTAR_DIA_TURMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_META_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_META_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_REALIZADO_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_REALIZADO_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PERCENTUAL_REALIZADO_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_PERCENTUAL_REALIZADO_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PROXIMA_META_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_PROXIMA_META_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_META_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByTAR_META_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_REALIZADO_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByTAR_REALIZADO_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PROXIMA_META_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByTAR_PROXIMA_META_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_META_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_META_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_REALIZADO_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_REALIZADO_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByOCO_ID_PERFORMANCE(string value )
        {
            var query = _query.FirstByOCO_ID_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_OBS_PERFORMANCE(string value )
        {
            var query = _query.FirstByTAR_OBS_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByOCO_ID_SETUP(string value )
        {
            var query = _query.FirstByOCO_ID_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_OBS_SETUP(string value )
        {
            var query = _query.FirstByTAR_OBS_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByOCO_ID_SETUPA(string value )
        {
            var query = _query.FirstByOCO_ID_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_OBS_SETUPA(string value )
        {
            var query = _query.FirstByTAR_OBS_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_TIPO_FEEDBACK_PERFORMANCE(string value )
        {
            var query = _query.FirstByTAR_TIPO_FEEDBACK_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_TIPO_FEEDBACK_SETUP(string value )
        {
            var query = _query.FirstByTAR_TIPO_FEEDBACK_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_TIPO_FEEDBACK_SETUP_AJUSTE(string value )
        {
            var query = _query.FirstByTAR_TIPO_FEEDBACK_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_QTD_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_QTD_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_QTD(Decimal value )
        {
            var query = _query.FirstByTAR_QTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(int value )
        {
            var query = _query.FirstByTAR_PARAMETRO_TIME_WORK_STOP_MACHINEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(int value )
        {
            var query = _query.FirstByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PERFORMANCE_MAX_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_PERFORMANCE_MAX_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PERFORMANCE_MIN_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_PERFORMANCE_MIN_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_SETUP_MAX_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUP_MAX_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_SETUP_MIN_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUP_MIN_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_SETUPA_MAX_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUPA_MAX_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_SETUPA_MIN_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUPA_MIN_VERDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_PERFORMANCE_MIN_AMARELO(Decimal value )
        {
            var query = _query.FirstByTAR_PERFORMANCE_MIN_AMARELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_SETUP_MAX_AMARELO(Decimal value )
        {
            var query = _query.FirstByTAR_SETUP_MAX_AMARELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_SETUPA_MAX_AMARELO(Decimal value )
        {
            var query = _query.FirstByTAR_SETUPA_MAX_AMARELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_OBS_OP_PARCIAL(string value )
        {
            var query = _query.FirstByTAR_OBS_OP_PARCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_OCO_ID_OP_PARCIAL(string value )
        {
            var query = _query.FirstByTAR_OCO_ID_OP_PARCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_COR_PERFORMANCE(string value )
        {
            var query = _query.FirstByTAR_COR_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_COR_SETUP_GERAL(string value )
        {
            var query = _query.FirstByTAR_COR_SETUP_GERALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_COR_SETUP(string value )
        {
            var query = _query.FirstByTAR_COR_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_COR_SETUPA(string value )
        {
            var query = _query.FirstByTAR_COR_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_DIA_TURMA_D(DateTime value )
        {
            var query = _query.FirstByTAR_DIA_TURMA_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByFEE_QTD_PECAS_POR_PULSO(Decimal value )
        {
            var query = _query.FirstByFEE_QTD_PECAS_POR_PULSOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_QTD_PERDAS(Decimal value )
        {
            var query = _query.FirstByTAR_QTD_PERDASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_DATA_INICIAL(DateTime value )
        {
            var query = _query.FirstByTAR_DATA_INICIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_DATA_FINAL(DateTime value )
        {
            var query = _query.FirstByTAR_DATA_FINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_APROVADO(string value )
        {
            var query = _query.FirstByTAR_APROVADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTAR_TEMPO_PRODUZINDO(int value )
        {
            var query = _query.FirstByTAR_TEMPO_PRODUZINDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TargetProdutoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TargetProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_ID(int value )
        {
            var query = _query.FirstByTAR_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByMOV_ID(int value )
        {
            var query = _query.FirstByMOV_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTURN_ID(string value )
        {
            var query = _query.FirstByTURN_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_DIA_TURMA(string value )
        {
            var query = _query.FirstByTAR_DIA_TURMAQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_META_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_META_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_REALIZADO_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_REALIZADO_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PERCENTUAL_REALIZADO_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_PERCENTUAL_REALIZADO_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PROXIMA_META_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByTAR_PROXIMA_META_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_META_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByTAR_META_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_REALIZADO_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByTAR_REALIZADO_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PROXIMA_META_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByTAR_PROXIMA_META_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_META_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_META_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_REALIZADO_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_REALIZADO_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByOCO_ID_PERFORMANCE(string value )
        {
            var query = _query.FirstByOCO_ID_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_OBS_PERFORMANCE(string value )
        {
            var query = _query.FirstByTAR_OBS_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByOCO_ID_SETUP(string value )
        {
            var query = _query.FirstByOCO_ID_SETUPQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_OBS_SETUP(string value )
        {
            var query = _query.FirstByTAR_OBS_SETUPQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByOCO_ID_SETUPA(string value )
        {
            var query = _query.FirstByOCO_ID_SETUPAQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_OBS_SETUPA(string value )
        {
            var query = _query.FirstByTAR_OBS_SETUPAQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_TIPO_FEEDBACK_PERFORMANCE(string value )
        {
            var query = _query.FirstByTAR_TIPO_FEEDBACK_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_TIPO_FEEDBACK_SETUP(string value )
        {
            var query = _query.FirstByTAR_TIPO_FEEDBACK_SETUPQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_TIPO_FEEDBACK_SETUP_AJUSTE(string value )
        {
            var query = _query.FirstByTAR_TIPO_FEEDBACK_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_QTD_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByTAR_QTD_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_QTD(Decimal value )
        {
            var query = _query.FirstByTAR_QTDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(int value )
        {
            var query = _query.FirstByTAR_PARAMETRO_TIME_WORK_STOP_MACHINEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(int value )
        {
            var query = _query.FirstByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PERFORMANCE_MAX_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_PERFORMANCE_MAX_VERDEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PERFORMANCE_MIN_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_PERFORMANCE_MIN_VERDEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_SETUP_MAX_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUP_MAX_VERDEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_SETUP_MIN_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUP_MIN_VERDEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_SETUPA_MAX_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUPA_MAX_VERDEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_SETUPA_MIN_VERDE(Decimal value )
        {
            var query = _query.FirstByTAR_SETUPA_MIN_VERDEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_PERFORMANCE_MIN_AMARELO(Decimal value )
        {
            var query = _query.FirstByTAR_PERFORMANCE_MIN_AMARELOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_SETUP_MAX_AMARELO(Decimal value )
        {
            var query = _query.FirstByTAR_SETUP_MAX_AMARELOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_SETUPA_MAX_AMARELO(Decimal value )
        {
            var query = _query.FirstByTAR_SETUPA_MAX_AMARELOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_OBS_OP_PARCIAL(string value )
        {
            var query = _query.FirstByTAR_OBS_OP_PARCIALQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_OCO_ID_OP_PARCIAL(string value )
        {
            var query = _query.FirstByTAR_OCO_ID_OP_PARCIALQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_COR_PERFORMANCE(string value )
        {
            var query = _query.FirstByTAR_COR_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_COR_SETUP_GERAL(string value )
        {
            var query = _query.FirstByTAR_COR_SETUP_GERALQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_COR_SETUP(string value )
        {
            var query = _query.FirstByTAR_COR_SETUPQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_COR_SETUPA(string value )
        {
            var query = _query.FirstByTAR_COR_SETUPAQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_DIA_TURMA_D(DateTime value )
        {
            var query = _query.FirstByTAR_DIA_TURMA_DQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByFEE_QTD_PECAS_POR_PULSO(Decimal value )
        {
            var query = _query.FirstByFEE_QTD_PECAS_POR_PULSOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_QTD_PERDAS(Decimal value )
        {
            var query = _query.FirstByTAR_QTD_PERDASQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_DATA_INICIAL(DateTime value )
        {
            var query = _query.FirstByTAR_DATA_INICIALQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_DATA_FINAL(DateTime value )
        {
            var query = _query.FirstByTAR_DATA_FINALQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_APROVADO(string value )
        {
            var query = _query.FirstByTAR_APROVADOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTAR_TEMPO_PRODUZINDO(int value )
        {
            var query = _query.FirstByTAR_TEMPO_PRODUZINDOQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

        public IEnumerable<TargetProdutoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TargetProdutoDTO>(query.Query,query.Parameters) as List<TargetProdutoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration