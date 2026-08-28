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
    public class TemplateDeTestesQueryWrite : QueryBase, ITemplateDeTestesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TemplateDeTestesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes)
        {
            this.Query = $@" INSERT INTO TemplateDeTestes (Descricao, TenantID, Deleted, Changed, UserId, Observacao) OUTPUT INSERTED.Id VALUES(@Descricao, @TenantID, @Deleted, @Changed, @UserId, @Observacao) ";
            this.Parameters = new
            {
                Descricao = TemplateDeTestes.Descricao,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                Observacao = TemplateDeTestes.Observacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET Descricao = @Descricao, Changed = @Changed, UserId = @UserId, Observacao = @Observacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = TemplateDeTestes.Descricao,
                Changed = TemplateDeTestes.Changed,
                UserId = _executionContext.UserId,
                Observacao = TemplateDeTestes.Observacao,
                Id = TemplateDeTestes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(int id, string value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObservacao(int id, string value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET Observacao = @Observacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Observacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes)
        {
            this.Query = $@" DELETE FROM TemplateDeTestes WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = TemplateDeTestes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration