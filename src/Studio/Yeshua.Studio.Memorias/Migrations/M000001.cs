using Dominio;
using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000001)]
public class M000001 : MigrationBase
{
    public override void Up()
    {
        ConfigureSagaWorkers(loopMilliseconds: 500);

        AddModule("MEM", "Memorias");

        AddEntity("Foto", "Foto").AddModule("MEM")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("StorageKey", "Arquivo").Varchar(500).NotNull().Group("Arquivo")
            .AddColumn("NomeOriginal", "Nome Original").Varchar(300).NotNull().Group("Arquivo")
            .AddColumn("ContentType", "Tipo do Arquivo").Varchar(100).NotNull().Group("Arquivo")
            .AddColumn("HashArquivo", "Hash").Varchar(100).Group("Arquivo")
            .AddColumn("CapturadaEmUtc", "Capturada em UTC").DateTime().Group("Imagem")
            .AddColumn("Largura", "Largura").Int().Group("Imagem")
            .AddColumn("Altura", "Altura").Int().Group("Imagem")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebida")
                .Enumerable(2, "Disponivel")
                .Enumerable(3, "Invalida");

        AddEntity("Album", "Album").AddModule("MEM")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("Titulo", "Titulo").Varchar(200).NotNull().Group("Identificacao")
            .AddColumn("Descricao", "Descricao").Varchar(2000).Group("Identificacao")
            .AddColumn("Privacidade", "Privacidade no YouTube").Int().NotNull().Group("Publicacao")
                .Enumerable(1, "Privado")
                .Enumerable(2, "Nao Listado")
                .Enumerable(3, "Publico")
            .AddColumn("SegundosPorFoto", "Segundos por Foto").Int().NotNull().Group("Renderizacao")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Em Edicao")
                .Enumerable(2, "Pronto Para Publicar")
                .Enumerable(3, "Publicando")
                .Enumerable(4, "Publicado")
                .Enumerable(5, "Falha");

        AddEntity("AlbumFoto", "Foto do Album").AddModule("MEM")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("AlbumId", "Album").FK("Album", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("FotoId", "Foto").FK("Foto", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("Ordem", "Ordem").Int().NotNull().Group("Apresentacao")
            .AddColumn("Legenda", "Legenda").Varchar(500).Group("Apresentacao");

        AddEntity("PublicacaoAlbum", "Publicacao do Album").AddModule("MEM")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("AlbumId", "Album").FK("Album", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Processamento")
            .AddColumn("ManifestStorageKey", "Manifesto de Renderizacao").Varchar(500).Group("Renderizacao")
            .AddColumn("VideoStorageKey", "Video Renderizado").Varchar(500).Group("Renderizacao")
            .AddColumn("YouTubeVideoId", "Video no YouTube").Varchar(100).Group("YouTube")
            .AddColumn("YouTubeUrl", "URL no YouTube").Varchar(500).Group("YouTube")
            .AddColumn("Mensagem", "Mensagem").Varchar(2000).Group("Status")
            .AddColumn("SolicitadaEmUtc", "Solicitada em UTC").DateTime().NotNull().Group("Datas")
            .AddColumn("PublicadaEmUtc", "Publicada em UTC").DateTime().Group("Datas")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Solicitada")
                .Enumerable(2, "Preparando Manifesto")
                .Enumerable(3, "Renderizando")
                .Enumerable(4, "Enviando ao YouTube")
                .Enumerable(5, "Publicada")
                .Enumerable(6, "Falha");

        AddUsecaseGroup("Memorias")
            .AddUseCaseSubGrup("Albuns")
            .AddCommand(
                "SolicitarPublicacaoAlbum",
                new SolicitarPublicacaoAlbumInput(0),
                new SolicitarPublicacaoAlbumOutput(0, string.Empty, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("memorias.album.publicar")
            .AddEntity("Album");

        AddUsecaseGroup("Memorias")
            .AddUseCaseSubGrup("Publicacao")
            .AddSaga("PublicarAlbumYouTube")
            .AddStepGroup("preparacao")
                .AddStep("prepararManifestoAlbum")
            .AddStepGroup("renderizacao")
                .AddStepWait("renderizarVideoAlbum")
                    .AddOutBoxPollingWorker(
                        "media.tasks",
                        ExchangeType.topic,
                        "media.album.render.outbox",
                        "media.album.render")
                    .AddInboxListenerWorker(
                        "media.results",
                        ExchangeType.topic,
                        "media.album.rendered.inbox",
                        "media.album.rendered")
            .AddStepGroup("youtube")
                .AddStep("enviarVideoParaYouTube")
            .AddStepGroup("finalizacao")
                .AddStep("finalizarPublicacaoAlbum");

        AddMenuGroup("MEM", "Albuns", "Album", "AlbumFoto");
        AddMenuGroup("MEM", "Fotos", "Foto");
        AddMenuGroup("MEM", "Publicacoes", "PublicacaoAlbum");
    }
}

public sealed record SolicitarPublicacaoAlbumInput(int AlbumId);

public sealed record SolicitarPublicacaoAlbumOutput(
    int PublicacaoAlbumId,
    string CorrelationId,
    string Status);
