// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Feedback
{
    public partial class FeedbackWriteRepository : IFeedbackWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IFeedbackQueryWrite _query; 

        public FeedbackWriteRepository(IUnitOfWork unitOfWork,IFeedbackQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IFeedbackEntity Feedback)
        {
            var query = _query.InserirFeedbackQuery(Feedback);
        Feedback.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IFeedbackEntity Feedback)
        {
            var query = _query.UpdateFeedbackQuery(Feedback);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IFeedbackEntity Feedback)
        {
            var query = _query.DeleteFeedbackQuery(Feedback);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataInicial(int id, DateTime value)
        {
            var query = _query.UpdateDataInicial(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDatafinal(int id, DateTime value)
        {
            var query = _query.UpdateDatafinal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMaquinaId(int id, string value)
        {
            var query = _query.UpdateMaquinaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOcorrenciaId(int id, string value)
        {
            var query = _query.UpdateOcorrenciaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTurnoId(int id, string value)
        {
            var query = _query.UpdateTurnoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTurmaId(int id, string value)
        {
            var query = _query.UpdateTurmaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUsuarioId(int id, int value)
        {
            var query = _query.UpdateUsuarioId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOrderId(int id, string value)
        {
            var query = _query.UpdateOrderId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoId(int id, string value)
        {
            var query = _query.UpdateProdutoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObservacoes(int id, string value)
        {
            var query = _query.UpdateObservacoes(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrupo(int id, Decimal value)
        {
            var query = _query.UpdateGrupo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDiaTurma(int id, string value)
        {
            var query = _query.UpdateDiaTurma(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSequenciaTransformacao(int id, int value)
        {
            var query = _query.UpdateSequenciaTransformacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSequenciaRepeticao(int id, int value)
        {
            var query = _query.UpdateSequenciaRepeticao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadePulsos(int id, Decimal value)
        {
            var query = _query.UpdateQuantidadePulsos(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadePecasPorPulso(int id, Decimal value)
        {
            var query = _query.UpdateQuantidadePecasPorPulso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(int id, Decimal value)
        {
            var query = _query.UpdateFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int id, string value)
        {
            var query = _query.UpdateBOL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SEQUENCIA(int id, int value)
        {
            var query = _query.UpdateCOR_SEQUENCIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration