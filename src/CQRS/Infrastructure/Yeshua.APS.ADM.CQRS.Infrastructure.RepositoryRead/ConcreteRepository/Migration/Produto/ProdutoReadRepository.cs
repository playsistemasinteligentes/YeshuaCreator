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
    public partial class ProdutoReadRepository : IProdutoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IProdutoQueryRead _query;

        public ProdutoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IProdutoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetProdutoCustom(Command.Read.ProdutoReadCommand command, ref DataPagination<ProdutoDTO> result, ref bool handled);

        public DataPagination<ProdutoDTO> getProduto(ICommandRead command )
         {
            if (command is Command.Read.ProdutoReadCommand c)
                return getProduto(c );
            throw new NotImplementedException();
        }
        private DataPagination<ProdutoDTO> getProduto(Command.Read.ProdutoReadCommand command )
        {
            DataPagination<ProdutoDTO> customResult = null;
            var customHandled = false;
            TryGetProdutoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ProdutoQuery(command );

                var itens = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters);
                return new DataPagination<ProdutoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ProdutoTenantIDDTO> getProdutoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProdutoTenantIDDTO> lista;
            var query = _query.ProdutoTenantIDQuery(command );

                lista = _unitOfWork.Query<ProdutoTenantIDDTO>(query.Query,query.Parameters) as List<ProdutoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ProdutoTenantIDDTO> getProdutoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProdutoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProdutoUserIdDTO> getProdutoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProdutoUserIdDTO> lista;
            var query = _query.ProdutoUserIdQuery(command );

                lista = _unitOfWork.Query<ProdutoUserIdDTO>(query.Query,query.Parameters) as List<ProdutoUserIdDTO>;
            return lista;
        }

        public IEnumerable<ProdutoUserIdDTO> getProdutoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProdutoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProdutoUNI_IDDTO> getProdutoReadFKUNI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProdutoUNI_IDDTO> lista;
            var query = _query.ProdutoUNI_IDQuery(command );

                lista = _unitOfWork.Query<ProdutoUNI_IDDTO>(query.Query,query.Parameters) as List<ProdutoUNI_IDDTO>;
            return lista;
        }

        public IEnumerable<ProdutoUNI_IDDTO> getProdutoReadFKUNI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProdutoReadFKUNI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProdutoGRP_IDDTO> getProdutoReadFKGRP_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProdutoGRP_IDDTO> lista;
            var query = _query.ProdutoGRP_IDQuery(command );

                lista = _unitOfWork.Query<ProdutoGRP_IDDTO>(query.Query,query.Parameters) as List<ProdutoGRP_IDDTO>;
            return lista;
        }

        public IEnumerable<ProdutoGRP_IDDTO> getProdutoReadFKGRP_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProdutoReadFKGRP_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProdutoVIN_IDDTO> getProdutoReadFKVIN_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProdutoVIN_IDDTO> lista;
            var query = _query.ProdutoVIN_IDQuery(command );

                lista = _unitOfWork.Query<ProdutoVIN_IDDTO>(query.Query,query.Parameters) as List<ProdutoVIN_IDDTO>;
            return lista;
        }

        public IEnumerable<ProdutoVIN_IDDTO> getProdutoReadFKVIN_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProdutoReadFKVIN_ID(c );
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

        public bool ExistsByPRO_ESTOQUE_ATUAL(Decimal value )
        {
            var query = _query.ExistsByPRO_ESTOQUE_ATUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ID(string value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FARDOS_POR_CAMADA(Decimal value )
        {
            var query = _query.ExistsByPRO_FARDOS_POR_CAMADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_CAMADAS_POR_PALETE(Decimal value )
        {
            var query = _query.ExistsByPRO_CAMADAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TIPO_IDENTIFICACAO(int value )
        {
            var query = _query.ExistsByPRO_TIPO_IDENTIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_GRUPO_PALETIZACAO(string value )
        {
            var query = _query.ExistsByPRO_GRUPO_PALETIZACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PECAS_POR_FARDO(Decimal value )
        {
            var query = _query.ExistsByPRO_PECAS_POR_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByPRO_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByPRO_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID(string value )
        {
            var query = _query.ExistsByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ALTURA_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_ALTURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LARGURA_EMBALADA(Decimal value )
        {
            var query = _query.ExistsByPRO_LARGURA_EMBALADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_EMBALADA(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_EMBALADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ALTURA_EMBALADA(Decimal value )
        {
            var query = _query.ExistsByPRO_ALTURA_EMBALADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FRENTE(string value )
        {
            var query = _query.ExistsByPRO_FRENTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ROTACIONA_COMPRIMENTO(string value )
        {
            var query = _query.ExistsByPRO_ROTACIONA_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ROTACIONA_LARGURA(string value )
        {
            var query = _query.ExistsByPRO_ROTACIONA_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ROTACIONA_ALTURA(string value )
        {
            var query = _query.ExistsByPRO_ROTACIONA_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ESCALA_COR(string value )
        {
            var query = _query.ExistsByPRO_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SUB_ESCALA_COR(string value )
        {
            var query = _query.ExistsByPRO_SUB_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_CUSTO_SUBIDA_ESCALA_COR(Decimal value )
        {
            var query = _query.ExistsByPRO_CUSTO_SUBIDA_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_CUSTO_DECIDA_ESCALA_COR(Decimal value )
        {
            var query = _query.ExistsByPRO_CUSTO_DECIDA_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTMP_TIPO_CARGA(string value )
        {
            var query = _query.ExistsByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TEMPO_CARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByPRO_TEMPO_CARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByPRO_TEMPO_DESCARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PERCENTUAL_JANELA_EMBARQUE(Decimal value )
        {
            var query = _query.ExistsByPRO_PERCENTUAL_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TEMPO_PRODUCAO_CONJUNTO(Decimal value )
        {
            var query = _query.ExistsByPRO_TEMPO_PRODUCAO_CONJUNTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PECAS_DA_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_PECAS_DA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TYPE(int value )
        {
            var query = _query.ExistsByPRO_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COLOR_HEXA(string value )
        {
            var query = _query.ExistsByPRO_COLOR_HEXAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_VINCOS_LARGURA(string value )
        {
            var query = _query.ExistsByPRO_VINCOS_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_VINCOS_COMPRIMENTO(string value )
        {
            var query = _query.ExistsByPRO_VINCOS_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LARGURA_INTERNA(Decimal value )
        {
            var query = _query.ExistsByPRO_LARGURA_INTERNAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_INTERNA(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_INTERNAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ALTURA_INTERNA(Decimal value )
        {
            var query = _query.ExistsByPRO_ALTURA_INTERNAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COD_DESENHO(string value )
        {
            var query = _query.ExistsByPRO_COD_DESENHOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FECHAMENTO(string value )
        {
            var query = _query.ExistsByPRO_FECHAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TIPO_LAP(string value )
        {
            var query = _query.ExistsByPRO_TIPO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TAMANHO_LAP(Decimal value )
        {
            var query = _query.ExistsByPRO_TAMANHO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LAP_PROLONGADO(string value )
        {
            var query = _query.ExistsByPRO_LAP_PROLONGADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TAMANHO_LAP_PROLONG(Decimal value )
        {
            var query = _query.ExistsByPRO_TAMANHO_LAP_PROLONGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ARRANJO_LARGURA(Decimal value )
        {
            var query = _query.ExistsByPRO_ARRANJO_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ARRANJO_COMPRIMENTO(Decimal value )
        {
            var query = _query.ExistsByPRO_ARRANJO_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FITILHOS_FARDO_LARG(int value )
        {
            var query = _query.ExistsByPRO_FITILHOS_FARDO_LARGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FITILHOS_FARDO_COMP(int value )
        {
            var query = _query.ExistsByPRO_FITILHOS_FARDO_COMPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FITILHOS_PALETE_LARG(int value )
        {
            var query = _query.ExistsByPRO_FITILHOS_PALETE_LARGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FITILHOS_PALETE_COMP(int value )
        {
            var query = _query.ExistsByPRO_FITILHOS_PALETE_COMPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_FILME_PALETE(int value )
        {
            var query = _query.ExistsByPRO_FILME_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QTD_ESPELHO(int value )
        {
            var query = _query.ExistsByPRO_QTD_ESPELHOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_CUSTO(Decimal value )
        {
            var query = _query.ExistsByPRO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_AREA_LIQUIDA(Decimal value )
        {
            var query = _query.ExistsByPRO_AREA_LIQUIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PESO(Decimal value )
        {
            var query = _query.ExistsByPRO_PESOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TOLERANCIA_DIMENSAO_CHAPA_DE(int value )
        {
            var query = _query.ExistsByPRO_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(int value )
        {
            var query = _query.ExistsByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_IMG_LASTRO(string value )
        {
            var query = _query.ExistsByPRO_IMG_LASTROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByABN_ID(string value )
        {
            var query = _query.ExistsByABN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEG_ID(int value )
        {
            var query = _query.ExistsBySEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_RESINA(string value )
        {
            var query = _query.ExistsByPRO_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.ExistsByPRO_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.ExistsByPRO_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ADICIONAL_ABA_SUPERIOR(int value )
        {
            var query = _query.ExistsByPRO_ADICIONAL_ABA_SUPERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ADICIONAL_ABA_INFERIOR(int value )
        {
            var query = _query.ExistsByPRO_ADICIONAL_ABA_INFERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PROMOVE_RESINA(string value )
        {
            var query = _query.ExistsByPRO_PROMOVE_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PROMOVE_DE(Decimal value )
        {
            var query = _query.ExistsByPRO_PROMOVE_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PROMOVE_ATE(Decimal value )
        {
            var query = _query.ExistsByPRO_PROMOVE_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PROFUNDIDADE_VINCO(int value )
        {
            var query = _query.ExistsByPRO_PROFUNDIDADE_VINCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVIN_ID(int value )
        {
            var query = _query.ExistsByVIN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PROMOVE_PRODUTO(string value )
        {
            var query = _query.ExistsByPRO_PROMOVE_PRODUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TARA(Decimal value )
        {
            var query = _query.ExistsByPRO_TARAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRESSAO(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COD_BARRAS_CAIXA(string value )
        {
            var query = _query.ExistsByPRO_COD_BARRAS_CAIXAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCJN_ID(string value )
        {
            var query = _query.ExistsByCJN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRJ_ID(string value )
        {
            var query = _query.ExistsByPRJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_REFILE_LARGURA(int value )
        {
            var query = _query.ExistsByPRO_REFILE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_REFILE_COMPRIMENTO(int value )
        {
            var query = _query.ExistsByPRO_REFILE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_M2_PONTA(Decimal value )
        {
            var query = _query.ExistsByPRO_M2_PONTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QTD_CORTES_PECA1(int value )
        {
            var query = _query.ExistsByPRO_QTD_CORTES_PECA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QTD_CORTES_PECA2(int value )
        {
            var query = _query.ExistsByPRO_QTD_CORTES_PECA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_DIVISAO_MONTADA(string value )
        {
            var query = _query.ExistsByPRO_DIVISAO_MONTADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_A(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_AQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_B(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_BQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_C(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_CQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_D(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_E(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_F(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_FQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_G(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_GQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_H(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_HQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_SEGMENTO_I(Decimal value )
        {
            var query = _query.ExistsByPRO_SEGMENTO_IQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QTD_GRAMPOS(Decimal value )
        {
            var query = _query.ExistsByPRO_QTD_GRAMPOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_AREA_REFILE_INTERNO(Decimal value )
        {
            var query = _query.ExistsByPRO_AREA_REFILE_INTERNOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_AREA_REFILE_EXTERNO(Decimal value )
        {
            var query = _query.ExistsByPRO_AREA_REFILE_EXTERNOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PESO_REFILE(Decimal value )
        {
            var query = _query.ExistsByPRO_PESO_REFILEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ORELHA_INVERTIDA(string value )
        {
            var query = _query.ExistsByPRO_ORELHA_INVERTIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ENDERECO(string value )
        {
            var query = _query.ExistsByPRO_ENDERECOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_VINCULADO(string value )
        {
            var query = _query.ExistsByPRO_ID_VINCULADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_BATIDAS_PROXIMA_MANUTENCAO(int value )
        {
            var query = _query.ExistsByPRO_BATIDAS_PROXIMA_MANUTENCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ENTRADA_NA_MAQUINA(string value )
        {
            var query = _query.ExistsByPRO_ENTRADA_NA_MAQUINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTDI_ID(string value )
        {
            var query = _query.ExistsByTDI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QUEBRA_VINCO(int value )
        {
            var query = _query.ExistsByPRO_QUEBRA_VINCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LARGURA_FARDO(int value )
        {
            var query = _query.ExistsByPRO_LARGURA_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_FARDO(int value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ALTURA_FARDO(Decimal value )
        {
            var query = _query.ExistsByPRO_ALTURA_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_TIPO_CUSTO(string value )
        {
            var query = _query.ExistsByPRO_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_GRUPO_CONTABIL(string value )
        {
            var query = _query.ExistsByPRO_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_CLASSE_CUSTO_01(string value )
        {
            var query = _query.ExistsByPRO_CLASSE_CUSTO_01Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_OBS_ALTERACAO(string value )
        {
            var query = _query.ExistsByPRO_OBS_ALTERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_ID(int value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_PECAS_POR_VEICULO(Decimal value )
        {
            var query = _query.ExistsByPRO_PECAS_POR_VEICULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_DISTANCIA_ENTRE_VINCOS(int value )
        {
            var query = _query.ExistsByPRO_DISTANCIA_ENTRE_VINCOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_DISTANCIA_ENTRE_VINCOS2(int value )
        {
            var query = _query.ExistsByPRO_DISTANCIA_ENTRE_VINCOS2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_DISTANCIA_ENTRE_VINCOS3(int value )
        {
            var query = _query.ExistsByPRO_DISTANCIA_ENTRE_VINCOS3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_OUT(int value )
        {
            var query = _query.ExistsByPRO_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_FACA(string value )
        {
            var query = _query.ExistsByPRO_ID_FACAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_CLICHE(string value )
        {
            var query = _query.ExistsByPRO_ID_CLICHEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_TINTA_01(string value )
        {
            var query = _query.ExistsByPRO_ID_TINTA_01Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_TINTA_02(string value )
        {
            var query = _query.ExistsByPRO_ID_TINTA_02Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_TINTA_03(string value )
        {
            var query = _query.ExistsByPRO_ID_TINTA_03Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_TINTA_04(string value )
        {
            var query = _query.ExistsByPRO_ID_TINTA_04Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_TINTA_05(string value )
        {
            var query = _query.ExistsByPRO_ID_TINTA_05Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_FORROSUP(string value )
        {
            var query = _query.ExistsByPRO_ID_FORROSUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_CANTONEIRA(string value )
        {
            var query = _query.ExistsByPRO_ID_CANTONEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_PALETE(string value )
        {
            var query = _query.ExistsByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_TAMPO(string value )
        {
            var query = _query.ExistsByPRO_ID_TAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_FORROINF(string value )
        {
            var query = _query.ExistsByPRO_ID_FORROINFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_CHAPA(string value )
        {
            var query = _query.ExistsByPRO_ID_CHAPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_COMPOSICAO(string value )
        {
            var query = _query.ExistsByPRO_ID_COMPOSICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QUEBRA_VINCO_MAIOR(int value )
        {
            var query = _query.ExistsByPRO_QUEBRA_VINCO_MAIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QUEBRA_VINCO_MENOR(int value )
        {
            var query = _query.ExistsByPRO_QUEBRA_VINCO_MENORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ProdutoDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ESTOQUE_ATUAL(Decimal value )
        {
            var query = _query.FirstByPRO_ESTOQUE_ATUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FARDOS_POR_CAMADA(Decimal value )
        {
            var query = _query.FirstByPRO_FARDOS_POR_CAMADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_CAMADAS_POR_PALETE(Decimal value )
        {
            var query = _query.FirstByPRO_CAMADAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TIPO_IDENTIFICACAO(int value )
        {
            var query = _query.FirstByPRO_TIPO_IDENTIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_GRUPO_PALETIZACAO(string value )
        {
            var query = _query.FirstByPRO_GRUPO_PALETIZACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PECAS_POR_FARDO(Decimal value )
        {
            var query = _query.FirstByPRO_PECAS_POR_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByPRO_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByPRO_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ALTURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_LARGURA_EMBALADA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_EMBALADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COMPRIMENTO_EMBALADA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_EMBALADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ALTURA_EMBALADA(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_EMBALADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FRENTE(string value )
        {
            var query = _query.FirstByPRO_FRENTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ROTACIONA_COMPRIMENTO(string value )
        {
            var query = _query.FirstByPRO_ROTACIONA_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ROTACIONA_LARGURA(string value )
        {
            var query = _query.FirstByPRO_ROTACIONA_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ROTACIONA_ALTURA(string value )
        {
            var query = _query.FirstByPRO_ROTACIONA_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ESCALA_COR(string value )
        {
            var query = _query.FirstByPRO_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SUB_ESCALA_COR(string value )
        {
            var query = _query.FirstByPRO_SUB_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_CUSTO_SUBIDA_ESCALA_COR(Decimal value )
        {
            var query = _query.FirstByPRO_CUSTO_SUBIDA_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_CUSTO_DECIDA_ESCALA_COR(Decimal value )
        {
            var query = _query.FirstByPRO_CUSTO_DECIDA_ESCALA_CORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByTMP_TIPO_CARGA(string value )
        {
            var query = _query.FirstByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TEMPO_CARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByPRO_TEMPO_CARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByPRO_TEMPO_DESCARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PERCENTUAL_JANELA_EMBARQUE(Decimal value )
        {
            var query = _query.FirstByPRO_PERCENTUAL_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TEMPO_PRODUCAO_CONJUNTO(Decimal value )
        {
            var query = _query.FirstByPRO_TEMPO_PRODUCAO_CONJUNTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PECAS_DA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_PECAS_DA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TYPE(int value )
        {
            var query = _query.FirstByPRO_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COLOR_HEXA(string value )
        {
            var query = _query.FirstByPRO_COLOR_HEXAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_VINCOS_LARGURA(string value )
        {
            var query = _query.FirstByPRO_VINCOS_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_VINCOS_COMPRIMENTO(string value )
        {
            var query = _query.FirstByPRO_VINCOS_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_LARGURA_INTERNA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_INTERNAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COMPRIMENTO_INTERNA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_INTERNAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ALTURA_INTERNA(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_INTERNAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COD_DESENHO(string value )
        {
            var query = _query.FirstByPRO_COD_DESENHOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FECHAMENTO(string value )
        {
            var query = _query.FirstByPRO_FECHAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TIPO_LAP(string value )
        {
            var query = _query.FirstByPRO_TIPO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TAMANHO_LAP(Decimal value )
        {
            var query = _query.FirstByPRO_TAMANHO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_LAP_PROLONGADO(string value )
        {
            var query = _query.FirstByPRO_LAP_PROLONGADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TAMANHO_LAP_PROLONG(Decimal value )
        {
            var query = _query.FirstByPRO_TAMANHO_LAP_PROLONGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ARRANJO_LARGURA(Decimal value )
        {
            var query = _query.FirstByPRO_ARRANJO_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ARRANJO_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByPRO_ARRANJO_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FITILHOS_FARDO_LARG(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_FARDO_LARGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FITILHOS_FARDO_COMP(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_FARDO_COMPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FITILHOS_PALETE_LARG(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_PALETE_LARGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FITILHOS_PALETE_COMP(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_PALETE_COMPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_FILME_PALETE(int value )
        {
            var query = _query.FirstByPRO_FILME_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_QTD_ESPELHO(int value )
        {
            var query = _query.FirstByPRO_QTD_ESPELHOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_CUSTO(Decimal value )
        {
            var query = _query.FirstByPRO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_AREA_LIQUIDA(Decimal value )
        {
            var query = _query.FirstByPRO_AREA_LIQUIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PESO(Decimal value )
        {
            var query = _query.FirstByPRO_PESOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_DE(int value )
        {
            var query = _query.FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(int value )
        {
            var query = _query.FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_IMG_LASTRO(string value )
        {
            var query = _query.FirstByPRO_IMG_LASTROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByABN_ID(string value )
        {
            var query = _query.FirstByABN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstBySEG_ID(int value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_RESINA(string value )
        {
            var query = _query.FirstByPRO_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.FirstByPRO_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.FirstByPRO_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ADICIONAL_ABA_SUPERIOR(int value )
        {
            var query = _query.FirstByPRO_ADICIONAL_ABA_SUPERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ADICIONAL_ABA_INFERIOR(int value )
        {
            var query = _query.FirstByPRO_ADICIONAL_ABA_INFERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PROMOVE_RESINA(string value )
        {
            var query = _query.FirstByPRO_PROMOVE_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PROMOVE_DE(Decimal value )
        {
            var query = _query.FirstByPRO_PROMOVE_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PROMOVE_ATE(Decimal value )
        {
            var query = _query.FirstByPRO_PROMOVE_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PROFUNDIDADE_VINCO(int value )
        {
            var query = _query.FirstByPRO_PROFUNDIDADE_VINCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PROMOVE_PRODUTO(string value )
        {
            var query = _query.FirstByPRO_PROMOVE_PRODUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TARA(Decimal value )
        {
            var query = _query.FirstByPRO_TARAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COMPRESSAO(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COD_BARRAS_CAIXA(string value )
        {
            var query = _query.FirstByPRO_COD_BARRAS_CAIXAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByCJN_ID(string value )
        {
            var query = _query.FirstByCJN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRJ_ID(string value )
        {
            var query = _query.FirstByPRJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_REFILE_LARGURA(int value )
        {
            var query = _query.FirstByPRO_REFILE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_REFILE_COMPRIMENTO(int value )
        {
            var query = _query.FirstByPRO_REFILE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_M2_PONTA(Decimal value )
        {
            var query = _query.FirstByPRO_M2_PONTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_QTD_CORTES_PECA1(int value )
        {
            var query = _query.FirstByPRO_QTD_CORTES_PECA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_QTD_CORTES_PECA2(int value )
        {
            var query = _query.FirstByPRO_QTD_CORTES_PECA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_DIVISAO_MONTADA(string value )
        {
            var query = _query.FirstByPRO_DIVISAO_MONTADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_A(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_AQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_B(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_BQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_C(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_CQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_D(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_E(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_F(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_FQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_G(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_GQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_H(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_HQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_SEGMENTO_I(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_IQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_QTD_GRAMPOS(Decimal value )
        {
            var query = _query.FirstByPRO_QTD_GRAMPOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_AREA_REFILE_INTERNO(Decimal value )
        {
            var query = _query.FirstByPRO_AREA_REFILE_INTERNOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_AREA_REFILE_EXTERNO(Decimal value )
        {
            var query = _query.FirstByPRO_AREA_REFILE_EXTERNOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PESO_REFILE(Decimal value )
        {
            var query = _query.FirstByPRO_PESO_REFILEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ORELHA_INVERTIDA(string value )
        {
            var query = _query.FirstByPRO_ORELHA_INVERTIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ENDERECO(string value )
        {
            var query = _query.FirstByPRO_ENDERECOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_VINCULADO(string value )
        {
            var query = _query.FirstByPRO_ID_VINCULADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_BATIDAS_PROXIMA_MANUTENCAO(int value )
        {
            var query = _query.FirstByPRO_BATIDAS_PROXIMA_MANUTENCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ENTRADA_NA_MAQUINA(string value )
        {
            var query = _query.FirstByPRO_ENTRADA_NA_MAQUINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByTDI_ID(string value )
        {
            var query = _query.FirstByTDI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_QUEBRA_VINCO(int value )
        {
            var query = _query.FirstByPRO_QUEBRA_VINCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_LARGURA_FARDO(int value )
        {
            var query = _query.FirstByPRO_LARGURA_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_COMPRIMENTO_FARDO(int value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ALTURA_FARDO(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_FARDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_TIPO_CUSTO(string value )
        {
            var query = _query.FirstByPRO_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_GRUPO_CONTABIL(string value )
        {
            var query = _query.FirstByPRO_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_CLASSE_CUSTO_01(string value )
        {
            var query = _query.FirstByPRO_CLASSE_CUSTO_01Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_OBS_ALTERACAO(string value )
        {
            var query = _query.FirstByPRO_OBS_ALTERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_PECAS_POR_VEICULO(Decimal value )
        {
            var query = _query.FirstByPRO_PECAS_POR_VEICULOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_DISTANCIA_ENTRE_VINCOS(int value )
        {
            var query = _query.FirstByPRO_DISTANCIA_ENTRE_VINCOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_DISTANCIA_ENTRE_VINCOS2(int value )
        {
            var query = _query.FirstByPRO_DISTANCIA_ENTRE_VINCOS2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_DISTANCIA_ENTRE_VINCOS3(int value )
        {
            var query = _query.FirstByPRO_DISTANCIA_ENTRE_VINCOS3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_OUT(int value )
        {
            var query = _query.FirstByPRO_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_FACA(string value )
        {
            var query = _query.FirstByPRO_ID_FACAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_CLICHE(string value )
        {
            var query = _query.FirstByPRO_ID_CLICHEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_TINTA_01(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_01Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_TINTA_02(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_02Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_TINTA_03(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_03Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_TINTA_04(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_04Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_TINTA_05(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_05Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_FORROSUP(string value )
        {
            var query = _query.FirstByPRO_ID_FORROSUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_CANTONEIRA(string value )
        {
            var query = _query.FirstByPRO_ID_CANTONEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_TAMPO(string value )
        {
            var query = _query.FirstByPRO_ID_TAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_FORROINF(string value )
        {
            var query = _query.FirstByPRO_ID_FORROINFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_CHAPA(string value )
        {
            var query = _query.FirstByPRO_ID_CHAPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_ID_COMPOSICAO(string value )
        {
            var query = _query.FirstByPRO_ID_COMPOSICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_QUEBRA_VINCO_MAIOR(int value )
        {
            var query = _query.FirstByPRO_QUEBRA_VINCO_MAIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_QUEBRA_VINCO_MENOR(int value )
        {
            var query = _query.FirstByPRO_QUEBRA_VINCO_MENORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ESTOQUE_ATUAL(Decimal value )
        {
            var query = _query.FirstByPRO_ESTOQUE_ATUALQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FARDOS_POR_CAMADA(Decimal value )
        {
            var query = _query.FirstByPRO_FARDOS_POR_CAMADAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_CAMADAS_POR_PALETE(Decimal value )
        {
            var query = _query.FirstByPRO_CAMADAS_POR_PALETEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TIPO_IDENTIFICACAO(int value )
        {
            var query = _query.FirstByPRO_TIPO_IDENTIFICACAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_GRUPO_PALETIZACAO(string value )
        {
            var query = _query.FirstByPRO_GRUPO_PALETIZACAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PECAS_POR_FARDO(Decimal value )
        {
            var query = _query.FirstByPRO_PECAS_POR_FARDOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByPRO_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByPRO_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ALTURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_PECAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_LARGURA_EMBALADA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_EMBALADAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COMPRIMENTO_EMBALADA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_EMBALADAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ALTURA_EMBALADA(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_EMBALADAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FRENTE(string value )
        {
            var query = _query.FirstByPRO_FRENTEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ROTACIONA_COMPRIMENTO(string value )
        {
            var query = _query.FirstByPRO_ROTACIONA_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ROTACIONA_LARGURA(string value )
        {
            var query = _query.FirstByPRO_ROTACIONA_LARGURAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ROTACIONA_ALTURA(string value )
        {
            var query = _query.FirstByPRO_ROTACIONA_ALTURAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ESCALA_COR(string value )
        {
            var query = _query.FirstByPRO_ESCALA_CORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SUB_ESCALA_COR(string value )
        {
            var query = _query.FirstByPRO_SUB_ESCALA_CORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_CUSTO_SUBIDA_ESCALA_COR(Decimal value )
        {
            var query = _query.FirstByPRO_CUSTO_SUBIDA_ESCALA_CORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_CUSTO_DECIDA_ESCALA_COR(Decimal value )
        {
            var query = _query.FirstByPRO_CUSTO_DECIDA_ESCALA_CORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByTMP_TIPO_CARGA(string value )
        {
            var query = _query.FirstByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TEMPO_CARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByPRO_TEMPO_CARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByPRO_TEMPO_DESCARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PERCENTUAL_JANELA_EMBARQUE(Decimal value )
        {
            var query = _query.FirstByPRO_PERCENTUAL_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TEMPO_PRODUCAO_CONJUNTO(Decimal value )
        {
            var query = _query.FirstByPRO_TEMPO_PRODUCAO_CONJUNTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PECAS_DA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_PECAS_DA_PECAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TYPE(int value )
        {
            var query = _query.FirstByPRO_TYPEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COLOR_HEXA(string value )
        {
            var query = _query.FirstByPRO_COLOR_HEXAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_VINCOS_LARGURA(string value )
        {
            var query = _query.FirstByPRO_VINCOS_LARGURAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_VINCOS_COMPRIMENTO(string value )
        {
            var query = _query.FirstByPRO_VINCOS_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_LARGURA_INTERNA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_INTERNAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COMPRIMENTO_INTERNA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_INTERNAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ALTURA_INTERNA(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_INTERNAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COD_DESENHO(string value )
        {
            var query = _query.FirstByPRO_COD_DESENHOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FECHAMENTO(string value )
        {
            var query = _query.FirstByPRO_FECHAMENTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TIPO_LAP(string value )
        {
            var query = _query.FirstByPRO_TIPO_LAPQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TAMANHO_LAP(Decimal value )
        {
            var query = _query.FirstByPRO_TAMANHO_LAPQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_LAP_PROLONGADO(string value )
        {
            var query = _query.FirstByPRO_LAP_PROLONGADOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TAMANHO_LAP_PROLONG(Decimal value )
        {
            var query = _query.FirstByPRO_TAMANHO_LAP_PROLONGQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ARRANJO_LARGURA(Decimal value )
        {
            var query = _query.FirstByPRO_ARRANJO_LARGURAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ARRANJO_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByPRO_ARRANJO_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FITILHOS_FARDO_LARG(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_FARDO_LARGQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FITILHOS_FARDO_COMP(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_FARDO_COMPQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FITILHOS_PALETE_LARG(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_PALETE_LARGQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FITILHOS_PALETE_COMP(int value )
        {
            var query = _query.FirstByPRO_FITILHOS_PALETE_COMPQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_FILME_PALETE(int value )
        {
            var query = _query.FirstByPRO_FILME_PALETEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_QTD_ESPELHO(int value )
        {
            var query = _query.FirstByPRO_QTD_ESPELHOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_CUSTO(Decimal value )
        {
            var query = _query.FirstByPRO_CUSTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_AREA_LIQUIDA(Decimal value )
        {
            var query = _query.FirstByPRO_AREA_LIQUIDAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PESO(Decimal value )
        {
            var query = _query.FirstByPRO_PESOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TOLERANCIA_DIMENSAO_CHAPA_DE(int value )
        {
            var query = _query.FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(int value )
        {
            var query = _query.FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_IMG_LASTRO(string value )
        {
            var query = _query.FirstByPRO_IMG_LASTROQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByABN_ID(string value )
        {
            var query = _query.FirstByABN_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllBySEG_ID(int value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_RESINA(string value )
        {
            var query = _query.FirstByPRO_RESINAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.FirstByPRO_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.FirstByPRO_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ADICIONAL_ABA_SUPERIOR(int value )
        {
            var query = _query.FirstByPRO_ADICIONAL_ABA_SUPERIORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ADICIONAL_ABA_INFERIOR(int value )
        {
            var query = _query.FirstByPRO_ADICIONAL_ABA_INFERIORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PROMOVE_RESINA(string value )
        {
            var query = _query.FirstByPRO_PROMOVE_RESINAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PROMOVE_DE(Decimal value )
        {
            var query = _query.FirstByPRO_PROMOVE_DEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PROMOVE_ATE(Decimal value )
        {
            var query = _query.FirstByPRO_PROMOVE_ATEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PROFUNDIDADE_VINCO(int value )
        {
            var query = _query.FirstByPRO_PROFUNDIDADE_VINCOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PROMOVE_PRODUTO(string value )
        {
            var query = _query.FirstByPRO_PROMOVE_PRODUTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TARA(Decimal value )
        {
            var query = _query.FirstByPRO_TARAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COMPRESSAO(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRESSAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COD_BARRAS_CAIXA(string value )
        {
            var query = _query.FirstByPRO_COD_BARRAS_CAIXAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByCJN_ID(string value )
        {
            var query = _query.FirstByCJN_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRJ_ID(string value )
        {
            var query = _query.FirstByPRJ_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_REFILE_LARGURA(int value )
        {
            var query = _query.FirstByPRO_REFILE_LARGURAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_REFILE_COMPRIMENTO(int value )
        {
            var query = _query.FirstByPRO_REFILE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_M2_PONTA(Decimal value )
        {
            var query = _query.FirstByPRO_M2_PONTAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_QTD_CORTES_PECA1(int value )
        {
            var query = _query.FirstByPRO_QTD_CORTES_PECA1Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_QTD_CORTES_PECA2(int value )
        {
            var query = _query.FirstByPRO_QTD_CORTES_PECA2Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_DIVISAO_MONTADA(string value )
        {
            var query = _query.FirstByPRO_DIVISAO_MONTADAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_A(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_AQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_B(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_BQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_C(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_CQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_D(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_DQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_E(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_EQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_F(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_FQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_G(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_GQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_H(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_HQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_SEGMENTO_I(Decimal value )
        {
            var query = _query.FirstByPRO_SEGMENTO_IQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_QTD_GRAMPOS(Decimal value )
        {
            var query = _query.FirstByPRO_QTD_GRAMPOSQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_AREA_REFILE_INTERNO(Decimal value )
        {
            var query = _query.FirstByPRO_AREA_REFILE_INTERNOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_AREA_REFILE_EXTERNO(Decimal value )
        {
            var query = _query.FirstByPRO_AREA_REFILE_EXTERNOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PESO_REFILE(Decimal value )
        {
            var query = _query.FirstByPRO_PESO_REFILEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ORELHA_INVERTIDA(string value )
        {
            var query = _query.FirstByPRO_ORELHA_INVERTIDAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ENDERECO(string value )
        {
            var query = _query.FirstByPRO_ENDERECOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_VINCULADO(string value )
        {
            var query = _query.FirstByPRO_ID_VINCULADOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_BATIDAS_PROXIMA_MANUTENCAO(int value )
        {
            var query = _query.FirstByPRO_BATIDAS_PROXIMA_MANUTENCAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ENTRADA_NA_MAQUINA(string value )
        {
            var query = _query.FirstByPRO_ENTRADA_NA_MAQUINAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByTDI_ID(string value )
        {
            var query = _query.FirstByTDI_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_QUEBRA_VINCO(int value )
        {
            var query = _query.FirstByPRO_QUEBRA_VINCOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_LARGURA_FARDO(int value )
        {
            var query = _query.FirstByPRO_LARGURA_FARDOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_COMPRIMENTO_FARDO(int value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_FARDOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ALTURA_FARDO(Decimal value )
        {
            var query = _query.FirstByPRO_ALTURA_FARDOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_TIPO_CUSTO(string value )
        {
            var query = _query.FirstByPRO_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_GRUPO_CONTABIL(string value )
        {
            var query = _query.FirstByPRO_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_CLASSE_CUSTO_01(string value )
        {
            var query = _query.FirstByPRO_CLASSE_CUSTO_01Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_OBS_ALTERACAO(string value )
        {
            var query = _query.FirstByPRO_OBS_ALTERACAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_PECAS_POR_VEICULO(Decimal value )
        {
            var query = _query.FirstByPRO_PECAS_POR_VEICULOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_DISTANCIA_ENTRE_VINCOS(int value )
        {
            var query = _query.FirstByPRO_DISTANCIA_ENTRE_VINCOSQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_DISTANCIA_ENTRE_VINCOS2(int value )
        {
            var query = _query.FirstByPRO_DISTANCIA_ENTRE_VINCOS2Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_DISTANCIA_ENTRE_VINCOS3(int value )
        {
            var query = _query.FirstByPRO_DISTANCIA_ENTRE_VINCOS3Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_OUT(int value )
        {
            var query = _query.FirstByPRO_OUTQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_FACA(string value )
        {
            var query = _query.FirstByPRO_ID_FACAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_CLICHE(string value )
        {
            var query = _query.FirstByPRO_ID_CLICHEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_TINTA_01(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_01Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_TINTA_02(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_02Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_TINTA_03(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_03Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_TINTA_04(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_04Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_TINTA_05(string value )
        {
            var query = _query.FirstByPRO_ID_TINTA_05Query(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_FORROSUP(string value )
        {
            var query = _query.FirstByPRO_ID_FORROSUPQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_CANTONEIRA(string value )
        {
            var query = _query.FirstByPRO_ID_CANTONEIRAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_TAMPO(string value )
        {
            var query = _query.FirstByPRO_ID_TAMPOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_FORROINF(string value )
        {
            var query = _query.FirstByPRO_ID_FORROINFQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_CHAPA(string value )
        {
            var query = _query.FirstByPRO_ID_CHAPAQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID_COMPOSICAO(string value )
        {
            var query = _query.FirstByPRO_ID_COMPOSICAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_QUEBRA_VINCO_MAIOR(int value )
        {
            var query = _query.FirstByPRO_QUEBRA_VINCO_MAIORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_QUEBRA_VINCO_MENOR(int value )
        {
            var query = _query.FirstByPRO_QUEBRA_VINCO_MENORQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration