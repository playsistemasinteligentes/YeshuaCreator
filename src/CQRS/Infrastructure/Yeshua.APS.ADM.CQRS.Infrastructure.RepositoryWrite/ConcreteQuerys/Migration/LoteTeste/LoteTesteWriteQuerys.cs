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
    public class LoteTesteQueryWrite : QueryBase, ILoteTesteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public LoteTesteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirLoteTesteQuery(ILoteTesteEntity LoteTeste)
        {
            this.Query = $@" INSERT INTO LoteTeste (TES_ID, RL_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@TES_ID, @RL_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TES_ID = LoteTeste.TES_ID,
                RL_ID = LoteTeste.RL_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLoteTesteQuery(ILoteTesteEntity LoteTeste)
        {
            this.Query = $@" UPDATE LoteTeste SET LT_ID = @LT_ID, TES_ID = @TES_ID, RL_ID = @RL_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                LT_ID = LoteTeste.LT_ID,
                TES_ID = LoteTeste.TES_ID,
                RL_ID = LoteTeste.RL_ID,
                Changed = LoteTeste.Changed,
                UserId = _executionContext.UserId,
                Id = LoteTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLT_ID(int id, int value)
        {
            this.Query = $@" UPDATE LoteTeste SET LT_ID = @LT_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                LT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_ID(int id, int value)
        {
            this.Query = $@" UPDATE LoteTeste SET TES_ID = @TES_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TES_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRL_ID(int id, int value)
        {
            this.Query = $@" UPDATE LoteTeste SET RL_ID = @RL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                RL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE LoteTeste SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE LoteTeste SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE LoteTeste SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE LoteTeste SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteLoteTesteQuery(ILoteTesteEntity LoteTeste)
        {
            this.Query = $@" DELETE FROM LoteTeste WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = LoteTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration