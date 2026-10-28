namespace Clinica.Atendimentos;

public sealed record ClinicaInicialInfo(int Id, string Nome, string Endereco, string Telefone, int TipoEstrutura);
public sealed record ProfissionalInicialInfo(int Id, string Nome, string Telefone, bool Vinculado);
public sealed record ServicoInicialInfo(int Id, string Nome, decimal Valor, int ModeloConsulta);
public sealed class ConfiguracaoOpcoes
{
    public IReadOnlyList<ClinicaInicialInfo> Clinicas {get;set;}=[];
    public IReadOnlyList<ProfissionalInicialInfo> Profissionais {get;set;}=[];
    public IReadOnlyList<ServicoInicialInfo> Servicos {get;set;}=[];
}
public sealed class EtapaConfiguracao
{
    public int SagaId {get;set;}
    public int SagaStepId {get;set;}
    public string CorrelationId {get;set;}="";
    public string StepCorrelationId {get;set;}="";
    public string StepKey {get;set;}="";
    public int Status {get;set;}
    public int SagaStatus {get;set;}
    public string CurrentKey {get;set;}="";
    public int InboxId {get;set;}
    public string InputHash {get;set;}="";
}
public sealed record ConfiguracaoAceita(bool Accepted, int SagaId, int SagaStepId, int InboxId, string CorrelationId, string StepKey);
