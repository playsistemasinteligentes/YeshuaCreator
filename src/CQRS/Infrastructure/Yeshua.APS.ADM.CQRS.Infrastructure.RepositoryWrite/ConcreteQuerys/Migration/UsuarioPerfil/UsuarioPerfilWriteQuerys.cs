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
    public class UsuarioPerfilQueryWrite : QueryBase, IUsuarioPerfilQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public UsuarioPerfilQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUsuarioPerfilQuery(IUsuarioPerfilEntity UsuarioPerfil)
        {
            this.Query = $@" INSERT INTO [UsuarioPerfil] ([USE_ID], [PER_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@USE_ID, @PER_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                USE_ID = UsuarioPerfil.USE_ID,
                PER_ID = UsuarioPerfil.PER_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUsuarioPerfilQuery(IUsuarioPerfilEntity UsuarioPerfil)
        {
            this.Query = $@" UPDATE [UsuarioPerfil] SET [USE_ID] = @USE_ID, [PER_ID] = @PER_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USE_ID = UsuarioPerfil.USE_ID,
                PER_ID = UsuarioPerfil.PER_ID,
                Changed = UsuarioPerfil.Changed,
                UserId = _executionContext.UserId,
                Id = UsuarioPerfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int id, int value)
        {
            this.Query = $@" UPDATE [UsuarioPerfil] SET [USE_ID] = @USE_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int id, int value)
        {
            this.Query = $@" UPDATE [UsuarioPerfil] SET [PER_ID] = @PER_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [UsuarioPerfil] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [UsuarioPerfil] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [UsuarioPerfil] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [UsuarioPerfil] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUsuarioPerfilQuery(IUsuarioPerfilEntity UsuarioPerfil)
        {
            this.Query = $@" DELETE FROM [UsuarioPerfil] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = UsuarioPerfil.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration