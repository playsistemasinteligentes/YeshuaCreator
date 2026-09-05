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
    public class UsuarioObjetoControlavelQueryWrite : QueryBase, IUsuarioObjetoControlavelQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public UsuarioObjetoControlavelQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUsuarioObjetoControlavelQuery(IUsuarioObjetoControlavelEntity UsuarioObjetoControlavel)
        {
            this.Query = $@" INSERT INTO [UsuarioObjetoControlavel] ([USE_ID], [OBJ_ID], [USU_OBJETO_ACAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@USE_ID, @OBJ_ID, @USU_OBJETO_ACAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                USE_ID = UsuarioObjetoControlavel.USE_ID,
                OBJ_ID = UsuarioObjetoControlavel.OBJ_ID,
                USU_OBJETO_ACAO = UsuarioObjetoControlavel.USU_OBJETO_ACAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUsuarioObjetoControlavelQuery(IUsuarioObjetoControlavelEntity UsuarioObjetoControlavel)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [USE_ID] = @USE_ID, [OBJ_ID] = @OBJ_ID, [USU_OBJETO_ACAO] = @USU_OBJETO_ACAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USE_ID = UsuarioObjetoControlavel.USE_ID,
                OBJ_ID = UsuarioObjetoControlavel.OBJ_ID,
                USU_OBJETO_ACAO = UsuarioObjetoControlavel.USU_OBJETO_ACAO,
                Changed = UsuarioObjetoControlavel.Changed,
                UserId = _executionContext.UserId,
                Id = UsuarioObjetoControlavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int id, int value)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [USE_ID] = @USE_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBJ_ID(int id, string value)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [OBJ_ID] = @OBJ_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OBJ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSU_OBJETO_ACAO(int id, string value)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [USU_OBJETO_ACAO] = @USU_OBJETO_ACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USU_OBJETO_ACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [UsuarioObjetoControlavel] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUsuarioObjetoControlavelQuery(IUsuarioObjetoControlavelEntity UsuarioObjetoControlavel)
        {
            this.Query = $@" DELETE FROM [UsuarioObjetoControlavel] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = UsuarioObjetoControlavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration