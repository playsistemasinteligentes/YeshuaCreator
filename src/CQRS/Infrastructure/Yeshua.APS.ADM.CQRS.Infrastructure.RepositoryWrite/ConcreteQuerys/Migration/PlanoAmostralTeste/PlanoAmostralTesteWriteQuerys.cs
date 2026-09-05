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
    public class PlanoAmostralTesteQueryWrite : QueryBase, IPlanoAmostralTesteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PlanoAmostralTesteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPlanoAmostralTesteQuery(IPlanoAmostralTesteEntity PlanoAmostralTeste)
        {
            this.Query = $@" INSERT INTO [PlanoAmostralTeste] ([GRP_TIPO], [TenantID], [Deleted], [Changed], [UserId], [PAT_QTD_CAIXAS_DE], [PAT_QTD_CAIXAS_ATE], [PAT_N_AMOSTRAGEM], [PAT_PERCENT_ESPECIF]) OUTPUT INSERTED.[PAT_ID] VALUES(@GRP_TIPO, @TenantID, @Deleted, @Changed, @UserId, @PAT_QTD_CAIXAS_DE, @PAT_QTD_CAIXAS_ATE, @PAT_N_AMOSTRAGEM, @PAT_PERCENT_ESPECIF) ";
            this.Parameters = new
            {
                GRP_TIPO = PlanoAmostralTeste.GRP_TIPO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                PAT_QTD_CAIXAS_DE = PlanoAmostralTeste.PAT_QTD_CAIXAS_DE,
                PAT_QTD_CAIXAS_ATE = PlanoAmostralTeste.PAT_QTD_CAIXAS_ATE,
                PAT_N_AMOSTRAGEM = PlanoAmostralTeste.PAT_N_AMOSTRAGEM,
                PAT_PERCENT_ESPECIF = PlanoAmostralTeste.PAT_PERCENT_ESPECIF,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlanoAmostralTesteQuery(IPlanoAmostralTesteEntity PlanoAmostralTeste)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [GRP_TIPO] = @GRP_TIPO, [Changed] = @Changed, [UserId] = @UserId, [PAT_QTD_CAIXAS_DE] = @PAT_QTD_CAIXAS_DE, [PAT_QTD_CAIXAS_ATE] = @PAT_QTD_CAIXAS_ATE, [PAT_N_AMOSTRAGEM] = @PAT_N_AMOSTRAGEM, [PAT_PERCENT_ESPECIF] = @PAT_PERCENT_ESPECIF WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                GRP_TIPO = PlanoAmostralTeste.GRP_TIPO,
                Changed = PlanoAmostralTeste.Changed,
                UserId = _executionContext.UserId,
                PAT_QTD_CAIXAS_DE = PlanoAmostralTeste.PAT_QTD_CAIXAS_DE,
                PAT_QTD_CAIXAS_ATE = PlanoAmostralTeste.PAT_QTD_CAIXAS_ATE,
                PAT_N_AMOSTRAGEM = PlanoAmostralTeste.PAT_N_AMOSTRAGEM,
                PAT_PERCENT_ESPECIF = PlanoAmostralTeste.PAT_PERCENT_ESPECIF,
                PAT_ID = PlanoAmostralTeste.PAT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TIPO(int pat_id, Decimal value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [GRP_TIPO] = @GRP_TIPO WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                GRP_TIPO = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int pat_id, int value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [TenantID] = @TenantID WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int pat_id, bool value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [Deleted] = @Deleted WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int pat_id, DateTime value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [Changed] = @Changed WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                Changed = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int pat_id, int value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [UserId] = @UserId WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                UserId = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAT_QTD_CAIXAS_DE(int pat_id, int value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [PAT_QTD_CAIXAS_DE] = @PAT_QTD_CAIXAS_DE WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                PAT_QTD_CAIXAS_DE = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAT_QTD_CAIXAS_ATE(int pat_id, int value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [PAT_QTD_CAIXAS_ATE] = @PAT_QTD_CAIXAS_ATE WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                PAT_QTD_CAIXAS_ATE = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAT_N_AMOSTRAGEM(int pat_id, int value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [PAT_N_AMOSTRAGEM] = @PAT_N_AMOSTRAGEM WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                PAT_N_AMOSTRAGEM = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePAT_PERCENT_ESPECIF(int pat_id, Decimal value)
        {
            this.Query = $@" UPDATE [PlanoAmostralTeste] SET [PAT_PERCENT_ESPECIF] = @PAT_PERCENT_ESPECIF WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                PAT_PERCENT_ESPECIF = value,
                PAT_ID = pat_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePlanoAmostralTesteQuery(IPlanoAmostralTesteEntity PlanoAmostralTeste)
        {
            this.Query = $@" DELETE FROM [PlanoAmostralTeste] WHERE [PAT_ID] = @PAT_ID ";
            this.Parameters = new
            {
                PAT_ID = PlanoAmostralTeste.PAT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration