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
    public class IndicadoresDepartamentosQueryWrite : QueryBase, IIndicadoresDepartamentosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public IndicadoresDepartamentosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirIndicadoresDepartamentosQuery(IIndicadoresDepartamentosEntity IndicadoresDepartamentos)
        {
            this.Query = $@" INSERT INTO [IndicadoresDepartamentos] ([DEP_ID], [IND_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[INDDEP_ID] VALUES(@DEP_ID, @IND_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DEP_ID = IndicadoresDepartamentos.DEP_ID,
                IND_ID = IndicadoresDepartamentos.IND_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIndicadoresDepartamentosQuery(IIndicadoresDepartamentosEntity IndicadoresDepartamentos)
        {
            this.Query = $@" UPDATE [IndicadoresDepartamentos] SET [DEP_ID] = @DEP_ID, [IND_ID] = @IND_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                DEP_ID = IndicadoresDepartamentos.DEP_ID,
                IND_ID = IndicadoresDepartamentos.IND_ID,
                Changed = IndicadoresDepartamentos.Changed,
                UserId = _executionContext.UserId,
                INDDEP_ID = IndicadoresDepartamentos.INDDEP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDEP_ID(int inddep_id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDepartamentos] SET [DEP_ID] = @DEP_ID WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                DEP_ID = value,
                INDDEP_ID = inddep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int inddep_id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDepartamentos] SET [IND_ID] = @IND_ID WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                IND_ID = value,
                INDDEP_ID = inddep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int inddep_id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDepartamentos] SET [TenantID] = @TenantID WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                TenantID = value,
                INDDEP_ID = inddep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int inddep_id, bool value)
        {
            this.Query = $@" UPDATE [IndicadoresDepartamentos] SET [Deleted] = @Deleted WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                Deleted = value,
                INDDEP_ID = inddep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int inddep_id, DateTime value)
        {
            this.Query = $@" UPDATE [IndicadoresDepartamentos] SET [Changed] = @Changed WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                Changed = value,
                INDDEP_ID = inddep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int inddep_id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDepartamentos] SET [UserId] = @UserId WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                UserId = value,
                INDDEP_ID = inddep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteIndicadoresDepartamentosQuery(IIndicadoresDepartamentosEntity IndicadoresDepartamentos)
        {
            this.Query = $@" DELETE FROM [IndicadoresDepartamentos] WHERE [INDDEP_ID] = @INDDEP_ID ";
            this.Parameters = new
            {
                INDDEP_ID = IndicadoresDepartamentos.INDDEP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration