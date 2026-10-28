using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace AppClinicas;

[Migration(000007)]
public sealed class M000007 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("Clinica").AddColumn("TipoEstrutura", "Estrutura da clínica").Int()
            .Enumerable(1, "Individual").Enumerable(2, "Equipe");
        var commands = AddUsecaseGroup("Clinica").AddUseCaseSubGrup("Configuracao");
        commands.AddCommand("AbrirConfiguracaoClinica", new AbrirConfiguracaoInput(), new ConfiguracaoClinicaOutput())
            .Authorization(Authorization.User).AddScope("clinica.atendimentos.configurar");
        commands.AddSaga("ConfiguracaoInicialClinica")
            .AddStepGroup("cadastrosIniciais")
            .AddStepWait("configurarEstabelecimento")
                .HttpApi("ConfirmarEstabelecimentoClinica", new EstabelecimentoInicialInput(), new ConfiguracaoAceitaOutput()).Immediate()
                .Authorization(Authorization.User).AddScope("clinica.atendimentos.configurar")
            .AddStepWait("vincularProfissionalInicial")
                .HttpApi("ConfirmarProfissionalClinica", new ProfissionalInicialInput(), new ConfiguracaoAceitaOutput()).Immediate()
                .Authorization(Authorization.User).AddScope("clinica.atendimentos.configurar")
            .AddStepWait("definirServicoInicial")
                .HttpApi("ConfirmarServicoClinica", new ServicoInicialInput(), new ConfiguracaoAceitaOutput()).Immediate()
                .Authorization(Authorization.User).AddScope("clinica.atendimentos.configurar");
    }
}

public sealed record AbrirConfiguracaoInput();
public sealed record EstabelecimentoInicialInput(int SagaId=0, int SagaStepId=0, int ClinicaId=0, string Nome="", string Endereco="", string Telefone="", int TipoEstrutura=1);
public sealed record ProfissionalInicialInput(int SagaId=0, int SagaStepId=0, int ProfissionalId=0, string Nome="", string Telefone="");
public sealed record ServicoInicialInput(int SagaId=0, int SagaStepId=0, int ServicoId=0, string Nome="", decimal Valor=0, int ModeloConsulta=1);
public sealed record ConfiguracaoAceitaOutput(bool Accepted=false, int SagaId=0, int SagaStepId=0, int InboxId=0, string CorrelationId="", string StepKey="");
public sealed record ClinicaInicialInfo(int Id=0, string Nome="", string Endereco="", string Telefone="", int TipoEstrutura=1);
public sealed record ProfissionalInicialInfo(int Id=0, string Nome="", string Telefone="", bool Vinculado=false);
public sealed record ServicoInicialInfo(int Id=0, string Nome="", decimal Valor=0, int ModeloConsulta=1);
public sealed class ConfiguracaoClinicaOutput
{
    public int SagaId {get;set;}
    public int SagaStepId {get;set;}
    public int Etapa {get;set;}
    public bool Concluida {get;set;}
    public List<ClinicaInicialInfo> Clinicas {get;set;}=[];
    public List<ProfissionalInicialInfo> Profissionais {get;set;}=[];
    public List<ServicoInicialInfo> Servicos {get;set;}=[];
}
