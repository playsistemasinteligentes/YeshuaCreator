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
    public class UsuariosCargaQueryWrite : QueryBase, IUsuariosCargaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public UsuariosCargaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUsuariosCargaQuery(IUsuariosCargaEntity UsuariosCarga)
        {
            this.Query = $@" INSERT INTO [UsuariosCarga] ([USE_ID], [CAR_ID], [RGO_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@USE_ID, @CAR_ID, @RGO_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                USE_ID = UsuariosCarga.USE_ID,
                CAR_ID = UsuariosCarga.CAR_ID,
                RGO_ID = UsuariosCarga.RGO_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUsuariosCargaQuery(IUsuariosCargaEntity UsuariosCarga)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [USE_ID] = @USE_ID, [CAR_ID] = @CAR_ID, [RGO_ID] = @RGO_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USE_ID = UsuariosCarga.USE_ID,
                CAR_ID = UsuariosCarga.CAR_ID,
                RGO_ID = UsuariosCarga.RGO_ID,
                Changed = UsuariosCarga.Changed,
                UserId = _executionContext.UserId,
                Id = UsuariosCarga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int id, int value)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [USE_ID] = @USE_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int id, string value)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [CAR_ID] = @CAR_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRGO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [RGO_ID] = @RGO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RGO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [UsuariosCarga] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUsuariosCargaQuery(IUsuariosCargaEntity UsuariosCarga)
        {
            this.Query = $@" DELETE FROM [UsuariosCarga] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = UsuariosCarga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration