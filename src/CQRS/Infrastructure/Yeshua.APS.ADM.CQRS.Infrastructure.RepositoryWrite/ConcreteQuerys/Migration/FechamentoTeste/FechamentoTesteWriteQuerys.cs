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
    public class FechamentoTesteQueryWrite : QueryBase, IFechamentoTesteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public FechamentoTesteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirFechamentoTesteQuery(IFechamentoTesteEntity FechamentoTeste)
        {
            this.Query = $@" INSERT INTO FechamentoTeste (FEC_QTD, GRP_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@FEC_QTD, @GRP_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                FEC_QTD = FechamentoTeste.FEC_QTD,
                GRP_ID = FechamentoTeste.GRP_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFechamentoTesteQuery(IFechamentoTesteEntity FechamentoTeste)
        {
            this.Query = $@" UPDATE FechamentoTeste SET FEC_ID = @FEC_ID, FEC_QTD = @FEC_QTD, GRP_ID = @GRP_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                FEC_ID = FechamentoTeste.FEC_ID,
                FEC_QTD = FechamentoTeste.FEC_QTD,
                GRP_ID = FechamentoTeste.GRP_ID,
                Changed = FechamentoTeste.Changed,
                UserId = _executionContext.UserId,
                Id = FechamentoTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFEC_ID(int id, int value)
        {
            this.Query = $@" UPDATE FechamentoTeste SET FEC_ID = @FEC_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                FEC_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFEC_QTD(int id, int value)
        {
            this.Query = $@" UPDATE FechamentoTeste SET FEC_QTD = @FEC_QTD WHERE Id = @Id ";
            this.Parameters = new
            {
                FEC_QTD = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID(int id, string value)
        {
            this.Query = $@" UPDATE FechamentoTeste SET GRP_ID = @GRP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE FechamentoTeste SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE FechamentoTeste SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE FechamentoTeste SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE FechamentoTeste SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteFechamentoTesteQuery(IFechamentoTesteEntity FechamentoTeste)
        {
            this.Query = $@" DELETE FROM FechamentoTeste WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = FechamentoTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration