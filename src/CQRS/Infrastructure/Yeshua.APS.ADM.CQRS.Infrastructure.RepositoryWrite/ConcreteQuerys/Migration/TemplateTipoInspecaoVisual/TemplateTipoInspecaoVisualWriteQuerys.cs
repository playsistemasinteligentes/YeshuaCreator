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
    public class TemplateTipoInspecaoVisualQueryWrite : QueryBase, ITemplateTipoInspecaoVisualQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TemplateTipoInspecaoVisualQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTemplateTipoInspecaoVisualQuery(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual)
        {
            this.Query = $@" INSERT INTO [TemplateTipoInspecaoVisual] ([TIV_ID], [TEM_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[TTI_ID] VALUES(@TIV_ID, @TEM_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TIV_ID = TemplateTipoInspecaoVisual.TIV_ID,
                TEM_ID = TemplateTipoInspecaoVisual.TEM_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplateTipoInspecaoVisualQuery(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual)
        {
            this.Query = $@" UPDATE [TemplateTipoInspecaoVisual] SET [TIV_ID] = @TIV_ID, [TEM_ID] = @TEM_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                TIV_ID = TemplateTipoInspecaoVisual.TIV_ID,
                TEM_ID = TemplateTipoInspecaoVisual.TEM_ID,
                Changed = TemplateTipoInspecaoVisual.Changed,
                UserId = _executionContext.UserId,
                TTI_ID = TemplateTipoInspecaoVisual.TTI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_ID(int tti_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoInspecaoVisual] SET [TIV_ID] = @TIV_ID WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                TIV_ID = value,
                TTI_ID = tti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(int tti_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoInspecaoVisual] SET [TEM_ID] = @TEM_ID WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                TEM_ID = value,
                TTI_ID = tti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int tti_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoInspecaoVisual] SET [TenantID] = @TenantID WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TTI_ID = tti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int tti_id, bool value)
        {
            this.Query = $@" UPDATE [TemplateTipoInspecaoVisual] SET [Deleted] = @Deleted WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TTI_ID = tti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int tti_id, DateTime value)
        {
            this.Query = $@" UPDATE [TemplateTipoInspecaoVisual] SET [Changed] = @Changed WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                Changed = value,
                TTI_ID = tti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int tti_id, int value)
        {
            this.Query = $@" UPDATE [TemplateTipoInspecaoVisual] SET [UserId] = @UserId WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                UserId = value,
                TTI_ID = tti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTemplateTipoInspecaoVisualQuery(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual)
        {
            this.Query = $@" DELETE FROM [TemplateTipoInspecaoVisual] WHERE [TTI_ID] = @TTI_ID ";
            this.Parameters = new
            {
                TTI_ID = TemplateTipoInspecaoVisual.TTI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration