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
    public class ParametrosDeCustoQueryWrite : QueryBase, IParametrosDeCustoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ParametrosDeCustoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirParametrosDeCustoQuery(IParametrosDeCustoEntity ParametrosDeCusto)
        {
            this.Query = $@" INSERT INTO ParametrosDeCusto (PRO_ID, CUS_ID, PAR_VALOR, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PRO_ID, @CUS_ID, @PAR_VALOR, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PRO_ID = ParametrosDeCusto.PRO_ID,
                CUS_ID = ParametrosDeCusto.CUS_ID,
                PAR_VALOR = ParametrosDeCusto.PAR_VALOR,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateParametrosDeCustoQuery(IParametrosDeCustoEntity ParametrosDeCusto)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET PAR_ID = @PAR_ID, PRO_ID = @PRO_ID, CUS_ID = @CUS_ID, PAR_VALOR = @PAR_VALOR, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                PAR_ID = ParametrosDeCusto.PAR_ID,
                PRO_ID = ParametrosDeCusto.PRO_ID,
                CUS_ID = ParametrosDeCusto.CUS_ID,
                PAR_VALOR = ParametrosDeCusto.PAR_VALOR,
                Changed = ParametrosDeCusto.Changed,
                UserId = _executionContext.UserId,
                Id = ParametrosDeCusto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAR_ID(int id, int value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET PAR_ID = @PAR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET PRO_ID = @PRO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCUS_ID(int id, string value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET CUS_ID = @CUS_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CUS_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAR_VALOR(int id, string value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET PAR_VALOR = @PAR_VALOR WHERE Id = @Id ";
            this.Parameters = new
            {
                PAR_VALOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE ParametrosDeCusto SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteParametrosDeCustoQuery(IParametrosDeCustoEntity ParametrosDeCusto)
        {
            this.Query = $@" DELETE FROM ParametrosDeCusto WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ParametrosDeCusto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration