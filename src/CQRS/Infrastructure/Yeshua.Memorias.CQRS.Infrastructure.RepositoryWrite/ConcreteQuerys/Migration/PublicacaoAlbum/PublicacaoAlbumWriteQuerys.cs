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
    public class PublicacaoAlbumQueryWrite : QueryBase, IPublicacaoAlbumQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PublicacaoAlbumQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPublicacaoAlbumQuery(IPublicacaoAlbumEntity PublicacaoAlbum)
        {
            this.Query = $@" INSERT INTO [PublicacaoAlbum] ([AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@AlbumId, @CorrelationId, @ManifestStorageKey, @VideoStorageKey, @YouTubeVideoId, @YouTubeUrl, @Mensagem, @SolicitadaEmUtc, @PublicadaEmUtc, @Status, @OperationalEntityId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                AlbumId = PublicacaoAlbum.AlbumId,
                CorrelationId = PublicacaoAlbum.CorrelationId,
                ManifestStorageKey = PublicacaoAlbum.ManifestStorageKey,
                VideoStorageKey = PublicacaoAlbum.VideoStorageKey,
                YouTubeVideoId = PublicacaoAlbum.YouTubeVideoId,
                YouTubeUrl = PublicacaoAlbum.YouTubeUrl,
                Mensagem = PublicacaoAlbum.Mensagem,
                SolicitadaEmUtc = PublicacaoAlbum.SolicitadaEmUtc,
                PublicadaEmUtc = PublicacaoAlbum.PublicadaEmUtc,
                Status = PublicacaoAlbum.Status,
                OperationalEntityId = PublicacaoAlbum.OperationalEntityId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePublicacaoAlbumQuery(IPublicacaoAlbumEntity PublicacaoAlbum)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [AlbumId] = @AlbumId, [CorrelationId] = @CorrelationId, [ManifestStorageKey] = @ManifestStorageKey, [VideoStorageKey] = @VideoStorageKey, [YouTubeVideoId] = @YouTubeVideoId, [YouTubeUrl] = @YouTubeUrl, [Mensagem] = @Mensagem, [SolicitadaEmUtc] = @SolicitadaEmUtc, [PublicadaEmUtc] = @PublicadaEmUtc, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AlbumId = PublicacaoAlbum.AlbumId,
                CorrelationId = PublicacaoAlbum.CorrelationId,
                ManifestStorageKey = PublicacaoAlbum.ManifestStorageKey,
                VideoStorageKey = PublicacaoAlbum.VideoStorageKey,
                YouTubeVideoId = PublicacaoAlbum.YouTubeVideoId,
                YouTubeUrl = PublicacaoAlbum.YouTubeUrl,
                Mensagem = PublicacaoAlbum.Mensagem,
                SolicitadaEmUtc = PublicacaoAlbum.SolicitadaEmUtc,
                PublicadaEmUtc = PublicacaoAlbum.PublicadaEmUtc,
                Status = PublicacaoAlbum.Status,
                Changed = PublicacaoAlbum.Changed,
                UserId = _executionContext.UserId,
                Id = PublicacaoAlbum.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAlbumId(int id, int value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [AlbumId] = @AlbumId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AlbumId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateManifestStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [ManifestStorageKey] = @ManifestStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ManifestStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVideoStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [VideoStorageKey] = @VideoStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VideoStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYouTubeVideoId(int id, string value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [YouTubeVideoId] = @YouTubeVideoId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                YouTubeVideoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYouTubeUrl(int id, string value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [YouTubeUrl] = @YouTubeUrl WHERE [Id] = @Id ";
            this.Parameters = new
            {
                YouTubeUrl = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMensagem(int id, string value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [Mensagem] = @Mensagem WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Mensagem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSolicitadaEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [SolicitadaEmUtc] = @SolicitadaEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SolicitadaEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePublicadaEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [PublicadaEmUtc] = @PublicadaEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PublicadaEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [PublicacaoAlbum] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePublicacaoAlbumQuery(IPublicacaoAlbumEntity PublicacaoAlbum)
        {
            this.Query = $@" DELETE FROM [PublicacaoAlbum] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = PublicacaoAlbum.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration