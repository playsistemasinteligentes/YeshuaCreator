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
    public class AlbumFotoQueryWrite : QueryBase, IAlbumFotoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public AlbumFotoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirAlbumFotoQuery(IAlbumFotoEntity AlbumFoto)
        {
            this.Query = $@" INSERT INTO [AlbumFoto] ([AlbumId], [FotoId], [Ordem], [Legenda], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@AlbumId, @FotoId, @Ordem, @Legenda, @OperationalEntityId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                AlbumId = AlbumFoto.AlbumId,
                FotoId = AlbumFoto.FotoId,
                Ordem = AlbumFoto.Ordem,
                Legenda = AlbumFoto.Legenda,
                OperationalEntityId = AlbumFoto.OperationalEntityId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAlbumFotoQuery(IAlbumFotoEntity AlbumFoto)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [AlbumId] = @AlbumId, [FotoId] = @FotoId, [Ordem] = @Ordem, [Legenda] = @Legenda, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AlbumId = AlbumFoto.AlbumId,
                FotoId = AlbumFoto.FotoId,
                Ordem = AlbumFoto.Ordem,
                Legenda = AlbumFoto.Legenda,
                Changed = AlbumFoto.Changed,
                UserId = _executionContext.UserId,
                Id = AlbumFoto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAlbumId(int id, int value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [AlbumId] = @AlbumId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AlbumId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFotoId(int id, int value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [FotoId] = @FotoId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FotoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrdem(int id, int value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [Ordem] = @Ordem WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ordem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLegenda(int id, string value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [Legenda] = @Legenda WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Legenda = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [AlbumFoto] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteAlbumFotoQuery(IAlbumFotoEntity AlbumFoto)
        {
            this.Query = $@" DELETE FROM [AlbumFoto] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = AlbumFoto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration