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
    public partial class CorridasOnduladeiraReadRepository : ICorridasOnduladeiraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICorridasOnduladeiraQueryRead _query;

        public CorridasOnduladeiraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICorridasOnduladeiraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CorridasOnduladeiraDTO> getCorridasOnduladeira(ICommandRead command )
         {
            if (command is Command.Read.CorridasOnduladeiraReadCommand c)
                return getCorridasOnduladeira(c );
            throw new NotImplementedException();
        }
        private DataPagination<CorridasOnduladeiraDTO> getCorridasOnduladeira(Command.Read.CorridasOnduladeiraReadCommand command )
        {
            var query = _query.CorridasOnduladeiraQuery(command );

                var itens = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters);
                return new DataPagination<CorridasOnduladeiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CorridasOnduladeiraTenantIDDTO> getCorridasOnduladeiraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CorridasOnduladeiraTenantIDDTO> lista;
            var query = _query.CorridasOnduladeiraTenantIDQuery(command );

                lista = _unitOfWork.Query<CorridasOnduladeiraTenantIDDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CorridasOnduladeiraTenantIDDTO> getCorridasOnduladeiraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCorridasOnduladeiraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CorridasOnduladeiraUserIdDTO> getCorridasOnduladeiraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CorridasOnduladeiraUserIdDTO> lista;
            var query = _query.CorridasOnduladeiraUserIdQuery(command );

                lista = _unitOfWork.Query<CorridasOnduladeiraUserIdDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraUserIdDTO>;
            return lista;
        }

        public IEnumerable<CorridasOnduladeiraUserIdDTO> getCorridasOnduladeiraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCorridasOnduladeiraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByBOL_ID(string value )
        {
            var query = _query.ExistsByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_ID_ORIGEM(string value )
        {
            var query = _query.ExistsByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LARGURA_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.ExistsByPRO_LARGURA_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value )
        {
            var query = _query.ExistsByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_VINCOS_RECALCULADOS(string value )
        {
            var query = _query.ExistsByPRO_VINCOS_RECALCULADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SOLVER(string value )
        {
            var query = _query.ExistsByCOR_SOLVERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.ExistsByCOR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.ExistsByCOR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_PILHAS_POR_PALETE(int value )
        {
            var query = _query.ExistsByCOR_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_COR_FILA(string value )
        {
            var query = _query.ExistsByCOR_COR_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_M_LINEAR_REALIZADO(Decimal value )
        {
            var query = _query.ExistsByCOR_M_LINEAR_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_PALETE(string value )
        {
            var query = _query.ExistsByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_STATUS_PALETE(string value )
        {
            var query = _query.ExistsByCOR_STATUS_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.ExistsByCOR_GRUPO_PRODUTIVOQuery(value );

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

        public bool ExistsByCOR_ID(int value )
        {
            var query = _query.ExistsByCOR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_STATUS(string value )
        {
            var query = _query.ExistsByCOR_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_STATUS_INTERFACE(string value )
        {
            var query = _query.ExistsByCOR_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_ID_INTERFACE(int value )
        {
            var query = _query.ExistsByCOR_ID_INTERFACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SEQUENCIA(int value )
        {
            var query = _query.ExistsByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SEQUENCIA_ORIGEM(int value )
        {
            var query = _query.ExistsByCOR_SEQUENCIA_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.ExistsByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_FACAO(int value )
        {
            var query = _query.ExistsByCOR_FACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_FORMATO_BOBINA(int value )
        {
            var query = _query.ExistsByCOR_FORMATO_BOBINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.ExistsByCOR_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_FIM_PREVISTO(DateTime value )
        {
            var query = _query.ExistsByCOR_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_QTD_PLANEJADO(int value )
        {
            var query = _query.ExistsByCOR_QTD_PLANEJADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_QTD_PACAS(int value )
        {
            var query = _query.ExistsByPRO_QTD_PACASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_PECAS_LARGURA(int value )
        {
            var query = _query.ExistsByCOR_PECAS_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public CorridasOnduladeiraDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_LARGURA_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value )
        {
            var query = _query.FirstByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_VINCOS_RECALCULADOS(string value )
        {
            var query = _query.FirstByPRO_VINCOS_RECALCULADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_SOLVER(string value )
        {
            var query = _query.FirstByCOR_SOLVERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_PILHAS_POR_PALETE(int value )
        {
            var query = _query.FirstByCOR_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_COR_FILA(string value )
        {
            var query = _query.FirstByCOR_COR_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_M_LINEAR_REALIZADO(Decimal value )
        {
            var query = _query.FirstByCOR_M_LINEAR_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_STATUS_PALETE(string value )
        {
            var query = _query.FirstByCOR_STATUS_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCOR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_ID(int value )
        {
            var query = _query.FirstByCOR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_STATUS(string value )
        {
            var query = _query.FirstByCOR_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_STATUS_INTERFACE(string value )
        {
            var query = _query.FirstByCOR_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_ID_INTERFACE(int value )
        {
            var query = _query.FirstByCOR_ID_INTERFACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_SEQUENCIA_ORIGEM(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIA_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_FACAO(int value )
        {
            var query = _query.FirstByCOR_FACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_FORMATO_BOBINA(int value )
        {
            var query = _query.FirstByCOR_FORMATO_BOBINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCOR_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_FIM_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCOR_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_QTD_PLANEJADO(int value )
        {
            var query = _query.FirstByCOR_QTD_PLANEJADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByPRO_QTD_PACAS(int value )
        {
            var query = _query.FirstByPRO_QTD_PACASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraDTO FirstByCOR_PECAS_LARGURA(int value )
        {
            var query = _query.FirstByCOR_PECAS_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_LARGURA_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value )
        {
            var query = _query.FirstByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_VINCOS_RECALCULADOS(string value )
        {
            var query = _query.FirstByPRO_VINCOS_RECALCULADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_SOLVER(string value )
        {
            var query = _query.FirstByCOR_SOLVERQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_PILHAS_POR_PALETE(int value )
        {
            var query = _query.FirstByCOR_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_COR_FILA(string value )
        {
            var query = _query.FirstByCOR_COR_FILAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_M_LINEAR_REALIZADO(Decimal value )
        {
            var query = _query.FirstByCOR_M_LINEAR_REALIZADOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_STATUS_PALETE(string value )
        {
            var query = _query.FirstByCOR_STATUS_PALETEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCOR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_ID(int value )
        {
            var query = _query.FirstByCOR_IDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_STATUS(string value )
        {
            var query = _query.FirstByCOR_STATUSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_STATUS_INTERFACE(string value )
        {
            var query = _query.FirstByCOR_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_ID_INTERFACE(int value )
        {
            var query = _query.FirstByCOR_ID_INTERFACEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_SEQUENCIA_ORIGEM(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIA_ORIGEMQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_FACAO(int value )
        {
            var query = _query.FirstByCOR_FACAOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_FORMATO_BOBINA(int value )
        {
            var query = _query.FirstByCOR_FORMATO_BOBINAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_INICIO_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCOR_INICIO_PREVISTOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_FIM_PREVISTO(DateTime value )
        {
            var query = _query.FirstByCOR_FIM_PREVISTOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_QTD_PLANEJADO(int value )
        {
            var query = _query.FirstByCOR_QTD_PLANEJADOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_QTD_PACAS(int value )
        {
            var query = _query.FirstByPRO_QTD_PACASQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_PECAS_LARGURA(int value )
        {
            var query = _query.FirstByCOR_PECAS_LARGURAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration