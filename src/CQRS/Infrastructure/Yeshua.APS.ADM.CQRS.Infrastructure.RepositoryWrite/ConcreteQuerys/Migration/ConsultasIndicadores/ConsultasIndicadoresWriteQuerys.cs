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
    public class ConsultasIndicadoresQueryWrite : QueryBase, IConsultasIndicadoresQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ConsultasIndicadoresQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirConsultasIndicadoresQuery(IConsultasIndicadoresEntity ConsultasIndicadores)
        {
            this.Query = $@" INSERT INTO [ConsultasIndicadores] ([CON_ID], [IND_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CON_ID, @IND_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CON_ID = ConsultasIndicadores.CON_ID,
                IND_ID = ConsultasIndicadores.IND_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConsultasIndicadoresQuery(IConsultasIndicadoresEntity ConsultasIndicadores)
        {
            this.Query = $@" UPDATE [ConsultasIndicadores] SET [CON_ID] = @CON_ID, [IND_ID] = @IND_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_ID = ConsultasIndicadores.CON_ID,
                IND_ID = ConsultasIndicadores.IND_ID,
                Changed = ConsultasIndicadores.Changed,
                UserId = _executionContext.UserId,
                Id = ConsultasIndicadores.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasIndicadores] SET [CON_ID] = @CON_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasIndicadores] SET [IND_ID] = @IND_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IND_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasIndicadores] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ConsultasIndicadores] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ConsultasIndicadores] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ConsultasIndicadores] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteConsultasIndicadoresQuery(IConsultasIndicadoresEntity ConsultasIndicadores)
        {
            this.Query = $@" DELETE FROM [ConsultasIndicadores] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ConsultasIndicadores.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration