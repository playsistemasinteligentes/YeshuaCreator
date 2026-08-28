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
    public class InpecaoVisualQueryWrite : QueryBase, IInpecaoVisualQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public InpecaoVisualQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirInpecaoVisualQuery(IInpecaoVisualEntity InpecaoVisual)
        {
            this.Query = $@" INSERT INTO InpecaoVisual (IPV_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@IPV_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IPV_ID = InpecaoVisual.IPV_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateInpecaoVisualQuery(IInpecaoVisualEntity InpecaoVisual)
        {
            this.Query = $@" UPDATE InpecaoVisual SET IPV_ID = @IPV_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                IPV_ID = InpecaoVisual.IPV_ID,
                Changed = InpecaoVisual.Changed,
                UserId = _executionContext.UserId,
                Id = InpecaoVisual.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_ID(int id, int value)
        {
            this.Query = $@" UPDATE InpecaoVisual SET IPV_ID = @IPV_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                IPV_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE InpecaoVisual SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE InpecaoVisual SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE InpecaoVisual SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE InpecaoVisual SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteInpecaoVisualQuery(IInpecaoVisualEntity InpecaoVisual)
        {
            this.Query = $@" DELETE FROM InpecaoVisual WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = InpecaoVisual.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration