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
    public class PerfilObjetoControlavelQueryWrite : QueryBase, IPerfilObjetoControlavelQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PerfilObjetoControlavelQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPerfilObjetoControlavelQuery(IPerfilObjetoControlavelEntity PerfilObjetoControlavel)
        {
            this.Query = $@" INSERT INTO [PerfilObjetoControlavel] ([PER_ID], [OBJ_ID], [PEO_ACAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@PER_ID, @OBJ_ID, @PEO_ACAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PER_ID = PerfilObjetoControlavel.PER_ID,
                OBJ_ID = PerfilObjetoControlavel.OBJ_ID,
                PEO_ACAO = PerfilObjetoControlavel.PEO_ACAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilObjetoControlavelQuery(IPerfilObjetoControlavelEntity PerfilObjetoControlavel)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [PER_ID] = @PER_ID, [OBJ_ID] = @OBJ_ID, [PEO_ACAO] = @PEO_ACAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PER_ID = PerfilObjetoControlavel.PER_ID,
                OBJ_ID = PerfilObjetoControlavel.OBJ_ID,
                PEO_ACAO = PerfilObjetoControlavel.PEO_ACAO,
                Changed = PerfilObjetoControlavel.Changed,
                UserId = _executionContext.UserId,
                Id = PerfilObjetoControlavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int id, int value)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [PER_ID] = @PER_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBJ_ID(int id, string value)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [OBJ_ID] = @OBJ_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OBJ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePEO_ACAO(int id, string value)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [PEO_ACAO] = @PEO_ACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PEO_ACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [PerfilObjetoControlavel] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePerfilObjetoControlavelQuery(IPerfilObjetoControlavelEntity PerfilObjetoControlavel)
        {
            this.Query = $@" DELETE FROM [PerfilObjetoControlavel] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = PerfilObjetoControlavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration