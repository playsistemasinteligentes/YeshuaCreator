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
    public class CorConfiguracaoGraficoQueryWrite : QueryBase, ICorConfiguracaoGraficoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CorConfiguracaoGraficoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCorConfiguracaoGraficoQuery(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico)
        {
            this.Query = $@" INSERT INTO CorConfiguracaoGrafico (COR_ID, COR_PERCENTUAL_INI, COR_PERCENTUAL_FIM, COR_DESCRICAO, TenantID, Deleted, Changed, UserId) VALUES(@COR_ID, @COR_PERCENTUAL_INI, @COR_PERCENTUAL_FIM, @COR_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                COR_ID = CorConfiguracaoGrafico.COR_ID,
                COR_PERCENTUAL_INI = CorConfiguracaoGrafico.COR_PERCENTUAL_INI,
                COR_PERCENTUAL_FIM = CorConfiguracaoGrafico.COR_PERCENTUAL_FIM,
                COR_DESCRICAO = CorConfiguracaoGrafico.COR_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorConfiguracaoGraficoQuery(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET COR_PERCENTUAL_INI = @COR_PERCENTUAL_INI, COR_PERCENTUAL_FIM = @COR_PERCENTUAL_FIM, COR_DESCRICAO = @COR_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                COR_PERCENTUAL_INI = CorConfiguracaoGrafico.COR_PERCENTUAL_INI,
                COR_PERCENTUAL_FIM = CorConfiguracaoGrafico.COR_PERCENTUAL_FIM,
                COR_DESCRICAO = CorConfiguracaoGrafico.COR_DESCRICAO,
                Changed = CorConfiguracaoGrafico.Changed,
                UserId = _executionContext.UserId,
                COR_ID = CorConfiguracaoGrafico.COR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_PERCENTUAL_INI(string cor_id, Decimal value)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET COR_PERCENTUAL_INI = @COR_PERCENTUAL_INI WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                COR_PERCENTUAL_INI = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_PERCENTUAL_FIM(string cor_id, Decimal value)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET COR_PERCENTUAL_FIM = @COR_PERCENTUAL_FIM WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                COR_PERCENTUAL_FIM = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_DESCRICAO(string cor_id, string value)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET COR_DESCRICAO = @COR_DESCRICAO WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                COR_DESCRICAO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string cor_id, int value)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET TenantID = @TenantID WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                TenantID = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string cor_id, bool value)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET Deleted = @Deleted WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                Deleted = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string cor_id, DateTime value)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET Changed = @Changed WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                Changed = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string cor_id, int value)
        {
            this.Query = $@" UPDATE CorConfiguracaoGrafico SET UserId = @UserId WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                UserId = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCorConfiguracaoGraficoQuery(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico)
        {
            this.Query = $@" DELETE FROM CorConfiguracaoGrafico WHERE COR_ID = @COR_ID ";
            this.Parameters = new
            {
                COR_ID = CorConfiguracaoGrafico.COR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration