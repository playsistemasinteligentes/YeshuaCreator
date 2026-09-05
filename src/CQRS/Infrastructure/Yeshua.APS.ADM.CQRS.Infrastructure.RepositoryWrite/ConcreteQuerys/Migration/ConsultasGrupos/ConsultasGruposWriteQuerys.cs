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
    public class ConsultasGruposQueryWrite : QueryBase, IConsultasGruposQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ConsultasGruposQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirConsultasGruposQuery(IConsultasGruposEntity ConsultasGrupos)
        {
            this.Query = $@" INSERT INTO [ConsultasGrupos] ([CON_ID], [GRU_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CON_ID, @GRU_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CON_ID = ConsultasGrupos.CON_ID,
                GRU_ID = ConsultasGrupos.GRU_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConsultasGruposQuery(IConsultasGruposEntity ConsultasGrupos)
        {
            this.Query = $@" UPDATE [ConsultasGrupos] SET [CON_ID] = @CON_ID, [GRU_ID] = @GRU_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_ID = ConsultasGrupos.CON_ID,
                GRU_ID = ConsultasGrupos.GRU_ID,
                Changed = ConsultasGrupos.Changed,
                UserId = _executionContext.UserId,
                Id = ConsultasGrupos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasGrupos] SET [CON_ID] = @CON_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRU_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasGrupos] SET [GRU_ID] = @GRU_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRU_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasGrupos] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ConsultasGrupos] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ConsultasGrupos] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasGrupos] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteConsultasGruposQuery(IConsultasGruposEntity ConsultasGrupos)
        {
            this.Query = $@" DELETE FROM [ConsultasGrupos] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ConsultasGrupos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration