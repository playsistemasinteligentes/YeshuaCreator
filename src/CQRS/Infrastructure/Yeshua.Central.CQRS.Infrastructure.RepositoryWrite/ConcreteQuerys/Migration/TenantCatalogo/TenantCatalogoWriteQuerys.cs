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
    public class TenantCatalogoQueryWrite : QueryBase, ITenantCatalogoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TenantCatalogoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTenantCatalogoQuery(ITenantCatalogoEntity TenantCatalogo)
        {
            this.Query = $@" INSERT INTO [TenantCatalogo] ([Catalogo], [TenantID], [ValidUntil], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@Catalogo, @TenantID, @ValidUntil, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Catalogo = TenantCatalogo.Catalogo,
                TenantID = _executionContext.TenantID,
                ValidUntil = TenantCatalogo.ValidUntil,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantCatalogoQuery(ITenantCatalogoEntity TenantCatalogo)
        {
            this.Query = $@" UPDATE [TenantCatalogo] SET [Catalogo] = @Catalogo, [ValidUntil] = @ValidUntil, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Catalogo = TenantCatalogo.Catalogo,
                ValidUntil = TenantCatalogo.ValidUntil,
                Changed = TenantCatalogo.Changed,
                UserId = _executionContext.UserId,
                Id = TenantCatalogo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCatalogo(int id, string value)
        {
            this.Query = $@" UPDATE [TenantCatalogo] SET [Catalogo] = @Catalogo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Catalogo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [TenantCatalogo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TenantCatalogo] SET [ValidUntil] = @ValidUntil WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [TenantCatalogo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TenantCatalogo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [TenantCatalogo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTenantCatalogoQuery(ITenantCatalogoEntity TenantCatalogo)
        {
            this.Query = $@" DELETE FROM [TenantCatalogo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = TenantCatalogo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration