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
    public class ResultMedidaQueryWrite : QueryBase, IResultMedidaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ResultMedidaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirResultMedidaQuery(IResultMedidaEntity ResultMedida)
        {
            this.Query = $@" INSERT INTO ResultMedida (RL_ID, MDT_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@RL_ID, @MDT_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                RL_ID = ResultMedida.RL_ID,
                MDT_ID = ResultMedida.MDT_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateResultMedidaQuery(IResultMedidaEntity ResultMedida)
        {
            this.Query = $@" UPDATE ResultMedida SET RSM_ID = @RSM_ID, RL_ID = @RL_ID, MDT_ID = @MDT_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                RSM_ID = ResultMedida.RSM_ID,
                RL_ID = ResultMedida.RL_ID,
                MDT_ID = ResultMedida.MDT_ID,
                Changed = ResultMedida.Changed,
                UserId = _executionContext.UserId,
                Id = ResultMedida.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRSM_ID(int id, int value)
        {
            this.Query = $@" UPDATE ResultMedida SET RSM_ID = @RSM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                RSM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRL_ID(int id, int value)
        {
            this.Query = $@" UPDATE ResultMedida SET RL_ID = @RL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                RL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDT_ID(int id, int value)
        {
            this.Query = $@" UPDATE ResultMedida SET MDT_ID = @MDT_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MDT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE ResultMedida SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE ResultMedida SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE ResultMedida SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE ResultMedida SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteResultMedidaQuery(IResultMedidaEntity ResultMedida)
        {
            this.Query = $@" DELETE FROM ResultMedida WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ResultMedida.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration