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
    public class TemplatesGrupoMaquinaQueryWrite : QueryBase, ITemplatesGrupoMaquinaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TemplatesGrupoMaquinaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTemplatesGrupoMaquinaQuery(ITemplatesGrupoMaquinaEntity TemplatesGrupoMaquina)
        {
            this.Query = $@" INSERT INTO [TemplatesGrupoMaquina] ([TEM_ID], [GMA_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@TEM_ID, @GMA_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TEM_ID = TemplatesGrupoMaquina.TEM_ID,
                GMA_ID = TemplatesGrupoMaquina.GMA_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplatesGrupoMaquinaQuery(ITemplatesGrupoMaquinaEntity TemplatesGrupoMaquina)
        {
            this.Query = $@" UPDATE [TemplatesGrupoMaquina] SET [TEM_ID] = @TEM_ID, [GMA_ID] = @GMA_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TEM_ID = TemplatesGrupoMaquina.TEM_ID,
                GMA_ID = TemplatesGrupoMaquina.GMA_ID,
                Changed = TemplatesGrupoMaquina.Changed,
                UserId = _executionContext.UserId,
                Id = TemplatesGrupoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(int id, int value)
        {
            this.Query = $@" UPDATE [TemplatesGrupoMaquina] SET [TEM_ID] = @TEM_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TEM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_ID(int id, string value)
        {
            this.Query = $@" UPDATE [TemplatesGrupoMaquina] SET [GMA_ID] = @GMA_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GMA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [TemplatesGrupoMaquina] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [TemplatesGrupoMaquina] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TemplatesGrupoMaquina] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [TemplatesGrupoMaquina] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTemplatesGrupoMaquinaQuery(ITemplatesGrupoMaquinaEntity TemplatesGrupoMaquina)
        {
            this.Query = $@" DELETE FROM [TemplatesGrupoMaquina] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = TemplatesGrupoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration