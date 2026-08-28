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
    public class MesesQueryWrite : QueryBase, IMesesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MesesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMesesQuery(IMesesEntity Meses)
        {
            this.Query = $@" INSERT INTO Meses (MES, fator, TenantID, Deleted, Changed, UserId) VALUES(@MES, @fator, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MES = Meses.MES,
                fator = Meses.fator,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMesesQuery(IMesesEntity Meses)
        {
            this.Query = $@" UPDATE Meses SET fator = @fator, Changed = @Changed, UserId = @UserId WHERE MES = @MES ";
            this.Parameters = new
            {
                fator = Meses.fator,
                Changed = Meses.Changed,
                UserId = _executionContext.UserId,
                MES = Meses.MES,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel Updatefator(string mes, int value)
        {
            this.Query = $@" UPDATE Meses SET fator = @fator WHERE MES = @MES ";
            this.Parameters = new
            {
                fator = value,
                MES = mes,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string mes, int value)
        {
            this.Query = $@" UPDATE Meses SET TenantID = @TenantID WHERE MES = @MES ";
            this.Parameters = new
            {
                TenantID = value,
                MES = mes,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string mes, bool value)
        {
            this.Query = $@" UPDATE Meses SET Deleted = @Deleted WHERE MES = @MES ";
            this.Parameters = new
            {
                Deleted = value,
                MES = mes,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string mes, DateTime value)
        {
            this.Query = $@" UPDATE Meses SET Changed = @Changed WHERE MES = @MES ";
            this.Parameters = new
            {
                Changed = value,
                MES = mes,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string mes, int value)
        {
            this.Query = $@" UPDATE Meses SET UserId = @UserId WHERE MES = @MES ";
            this.Parameters = new
            {
                UserId = value,
                MES = mes,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMesesQuery(IMesesEntity Meses)
        {
            this.Query = $@" DELETE FROM Meses WHERE MES = @MES ";
            this.Parameters = new
            {
                MES = Meses.MES,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration