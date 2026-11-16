namespace Clinica.Atendimentos;

public sealed record PedidoRecorrencia(int PacienteId, int ServicoId, int ModeloConsulta, int VersaoModeloConsulta,
    string DataInicio, string DataFim, int IntervaloDias, string DataFinal, int SessaoId, bool SerieFutura);
public sealed record EscolhaRecorrencia(int Ordem, string DataInicio, string DataFim, bool Agendar);
public sealed record OcorrenciaRecorrencia(int Ordem, int SessaoId, string DataInicio, string DataFim, bool Agendar, bool Conflito);
public sealed record ResultadoRecorrencia(string PlanoId, bool Confirmado, List<OcorrenciaRecorrencia> Ocorrencias);
public sealed class PlanoConsultas
{
    public string Id { get; set; } = "";
    public string SerieId { get; set; } = "";
    public int ProfissionalId { get; set; }
    public PedidoRecorrencia Pedido { get; set; } = null!;
    public List<SessaoRecorrencia> Originais { get; set; } = [];
    public List<OcorrenciaRecorrencia> Ocorrencias { get; set; } = [];
}
// Deliberately excludes clinical content.
public sealed class SessaoRecorrencia
{
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public int Versao { get; set; }
    public string RecorrenciaId { get; set; } = "";
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
