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
    public partial class FeedbackReadRepository : IFeedbackReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IFeedbackQueryRead _query;

        public FeedbackReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IFeedbackQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetFeedbackCustom(Command.Read.FeedbackReadCommand command, ref DataPagination<FeedbackDTO> result, ref bool handled);

        public DataPagination<FeedbackDTO> getFeedback(ICommandRead command )
         {
            if (command is Command.Read.FeedbackReadCommand c)
                return getFeedback(c );
            throw new NotImplementedException();
        }
        private DataPagination<FeedbackDTO> getFeedback(Command.Read.FeedbackReadCommand command )
        {
            DataPagination<FeedbackDTO> customResult = null;
            var customHandled = false;
            TryGetFeedbackCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.FeedbackQuery(command );

                var itens = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters);
                return new DataPagination<FeedbackDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<FeedbackOcorrenciaIdDTO> getFeedbackReadFKOcorrenciaId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FeedbackOcorrenciaIdDTO> lista;
            var query = _query.FeedbackOcorrenciaIdQuery(command );

                lista = _unitOfWork.Query<FeedbackOcorrenciaIdDTO>(query.Query,query.Parameters) as List<FeedbackOcorrenciaIdDTO>;
            return lista;
        }

        public IEnumerable<FeedbackOcorrenciaIdDTO> getFeedbackReadFKOcorrenciaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFeedbackReadFKOcorrenciaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FeedbackTurnoIdDTO> getFeedbackReadFKTurnoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FeedbackTurnoIdDTO> lista;
            var query = _query.FeedbackTurnoIdQuery(command );

                lista = _unitOfWork.Query<FeedbackTurnoIdDTO>(query.Query,query.Parameters) as List<FeedbackTurnoIdDTO>;
            return lista;
        }

        public IEnumerable<FeedbackTurnoIdDTO> getFeedbackReadFKTurnoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFeedbackReadFKTurnoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FeedbackTurmaIdDTO> getFeedbackReadFKTurmaId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FeedbackTurmaIdDTO> lista;
            var query = _query.FeedbackTurmaIdQuery(command );

                lista = _unitOfWork.Query<FeedbackTurmaIdDTO>(query.Query,query.Parameters) as List<FeedbackTurmaIdDTO>;
            return lista;
        }

        public IEnumerable<FeedbackTurmaIdDTO> getFeedbackReadFKTurmaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFeedbackReadFKTurmaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FeedbackUsuarioIdDTO> getFeedbackReadFKUsuarioId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FeedbackUsuarioIdDTO> lista;
            var query = _query.FeedbackUsuarioIdQuery(command );

                lista = _unitOfWork.Query<FeedbackUsuarioIdDTO>(query.Query,query.Parameters) as List<FeedbackUsuarioIdDTO>;
            return lista;
        }

        public IEnumerable<FeedbackUsuarioIdDTO> getFeedbackReadFKUsuarioId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFeedbackReadFKUsuarioId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FeedbackTenantIDDTO> getFeedbackReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FeedbackTenantIDDTO> lista;
            var query = _query.FeedbackTenantIDQuery(command );

                lista = _unitOfWork.Query<FeedbackTenantIDDTO>(query.Query,query.Parameters) as List<FeedbackTenantIDDTO>;
            return lista;
        }

        public IEnumerable<FeedbackTenantIDDTO> getFeedbackReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFeedbackReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FeedbackUserIdDTO> getFeedbackReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FeedbackUserIdDTO> lista;
            var query = _query.FeedbackUserIdQuery(command );

                lista = _unitOfWork.Query<FeedbackUserIdDTO>(query.Query,query.Parameters) as List<FeedbackUserIdDTO>;
            return lista;
        }

        public IEnumerable<FeedbackUserIdDTO> getFeedbackReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFeedbackReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataInicial(DateTime value )
        {
            var query = _query.ExistsByDataInicialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDatafinal(DateTime value )
        {
            var query = _query.ExistsByDatafinalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMaquinaId(string value )
        {
            var query = _query.ExistsByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOcorrenciaId(string value )
        {
            var query = _query.ExistsByOcorrenciaIdQuery(value );

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

        public bool ExistsByUsuarioId(int value )
        {
            var query = _query.ExistsByUsuarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOrderId(string value )
        {
            var query = _query.ExistsByOrderIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoId(string value )
        {
            var query = _query.ExistsByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObservacoes(string value )
        {
            var query = _query.ExistsByObservacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupo(Decimal value )
        {
            var query = _query.ExistsByGrupoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDiaTurma(string value )
        {
            var query = _query.ExistsByDiaTurmaQuery(value );

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

        public bool ExistsByQuantidadePulsos(Decimal value )
        {
            var query = _query.ExistsByQuantidadePulsosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidadePecasPorPulso(Decimal value )
        {
            var query = _query.ExistsByQuantidadePecasPorPulsoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(Decimal value )
        {
            var query = _query.ExistsByFEE_QTD_TOTAL_PRODUCAO_AJUSTADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_ID(string value )
        {
            var query = _query.ExistsByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SEQUENCIA(int value )
        {
            var query = _query.ExistsByCOR_SEQUENCIAQuery(value );

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

        public FeedbackDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByDataInicial(DateTime value )
        {
            var query = _query.FirstByDataInicialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByDatafinal(DateTime value )
        {
            var query = _query.FirstByDatafinalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByOcorrenciaId(string value )
        {
            var query = _query.FirstByOcorrenciaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByTurnoId(string value )
        {
            var query = _query.FirstByTurnoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByTurmaId(string value )
        {
            var query = _query.FirstByTurmaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByUsuarioId(int value )
        {
            var query = _query.FirstByUsuarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByOrderId(string value )
        {
            var query = _query.FirstByOrderIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByObservacoes(string value )
        {
            var query = _query.FirstByObservacoesQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByGrupo(Decimal value )
        {
            var query = _query.FirstByGrupoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByDiaTurma(string value )
        {
            var query = _query.FirstByDiaTurmaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstBySequenciaRepeticao(int value )
        {
            var query = _query.FirstBySequenciaRepeticaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByQuantidadePulsos(Decimal value )
        {
            var query = _query.FirstByQuantidadePulsosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByQuantidadePecasPorPulso(Decimal value )
        {
            var query = _query.FirstByQuantidadePecasPorPulsoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(Decimal value )
        {
            var query = _query.FirstByFEE_QTD_TOTAL_PRODUCAO_AJUSTADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public FeedbackDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FeedbackDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByDataInicial(DateTime value )
        {
            var query = _query.FirstByDataInicialQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByDatafinal(DateTime value )
        {
            var query = _query.FirstByDatafinalQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByOcorrenciaId(string value )
        {
            var query = _query.FirstByOcorrenciaIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByTurnoId(string value )
        {
            var query = _query.FirstByTurnoIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByTurmaId(string value )
        {
            var query = _query.FirstByTurmaIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByUsuarioId(int value )
        {
            var query = _query.FirstByUsuarioIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByOrderId(string value )
        {
            var query = _query.FirstByOrderIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByObservacoes(string value )
        {
            var query = _query.FirstByObservacoesQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByGrupo(Decimal value )
        {
            var query = _query.FirstByGrupoQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByDiaTurma(string value )
        {
            var query = _query.FirstByDiaTurmaQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllBySequenciaTransformacao(int value )
        {
            var query = _query.FirstBySequenciaTransformacaoQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllBySequenciaRepeticao(int value )
        {
            var query = _query.FirstBySequenciaRepeticaoQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByQuantidadePulsos(Decimal value )
        {
            var query = _query.FirstByQuantidadePulsosQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByQuantidadePecasPorPulso(Decimal value )
        {
            var query = _query.FirstByQuantidadePecasPorPulsoQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(Decimal value )
        {
            var query = _query.FirstByFEE_QTD_TOTAL_PRODUCAO_AJUSTADAQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

        public IEnumerable<FeedbackDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<FeedbackDTO>(query.Query,query.Parameters) as List<FeedbackDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration