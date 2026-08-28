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
    public partial class MaquinaReadRepository : IMaquinaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMaquinaQueryRead _query;

        public MaquinaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMaquinaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MaquinaDTO> getMaquina(ICommandRead command )
         {
            if (command is Command.Read.MaquinaReadCommand c)
                return getMaquina(c );
            throw new NotImplementedException();
        }
        private DataPagination<MaquinaDTO> getMaquina(Command.Read.MaquinaReadCommand command )
        {
            var query = _query.MaquinaQuery(command );

                var itens = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters);
                return new DataPagination<MaquinaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MaquinaTenantIDDTO> getMaquinaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaTenantIDDTO> lista;
            var query = _query.MaquinaTenantIDQuery(command );

                lista = _unitOfWork.Query<MaquinaTenantIDDTO>(query.Query,query.Parameters) as List<MaquinaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MaquinaTenantIDDTO> getMaquinaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MaquinaUserIdDTO> getMaquinaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaUserIdDTO> lista;
            var query = _query.MaquinaUserIdQuery(command );

                lista = _unitOfWork.Query<MaquinaUserIdDTO>(query.Query,query.Parameters) as List<MaquinaUserIdDTO>;
            return lista;
        }

        public IEnumerable<MaquinaUserIdDTO> getMaquinaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MaquinaCAL_IDDTO> getMaquinaReadFKCAL_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaCAL_IDDTO> lista;
            var query = _query.MaquinaCAL_IDQuery(command );

                lista = _unitOfWork.Query<MaquinaCAL_IDDTO>(query.Query,query.Parameters) as List<MaquinaCAL_IDDTO>;
            return lista;
        }

        public IEnumerable<MaquinaCAL_IDDTO> getMaquinaReadFKCAL_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaReadFKCAL_ID(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(string value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public bool ExistsByCAL_ID(int value )
        {
            var query = _query.ExistsByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_CONTROL_IP(string value )
        {
            var query = _query.ExistsByMAQ_CONTROL_IPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGMA_ID(string value )
        {
            var query = _query.ExistsByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ULTIMA_ATUALIZACAO(DateTime value )
        {
            var query = _query.ExistsByMAQ_ULTIMA_ATUALIZACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_SIRENE_SEMAFORO(int value )
        {
            var query = _query.ExistsByMAQ_SIRENE_SEMAFOROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COR_SEMAFORO(string value )
        {
            var query = _query.ExistsByMAQ_COR_SEMAFOROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID_MAQ_PAI(string value )
        {
            var query = _query.ExistsByMAQ_ID_MAQ_PAIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TIPO_CONTADOR(int value )
        {
            var query = _query.ExistsByMAQ_TIPO_CONTADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TIPO_PLANEJAMENTO(string value )
        {
            var query = _query.ExistsByMAQ_TIPO_PLANEJAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_AVALIA_CUSTO(int value )
        {
            var query = _query.ExistsByMAQ_AVALIA_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_ID_OP_PRODUZINDO(int value )
        {
            var query = _query.ExistsByFPR_ID_OP_PRODUZINDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_CONGELA_FILA(int value )
        {
            var query = _query.ExistsByMAQ_CONGELA_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TEMPO_MIN_PARADA(int value )
        {
            var query = _query.ExistsByMAQ_TEMPO_MIN_PARADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_QTD_CORES(int value )
        {
            var query = _query.ExistsByMAQ_QTD_CORESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByMAQ_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByMAQ_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.ExistsByMAQ_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEQU_ID(string value )
        {
            var query = _query.ExistsByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value )
        {
            var query = _query.ExistsByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ACOMPANHA_LOTE_PILOTO(string value )
        {
            var query = _query.ExistsByMAQ_ACOMPANHA_LOTE_PILOTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID_SENSOR(int value )
        {
            var query = _query.ExistsByMAQ_ID_SENSORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_DEBOUNCING_LOW(int value )
        {
            var query = _query.ExistsByMAQ_DEBOUNCING_LOWQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_DEBOUNCING_HIGHT(int value )
        {
            var query = _query.ExistsByMAQ_DEBOUNCING_HIGHTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TIPO_SINAL(int value )
        {
            var query = _query.ExistsByMAQ_TIPO_SINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_CHAPA_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_CHAPA_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LARGURA_CHAPA_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_LARGURA_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LARGURA_CHAPA_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_LARGURA_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LARGURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_LARGURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LARGURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_LARGURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ALTURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_ALTURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ALTURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_ALTURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ABA_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_ABA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ABA_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_ABA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LAP_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_LAP_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LAP_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_LAP_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ONDAS(string value )
        {
            var query = _query.ExistsByMAQ_ONDASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_PROLONGA_LAP(string value )
        {
            var query = _query.ExistsByMAQ_PROLONGA_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LARGURA_IMPRESSAO(Decimal value )
        {
            var query = _query.ExistsByMAQ_LARGURA_IMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_COMPRIMENTO_IMPRESSAO(Decimal value )
        {
            var query = _query.ExistsByMAQ_COMPRIMENTO_IMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ROLO_DISPOSITIVO_DE(Decimal value )
        {
            var query = _query.ExistsByMAQ_ROLO_DISPOSITIVO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ROLO_DISPOSITIVO_ATE(Decimal value )
        {
            var query = _query.ExistsByMAQ_ROLO_DISPOSITIVO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_FAMILIAS(string value )
        {
            var query = _query.ExistsByMAQ_FAMILIASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_REFILE_MINIMO(Decimal value )
        {
            var query = _query.ExistsByMAQ_REFILE_MINIMOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_LARGURA_UTIL(Decimal value )
        {
            var query = _query.ExistsByMAQ_LARGURA_UTILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TOTAL_ACO(Decimal value )
        {
            var query = _query.ExistsByMAQ_TOTAL_ACOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_FECHAMENTO(string value )
        {
            var query = _query.ExistsByMAQ_FECHAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_OPERACAO_VINCAR(Decimal value )
        {
            var query = _query.ExistsByMAQ_OPERACAO_VINCARQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_OPERACAO_MONTA_DIVISAO(Decimal value )
        {
            var query = _query.ExistsByMAQ_OPERACAO_MONTA_DIVISAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_OPERACAO_SERRAR(Decimal value )
        {
            var query = _query.ExistsByMAQ_OPERACAO_SERRARQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TIPO_LAP(string value )
        {
            var query = _query.ExistsByMAQ_TIPO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_INDICE_PARADAS_POR_OP(Decimal value )
        {
            var query = _query.ExistsByMAQ_INDICE_PARADAS_POR_OPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_PERDA_MAXIMA(int value )
        {
            var query = _query.ExistsByMAQ_PERDA_MAXIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TOTAL_PECAS_REFILANDO(int value )
        {
            var query = _query.ExistsByMAQ_TOTAL_PECAS_REFILANDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TOTAL_PECAS_NAO_REFILANDO(int value )
        {
            var query = _query.ExistsByMAQ_TOTAL_PECAS_NAO_REFILANDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_TOTAL_VINCOS(int value )
        {
            var query = _query.ExistsByMAQ_TOTAL_VINCOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public MaquinaDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_CONTROL_IP(string value )
        {
            var query = _query.FirstByMAQ_CONTROL_IPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ULTIMA_ATUALIZACAO(DateTime value )
        {
            var query = _query.FirstByMAQ_ULTIMA_ATUALIZACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_SIRENE_SEMAFORO(int value )
        {
            var query = _query.FirstByMAQ_SIRENE_SEMAFOROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COR_SEMAFORO(string value )
        {
            var query = _query.FirstByMAQ_COR_SEMAFOROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ID_MAQ_PAI(string value )
        {
            var query = _query.FirstByMAQ_ID_MAQ_PAIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TIPO_CONTADOR(int value )
        {
            var query = _query.FirstByMAQ_TIPO_CONTADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TIPO_PLANEJAMENTO(string value )
        {
            var query = _query.FirstByMAQ_TIPO_PLANEJAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_AVALIA_CUSTO(int value )
        {
            var query = _query.FirstByMAQ_AVALIA_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByFPR_ID_OP_PRODUZINDO(int value )
        {
            var query = _query.FirstByFPR_ID_OP_PRODUZINDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_CONGELA_FILA(int value )
        {
            var query = _query.FirstByMAQ_CONGELA_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TEMPO_MIN_PARADA(int value )
        {
            var query = _query.FirstByMAQ_TEMPO_MIN_PARADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_QTD_CORES(int value )
        {
            var query = _query.FirstByMAQ_QTD_CORESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByMAQ_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByMAQ_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.FirstByMAQ_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ACOMPANHA_LOTE_PILOTO(string value )
        {
            var query = _query.FirstByMAQ_ACOMPANHA_LOTE_PILOTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ID_SENSOR(int value )
        {
            var query = _query.FirstByMAQ_ID_SENSORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_DEBOUNCING_LOW(int value )
        {
            var query = _query.FirstByMAQ_DEBOUNCING_LOWQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_DEBOUNCING_HIGHT(int value )
        {
            var query = _query.FirstByMAQ_DEBOUNCING_HIGHTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TIPO_SINAL(int value )
        {
            var query = _query.FirstByMAQ_TIPO_SINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_CHAPA_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_CHAPA_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LARGURA_CHAPA_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LARGURA_CHAPA_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LARGURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LARGURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ALTURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_ALTURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ALTURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_ALTURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ABA_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_ABA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ABA_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_ABA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LAP_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_LAP_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LAP_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_LAP_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ONDAS(string value )
        {
            var query = _query.FirstByMAQ_ONDASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_PROLONGA_LAP(string value )
        {
            var query = _query.FirstByMAQ_PROLONGA_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LARGURA_IMPRESSAO(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_IMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_COMPRIMENTO_IMPRESSAO(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_IMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ROLO_DISPOSITIVO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_ROLO_DISPOSITIVO_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_ROLO_DISPOSITIVO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_ROLO_DISPOSITIVO_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_FAMILIAS(string value )
        {
            var query = _query.FirstByMAQ_FAMILIASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_REFILE_MINIMO(Decimal value )
        {
            var query = _query.FirstByMAQ_REFILE_MINIMOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_LARGURA_UTIL(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_UTILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TOTAL_ACO(Decimal value )
        {
            var query = _query.FirstByMAQ_TOTAL_ACOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_FECHAMENTO(string value )
        {
            var query = _query.FirstByMAQ_FECHAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_OPERACAO_VINCAR(Decimal value )
        {
            var query = _query.FirstByMAQ_OPERACAO_VINCARQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_OPERACAO_MONTA_DIVISAO(Decimal value )
        {
            var query = _query.FirstByMAQ_OPERACAO_MONTA_DIVISAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_OPERACAO_SERRAR(Decimal value )
        {
            var query = _query.FirstByMAQ_OPERACAO_SERRARQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TIPO_LAP(string value )
        {
            var query = _query.FirstByMAQ_TIPO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_INDICE_PARADAS_POR_OP(Decimal value )
        {
            var query = _query.FirstByMAQ_INDICE_PARADAS_POR_OPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_PERDA_MAXIMA(int value )
        {
            var query = _query.FirstByMAQ_PERDA_MAXIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TOTAL_PECAS_REFILANDO(int value )
        {
            var query = _query.FirstByMAQ_TOTAL_PECAS_REFILANDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TOTAL_PECAS_NAO_REFILANDO(int value )
        {
            var query = _query.FirstByMAQ_TOTAL_PECAS_NAO_REFILANDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaDTO FirstByMAQ_TOTAL_VINCOS(int value )
        {
            var query = _query.FirstByMAQ_TOTAL_VINCOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_CONTROL_IP(string value )
        {
            var query = _query.FirstByMAQ_CONTROL_IPQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ULTIMA_ATUALIZACAO(DateTime value )
        {
            var query = _query.FirstByMAQ_ULTIMA_ATUALIZACAOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_SIRENE_SEMAFORO(int value )
        {
            var query = _query.FirstByMAQ_SIRENE_SEMAFOROQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COR_SEMAFORO(string value )
        {
            var query = _query.FirstByMAQ_COR_SEMAFOROQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ID_MAQ_PAI(string value )
        {
            var query = _query.FirstByMAQ_ID_MAQ_PAIQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TIPO_CONTADOR(int value )
        {
            var query = _query.FirstByMAQ_TIPO_CONTADORQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TIPO_PLANEJAMENTO(string value )
        {
            var query = _query.FirstByMAQ_TIPO_PLANEJAMENTOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_AVALIA_CUSTO(int value )
        {
            var query = _query.FirstByMAQ_AVALIA_CUSTOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByFPR_ID_OP_PRODUZINDO(int value )
        {
            var query = _query.FirstByFPR_ID_OP_PRODUZINDOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_CONGELA_FILA(int value )
        {
            var query = _query.FirstByMAQ_CONGELA_FILAQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TEMPO_MIN_PARADA(int value )
        {
            var query = _query.FirstByMAQ_TEMPO_MIN_PARADAQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_QTD_CORES(int value )
        {
            var query = _query.FirstByMAQ_QTD_CORESQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByMAQ_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByMAQ_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.FirstByMAQ_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ACOMPANHA_LOTE_PILOTO(string value )
        {
            var query = _query.FirstByMAQ_ACOMPANHA_LOTE_PILOTOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ID_SENSOR(int value )
        {
            var query = _query.FirstByMAQ_ID_SENSORQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_DEBOUNCING_LOW(int value )
        {
            var query = _query.FirstByMAQ_DEBOUNCING_LOWQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_DEBOUNCING_HIGHT(int value )
        {
            var query = _query.FirstByMAQ_DEBOUNCING_HIGHTQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TIPO_SINAL(int value )
        {
            var query = _query.FirstByMAQ_TIPO_SINALQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_CHAPA_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_CHAPA_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LARGURA_CHAPA_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_CHAPA_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LARGURA_CHAPA_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_CHAPA_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIORQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIORQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIORQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIORQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LARGURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LARGURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ALTURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_ALTURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ALTURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_ALTURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ABA_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_ABA_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ABA_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_ABA_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LAP_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_LAP_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LAP_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_LAP_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ONDAS(string value )
        {
            var query = _query.FirstByMAQ_ONDASQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_PROLONGA_LAP(string value )
        {
            var query = _query.FirstByMAQ_PROLONGA_LAPQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LARGURA_IMPRESSAO(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_IMPRESSAOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_COMPRIMENTO_IMPRESSAO(Decimal value )
        {
            var query = _query.FirstByMAQ_COMPRIMENTO_IMPRESSAOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ROLO_DISPOSITIVO_DE(Decimal value )
        {
            var query = _query.FirstByMAQ_ROLO_DISPOSITIVO_DEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_ROLO_DISPOSITIVO_ATE(Decimal value )
        {
            var query = _query.FirstByMAQ_ROLO_DISPOSITIVO_ATEQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_FAMILIAS(string value )
        {
            var query = _query.FirstByMAQ_FAMILIASQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_REFILE_MINIMO(Decimal value )
        {
            var query = _query.FirstByMAQ_REFILE_MINIMOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_LARGURA_UTIL(Decimal value )
        {
            var query = _query.FirstByMAQ_LARGURA_UTILQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TOTAL_ACO(Decimal value )
        {
            var query = _query.FirstByMAQ_TOTAL_ACOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_FECHAMENTO(string value )
        {
            var query = _query.FirstByMAQ_FECHAMENTOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_OPERACAO_VINCAR(Decimal value )
        {
            var query = _query.FirstByMAQ_OPERACAO_VINCARQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_OPERACAO_MONTA_DIVISAO(Decimal value )
        {
            var query = _query.FirstByMAQ_OPERACAO_MONTA_DIVISAOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_OPERACAO_SERRAR(Decimal value )
        {
            var query = _query.FirstByMAQ_OPERACAO_SERRARQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TIPO_LAP(string value )
        {
            var query = _query.FirstByMAQ_TIPO_LAPQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_INDICE_PARADAS_POR_OP(Decimal value )
        {
            var query = _query.FirstByMAQ_INDICE_PARADAS_POR_OPQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_PERDA_MAXIMA(int value )
        {
            var query = _query.FirstByMAQ_PERDA_MAXIMAQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TOTAL_PECAS_REFILANDO(int value )
        {
            var query = _query.FirstByMAQ_TOTAL_PECAS_REFILANDOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TOTAL_PECAS_NAO_REFILANDO(int value )
        {
            var query = _query.FirstByMAQ_TOTAL_PECAS_NAO_REFILANDOQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

        public IEnumerable<MaquinaDTO> GetAllByMAQ_TOTAL_VINCOS(int value )
        {
            var query = _query.FirstByMAQ_TOTAL_VINCOSQuery(value );

                var result = _unitOfWork.Query<MaquinaDTO>(query.Query,query.Parameters) as List<MaquinaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration