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
    public class EstruturaImpressaoQueryWrite : QueryBase, IEstruturaImpressaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EstruturaImpressaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEstruturaImpressaoQuery(IEstruturaImpressaoEntity EstruturaImpressao)
        {
            this.Query = $@" INSERT INTO [EstruturaImpressao] ([HTML_ESTRUTURA], [CLI_ID], [EST_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[EST_ID] VALUES(@HTML_ESTRUTURA, @CLI_ID, @EST_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                HTML_ESTRUTURA = EstruturaImpressao.HTML_ESTRUTURA,
                CLI_ID = EstruturaImpressao.CLI_ID,
                EST_DESCRICAO = EstruturaImpressao.EST_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstruturaImpressaoQuery(IEstruturaImpressaoEntity EstruturaImpressao)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [HTML_ESTRUTURA] = @HTML_ESTRUTURA, [CLI_ID] = @CLI_ID, [EST_DESCRICAO] = @EST_DESCRICAO, [Changed] = @Changed, [UserId] = @UserId WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                HTML_ESTRUTURA = EstruturaImpressao.HTML_ESTRUTURA,
                CLI_ID = EstruturaImpressao.CLI_ID,
                EST_DESCRICAO = EstruturaImpressao.EST_DESCRICAO,
                Changed = EstruturaImpressao.Changed,
                UserId = _executionContext.UserId,
                EST_ID = EstruturaImpressao.EST_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHTML_ESTRUTURA(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [HTML_ESTRUTURA] = @HTML_ESTRUTURA WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                HTML_ESTRUTURA = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [CLI_ID] = @CLI_ID WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                CLI_ID = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_DESCRICAO(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [EST_DESCRICAO] = @EST_DESCRICAO WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_DESCRICAO = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int est_id, int value)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [TenantID] = @TenantID WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                TenantID = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int est_id, bool value)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [Deleted] = @Deleted WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                Deleted = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int est_id, DateTime value)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [Changed] = @Changed WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                Changed = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int est_id, int value)
        {
            this.Query = $@" UPDATE [EstruturaImpressao] SET [UserId] = @UserId WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                UserId = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEstruturaImpressaoQuery(IEstruturaImpressaoEntity EstruturaImpressao)
        {
            this.Query = $@" DELETE FROM [EstruturaImpressao] WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_ID = EstruturaImpressao.EST_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration