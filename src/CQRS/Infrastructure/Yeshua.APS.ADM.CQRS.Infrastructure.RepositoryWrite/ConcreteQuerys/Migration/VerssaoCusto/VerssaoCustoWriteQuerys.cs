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
    public class VerssaoCustoQueryWrite : QueryBase, IVerssaoCustoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public VerssaoCustoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirVerssaoCustoQuery(IVerssaoCustoEntity VerssaoCusto)
        {
            this.Query = $@" INSERT INTO VerssaoCusto (VER_ID, VER_STATUS, VER_DATA_VERSSAO_CUSTO, VER_OBS, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@VER_ID, @VER_STATUS, @VER_DATA_VERSSAO_CUSTO, @VER_OBS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                VER_ID = VerssaoCusto.VER_ID,
                VER_STATUS = VerssaoCusto.VER_STATUS,
                VER_DATA_VERSSAO_CUSTO = VerssaoCusto.VER_DATA_VERSSAO_CUSTO,
                VER_OBS = VerssaoCusto.VER_OBS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVerssaoCustoQuery(IVerssaoCustoEntity VerssaoCusto)
        {
            this.Query = $@" UPDATE VerssaoCusto SET VER_ID = @VER_ID, VER_STATUS = @VER_STATUS, VER_DATA_VERSSAO_CUSTO = @VER_DATA_VERSSAO_CUSTO, VER_OBS = @VER_OBS, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                VER_ID = VerssaoCusto.VER_ID,
                VER_STATUS = VerssaoCusto.VER_STATUS,
                VER_DATA_VERSSAO_CUSTO = VerssaoCusto.VER_DATA_VERSSAO_CUSTO,
                VER_OBS = VerssaoCusto.VER_OBS,
                Changed = VerssaoCusto.Changed,
                UserId = _executionContext.UserId,
                Id = VerssaoCusto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_ID(int id, int value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET VER_ID = @VER_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                VER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET VER_STATUS = @VER_STATUS WHERE Id = @Id ";
            this.Parameters = new
            {
                VER_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_DATA_VERSSAO_CUSTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET VER_DATA_VERSSAO_CUSTO = @VER_DATA_VERSSAO_CUSTO WHERE Id = @Id ";
            this.Parameters = new
            {
                VER_DATA_VERSSAO_CUSTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_OBS(int id, string value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET VER_OBS = @VER_OBS WHERE Id = @Id ";
            this.Parameters = new
            {
                VER_OBS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE VerssaoCusto SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteVerssaoCustoQuery(IVerssaoCustoEntity VerssaoCusto)
        {
            this.Query = $@" DELETE FROM VerssaoCusto WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = VerssaoCusto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration