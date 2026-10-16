// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
using System.Data.SqlTypes;
using Command.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Query.Read 
{
    public class PublicacaoAlbumQueryRead : QueryBase, IPublicacaoAlbumQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public PublicacaoAlbumQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel PublicacaoAlbumQuery(Command.Read.PublicacaoAlbumReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] from [PublicacaoAlbum] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.AlbumId.HasValue) dict["AlbumId"] = Command.AlbumId.Value;
if (Command.AlbumId.HasValue) whereClauses.Add($"[AlbumId] = @AlbumId");
if (!string.IsNullOrEmpty(Command.CorrelationId)) dict["CorrelationId"] = $"%{Command.CorrelationId}%";
if (!string.IsNullOrEmpty(Command.CorrelationId)) whereClauses.Add($"[CorrelationId] like @CorrelationId");
if (!string.IsNullOrEmpty(Command.ManifestStorageKey)) dict["ManifestStorageKey"] = $"%{Command.ManifestStorageKey}%";
if (!string.IsNullOrEmpty(Command.ManifestStorageKey)) whereClauses.Add($"[ManifestStorageKey] like @ManifestStorageKey");
if (!string.IsNullOrEmpty(Command.VideoStorageKey)) dict["VideoStorageKey"] = $"%{Command.VideoStorageKey}%";
if (!string.IsNullOrEmpty(Command.VideoStorageKey)) whereClauses.Add($"[VideoStorageKey] like @VideoStorageKey");
if (!string.IsNullOrEmpty(Command.YouTubeVideoId)) dict["YouTubeVideoId"] = $"%{Command.YouTubeVideoId}%";
if (!string.IsNullOrEmpty(Command.YouTubeVideoId)) whereClauses.Add($"[YouTubeVideoId] like @YouTubeVideoId");
if (!string.IsNullOrEmpty(Command.YouTubeUrl)) dict["YouTubeUrl"] = $"%{Command.YouTubeUrl}%";
if (!string.IsNullOrEmpty(Command.YouTubeUrl)) whereClauses.Add($"[YouTubeUrl] like @YouTubeUrl");
if (!string.IsNullOrEmpty(Command.ConexaoYouTubeId)) dict["ConexaoYouTubeId"] = $"%{Command.ConexaoYouTubeId}%";
if (!string.IsNullOrEmpty(Command.ConexaoYouTubeId)) whereClauses.Add($"[ConexaoYouTubeId] like @ConexaoYouTubeId");
if (!string.IsNullOrEmpty(Command.CanalYouTubeId)) dict["CanalYouTubeId"] = $"%{Command.CanalYouTubeId}%";
if (!string.IsNullOrEmpty(Command.CanalYouTubeId)) whereClauses.Add($"[CanalYouTubeId] like @CanalYouTubeId");
if (Command.YouTubeCredentialTenantId.HasValue) dict["YouTubeCredentialTenantId"] = Command.YouTubeCredentialTenantId.Value;
if (Command.YouTubeCredentialTenantId.HasValue) whereClauses.Add($"[YouTubeCredentialTenantId] = @YouTubeCredentialTenantId");
if (Command.CanalStandardId.HasValue) dict["CanalStandardId"] = Command.CanalStandardId.Value;
if (Command.CanalStandardId.HasValue) whereClauses.Add($"[CanalStandardId] = @CanalStandardId");
if (Command.PrivacidadeYouTube.HasValue) dict["PrivacidadeYouTube"] = Command.PrivacidadeYouTube.Value;
if (Command.PrivacidadeYouTube.HasValue) whereClauses.Add($"[PrivacidadeYouTube] = @PrivacidadeYouTube");
if (Command.QualidadeVideo.HasValue)
{
    dict["QualidadeVideo"] = Command.QualidadeVideo.Value;
    whereClauses.Add($"[QualidadeVideo] = @QualidadeVideo");
}
if (Command.ModeloVideo.HasValue)
{
    dict["ModeloVideo"] = Command.ModeloVideo.Value;
    whereClauses.Add($"[ModeloVideo] = @ModeloVideo");
}
if (Command.MusicaId.HasValue)
{
    dict["MusicaId"] = Command.MusicaId.Value;
    whereClauses.Add($"[MusicaId] = @MusicaId");
}
if (Command.VolumeMusica.HasValue) dict["VolumeMusica"] = Command.VolumeMusica.Value;
if (Command.VolumeMusica.HasValue) whereClauses.Add($"[VolumeMusica] = @VolumeMusica");
if (!string.IsNullOrEmpty(Command.Mensagem)) dict["Mensagem"] = $"%{Command.Mensagem}%";
if (!string.IsNullOrEmpty(Command.Mensagem)) whereClauses.Add($"[Mensagem] like @Mensagem");
if (Command.Status.HasValue)
{
    dict["Status"] = Command.Status.Value;
    whereClauses.Add($"[Status] = @Status");
}
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
if (!string.IsNullOrEmpty(Command.OperationalEntityId)) dict["OperationalEntityId"] = $"%{Command.OperationalEntityId}%";
if (!string.IsNullOrEmpty(Command.OperationalEntityId)) whereClauses.Add($"[OperationalEntityId] like @OperationalEntityId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel PublicacaoAlbumAlbumIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Descricao] from [Album] ";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Descricao] like @Descricao ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel PublicacaoAlbumTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yTenant] ";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel PublicacaoAlbumUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yUser] ";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" [Id] = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAlbumIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AlbumId"] = value; //04
                      whereClauses.Add($" [AlbumId] = @AlbumId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CorrelationId"] = value; //04
                      whereClauses.Add($" [CorrelationId] = @CorrelationId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByManifestStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ManifestStorageKey"] = value; //04
                      whereClauses.Add($" [ManifestStorageKey] = @ManifestStorageKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVideoStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VideoStorageKey"] = value; //04
                      whereClauses.Add($" [VideoStorageKey] = @VideoStorageKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByYouTubeVideoIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["YouTubeVideoId"] = value; //04
                      whereClauses.Add($" [YouTubeVideoId] = @YouTubeVideoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByYouTubeUrlQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["YouTubeUrl"] = value; //04
                      whereClauses.Add($" [YouTubeUrl] = @YouTubeUrl ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByConexaoYouTubeIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ConexaoYouTubeId"] = value; //04
                      whereClauses.Add($" [ConexaoYouTubeId] = @ConexaoYouTubeId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCanalYouTubeIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CanalYouTubeId"] = value; //04
                      whereClauses.Add($" [CanalYouTubeId] = @CanalYouTubeId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByYouTubeCredentialTenantIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["YouTubeCredentialTenantId"] = value; //04
                      whereClauses.Add($" [YouTubeCredentialTenantId] = @YouTubeCredentialTenantId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCanalStandardIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CanalStandardId"] = value; //04
                      whereClauses.Add($" [CanalStandardId] = @CanalStandardId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPrivacidadeYouTubeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PrivacidadeYouTube"] = value; //04
                      whereClauses.Add($" [PrivacidadeYouTube] = @PrivacidadeYouTube ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQualidadeVideoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QualidadeVideo"] = value; //04
                      whereClauses.Add($" [QualidadeVideo] = @QualidadeVideo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByModeloVideoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ModeloVideo"] = value; //04
                      whereClauses.Add($" [ModeloVideo] = @ModeloVideo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMusicaIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MusicaId"] = value; //04
                      whereClauses.Add($" [MusicaId] = @MusicaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVolumeMusicaQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VolumeMusica"] = value; //04
                      whereClauses.Add($" [VolumeMusica] = @VolumeMusica ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMensagemQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Mensagem"] = value; //04
                      whereClauses.Add($" [Mensagem] = @Mensagem ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySolicitadaEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SolicitadaEmUtc"] = value; //04
                      whereClauses.Add($" [SolicitadaEmUtc] = @SolicitadaEmUtc ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPublicadaEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PublicadaEmUtc"] = value; //04
                      whereClauses.Add($" [PublicadaEmUtc] = @PublicadaEmUtc ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //04
                      whereClauses.Add($" [Status] = @Status ");//04
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" [TenantID] = @TenantID ");//04
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" [Deleted] = @Deleted ");//04
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" [Changed] = @Changed ");//04
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" [UserId] = @UserId ");//04
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOperationalEntityIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OperationalEntityId"] = value; //04
                      whereClauses.Add($" [OperationalEntityId] = @OperationalEntityId ");//04
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" [Id] = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAlbumIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AlbumId"] = value; //06
                      whereClauses.Add($" [AlbumId] = @AlbumId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CorrelationId"] = value; //06
                      whereClauses.Add($" [CorrelationId] = @CorrelationId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByManifestStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ManifestStorageKey"] = value; //06
                      whereClauses.Add($" [ManifestStorageKey] = @ManifestStorageKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVideoStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VideoStorageKey"] = value; //06
                      whereClauses.Add($" [VideoStorageKey] = @VideoStorageKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByYouTubeVideoIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["YouTubeVideoId"] = value; //06
                      whereClauses.Add($" [YouTubeVideoId] = @YouTubeVideoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByYouTubeUrlQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["YouTubeUrl"] = value; //06
                      whereClauses.Add($" [YouTubeUrl] = @YouTubeUrl ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByConexaoYouTubeIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ConexaoYouTubeId"] = value; //06
                      whereClauses.Add($" [ConexaoYouTubeId] = @ConexaoYouTubeId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCanalYouTubeIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CanalYouTubeId"] = value; //06
                      whereClauses.Add($" [CanalYouTubeId] = @CanalYouTubeId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByYouTubeCredentialTenantIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["YouTubeCredentialTenantId"] = value; //06
                      whereClauses.Add($" [YouTubeCredentialTenantId] = @YouTubeCredentialTenantId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCanalStandardIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CanalStandardId"] = value; //06
                      whereClauses.Add($" [CanalStandardId] = @CanalStandardId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPrivacidadeYouTubeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PrivacidadeYouTube"] = value; //06
                      whereClauses.Add($" [PrivacidadeYouTube] = @PrivacidadeYouTube ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQualidadeVideoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QualidadeVideo"] = value; //06
                      whereClauses.Add($" [QualidadeVideo] = @QualidadeVideo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByModeloVideoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ModeloVideo"] = value; //06
                      whereClauses.Add($" [ModeloVideo] = @ModeloVideo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMusicaIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MusicaId"] = value; //06
                      whereClauses.Add($" [MusicaId] = @MusicaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVolumeMusicaQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VolumeMusica"] = value; //06
                      whereClauses.Add($" [VolumeMusica] = @VolumeMusica ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMensagemQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Mensagem"] = value; //06
                      whereClauses.Add($" [Mensagem] = @Mensagem ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySolicitadaEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SolicitadaEmUtc"] = value; //06
                      whereClauses.Add($" [SolicitadaEmUtc] = @SolicitadaEmUtc ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPublicadaEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PublicadaEmUtc"] = value; //06
                      whereClauses.Add($" [PublicadaEmUtc] = @PublicadaEmUtc ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //06
                      whereClauses.Add($" [Status] = @Status ");//06
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" [TenantID] = @TenantID ");//06
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" [Deleted] = @Deleted ");//06
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" [Changed] = @Changed ");//06
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" [UserId] = @UserId ");//06
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOperationalEntityIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AlbumId], [CorrelationId], [ManifestStorageKey], [VideoStorageKey], [YouTubeVideoId], [YouTubeUrl], [ConexaoYouTubeId], [CanalYouTubeId], [YouTubeCredentialTenantId], [CanalStandardId], [PrivacidadeYouTube], [QualidadeVideo], [ModeloVideo], [MusicaId], [VolumeMusica], [Mensagem], [SolicitadaEmUtc], [PublicadaEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId] FROM [PublicacaoAlbum] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OperationalEntityId"] = value; //06
                      whereClauses.Add($" [OperationalEntityId] = @OperationalEntityId ");//06
            if (whereClauses.Any())
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})";
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration