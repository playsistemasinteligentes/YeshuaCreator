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
    public partial class MovimentoEstoqueReadRepository : IMovimentoEstoqueReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMovimentoEstoqueQueryRead _query;

        public MovimentoEstoqueReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMovimentoEstoqueQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MovimentoEstoqueDTO> getMovimentoEstoque(ICommandRead command )
         {
            if (command is Command.Read.MovimentoEstoqueReadCommand c)
                return getMovimentoEstoque(c );
            throw new NotImplementedException();
        }
        private DataPagination<MovimentoEstoqueDTO> getMovimentoEstoque(Command.Read.MovimentoEstoqueReadCommand command )
        {
            var query = _query.MovimentoEstoqueQuery(command );

                var itens = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters);
                return new DataPagination<MovimentoEstoqueDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MovimentoEstoqueOrderIdDTO> getMovimentoEstoqueReadFKOrderId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueOrderIdDTO> lista;
            var query = _query.MovimentoEstoqueOrderIdQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueOrderIdDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueOrderIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueOrderIdDTO> getMovimentoEstoqueReadFKOrderId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKOrderId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoEstoqueTipoDTO> getMovimentoEstoqueReadFKTipo(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueTipoDTO> lista;
            var query = _query.MovimentoEstoqueTipoQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueTipoDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueTipoDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueTipoDTO> getMovimentoEstoqueReadFKTipo(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKTipo(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoEstoqueTurnoIdDTO> getMovimentoEstoqueReadFKTurnoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueTurnoIdDTO> lista;
            var query = _query.MovimentoEstoqueTurnoIdQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueTurnoIdDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueTurnoIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueTurnoIdDTO> getMovimentoEstoqueReadFKTurnoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKTurnoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoEstoqueTurmaIdDTO> getMovimentoEstoqueReadFKTurmaId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueTurmaIdDTO> lista;
            var query = _query.MovimentoEstoqueTurmaIdQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueTurmaIdDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueTurmaIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueTurmaIdDTO> getMovimentoEstoqueReadFKTurmaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKTurmaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoEstoqueOcorrenciaIdDTO> getMovimentoEstoqueReadFKOcorrenciaId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueOcorrenciaIdDTO> lista;
            var query = _query.MovimentoEstoqueOcorrenciaIdQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueOcorrenciaIdDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueOcorrenciaIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueOcorrenciaIdDTO> getMovimentoEstoqueReadFKOcorrenciaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKOcorrenciaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoEstoqueCLI_IDDTO> getMovimentoEstoqueReadFKCLI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueCLI_IDDTO> lista;
            var query = _query.MovimentoEstoqueCLI_IDQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueCLI_IDDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueCLI_IDDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueCLI_IDDTO> getMovimentoEstoqueReadFKCLI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKCLI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoEstoqueTenantIDDTO> getMovimentoEstoqueReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueTenantIDDTO> lista;
            var query = _query.MovimentoEstoqueTenantIDQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueTenantIDDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueTenantIDDTO> getMovimentoEstoqueReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoEstoqueUserIdDTO> getMovimentoEstoqueReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoEstoqueUserIdDTO> lista;
            var query = _query.MovimentoEstoqueUserIdQuery(command );

                lista = _unitOfWork.Query<MovimentoEstoqueUserIdDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueUserIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoEstoqueUserIdDTO> getMovimentoEstoqueReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoEstoqueReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoId(string value )
        {
            var query = _query.ExistsByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOrderId(string value )
        {
            var query = _query.ExistsByOrderIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipo(string value )
        {
            var query = _query.ExistsByTipoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTurnoId(string value )
        {
            var query = _query.ExistsByTurnoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTurmaId(string value )
        {
            var query = _query.ExistsByTurmaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidade(Decimal value )
        {
            var query = _query.ExistsByQuantidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_PESO_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByMOV_PESO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataHoraCriacao(DateTime value )
        {
            var query = _query.ExistsByDataHoraCriacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataHoraEmissao(DateTime value )
        {
            var query = _query.ExistsByDataHoraEmissaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiaTurma(string value )
        {
            var query = _query.ExistsByDiaTurmaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLote(string value )
        {
            var query = _query.ExistsByLoteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySubLote(string value )
        {
            var query = _query.ExistsBySubLoteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMaquinaId(string value )
        {
            var query = _query.ExistsByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObservacao(string value )
        {
            var query = _query.ExistsByObservacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOcorrenciaId(string value )
        {
            var query = _query.ExistsByOcorrenciaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByArmazem(string value )
        {
            var query = _query.ExistsByArmazemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEndereco(string value )
        {
            var query = _query.ExistsByEnderecoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEstorno(string value )
        {
            var query = _query.ExistsByEstornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySequenciaTransformacao(int value )
        {
            var query = _query.ExistsBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySequenciaRepeticao(int value )
        {
            var query = _query.ExistsBySequenciaRepeticaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObsOpParcial(string value )
        {
            var query = _query.ExistsByObsOpParcialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOcoIdOpParcial(string value )
        {
            var query = _query.ExistsByOcoIdOpParcialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByMOV_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByMOV_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID(string value )
        {
            var query = _query.ExistsByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_ID_DESTINO(int value )
        {
            var query = _query.ExistsByMOV_ID_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_DESTINO(string value )
        {
            var query = _query.ExistsByPRO_ID_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_LOTE_DESTINO(string value )
        {
            var query = _query.ExistsByMOV_LOTE_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_SUB_LOTE_DESTINO(string value )
        {
            var query = _query.ExistsByMOV_SUB_LOTE_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_ID_ORIGEM(int value )
        {
            var query = _query.ExistsByMOV_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_ORIGEM(string value )
        {
            var query = _query.ExistsByPRO_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_LOTE_ORIGEM(string value )
        {
            var query = _query.ExistsByMOV_LOTE_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_SUB_LOTE_ORIGEM(string value )
        {
            var query = _query.ExistsByMOV_SUB_LOTE_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_TYPE(int value )
        {
            var query = _query.ExistsByMOV_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_DOC(string value )
        {
            var query = _query.ExistsByMOV_DOCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_APROVEITAMENTO(string value )
        {
            var query = _query.ExistsByMOV_APROVEITAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_RETIDO(string value )
        {
            var query = _query.ExistsByMOV_RETIDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.ExistsByMOV_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_ID(string value )
        {
            var query = _query.ExistsByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID_ORIGEM(string value )
        {
            var query = _query.ExistsByORD_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SEQUENCIA(int value )
        {
            var query = _query.ExistsByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVER_ID(int value )
        {
            var query = _query.ExistsByVER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_TIPO_CUSTO(string value )
        {
            var query = _query.ExistsByMOV_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_GRUPO_CONTABIL(string value )
        {
            var query = _query.ExistsByMOV_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFOR_ID(string value )
        {
            var query = _query.ExistsByFOR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

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

        public MovimentoEstoqueDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByOrderId(string value )
        {
            var query = _query.FirstByOrderIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByTipo(string value )
        {
            var query = _query.FirstByTipoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByTurnoId(string value )
        {
            var query = _query.FirstByTurnoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByTurmaId(string value )
        {
            var query = _query.FirstByTurmaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByQuantidade(Decimal value )
        {
            var query = _query.FirstByQuantidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_PESO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByMOV_PESO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByDataHoraCriacao(DateTime value )
        {
            var query = _query.FirstByDataHoraCriacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByDataHoraEmissao(DateTime value )
        {
            var query = _query.FirstByDataHoraEmissaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByDiaTurma(string value )
        {
            var query = _query.FirstByDiaTurmaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByLote(string value )
        {
            var query = _query.FirstByLoteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstBySubLote(string value )
        {
            var query = _query.FirstBySubLoteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByObservacao(string value )
        {
            var query = _query.FirstByObservacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByOcorrenciaId(string value )
        {
            var query = _query.FirstByOcorrenciaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByArmazem(string value )
        {
            var query = _query.FirstByArmazemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByEndereco(string value )
        {
            var query = _query.FirstByEnderecoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByEstorno(string value )
        {
            var query = _query.FirstByEstornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstBySequenciaRepeticao(int value )
        {
            var query = _query.FirstBySequenciaRepeticaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByObsOpParcial(string value )
        {
            var query = _query.FirstByObsOpParcialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByOcoIdOpParcial(string value )
        {
            var query = _query.FirstByOcoIdOpParcialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByMOV_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByMOV_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_ID_DESTINO(int value )
        {
            var query = _query.FirstByMOV_ID_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByPRO_ID_DESTINO(string value )
        {
            var query = _query.FirstByPRO_ID_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_LOTE_DESTINO(string value )
        {
            var query = _query.FirstByMOV_LOTE_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_SUB_LOTE_DESTINO(string value )
        {
            var query = _query.FirstByMOV_SUB_LOTE_DESTINOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_ID_ORIGEM(int value )
        {
            var query = _query.FirstByMOV_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByPRO_ID_ORIGEM(string value )
        {
            var query = _query.FirstByPRO_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_LOTE_ORIGEM(string value )
        {
            var query = _query.FirstByMOV_LOTE_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_SUB_LOTE_ORIGEM(string value )
        {
            var query = _query.FirstByMOV_SUB_LOTE_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_TYPE(int value )
        {
            var query = _query.FirstByMOV_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_DOC(string value )
        {
            var query = _query.FirstByMOV_DOCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_APROVEITAMENTO(string value )
        {
            var query = _query.FirstByMOV_APROVEITAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_RETIDO(string value )
        {
            var query = _query.FirstByMOV_RETIDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.FirstByMOV_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByORD_ID_ORIGEM(string value )
        {
            var query = _query.FirstByORD_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_TIPO_CUSTO(string value )
        {
            var query = _query.FirstByMOV_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByMOV_GRUPO_CONTABIL(string value )
        {
            var query = _query.FirstByMOV_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByFOR_ID(string value )
        {
            var query = _query.FirstByFOR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoEstoqueDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByOrderId(string value )
        {
            var query = _query.FirstByOrderIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByTipo(string value )
        {
            var query = _query.FirstByTipoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByTurnoId(string value )
        {
            var query = _query.FirstByTurnoIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByTurmaId(string value )
        {
            var query = _query.FirstByTurmaIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByQuantidade(Decimal value )
        {
            var query = _query.FirstByQuantidadeQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_PESO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByMOV_PESO_UNITARIOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByDataHoraCriacao(DateTime value )
        {
            var query = _query.FirstByDataHoraCriacaoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByDataHoraEmissao(DateTime value )
        {
            var query = _query.FirstByDataHoraEmissaoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByDiaTurma(string value )
        {
            var query = _query.FirstByDiaTurmaQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByLote(string value )
        {
            var query = _query.FirstByLoteQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllBySubLote(string value )
        {
            var query = _query.FirstBySubLoteQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByObservacao(string value )
        {
            var query = _query.FirstByObservacaoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByOcorrenciaId(string value )
        {
            var query = _query.FirstByOcorrenciaIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByArmazem(string value )
        {
            var query = _query.FirstByArmazemQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByEndereco(string value )
        {
            var query = _query.FirstByEnderecoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByEstorno(string value )
        {
            var query = _query.FirstByEstornoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllBySequenciaRepeticao(int value )
        {
            var query = _query.FirstBySequenciaRepeticaoQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByObsOpParcial(string value )
        {
            var query = _query.FirstByObsOpParcialQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByOcoIdOpParcial(string value )
        {
            var query = _query.FirstByOcoIdOpParcialQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByMOV_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByMOV_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_ID_DESTINO(int value )
        {
            var query = _query.FirstByMOV_ID_DESTINOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByPRO_ID_DESTINO(string value )
        {
            var query = _query.FirstByPRO_ID_DESTINOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_LOTE_DESTINO(string value )
        {
            var query = _query.FirstByMOV_LOTE_DESTINOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_SUB_LOTE_DESTINO(string value )
        {
            var query = _query.FirstByMOV_SUB_LOTE_DESTINOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_ID_ORIGEM(int value )
        {
            var query = _query.FirstByMOV_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByPRO_ID_ORIGEM(string value )
        {
            var query = _query.FirstByPRO_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_LOTE_ORIGEM(string value )
        {
            var query = _query.FirstByMOV_LOTE_ORIGEMQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_SUB_LOTE_ORIGEM(string value )
        {
            var query = _query.FirstByMOV_SUB_LOTE_ORIGEMQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_TYPE(int value )
        {
            var query = _query.FirstByMOV_TYPEQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_DOC(string value )
        {
            var query = _query.FirstByMOV_DOCQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_APROVEITAMENTO(string value )
        {
            var query = _query.FirstByMOV_APROVEITAMENTOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_RETIDO(string value )
        {
            var query = _query.FirstByMOV_RETIDOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.FirstByMOV_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByORD_ID_ORIGEM(string value )
        {
            var query = _query.FirstByORD_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_TIPO_CUSTO(string value )
        {
            var query = _query.FirstByMOV_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByMOV_GRUPO_CONTABIL(string value )
        {
            var query = _query.FirstByMOV_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByFOR_ID(string value )
        {
            var query = _query.FirstByFOR_IDQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<MovimentoEstoqueDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MovimentoEstoqueDTO>(query.Query,query.Parameters) as List<MovimentoEstoqueDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration