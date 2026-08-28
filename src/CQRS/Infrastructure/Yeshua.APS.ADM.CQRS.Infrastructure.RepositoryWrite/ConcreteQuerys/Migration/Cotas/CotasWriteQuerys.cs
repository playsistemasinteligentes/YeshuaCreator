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
    public class CotasQueryWrite : QueryBase, ICotasQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CotasQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCotasQuery(ICotasEntity Cotas)
        {
            this.Query = $@" INSERT INTO Cotas (COT_DATA_DE, COT_DATA_ATE, COT_VALOR, COT_OCUPADO, REP_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@COT_DATA_DE, @COT_DATA_ATE, @COT_VALOR, @COT_OCUPADO, @REP_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                COT_DATA_DE = Cotas.COT_DATA_DE,
                COT_DATA_ATE = Cotas.COT_DATA_ATE,
                COT_VALOR = Cotas.COT_VALOR,
                COT_OCUPADO = Cotas.COT_OCUPADO,
                REP_ID = Cotas.REP_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCotasQuery(ICotasEntity Cotas)
        {
            this.Query = $@" UPDATE Cotas SET COT_ID = @COT_ID, COT_DATA_DE = @COT_DATA_DE, COT_DATA_ATE = @COT_DATA_ATE, COT_VALOR = @COT_VALOR, COT_OCUPADO = @COT_OCUPADO, REP_ID = @REP_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                COT_ID = Cotas.COT_ID,
                COT_DATA_DE = Cotas.COT_DATA_DE,
                COT_DATA_ATE = Cotas.COT_DATA_ATE,
                COT_VALOR = Cotas.COT_VALOR,
                COT_OCUPADO = Cotas.COT_OCUPADO,
                REP_ID = Cotas.REP_ID,
                Changed = Cotas.Changed,
                UserId = _executionContext.UserId,
                Id = Cotas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOT_ID(int id, int value)
        {
            this.Query = $@" UPDATE Cotas SET COT_ID = @COT_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                COT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOT_DATA_DE(int id, DateTime value)
        {
            this.Query = $@" UPDATE Cotas SET COT_DATA_DE = @COT_DATA_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                COT_DATA_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOT_DATA_ATE(int id, DateTime value)
        {
            this.Query = $@" UPDATE Cotas SET COT_DATA_ATE = @COT_DATA_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                COT_DATA_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOT_VALOR(int id, Decimal value)
        {
            this.Query = $@" UPDATE Cotas SET COT_VALOR = @COT_VALOR WHERE Id = @Id ";
            this.Parameters = new
            {
                COT_VALOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOT_OCUPADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Cotas SET COT_OCUPADO = @COT_OCUPADO WHERE Id = @Id ";
            this.Parameters = new
            {
                COT_OCUPADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREP_ID(int id, int value)
        {
            this.Query = $@" UPDATE Cotas SET REP_ID = @REP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                REP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Cotas SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Cotas SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Cotas SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Cotas SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCotasQuery(ICotasEntity Cotas)
        {
            this.Query = $@" DELETE FROM Cotas WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Cotas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration