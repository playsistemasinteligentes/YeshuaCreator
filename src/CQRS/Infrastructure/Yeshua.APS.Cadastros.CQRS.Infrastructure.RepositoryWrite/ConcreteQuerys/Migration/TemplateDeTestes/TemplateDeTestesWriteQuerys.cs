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
            this.Query = $@" INSERT INTO TemplateDeTestes (TEM_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.TEM_ID VALUES(@TEM_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TEM_DESCRICAO = TemplateDeTestes.TEM_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET TEM_DESCRICAO = @TEM_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TEM_DESCRICAO = TemplateDeTestes.TEM_DESCRICAO,
                Changed = TemplateDeTestes.Changed,
                UserId = _executionContext.UserId,
                TEM_ID = TemplateDeTestes.TEM_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_DESCRICAO(int tem_id, string value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET TEM_DESCRICAO = @TEM_DESCRICAO WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TEM_DESCRICAO = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int tem_id, int value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET TenantID = @TenantID WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int tem_id, bool value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET Deleted = @Deleted WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int tem_id, DateTime value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET Changed = @Changed WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                Changed = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int tem_id, int value)
        {
            this.Query = $@" UPDATE TemplateDeTestes SET UserId = @UserId WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                UserId = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes)
        {
            this.Query = $@" DELETE FROM TemplateDeTestes WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TEM_ID = TemplateDeTestes.TEM_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration