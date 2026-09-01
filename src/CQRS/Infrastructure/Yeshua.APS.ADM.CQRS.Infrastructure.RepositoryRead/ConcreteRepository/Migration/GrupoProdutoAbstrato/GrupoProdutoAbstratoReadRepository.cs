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
    public partial class GrupoProdutoAbstratoReadRepository : IGrupoProdutoAbstratoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IGrupoProdutoAbstratoQueryRead _query;

        public GrupoProdutoAbstratoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IGrupoProdutoAbstratoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetGrupoProdutoAbstratoCustom(Command.Read.GrupoProdutoAbstratoReadCommand command, ref DataPagination<GrupoProdutoAbstratoDTO> result, ref bool handled);

        public DataPagination<GrupoProdutoAbstratoDTO> getGrupoProdutoAbstrato(ICommandRead command )
         {
            if (command is Command.Read.GrupoProdutoAbstratoReadCommand c)
                return getGrupoProdutoAbstrato(c );
            throw new NotImplementedException();
        }
        private DataPagination<GrupoProdutoAbstratoDTO> getGrupoProdutoAbstrato(Command.Read.GrupoProdutoAbstratoReadCommand command )
        {
            DataPagination<GrupoProdutoAbstratoDTO> customResult = null;
            var customHandled = false;
            TryGetGrupoProdutoAbstratoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.GrupoProdutoAbstratoQuery(command );

                var itens = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoProdutoAbstratoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<GrupoProdutoAbstratoGRP_PAP_ONDADTO> getGrupoProdutoAbstratoReadFKGRP_PAP_ONDA(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoProdutoAbstratoGRP_PAP_ONDADTO> lista;
            var query = _query.GrupoProdutoAbstratoGRP_PAP_ONDAQuery(command );

                lista = _unitOfWork.Query<GrupoProdutoAbstratoGRP_PAP_ONDADTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoGRP_PAP_ONDADTO>;
            return lista;
        }

        public IEnumerable<GrupoProdutoAbstratoGRP_PAP_ONDADTO> getGrupoProdutoAbstratoReadFKGRP_PAP_ONDA(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoProdutoAbstratoReadFKGRP_PAP_ONDA(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoProdutoAbstratoVIN_IDDTO> getGrupoProdutoAbstratoReadFKVIN_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoProdutoAbstratoVIN_IDDTO> lista;
            var query = _query.GrupoProdutoAbstratoVIN_IDQuery(command );

                lista = _unitOfWork.Query<GrupoProdutoAbstratoVIN_IDDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoVIN_IDDTO>;
            return lista;
        }

        public IEnumerable<GrupoProdutoAbstratoVIN_IDDTO> getGrupoProdutoAbstratoReadFKVIN_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoProdutoAbstratoReadFKVIN_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoProdutoAbstratoTenantIDDTO> getGrupoProdutoAbstratoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoProdutoAbstratoTenantIDDTO> lista;
            var query = _query.GrupoProdutoAbstratoTenantIDQuery(command );

                lista = _unitOfWork.Query<GrupoProdutoAbstratoTenantIDDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<GrupoProdutoAbstratoTenantIDDTO> getGrupoProdutoAbstratoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoProdutoAbstratoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoProdutoAbstratoUserIdDTO> getGrupoProdutoAbstratoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoProdutoAbstratoUserIdDTO> lista;
            var query = _query.GrupoProdutoAbstratoUserIdQuery(command );

                lista = _unitOfWork.Query<GrupoProdutoAbstratoUserIdDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoUserIdDTO>;
            return lista;
        }

        public IEnumerable<GrupoProdutoAbstratoUserIdDTO> getGrupoProdutoAbstratoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoProdutoAbstratoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByGRP_ID(string value )
        {
            var query = _query.ExistsByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_DESCRICAO(string value )
        {
            var query = _query.ExistsByGRP_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TIPO(Decimal value )
        {
            var query = _query.ExistsByGRP_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAP_ONDA(string value )
        {
            var query = _query.ExistsByGRP_PAP_ONDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAP_GRAMATURA(Decimal value )
        {
            var query = _query.ExistsByGRP_PAP_GRAMATURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAP_ALTURA(Decimal value )
        {
            var query = _query.ExistsByGRP_PAP_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAP_NOME_COMERCIAL(string value )
        {
            var query = _query.ExistsByGRP_PAP_NOME_COMERCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ATIVO(string value )
        {
            var query = _query.ExistsByGRP_ATIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_DT_CRIACAO(DateTime value )
        {
            var query = _query.ExistsByGRP_DT_CRIACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL1(string value )
        {
            var query = _query.ExistsByGRP_PAPEL1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL2(string value )
        {
            var query = _query.ExistsByGRP_PAPEL2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL3(string value )
        {
            var query = _query.ExistsByGRP_PAPEL3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL4(string value )
        {
            var query = _query.ExistsByGRP_PAPEL4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL5(string value )
        {
            var query = _query.ExistsByGRP_PAPEL5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByGRP_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByGRP_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TYPE(int value )
        {
            var query = _query.ExistsByGRP_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByGRP_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(Decimal value )
        {
            var query = _query.ExistsByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_RESINA(string value )
        {
            var query = _query.ExistsByGRP_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.ExistsByGRP_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVIN_ID(int value )
        {
            var query = _query.ExistsByVIN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_COLUNA_DE(Decimal value )
        {
            var query = _query.ExistsByGRP_COLUNA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_COLUNA_ATE(Decimal value )
        {
            var query = _query.ExistsByGRP_COLUNA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_CRUSH(Decimal value )
        {
            var query = _query.ExistsByGRP_CRUSHQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID_FAMILIA(string value )
        {
            var query = _query.ExistsByGRP_ID_FAMILIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_REFILE_LARGURA(Decimal value )
        {
            var query = _query.ExistsByGRP_REFILE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_REFILE_COMPRIMENTO(Decimal value )
        {
            var query = _query.ExistsByGRP_REFILE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TIPO_LAP(string value )
        {
            var query = _query.ExistsByGRP_TIPO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_LAP_PROLONGADO(string value )
        {
            var query = _query.ExistsByGRP_LAP_PROLONGADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TAMANHO_LAP_OND_SIMPLES(Decimal value )
        {
            var query = _query.ExistsByGRP_TAMANHO_LAP_OND_SIMPLESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TAMANHO_LAP_OND_DUPLA(Decimal value )
        {
            var query = _query.ExistsByGRP_TAMANHO_LAP_OND_DUPLAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(Decimal value )
        {
            var query = _query.ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(Decimal value )
        {
            var query = _query.ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_FEFCO(string value )
        {
            var query = _query.ExistsByGRP_FEFCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(int value )
        {
            var query = _query.ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(int value )
        {
            var query = _query.ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PREFIXO_ID_PRODUTO(string value )
        {
            var query = _query.ExistsByGRP_PREFIXO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_COLUNA_CAIXA(Decimal value )
        {
            var query = _query.ExistsByGRP_COLUNA_CAIXAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_COLUNA_CHAPA(Decimal value )
        {
            var query = _query.ExistsByGRP_COLUNA_CHAPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_MULLEN(Decimal value )
        {
            var query = _query.ExistsByGRP_MULLENQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_TENDENCIA_TOLERANCIA_PEDIDO(int value )
        {
            var query = _query.ExistsByGRP_TENDENCIA_TOLERANCIA_PEDIDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PERCENTUAL_PERDA_MEDIA(Decimal value )
        {
            var query = _query.ExistsByGRP_PERCENTUAL_PERDA_MEDIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_FILTRA_SEQ_TRANS(int value )
        {
            var query = _query.ExistsByGRP_FILTRA_SEQ_TRANSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_IMG_CAIXA(string value )
        {
            var query = _query.ExistsByGRP_IMG_CAIXAQuery(value );

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

        public GrupoProdutoAbstratoDTO FirstByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_DESCRICAO(string value )
        {
            var query = _query.FirstByGRP_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TIPO(Decimal value )
        {
            var query = _query.FirstByGRP_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_ONDA(string value )
        {
            var query = _query.FirstByGRP_PAP_ONDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_GRAMATURA(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_GRAMATURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_ALTURA(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_NOME_COMERCIAL(string value )
        {
            var query = _query.FirstByGRP_PAP_NOME_COMERCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_ATIVO(string value )
        {
            var query = _query.FirstByGRP_ATIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_DT_CRIACAO(DateTime value )
        {
            var query = _query.FirstByGRP_DT_CRIACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL1(string value )
        {
            var query = _query.FirstByGRP_PAPEL1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL2(string value )
        {
            var query = _query.FirstByGRP_PAPEL2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL3(string value )
        {
            var query = _query.FirstByGRP_PAPEL3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL4(string value )
        {
            var query = _query.FirstByGRP_PAPEL4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL5(string value )
        {
            var query = _query.FirstByGRP_PAPEL5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByGRP_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByGRP_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TYPE(int value )
        {
            var query = _query.FirstByGRP_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByGRP_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(Decimal value )
        {
            var query = _query.FirstByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_RESINA(string value )
        {
            var query = _query.FirstByGRP_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.FirstByGRP_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_DE(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_ATE(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_CRUSH(Decimal value )
        {
            var query = _query.FirstByGRP_CRUSHQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_ID_FAMILIA(string value )
        {
            var query = _query.FirstByGRP_ID_FAMILIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_REFILE_LARGURA(Decimal value )
        {
            var query = _query.FirstByGRP_REFILE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_REFILE_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByGRP_REFILE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TIPO_LAP(string value )
        {
            var query = _query.FirstByGRP_TIPO_LAPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_LAP_PROLONGADO(string value )
        {
            var query = _query.FirstByGRP_LAP_PROLONGADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_OND_SIMPLES(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_OND_SIMPLESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_OND_DUPLA(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_OND_DUPLAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_FEFCO(string value )
        {
            var query = _query.FirstByGRP_FEFCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(int value )
        {
            var query = _query.FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(int value )
        {
            var query = _query.FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PREFIXO_ID_PRODUTO(string value )
        {
            var query = _query.FirstByGRP_PREFIXO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_CAIXA(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_CAIXAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_CHAPA(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_CHAPAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_MULLEN(Decimal value )
        {
            var query = _query.FirstByGRP_MULLENQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_TENDENCIA_TOLERANCIA_PEDIDO(int value )
        {
            var query = _query.FirstByGRP_TENDENCIA_TOLERANCIA_PEDIDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_PERCENTUAL_PERDA_MEDIA(Decimal value )
        {
            var query = _query.FirstByGRP_PERCENTUAL_PERDA_MEDIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_FILTRA_SEQ_TRANS(int value )
        {
            var query = _query.FirstByGRP_FILTRA_SEQ_TRANSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByGRP_IMG_CAIXA(string value )
        {
            var query = _query.FirstByGRP_IMG_CAIXAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoProdutoAbstratoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoProdutoAbstratoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_DESCRICAO(string value )
        {
            var query = _query.FirstByGRP_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TIPO(Decimal value )
        {
            var query = _query.FirstByGRP_TIPOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_ONDA(string value )
        {
            var query = _query.FirstByGRP_PAP_ONDAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_GRAMATURA(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_GRAMATURAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_ALTURA(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_ALTURAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_NOME_COMERCIAL(string value )
        {
            var query = _query.FirstByGRP_PAP_NOME_COMERCIALQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ATIVO(string value )
        {
            var query = _query.FirstByGRP_ATIVOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_DT_CRIACAO(DateTime value )
        {
            var query = _query.FirstByGRP_DT_CRIACAOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL1(string value )
        {
            var query = _query.FirstByGRP_PAPEL1Query(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL2(string value )
        {
            var query = _query.FirstByGRP_PAPEL2Query(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL3(string value )
        {
            var query = _query.FirstByGRP_PAPEL3Query(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL4(string value )
        {
            var query = _query.FirstByGRP_PAPEL4Query(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL5(string value )
        {
            var query = _query.FirstByGRP_PAPEL5Query(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByGRP_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByGRP_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TYPE(int value )
        {
            var query = _query.FirstByGRP_TYPEQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByGRP_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(Decimal value )
        {
            var query = _query.FirstByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_RESINA(string value )
        {
            var query = _query.FirstByGRP_RESINAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.FirstByGRP_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_DE(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_DEQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_ATE(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_ATEQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_CRUSH(Decimal value )
        {
            var query = _query.FirstByGRP_CRUSHQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID_FAMILIA(string value )
        {
            var query = _query.FirstByGRP_ID_FAMILIAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_REFILE_LARGURA(Decimal value )
        {
            var query = _query.FirstByGRP_REFILE_LARGURAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_REFILE_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByGRP_REFILE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TIPO_LAP(string value )
        {
            var query = _query.FirstByGRP_TIPO_LAPQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_LAP_PROLONGADO(string value )
        {
            var query = _query.FirstByGRP_LAP_PROLONGADOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_OND_SIMPLES(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_OND_SIMPLESQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_OND_DUPLA(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_OND_DUPLAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLESQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(Decimal value )
        {
            var query = _query.FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_FEFCO(string value )
        {
            var query = _query.FirstByGRP_FEFCOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(int value )
        {
            var query = _query.FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(int value )
        {
            var query = _query.FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PREFIXO_ID_PRODUTO(string value )
        {
            var query = _query.FirstByGRP_PREFIXO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_CAIXA(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_CAIXAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_CHAPA(Decimal value )
        {
            var query = _query.FirstByGRP_COLUNA_CHAPAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_MULLEN(Decimal value )
        {
            var query = _query.FirstByGRP_MULLENQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TENDENCIA_TOLERANCIA_PEDIDO(int value )
        {
            var query = _query.FirstByGRP_TENDENCIA_TOLERANCIA_PEDIDOQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PERCENTUAL_PERDA_MEDIA(Decimal value )
        {
            var query = _query.FirstByGRP_PERCENTUAL_PERDA_MEDIAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_FILTRA_SEQ_TRANS(int value )
        {
            var query = _query.FirstByGRP_FILTRA_SEQ_TRANSQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_IMG_CAIXA(string value )
        {
            var query = _query.FirstByGRP_IMG_CAIXAQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<GrupoProdutoAbstratoDTO>(query.Query,query.Parameters) as List<GrupoProdutoAbstratoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration