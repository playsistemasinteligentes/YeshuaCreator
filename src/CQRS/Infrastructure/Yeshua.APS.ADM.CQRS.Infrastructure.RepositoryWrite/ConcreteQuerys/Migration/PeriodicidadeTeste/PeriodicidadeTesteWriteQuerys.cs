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
    public class PeriodicidadeTesteQueryWrite : QueryBase, IPeriodicidadeTesteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PeriodicidadeTesteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPeriodicidadeTesteQuery(IPeriodicidadeTesteEntity PeriodicidadeTeste)
        {
            this.Query = $@" INSERT INTO PeriodicidadeTeste (PER_ID, PER_QTD, UNI_ID, GRP_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PER_ID, @PER_QTD, @UNI_ID, @GRP_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PER_ID = PeriodicidadeTeste.PER_ID,
                PER_QTD = PeriodicidadeTeste.PER_QTD,
                UNI_ID = PeriodicidadeTeste.UNI_ID,
                GRP_ID = PeriodicidadeTeste.GRP_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePeriodicidadeTesteQuery(IPeriodicidadeTesteEntity PeriodicidadeTeste)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET PER_ID = @PER_ID, PER_QTD = @PER_QTD, UNI_ID = @UNI_ID, GRP_ID = @GRP_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                PER_ID = PeriodicidadeTeste.PER_ID,
                PER_QTD = PeriodicidadeTeste.PER_QTD,
                UNI_ID = PeriodicidadeTeste.UNI_ID,
                GRP_ID = PeriodicidadeTeste.GRP_ID,
                Changed = PeriodicidadeTeste.Changed,
                UserId = _executionContext.UserId,
                Id = PeriodicidadeTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int id, int value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET PER_ID = @PER_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_QTD(int id, string value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET PER_QTD = @PER_QTD WHERE Id = @Id ";
            this.Parameters = new
            {
                PER_QTD = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ID(int id, string value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET UNI_ID = @UNI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                UNI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID(int id, string value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET GRP_ID = @GRP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE PeriodicidadeTeste SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePeriodicidadeTesteQuery(IPeriodicidadeTesteEntity PeriodicidadeTeste)
        {
            this.Query = $@" DELETE FROM PeriodicidadeTeste WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = PeriodicidadeTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration