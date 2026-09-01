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
    public partial class CargaPrevistaReadRepository : ICargaPrevistaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICargaPrevistaQueryRead _query;

        public CargaPrevistaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICargaPrevistaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCargaPrevistaCustom(Command.Read.CargaPrevistaReadCommand command, ref DataPagination<CargaPrevistaDTO> result, ref bool handled);

        public DataPagination<CargaPrevistaDTO> getCargaPrevista(ICommandRead command )
         {
            if (command is Command.Read.CargaPrevistaReadCommand c)
                return getCargaPrevista(c );
            throw new NotImplementedException();
        }
        private DataPagination<CargaPrevistaDTO> getCargaPrevista(Command.Read.CargaPrevistaReadCommand command )
        {
            DataPagination<CargaPrevistaDTO> customResult = null;
            var customHandled = false;
            TryGetCargaPrevistaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CargaPrevistaQuery(command );

                var itens = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters);
                return new DataPagination<CargaPrevistaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CargaPrevistaTenantIDDTO> getCargaPrevistaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CargaPrevistaTenantIDDTO> lista;
            var query = _query.CargaPrevistaTenantIDQuery(command );

                lista = _unitOfWork.Query<CargaPrevistaTenantIDDTO>(query.Query,query.Parameters) as List<CargaPrevistaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CargaPrevistaTenantIDDTO> getCargaPrevistaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCargaPrevistaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CargaPrevistaUserIdDTO> getCargaPrevistaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CargaPrevistaUserIdDTO> lista;
            var query = _query.CargaPrevistaUserIdQuery(command );

                lista = _unitOfWork.Query<CargaPrevistaUserIdDTO>(query.Query,query.Parameters) as List<CargaPrevistaUserIdDTO>;
            return lista;
        }

        public IEnumerable<CargaPrevistaUserIdDTO> getCargaPrevistaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCargaPrevistaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID(string value )
        {
            var query = _query.ExistsByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITC_QTD_PLANEJADA(Decimal value )
        {
            var query = _query.ExistsByITC_QTD_PLANEJADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.ExistsByCAR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_INICIO_REALIZADO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_INICIO_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_FIM_PREVISTO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_FIM_REALIZADO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_FIM_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.ExistsByCAR_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.ExistsByCAR_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.ExistsByCAR_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_STATUS(Decimal value )
        {
            var query = _query.ExistsByCAR_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_PESO_TEORICO(Decimal value )
        {
            var query = _query.ExistsByCAR_PESO_TEORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_VOLUME_TEORICO(Decimal value )
        {
            var query = _query.ExistsByCAR_VOLUME_TEORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_PESO_REAL(Decimal value )
        {
            var query = _query.ExistsByCAR_PESO_REALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_VOLUME_REAL(Decimal value )
        {
            var query = _query.ExistsByCAR_VOLUME_REALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_PESO_EMBALAGEM(Decimal value )
        {
            var query = _query.ExistsByCAR_PESO_EMBALAGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_PESO_ENTRADA(Decimal value )
        {
            var query = _query.ExistsByCAR_PESO_ENTRADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_PESO_SAIDA(Decimal value )
        {
            var query = _query.ExistsByCAR_PESO_SAIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID_DOCA(string value )
        {
            var query = _query.ExistsByCAR_ID_DOCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_PLACA(string value )
        {
            var query = _query.ExistsByVEI_PLACAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_ID(int value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_ID(string value )
        {
            var query = _query.ExistsByTRA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.ExistsByCAR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_ID(string value )
        {
            var query = _query.ExistsByROT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_OBSERVACAO_DE_TRANSPORTE(string value )
        {
            var query = _query.ExistsByCAR_OBSERVACAO_DE_TRANSPORTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value )
        {
            var query = _query.ExistsByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID(string value )
        {
            var query = _query.ExistsByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID_JUNTADA(string value )
        {
            var query = _query.ExistsByCAR_ID_JUNTADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.ExistsByCAR_OBSERVACAO_OTIMIZADORQuery(value );

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

        public CargaPrevistaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByITC_QTD_PLANEJADA(Decimal value )
        {
            var query = _query.FirstByITC_QTD_PLANEJADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.FirstByCAR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_DATA_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_DATA_INICIO_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_DATA_FIM_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_DATA_FIM_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.FirstByCAR_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_STATUS(Decimal value )
        {
            var query = _query.FirstByCAR_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_PESO_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_TEORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_VOLUME_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_TEORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_PESO_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_REALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_VOLUME_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_REALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_PESO_EMBALAGEM(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_EMBALAGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_PESO_ENTRADA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_ENTRADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_PESO_SAIDA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_SAIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_ID_DOCA(string value )
        {
            var query = _query.FirstByCAR_ID_DOCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByVEI_PLACA(string value )
        {
            var query = _query.FirstByVEI_PLACAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByTRA_ID(string value )
        {
            var query = _query.FirstByTRA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCAR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByROT_ID(string value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_OBSERVACAO_DE_TRANSPORTE(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_DE_TRANSPORTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value )
        {
            var query = _query.FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_ID_JUNTADA(string value )
        {
            var query = _query.FirstByCAR_ID_JUNTADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByCAR_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_OTIMIZADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaPrevistaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaPrevistaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByITC_QTD_PLANEJADA(Decimal value )
        {
            var query = _query.FirstByITC_QTD_PLANEJADAQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.FirstByCAR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_INICIO_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_REALIZADOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_FIM_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_FIM_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_REALIZADOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.FirstByCAR_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_STATUS(Decimal value )
        {
            var query = _query.FirstByCAR_STATUSQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_TEORICOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_VOLUME_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_TEORICOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_REALQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_VOLUME_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_REALQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_EMBALAGEM(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_EMBALAGEMQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_ENTRADA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_ENTRADAQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_SAIDA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_SAIDAQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_ID_DOCA(string value )
        {
            var query = _query.FirstByCAR_ID_DOCAQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByVEI_PLACA(string value )
        {
            var query = _query.FirstByVEI_PLACAQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByTRA_ID(string value )
        {
            var query = _query.FirstByTRA_IDQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCAR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByROT_ID(string value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_OBSERVACAO_DE_TRANSPORTE(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_DE_TRANSPORTEQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value )
        {
            var query = _query.FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_ID_JUNTADA(string value )
        {
            var query = _query.FirstByCAR_ID_JUNTADAQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_OTIMIZADORQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

        public IEnumerable<CargaPrevistaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CargaPrevistaDTO>(query.Query,query.Parameters) as List<CargaPrevistaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration