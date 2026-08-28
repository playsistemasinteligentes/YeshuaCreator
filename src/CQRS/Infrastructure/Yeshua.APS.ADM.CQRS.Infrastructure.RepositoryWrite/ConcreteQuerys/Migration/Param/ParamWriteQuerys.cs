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
    public class ParamQueryWrite : QueryBase, IParamQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ParamQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirParamQuery(IParamEntity Param)
        {
            this.Query = $@" INSERT INTO Param (PAR_ID, PAR_DESCRICAO, PAR_VALOR_S, PAR_VALOR_N, PAR_VALOR_D, TenantID, Deleted, Changed, UserId) VALUES(@PAR_ID, @PAR_DESCRICAO, @PAR_VALOR_S, @PAR_VALOR_N, @PAR_VALOR_D, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PAR_ID = Param.PAR_ID,
                PAR_DESCRICAO = Param.PAR_DESCRICAO,
                PAR_VALOR_S = Param.PAR_VALOR_S,
                PAR_VALOR_N = Param.PAR_VALOR_N,
                PAR_VALOR_D = Param.PAR_VALOR_D,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateParamQuery(IParamEntity Param)
        {
            this.Query = $@" UPDATE Param SET PAR_DESCRICAO = @PAR_DESCRICAO, PAR_VALOR_S = @PAR_VALOR_S, PAR_VALOR_N = @PAR_VALOR_N, PAR_VALOR_D = @PAR_VALOR_D, Changed = @Changed, UserId = @UserId WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                PAR_DESCRICAO = Param.PAR_DESCRICAO,
                PAR_VALOR_S = Param.PAR_VALOR_S,
                PAR_VALOR_N = Param.PAR_VALOR_N,
                PAR_VALOR_D = Param.PAR_VALOR_D,
                Changed = Param.Changed,
                UserId = _executionContext.UserId,
                PAR_ID = Param.PAR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAR_DESCRICAO(string par_id, string value)
        {
            this.Query = $@" UPDATE Param SET PAR_DESCRICAO = @PAR_DESCRICAO WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                PAR_DESCRICAO = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAR_VALOR_S(string par_id, string value)
        {
            this.Query = $@" UPDATE Param SET PAR_VALOR_S = @PAR_VALOR_S WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                PAR_VALOR_S = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAR_VALOR_N(string par_id, Decimal value)
        {
            this.Query = $@" UPDATE Param SET PAR_VALOR_N = @PAR_VALOR_N WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                PAR_VALOR_N = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAR_VALOR_D(string par_id, DateTime value)
        {
            this.Query = $@" UPDATE Param SET PAR_VALOR_D = @PAR_VALOR_D WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                PAR_VALOR_D = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string par_id, int value)
        {
            this.Query = $@" UPDATE Param SET TenantID = @TenantID WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string par_id, bool value)
        {
            this.Query = $@" UPDATE Param SET Deleted = @Deleted WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string par_id, DateTime value)
        {
            this.Query = $@" UPDATE Param SET Changed = @Changed WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                Changed = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string par_id, int value)
        {
            this.Query = $@" UPDATE Param SET UserId = @UserId WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                UserId = value,
                PAR_ID = par_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteParamQuery(IParamEntity Param)
        {
            this.Query = $@" DELETE FROM Param WHERE PAR_ID = @PAR_ID ";
            this.Parameters = new
            {
                PAR_ID = Param.PAR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration