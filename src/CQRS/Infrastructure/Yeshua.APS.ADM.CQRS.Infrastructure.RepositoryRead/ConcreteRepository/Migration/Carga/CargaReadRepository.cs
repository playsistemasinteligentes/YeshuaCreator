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
    public partial class CargaReadRepository : ICargaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICargaQueryRead _query;

        public CargaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICargaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CargaDTO> getCarga(ICommandRead command )
         {
            if (command is Command.Read.CargaReadCommand c)
                return getCarga(c );
            throw new NotImplementedException();
        }
        private DataPagination<CargaDTO> getCarga(Command.Read.CargaReadCommand command )
        {
            var query = _query.CargaQuery(command );

                var itens = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters);
                return new DataPagination<CargaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CargaOCO_IDDTO> getCargaReadFKOCO_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CargaOCO_IDDTO> lista;
            var query = _query.CargaOCO_IDQuery(command );

                lista = _unitOfWork.Query<CargaOCO_IDDTO>(query.Query,query.Parameters) as List<CargaOCO_IDDTO>;
            return lista;
        }

        public IEnumerable<CargaOCO_IDDTO> getCargaReadFKOCO_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCargaReadFKOCO_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CargaTenantIDDTO> getCargaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CargaTenantIDDTO> lista;
            var query = _query.CargaTenantIDQuery(command );

                lista = _unitOfWork.Query<CargaTenantIDDTO>(query.Query,query.Parameters) as List<CargaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CargaTenantIDDTO> getCargaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCargaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CargaUserIdDTO> getCargaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CargaUserIdDTO> lista;
            var query = _query.CargaUserIdQuery(command );

                lista = _unitOfWork.Query<CargaUserIdDTO>(query.Query,query.Parameters) as List<CargaUserIdDTO>;
            return lista;
        }

        public IEnumerable<CargaUserIdDTO> getCargaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCargaReadFKUserId(c );
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

        public bool ExistsByCAR_ID_INTEGRACAO_BALANCA(string value )
        {
            var query = _query.ExistsByCAR_ID_INTEGRACAO_BALANCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_PESAGEM_LIBERADA(string value )
        {
            var query = _query.ExistsByCAR_PESAGEM_LIBERADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_OBS_LIERACAO(string value )
        {
            var query = _query.ExistsByCAR_OBS_LIERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID_LIERACAO(string value )
        {
            var query = _query.ExistsByOCO_ID_LIERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_ENTRADA_VEICULO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_ENTRADA_VEICULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_SAIDA_VEICULO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_SAIDA_VEICULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_ROMANEIO_CONSOLIDADO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_ROMANEIO_CONSOLIDADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(string value )
        {
            var query = _query.ExistsByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DIFERENCA_PESAGEM(Decimal value )
        {
            var query = _query.ExistsByCAR_DIFERENCA_PESAGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_DATA_AGENCIAMENTO(DateTime value )
        {
            var query = _query.ExistsByCAR_DATA_AGENCIAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_ID(string value )
        {
            var query = _query.ExistsByTURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_ID(string value )
        {
            var query = _query.ExistsByTURM_IDQuery(value );

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

        public CargaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.FirstByCAR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_INICIO_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_FIM_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_FIM_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.FirstByCAR_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_STATUS(Decimal value )
        {
            var query = _query.FirstByCAR_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_PESO_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_TEORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_VOLUME_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_TEORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_PESO_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_REALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_VOLUME_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_REALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_PESO_EMBALAGEM(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_EMBALAGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_PESO_ENTRADA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_ENTRADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_PESO_SAIDA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_SAIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_ID_DOCA(string value )
        {
            var query = _query.FirstByCAR_ID_DOCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByVEI_PLACA(string value )
        {
            var query = _query.FirstByVEI_PLACAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByTRA_ID(string value )
        {
            var query = _query.FirstByTRA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCAR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByROT_ID(string value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_OBSERVACAO_DE_TRANSPORTE(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_DE_TRANSPORTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value )
        {
            var query = _query.FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_ID_JUNTADA(string value )
        {
            var query = _query.FirstByCAR_ID_JUNTADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_OTIMIZADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_ID_INTEGRACAO_BALANCA(string value )
        {
            var query = _query.FirstByCAR_ID_INTEGRACAO_BALANCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_PESAGEM_LIBERADA(string value )
        {
            var query = _query.FirstByCAR_PESAGEM_LIBERADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_OBS_LIERACAO(string value )
        {
            var query = _query.FirstByCAR_OBS_LIERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByOCO_ID_LIERACAO(string value )
        {
            var query = _query.FirstByOCO_ID_LIERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_ENTRADA_VEICULO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_ENTRADA_VEICULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_SAIDA_VEICULO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_SAIDA_VEICULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_ROMANEIO_CONSOLIDADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_ROMANEIO_CONSOLIDADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(string value )
        {
            var query = _query.FirstByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DIFERENCA_PESAGEM(Decimal value )
        {
            var query = _query.FirstByCAR_DIFERENCA_PESAGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByCAR_DATA_AGENCIAMENTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_AGENCIAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByTURN_ID(string value )
        {
            var query = _query.FirstByTURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public CargaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CargaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_PREVISAO_MATERIA_PRIMA(DateTime value )
        {
            var query = _query.FirstByCAR_PREVISAO_MATERIA_PRIMAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_INICIO_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_INICIO_REALIZADOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_FIM_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_FIM_REALIZADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_FIM_REALIZADOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByCAR_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.FirstByCAR_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_STATUS(Decimal value )
        {
            var query = _query.FirstByCAR_STATUSQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_PESO_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_TEORICOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_VOLUME_TEORICO(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_TEORICOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_PESO_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_REALQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_VOLUME_REAL(Decimal value )
        {
            var query = _query.FirstByCAR_VOLUME_REALQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_PESO_EMBALAGEM(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_EMBALAGEMQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_PESO_ENTRADA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_ENTRADAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_PESO_SAIDA(Decimal value )
        {
            var query = _query.FirstByCAR_PESO_SAIDAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_ID_DOCA(string value )
        {
            var query = _query.FirstByCAR_ID_DOCAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByVEI_PLACA(string value )
        {
            var query = _query.FirstByVEI_PLACAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByTRA_ID(string value )
        {
            var query = _query.FirstByTRA_IDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCAR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByROT_ID(string value )
        {
            var query = _query.FirstByROT_IDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_OBSERVACAO_DE_TRANSPORTE(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_DE_TRANSPORTEQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value )
        {
            var query = _query.FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_ID_JUNTADA(string value )
        {
            var query = _query.FirstByCAR_ID_JUNTADAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.FirstByCAR_OBSERVACAO_OTIMIZADORQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_ID_INTEGRACAO_BALANCA(string value )
        {
            var query = _query.FirstByCAR_ID_INTEGRACAO_BALANCAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_PESAGEM_LIBERADA(string value )
        {
            var query = _query.FirstByCAR_PESAGEM_LIBERADAQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_OBS_LIERACAO(string value )
        {
            var query = _query.FirstByCAR_OBS_LIERACAOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByOCO_ID_LIERACAO(string value )
        {
            var query = _query.FirstByOCO_ID_LIERACAOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_ENTRADA_VEICULO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_ENTRADA_VEICULOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_SAIDA_VEICULO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_SAIDA_VEICULOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_ROMANEIO_CONSOLIDADO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_ROMANEIO_CONSOLIDADOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(string value )
        {
            var query = _query.FirstByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DIFERENCA_PESAGEM(Decimal value )
        {
            var query = _query.FirstByCAR_DIFERENCA_PESAGEMQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByCAR_DATA_AGENCIAMENTO(DateTime value )
        {
            var query = _query.FirstByCAR_DATA_AGENCIAMENTOQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByTURN_ID(string value )
        {
            var query = _query.FirstByTURN_IDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

        public IEnumerable<CargaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CargaDTO>(query.Query,query.Parameters) as List<CargaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration