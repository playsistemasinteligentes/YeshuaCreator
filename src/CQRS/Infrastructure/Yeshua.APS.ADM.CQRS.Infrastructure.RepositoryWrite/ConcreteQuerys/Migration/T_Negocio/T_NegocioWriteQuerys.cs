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
    public class T_NegocioQueryWrite : QueryBase, IT_NegocioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_NegocioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_NegocioQuery(IT_NegocioEntity T_Negocio)
        {
            this.Query = $@" INSERT INTO T_Negocio (NEG_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.NEG_ID VALUES(@NEG_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                NEG_DESCRICAO = T_Negocio.NEG_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_NegocioQuery(IT_NegocioEntity T_Negocio)
        {
            this.Query = $@" UPDATE T_Negocio SET NEG_DESCRICAO = @NEG_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE NEG_ID = @NEG_ID ";
            this.Parameters = new
            {
                NEG_DESCRICAO = T_Negocio.NEG_DESCRICAO,
                Changed = T_Negocio.Changed,
                UserId = _executionContext.UserId,
                NEG_ID = T_Negocio.NEG_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNEG_DESCRICAO(int neg_id, string value)
        {
            this.Query = $@" UPDATE T_Negocio SET NEG_DESCRICAO = @NEG_DESCRICAO WHERE NEG_ID = @NEG_ID ";
            this.Parameters = new
            {
                NEG_DESCRICAO = value,
                NEG_ID = neg_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int neg_id, int value)
        {
            this.Query = $@" UPDATE T_Negocio SET TenantID = @TenantID WHERE NEG_ID = @NEG_ID ";
            this.Parameters = new
            {
                TenantID = value,
                NEG_ID = neg_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int neg_id, bool value)
        {
            this.Query = $@" UPDATE T_Negocio SET Deleted = @Deleted WHERE NEG_ID = @NEG_ID ";
            this.Parameters = new
            {
                Deleted = value,
                NEG_ID = neg_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int neg_id, DateTime value)
        {
            this.Query = $@" UPDATE T_Negocio SET Changed = @Changed WHERE NEG_ID = @NEG_ID ";
            this.Parameters = new
            {
                Changed = value,
                NEG_ID = neg_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int neg_id, int value)
        {
            this.Query = $@" UPDATE T_Negocio SET UserId = @UserId WHERE NEG_ID = @NEG_ID ";
            this.Parameters = new
            {
                UserId = value,
                NEG_ID = neg_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_NegocioQuery(IT_NegocioEntity T_Negocio)
        {
            this.Query = $@" DELETE FROM T_Negocio WHERE NEG_ID = @NEG_ID ";
            this.Parameters = new
            {
                NEG_ID = T_Negocio.NEG_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration