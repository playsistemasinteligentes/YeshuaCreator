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
    public class TemplatesMaquinasQueryWrite : QueryBase, ITemplatesMaquinasQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TemplatesMaquinasQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTemplatesMaquinasQuery(ITemplatesMaquinasEntity TemplatesMaquinas)
        {
            this.Query = $@" INSERT INTO TemplatesMaquinas (TEM_ID, MAQ_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@TEM_ID, @MAQ_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TEM_ID = TemplatesMaquinas.TEM_ID,
                MAQ_ID = TemplatesMaquinas.MAQ_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplatesMaquinasQuery(ITemplatesMaquinasEntity TemplatesMaquinas)
        {
            this.Query = $@" UPDATE TemplatesMaquinas SET TEM_ID = @TEM_ID, MAQ_ID = @MAQ_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                TEM_ID = TemplatesMaquinas.TEM_ID,
                MAQ_ID = TemplatesMaquinas.MAQ_ID,
                Changed = TemplatesMaquinas.Changed,
                UserId = _executionContext.UserId,
                Id = TemplatesMaquinas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(int id, int value)
        {
            this.Query = $@" UPDATE TemplatesMaquinas SET TEM_ID = @TEM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TEM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE TemplatesMaquinas SET MAQ_ID = @MAQ_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE TemplatesMaquinas SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE TemplatesMaquinas SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE TemplatesMaquinas SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE TemplatesMaquinas SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTemplatesMaquinasQuery(ITemplatesMaquinasEntity TemplatesMaquinas)
        {
            this.Query = $@" DELETE FROM TemplatesMaquinas WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = TemplatesMaquinas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration