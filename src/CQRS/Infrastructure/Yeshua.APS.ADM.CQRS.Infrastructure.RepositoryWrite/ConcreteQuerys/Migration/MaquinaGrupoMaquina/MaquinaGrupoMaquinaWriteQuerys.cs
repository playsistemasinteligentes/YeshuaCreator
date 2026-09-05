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
    public class MaquinaGrupoMaquinaQueryWrite : QueryBase, IMaquinaGrupoMaquinaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MaquinaGrupoMaquinaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMaquinaGrupoMaquinaQuery(IMaquinaGrupoMaquinaEntity MaquinaGrupoMaquina)
        {
            this.Query = $@" INSERT INTO [MaquinaGrupoMaquina] ([GMA_ID], [MAQ_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@GMA_ID, @MAQ_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GMA_ID = MaquinaGrupoMaquina.GMA_ID,
                MAQ_ID = MaquinaGrupoMaquina.MAQ_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaGrupoMaquinaQuery(IMaquinaGrupoMaquinaEntity MaquinaGrupoMaquina)
        {
            this.Query = $@" UPDATE [MaquinaGrupoMaquina] SET [GMA_ID] = @GMA_ID, [MAQ_ID] = @MAQ_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GMA_ID = MaquinaGrupoMaquina.GMA_ID,
                MAQ_ID = MaquinaGrupoMaquina.MAQ_ID,
                Changed = MaquinaGrupoMaquina.Changed,
                UserId = _executionContext.UserId,
                Id = MaquinaGrupoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_ID(int id, string value)
        {
            this.Query = $@" UPDATE [MaquinaGrupoMaquina] SET [GMA_ID] = @GMA_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GMA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE [MaquinaGrupoMaquina] SET [MAQ_ID] = @MAQ_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MaquinaGrupoMaquina] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MaquinaGrupoMaquina] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MaquinaGrupoMaquina] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MaquinaGrupoMaquina] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMaquinaGrupoMaquinaQuery(IMaquinaGrupoMaquinaEntity MaquinaGrupoMaquina)
        {
            this.Query = $@" DELETE FROM [MaquinaGrupoMaquina] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MaquinaGrupoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration