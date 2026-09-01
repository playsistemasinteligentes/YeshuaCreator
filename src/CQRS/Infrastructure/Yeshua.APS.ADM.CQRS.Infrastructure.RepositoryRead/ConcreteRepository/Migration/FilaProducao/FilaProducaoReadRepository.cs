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
    public partial class FilaProducaoReadRepository : IFilaProducaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IFilaProducaoQueryRead _query;

        public FilaProducaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IFilaProducaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetFilaProducaoCustom(Command.Read.FilaProducaoReadCommand command, ref DataPagination<FilaProducaoDTO> result, ref bool handled);

        public DataPagination<FilaProducaoDTO> getFilaProducao(ICommandRead command )
         {
            if (command is Command.Read.FilaProducaoReadCommand c)
                return getFilaProducao(c );
            throw new NotImplementedException();
        }
        private DataPagination<FilaProducaoDTO> getFilaProducao(Command.Read.FilaProducaoReadCommand command )
        {
            DataPagination<FilaProducaoDTO> customResult = null;
            var customHandled = false;
            TryGetFilaProducaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.FilaProducaoQuery(command );

                var itens = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters);
                return new DataPagination<FilaProducaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<FilaProducaoORD_IDDTO> getFilaProducaoReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FilaProducaoORD_IDDTO> lista;
            var query = _query.FilaProducaoORD_IDQuery(command );

                lista = _unitOfWork.Query<FilaProducaoORD_IDDTO>(query.Query,query.Parameters) as List<FilaProducaoORD_IDDTO>;
            return lista;
        }

        public IEnumerable<FilaProducaoORD_IDDTO> getFilaProducaoReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFilaProducaoReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FilaProducaoOCO_IDDTO> getFilaProducaoReadFKOCO_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FilaProducaoOCO_IDDTO> lista;
            var query = _query.FilaProducaoOCO_IDQuery(command );

                lista = _unitOfWork.Query<FilaProducaoOCO_IDDTO>(query.Query,query.Parameters) as List<FilaProducaoOCO_IDDTO>;
            return lista;
        }

        public IEnumerable<FilaProducaoOCO_IDDTO> getFilaProducaoReadFKOCO_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFilaProducaoReadFKOCO_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FilaProducaoTenantIDDTO> getFilaProducaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FilaProducaoTenantIDDTO> lista;
            var query = _query.FilaProducaoTenantIDQuery(command );

                lista = _unitOfWork.Query<FilaProducaoTenantIDDTO>(query.Query,query.Parameters) as List<FilaProducaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<FilaProducaoTenantIDDTO> getFilaProducaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFilaProducaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FilaProducaoUserIdDTO> getFilaProducaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FilaProducaoUserIdDTO> lista;
            var query = _query.FilaProducaoUserIdQuery(command );

                lista = _unitOfWork.Query<FilaProducaoUserIdDTO>(query.Query,query.Parameters) as List<FilaProducaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<FilaProducaoUserIdDTO> getFilaProducaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFilaProducaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PRO_ID(string value )
        {
            var query = _query.ExistsByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_QUANTIDADE_PREVISTA(Decimal value )
        {
            var query = _query.ExistsByFPR_QUANTIDADE_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_MAQ_ID(string value )
        {
            var query = _query.ExistsByROT_MAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_INICIO_PREVISTA(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_INICIO_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_FIM_PREVISTA(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_FIM_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_FIM_MAXIMA(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_FIM_MAXIMAQuery(value );

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

        public bool ExistsByFPR_OBS_PRODUCAO(string value )
        {
            var query = _query.ExistsByFPR_OBS_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_STATUS(string value )
        {
            var query = _query.ExistsByFPR_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TEMPO_DECORRIDO_SETUP(Decimal value )
        {
            var query = _query.ExistsByFPR_TEMPO_DECORRIDO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TEMPO_DECORRIDO_SETUPA(Decimal value )
        {
            var query = _query.ExistsByFPR_TEMPO_DECORRIDO_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TEMPO_DECORRIDO_PERFORMANC(Decimal value )
        {
            var query = _query.ExistsByFPR_TEMPO_DECORRIDO_PERFORMANCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TEMPO_DECO_PEQUENA_PARADA(Decimal value )
        {
            var query = _query.ExistsByFPR_TEMPO_DECO_PEQUENA_PARADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_QTD_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByFPR_QTD_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_QTD_SETUP(Decimal value )
        {
            var query = _query.ExistsByFPR_QTD_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_QTD_PRODUZIDA(Decimal value )
        {
            var query = _query.ExistsByFPR_QTD_PRODUZIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TEMPO_TEORICO_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByFPR_TEMPO_TEORICO_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TEMPO_RESTANTE_PERFORMANC(Decimal value )
        {
            var query = _query.ExistsByFPR_TEMPO_RESTANTE_PERFORMANCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_VELOCIDADE_P_ATINGIR_META(Decimal value )
        {
            var query = _query.ExistsByFPR_VELOCIDADE_P_ATINGIR_METAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_QTD_RESTANTE(Decimal value )
        {
            var query = _query.ExistsByFPR_QTD_RESTANTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_VELO_ATU_PC_SEGUNDO(Decimal value )
        {
            var query = _query.ExistsByFPR_VELO_ATU_PC_SEGUNDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_PERFORMANCE_PROJETADA(Decimal value )
        {
            var query = _query.ExistsByFPR_PERFORMANCE_PROJETADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TEMPO_RESTANTE_TOTAL(Decimal value )
        {
            var query = _query.ExistsByFPR_TEMPO_RESTANTE_TOTALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_FIM_PREVISTO_ATUAL(DateTime value )
        {
            var query = _query.ExistsByFPR_FIM_PREVISTO_ATUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_PRODUZINDO(int value )
        {
            var query = _query.ExistsByFPR_PRODUZINDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_ORDEM_NA_FILA(Decimal value )
        {
            var query = _query.ExistsByFPR_ORDEM_NA_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByFPR_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TRUNCADO(string value )
        {
            var query = _query.ExistsByFPR_TRUNCADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_TRUNC_INI(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_TRUNC_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_TRUNC_FIM(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_TRUNC_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_ID(int value )
        {
            var query = _query.ExistsByFPR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_COR_FILA(string value )
        {
            var query = _query.ExistsByFPR_COR_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID_MANUAL(string value )
        {
            var query = _query.ExistsByMAQ_ID_MANUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID_RESTRINGIDA(string value )
        {
            var query = _query.ExistsByMAQ_ID_RESTRINGIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.ExistsByFPR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_NECESSIDADE_INICIO_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_NECESSIDADE_FIM_PRODUCAO(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_NECESSIDADE_FIM_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.ExistsByFPR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_INICIO_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.ExistsByFPR_INICIO_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_FIM_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.ExistsByFPR_FIM_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_COR_BICO1(string value )
        {
            var query = _query.ExistsByFPR_COR_BICO1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_COR_BICO2(string value )
        {
            var query = _query.ExistsByFPR_COR_BICO2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_COR_BICO3(string value )
        {
            var query = _query.ExistsByFPR_COR_BICO3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_COR_BICO4(string value )
        {
            var query = _query.ExistsByFPR_COR_BICO4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_COR_BICO5(string value )
        {
            var query = _query.ExistsByFPR_COR_BICO5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_META_SETUP(Decimal value )
        {
            var query = _query.ExistsByFPR_META_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_ORD_ID_REPROGRAMADO(string value )
        {
            var query = _query.ExistsByFPR_ORD_ID_REPROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_PRIORIDADE(int value )
        {
            var query = _query.ExistsByFPR_PRIORIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_INCLUSAO_FILA(int value )
        {
            var query = _query.ExistsByFPR_SEQ_INCLUSAO_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_HIERARQUIA_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.ExistsByFPR_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_ID_ORIGEM(int value )
        {
            var query = _query.ExistsByFPR_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_ENTREGA(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEQU_ID(string value )
        {
            var query = _query.ExistsByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_GRUPO_PRODUTIVO_MANUAL(Decimal value )
        {
            var query = _query.ExistsByFPR_GRUPO_PRODUTIVO_MANUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByFPR_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_MOTIVO_PULA_FILA(string value )
        {
            var query = _query.ExistsByFPR_MOTIVO_PULA_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID(string value )
        {
            var query = _query.ExistsByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.ExistsByFPR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.ExistsByFPR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_DATA_ENCERRAMENTO(DateTime value )
        {
            var query = _query.ExistsByFPR_DATA_ENCERRAMENTOQuery(value );

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

        public FilaProducaoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_QUANTIDADE_PREVISTA(Decimal value )
        {
            var query = _query.FirstByFPR_QUANTIDADE_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByROT_MAQ_ID(string value )
        {
            var query = _query.FirstByROT_MAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_INICIO_PREVISTA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_INICIO_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_FIM_PREVISTA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_FIM_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_FIM_MAXIMA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_FIM_MAXIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_OBS_PRODUCAO(string value )
        {
            var query = _query.FirstByFPR_OBS_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_STATUS(string value )
        {
            var query = _query.FirstByFPR_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TEMPO_DECORRIDO_SETUP(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECORRIDO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TEMPO_DECORRIDO_SETUPA(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECORRIDO_SETUPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TEMPO_DECORRIDO_PERFORMANC(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECORRIDO_PERFORMANCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TEMPO_DECO_PEQUENA_PARADA(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECO_PEQUENA_PARADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_QTD_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_QTD_SETUP(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_QTD_PRODUZIDA(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_PRODUZIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TEMPO_TEORICO_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_TEORICO_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TEMPO_RESTANTE_PERFORMANC(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_RESTANTE_PERFORMANCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_VELOCIDADE_P_ATINGIR_META(Decimal value )
        {
            var query = _query.FirstByFPR_VELOCIDADE_P_ATINGIR_METAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_QTD_RESTANTE(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_RESTANTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_VELO_ATU_PC_SEGUNDO(Decimal value )
        {
            var query = _query.FirstByFPR_VELO_ATU_PC_SEGUNDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_PERFORMANCE_PROJETADA(Decimal value )
        {
            var query = _query.FirstByFPR_PERFORMANCE_PROJETADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TEMPO_RESTANTE_TOTAL(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_RESTANTE_TOTALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_FIM_PREVISTO_ATUAL(DateTime value )
        {
            var query = _query.FirstByFPR_FIM_PREVISTO_ATUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_PRODUZINDO(int value )
        {
            var query = _query.FirstByFPR_PRODUZINDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_ORDEM_NA_FILA(Decimal value )
        {
            var query = _query.FirstByFPR_ORDEM_NA_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByFPR_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TRUNCADO(string value )
        {
            var query = _query.FirstByFPR_TRUNCADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_TRUNC_INI(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_TRUNC_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_TRUNC_FIM(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_TRUNC_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_ID(int value )
        {
            var query = _query.FirstByFPR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_COR_FILA(string value )
        {
            var query = _query.FirstByFPR_COR_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByMAQ_ID_MANUAL(string value )
        {
            var query = _query.FirstByMAQ_ID_MANUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByMAQ_ID_RESTRINGIDA(string value )
        {
            var query = _query.FirstByMAQ_ID_RESTRINGIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.FirstByFPR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_NECESSIDADE_INICIO_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_NECESSIDADE_FIM_PRODUCAO(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_NECESSIDADE_FIM_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByFPR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_INICIO_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByFPR_INICIO_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_FIM_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByFPR_FIM_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_COR_BICO1(string value )
        {
            var query = _query.FirstByFPR_COR_BICO1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_COR_BICO2(string value )
        {
            var query = _query.FirstByFPR_COR_BICO2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_COR_BICO3(string value )
        {
            var query = _query.FirstByFPR_COR_BICO3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_COR_BICO4(string value )
        {
            var query = _query.FirstByFPR_COR_BICO4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_COR_BICO5(string value )
        {
            var query = _query.FirstByFPR_COR_BICO5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_META_SETUP(Decimal value )
        {
            var query = _query.FirstByFPR_META_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_ORD_ID_REPROGRAMADO(string value )
        {
            var query = _query.FirstByFPR_ORD_ID_REPROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_PRIORIDADE(int value )
        {
            var query = _query.FirstByFPR_PRIORIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_SEQ_INCLUSAO_FILA(int value )
        {
            var query = _query.FirstByFPR_SEQ_INCLUSAO_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_HIERARQUIA_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.FirstByFPR_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_ID_ORIGEM(int value )
        {
            var query = _query.FirstByFPR_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_ENTREGA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_GRUPO_PRODUTIVO_MANUAL(Decimal value )
        {
            var query = _query.FirstByFPR_GRUPO_PRODUTIVO_MANUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_EMISSAO(DateTime value )
        {
            var query = _query.FirstByFPR_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_MOTIVO_PULA_FILA(string value )
        {
            var query = _query.FirstByFPR_MOTIVO_PULA_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByFPR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByFPR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByFPR_DATA_ENCERRAMENTO(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_ENCERRAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public FilaProducaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FilaProducaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_QUANTIDADE_PREVISTA(Decimal value )
        {
            var query = _query.FirstByFPR_QUANTIDADE_PREVISTAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByROT_MAQ_ID(string value )
        {
            var query = _query.FirstByROT_MAQ_IDQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_INICIO_PREVISTA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_INICIO_PREVISTAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_FIM_PREVISTA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_FIM_PREVISTAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_FIM_MAXIMA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_FIM_MAXIMAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_OBS_PRODUCAO(string value )
        {
            var query = _query.FirstByFPR_OBS_PRODUCAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_STATUS(string value )
        {
            var query = _query.FirstByFPR_STATUSQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TEMPO_DECORRIDO_SETUP(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECORRIDO_SETUPQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TEMPO_DECORRIDO_SETUPA(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECORRIDO_SETUPAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TEMPO_DECORRIDO_PERFORMANC(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECORRIDO_PERFORMANCQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TEMPO_DECO_PEQUENA_PARADA(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_DECO_PEQUENA_PARADAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_QTD_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_QTD_SETUP(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_SETUPQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_QTD_PRODUZIDA(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_PRODUZIDAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TEMPO_TEORICO_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_TEORICO_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TEMPO_RESTANTE_PERFORMANC(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_RESTANTE_PERFORMANCQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_VELOCIDADE_P_ATINGIR_META(Decimal value )
        {
            var query = _query.FirstByFPR_VELOCIDADE_P_ATINGIR_METAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_QTD_RESTANTE(Decimal value )
        {
            var query = _query.FirstByFPR_QTD_RESTANTEQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_VELO_ATU_PC_SEGUNDO(Decimal value )
        {
            var query = _query.FirstByFPR_VELO_ATU_PC_SEGUNDOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_PERFORMANCE_PROJETADA(Decimal value )
        {
            var query = _query.FirstByFPR_PERFORMANCE_PROJETADAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TEMPO_RESTANTE_TOTAL(Decimal value )
        {
            var query = _query.FirstByFPR_TEMPO_RESTANTE_TOTALQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_FIM_PREVISTO_ATUAL(DateTime value )
        {
            var query = _query.FirstByFPR_FIM_PREVISTO_ATUALQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_PRODUZINDO(int value )
        {
            var query = _query.FirstByFPR_PRODUZINDOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_ORDEM_NA_FILA(Decimal value )
        {
            var query = _query.FirstByFPR_ORDEM_NA_FILAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByFPR_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TRUNCADO(string value )
        {
            var query = _query.FirstByFPR_TRUNCADOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_TRUNC_INI(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_TRUNC_INIQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_TRUNC_FIM(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_TRUNC_FIMQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_ID(int value )
        {
            var query = _query.FirstByFPR_IDQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_COR_FILA(string value )
        {
            var query = _query.FirstByFPR_COR_FILAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByMAQ_ID_MANUAL(string value )
        {
            var query = _query.FirstByMAQ_ID_MANUALQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByMAQ_ID_RESTRINGIDA(string value )
        {
            var query = _query.FirstByMAQ_ID_RESTRINGIDAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.FirstByFPR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_NECESSIDADE_INICIO_PRODUCAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_NECESSIDADE_FIM_PRODUCAO(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_NECESSIDADE_FIM_PRODUCAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByFPR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_INICIO_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByFPR_INICIO_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_FIM_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByFPR_FIM_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_COR_BICO1(string value )
        {
            var query = _query.FirstByFPR_COR_BICO1Query(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_COR_BICO2(string value )
        {
            var query = _query.FirstByFPR_COR_BICO2Query(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_COR_BICO3(string value )
        {
            var query = _query.FirstByFPR_COR_BICO3Query(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_COR_BICO4(string value )
        {
            var query = _query.FirstByFPR_COR_BICO4Query(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_COR_BICO5(string value )
        {
            var query = _query.FirstByFPR_COR_BICO5Query(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_META_SETUP(Decimal value )
        {
            var query = _query.FirstByFPR_META_SETUPQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_ORD_ID_REPROGRAMADO(string value )
        {
            var query = _query.FirstByFPR_ORD_ID_REPROGRAMADOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_PRIORIDADE(int value )
        {
            var query = _query.FirstByFPR_PRIORIDADEQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_SEQ_INCLUSAO_FILA(int value )
        {
            var query = _query.FirstByFPR_SEQ_INCLUSAO_FILAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_HIERARQUIA_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.FirstByFPR_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_ID_ORIGEM(int value )
        {
            var query = _query.FirstByFPR_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_ENTREGA(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_ENTREGAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_GRUPO_PRODUTIVO_MANUAL(Decimal value )
        {
            var query = _query.FirstByFPR_GRUPO_PRODUTIVO_MANUALQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_EMISSAO(DateTime value )
        {
            var query = _query.FirstByFPR_EMISSAOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_MOTIVO_PULA_FILA(string value )
        {
            var query = _query.FirstByFPR_MOTIVO_PULA_FILAQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByFPR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByFPR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByFPR_DATA_ENCERRAMENTO(DateTime value )
        {
            var query = _query.FirstByFPR_DATA_ENCERRAMENTOQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

        public IEnumerable<FilaProducaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<FilaProducaoDTO>(query.Query,query.Parameters) as List<FilaProducaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration