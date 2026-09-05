// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class T_FeedbackMovEstoqueQueryWrite : QueryBase, IT_FeedbackMovEstoqueQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_FeedbackMovEstoqueQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_FeedbackMovEstoqueQuery(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque)
        {
            this.Query = $@" INSERT INTO [T_FeedbackMovEstoque] ([FeedbackId], [MovimentoEstoqueId], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@FeedbackId, @MovimentoEstoqueId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                FeedbackId = T_FeedbackMovEstoque.FeedbackId,
                MovimentoEstoqueId = T_FeedbackMovEstoque.MovimentoEstoqueId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_FeedbackMovEstoqueQuery(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque)
        {
            this.Query = $@" UPDATE [T_FeedbackMovEstoque] SET [FeedbackId] = @FeedbackId, [MovimentoEstoqueId] = @MovimentoEstoqueId, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FeedbackId = T_FeedbackMovEstoque.FeedbackId,
                MovimentoEstoqueId = T_FeedbackMovEstoque.MovimentoEstoqueId,
                Changed = T_FeedbackMovEstoque.Changed,
                UserId = _executionContext.UserId,
                Id = T_FeedbackMovEstoque.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFeedbackId(int id, int value)
        {
            this.Query = $@" UPDATE [T_FeedbackMovEstoque] SET [FeedbackId] = @FeedbackId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FeedbackId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentoEstoqueId(int id, int value)
        {
            this.Query = $@" UPDATE [T_FeedbackMovEstoque] SET [MovimentoEstoqueId] = @MovimentoEstoqueId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MovimentoEstoqueId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [T_FeedbackMovEstoque] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [T_FeedbackMovEstoque] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [T_FeedbackMovEstoque] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [T_FeedbackMovEstoque] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_FeedbackMovEstoqueQuery(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque)
        {
            this.Query = $@" DELETE FROM [T_FeedbackMovEstoque] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = T_FeedbackMovEstoque.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration