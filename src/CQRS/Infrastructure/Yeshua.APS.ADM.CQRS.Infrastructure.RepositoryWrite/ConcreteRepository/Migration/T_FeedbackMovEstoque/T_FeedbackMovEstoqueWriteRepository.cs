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

namespace Input.Repository.T_FeedbackMovEstoque
{
    public partial class T_FeedbackMovEstoqueWriteRepository : IT_FeedbackMovEstoqueWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_FeedbackMovEstoqueQueryWrite _query; 

        public T_FeedbackMovEstoqueWriteRepository(IUnitOfWork unitOfWork,IT_FeedbackMovEstoqueQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque)
        {
            var query = _query.InserirT_FeedbackMovEstoqueQuery(T_FeedbackMovEstoque);
        T_FeedbackMovEstoque.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque)
        {
            var query = _query.UpdateT_FeedbackMovEstoqueQuery(T_FeedbackMovEstoque);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque)
        {
            var query = _query.DeleteT_FeedbackMovEstoqueQuery(T_FeedbackMovEstoque);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFeedbackId(int id, int value)
        {
            var query = _query.UpdateFeedbackId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMovimentoEstoqueId(int id, int value)
        {
            var query = _query.UpdateMovimentoEstoqueId(id, value);
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