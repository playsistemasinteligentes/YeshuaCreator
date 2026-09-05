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
    public class VariavelPlotagemQueryWrite : QueryBase, IVariavelPlotagemQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public VariavelPlotagemQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirVariavelPlotagemQuery(IVariavelPlotagemEntity VariavelPlotagem)
        {
            this.Query = $@" INSERT INTO [VariavelPlotagem] ([VAR_ID], [PLO_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@VAR_ID, @PLO_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                VAR_ID = VariavelPlotagem.VAR_ID,
                PLO_ID = VariavelPlotagem.PLO_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVariavelPlotagemQuery(IVariavelPlotagemEntity VariavelPlotagem)
        {
            this.Query = $@" UPDATE [VariavelPlotagem] SET [VAR_ID] = @VAR_ID, [PLO_ID] = @PLO_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VAR_ID = VariavelPlotagem.VAR_ID,
                PLO_ID = VariavelPlotagem.PLO_ID,
                Changed = VariavelPlotagem.Changed,
                UserId = _executionContext.UserId,
                Id = VariavelPlotagem.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVAR_ID(int id, int value)
        {
            this.Query = $@" UPDATE [VariavelPlotagem] SET [VAR_ID] = @VAR_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_ID(int id, int value)
        {
            this.Query = $@" UPDATE [VariavelPlotagem] SET [PLO_ID] = @PLO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PLO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [VariavelPlotagem] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [VariavelPlotagem] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [VariavelPlotagem] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [VariavelPlotagem] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteVariavelPlotagemQuery(IVariavelPlotagemEntity VariavelPlotagem)
        {
            this.Query = $@" DELETE FROM [VariavelPlotagem] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = VariavelPlotagem.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration