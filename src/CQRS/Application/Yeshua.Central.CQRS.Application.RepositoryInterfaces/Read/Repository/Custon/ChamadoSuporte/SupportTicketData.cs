namespace IRepository.Read;

public sealed class SupportTicketData
{
    public string Id { get; set; } = "";
    public string Aplicativo { get; set; } = "";
    public string Modulo { get; set; } = "";
    public string Tela { get; set; } = "";
    public string TituloTela { get; set; } = "";
    public string Rota { get; set; } = "";
    public string Caminho { get; set; } = "";
    public string Versao { get; set; } = "";
    public string FusoHorario { get; set; } = "";
    public string MomentoClienteUtc { get; set; } = "";
    public string Assunto { get; set; } = "";
    public string Descricao { get; set; } = "";
    public int Status { get; set; }
    public int? UploadId { get; set; }
    public int? UploadStatus { get; set; }
    public int? SagaId { get; set; }
    public int? SagaStatus { get; set; }
    public int? StepStatus { get; set; }
    public string? TranscriptPayload { get; set; }
}

public partial interface IChamadoSuporteReadRepository
{
    SupportTicketData? BuscarDoUsuario(string id);
}
