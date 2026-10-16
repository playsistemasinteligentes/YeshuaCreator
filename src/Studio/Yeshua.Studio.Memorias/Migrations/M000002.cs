using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000002)]
public class M000002 : MigrationBase
{
    public override void Up()
    {
        var commands = AddUsecaseGroup("Memorias").AddUseCaseSubGrup("YouTube");
        commands.AddCommand("IniciarConexaoYouTube", new YouTubeInput(), new YouTubeConnectionOutput())
            .Authorization(Authorization.User).AddScope("memorias.youtube.conectar");
        commands.AddCommand("ConcluirConexaoYouTube", new YouTubeCallbackInput(), new YouTubeConnectionOutput())
            .Authorization(Authorization.User).AddScope("memorias.youtube.conectar");
        commands.AddCommand("ConsultarConexaoYouTube", new YouTubeInput(), new YouTubeConnectionOutput())
            .Authorization(Authorization.User).AddScope("memorias.youtube.consultar");
        commands.AddCommand("ListarConexoesYouTube", new YouTubeInput(), new YouTubeConnectionsOutput())
            .Authorization(Authorization.User).AddScope("memorias.youtube.consultar");
        commands.AddCommand("DesconectarYouTube", new YouTubeInput(), new YouTubeConnectionOutput())
            .Authorization(Authorization.User).AddScope("memorias.youtube.conectar");
        commands.AddCommand("RetomarPublicacaoYouTube", new RetomarPublicacaoYouTubeInput(), new RetomarPublicacaoYouTubeOutput())
            .Authorization(Authorization.User).AddScope("memorias.album.publicar");
    }
}

public sealed record YouTubeInput(string ConexaoId = "");
public sealed record YouTubeCallbackInput(string AuthorizationCode = "", string TokenState = "");
public sealed record YouTubeConnectionOutput(
    bool Configurado = false, bool Conectado = false, string CanalId = "",
    string CanalTitulo = "", string AuthorizationUrl = "", string Mensagem = "", string ConexaoId = "");
public sealed record RetomarPublicacaoYouTubeInput(int PublicacaoAlbumId = 0, string ConexaoYouTubeId = "");
public sealed record RetomarPublicacaoYouTubeOutput(bool Agendada = false);

public sealed class YouTubeConnectionsOutput
{
    public bool Configurado { get; set; }
    public bool PublicacaoAutomaticaDisponivel { get; set; }
    public List<YouTubeConnectionInfo> Conexoes { get; set; } = [];
}

public sealed record YouTubeConnectionInfo(string ConexaoId, string CanalId, string CanalTitulo, bool Conectado);
