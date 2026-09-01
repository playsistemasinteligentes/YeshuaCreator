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
    public class RespInspVisualQueryWrite : QueryBase, IRespInspVisualQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RespInspVisualQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRespInspVisualQuery(IRespInspVisualEntity RespInspVisual)
        {
            this.Query = $@" INSERT INTO RespInspVisual (RIV_ID, IPV_ID, ITI_ID, RIV_STATUS, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@RIV_ID, @IPV_ID, @ITI_ID, @RIV_STATUS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                RIV_ID = RespInspVisual.RIV_ID,
                IPV_ID = RespInspVisual.IPV_ID,
                ITI_ID = RespInspVisual.ITI_ID,
                RIV_STATUS = RespInspVisual.RIV_STATUS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRespInspVisualQuery(IRespInspVisualEntity RespInspVisual)
        {
            this.Query = $@" UPDATE RespInspVisual SET RIV_ID = @RIV_ID, IPV_ID = @IPV_ID, ITI_ID = @ITI_ID, RIV_STATUS = @RIV_STATUS, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                RIV_ID = RespInspVisual.RIV_ID,
                IPV_ID = RespInspVisual.IPV_ID,
                ITI_ID = RespInspVisual.ITI_ID,
                RIV_STATUS = RespInspVisual.RIV_STATUS,
                Changed = RespInspVisual.Changed,
                UserId = _executionContext.UserId,
                Id = RespInspVisual.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRIV_ID(int id, int value)
        {
            this.Query = $@" UPDATE RespInspVisual SET RIV_ID = @RIV_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                RIV_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_ID(int id, int value)
        {
            this.Query = $@" UPDATE RespInspVisual SET IPV_ID = @IPV_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                IPV_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITI_ID(int id, int value)
        {
            this.Query = $@" UPDATE RespInspVisual SET ITI_ID = @ITI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ITI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRIV_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE RespInspVisual SET RIV_STATUS = @RIV_STATUS WHERE Id = @Id ";
            this.Parameters = new
            {
                RIV_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE RespInspVisual SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE RespInspVisual SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE RespInspVisual SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE RespInspVisual SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRespInspVisualQuery(IRespInspVisualEntity RespInspVisual)
        {
            this.Query = $@" DELETE FROM RespInspVisual WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = RespInspVisual.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration