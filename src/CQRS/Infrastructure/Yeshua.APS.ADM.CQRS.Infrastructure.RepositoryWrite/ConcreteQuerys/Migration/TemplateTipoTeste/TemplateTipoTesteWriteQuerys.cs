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
    public class TemplateTipoTesteQueryWrite : QueryBase, ITemplateTipoTesteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TemplateTipoTesteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTemplateTipoTesteQuery(ITemplateTipoTesteEntity TemplateTipoTeste)
        {
            this.Query = $@" INSERT INTO [TemplateTipoTeste] ([TT_ID], [TEM_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[TTT_ID] VALUES(@TT_ID, @TEM_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TT_ID = TemplateTipoTeste.TT_ID,
                TEM_ID = TemplateTipoTeste.TEM_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplateTipoTesteQuery(ITemplateTipoTesteEntity TemplateTipoTeste)
        {
            this.Query = $@" UPDATE [TemplateTipoTeste] SET [TT_ID] = @TT_ID, [TEM_ID] = @TEM_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                TT_ID = TemplateTipoTeste.TT_ID,
                TEM_ID = TemplateTipoTeste.TEM_ID,
                Changed = TemplateTipoTeste.Changed,
                UserId = _executionContext.UserId,
                TTT_ID = TemplateTipoTeste.TTT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_ID(int ttt_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoTeste] SET [TT_ID] = @TT_ID WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                TT_ID = value,
                TTT_ID = ttt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(int ttt_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoTeste] SET [TEM_ID] = @TEM_ID WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                TEM_ID = value,
                TTT_ID = ttt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int ttt_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoTeste] SET [TenantID] = @TenantID WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TTT_ID = ttt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int ttt_id, bool value)
        {
            this.Query = $@" UPDATE [TemplateTipoTeste] SET [Deleted] = @Deleted WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TTT_ID = ttt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int ttt_id, DateTime value)
        {
            this.Query = $@" UPDATE [TemplateTipoTeste] SET [Changed] = @Changed WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                Changed = value,
                TTT_ID = ttt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int ttt_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoTeste] SET [UserId] = @UserId WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                UserId = value,
                TTT_ID = ttt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTemplateTipoTesteQuery(ITemplateTipoTesteEntity TemplateTipoTeste)
        {
            this.Query = $@" DELETE FROM [TemplateTipoTeste] WHERE [TTT_ID] = @TTT_ID ";
            this.Parameters = new
            {
                TTT_ID = TemplateTipoTeste.TTT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration