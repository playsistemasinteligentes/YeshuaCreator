using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Patterns.Domain;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Atendimentos;

public class CadastrosClinicaTests
{
    private static DomainOperationContext Context(DomainOperation op=DomainOperation.Registro) =>
        DomainOperationContext.Create(op,DomainEntryPoint.Crud,"Cadastro",tenantId:7,userId:13);
    private static IPacienteEntity Patient(string name="Paciente fictício",string phone="(11) 99999-0000",DateTime? birth=null) =>
        new PacienteFactory(null!).Create(null,name,phone,birth,null,null,null,null,null,null,null);

    [Fact] public void QuickPatientRequiresOnlyNameAndContactAndUsesTheSameDomainAsCrud()
    {
        var entity=Patient("  Paciente fictício  ");
        Assert.True(PacienteDomainBehavior.Apply(entity,Context()).IsValid);
        Assert.Equal("Paciente fictício",entity.Nome);
        Assert.Null(entity.DataNascimento);Assert.Null(entity.Genero);
    }
    [Theory]
    [InlineData("", "11999990000", "Nome")]
    [InlineData("   ", "11999990000", "Nome")]
    [InlineData("Paciente", "", "Telefone")]
    [InlineData("Paciente", "abc", "Telefone")]
    [InlineData("Paciente", "123", "Telefone")]
    public void InvalidPatientHasAnActionableMessage(string name,string phone,string expected)
    {
        var result=PacienteDomainBehavior.Apply(Patient(name,phone),Context());
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,x=>x.Contains(expected,StringComparison.OrdinalIgnoreCase));
    }
    [Fact] public void PatientRejectsFutureBirthAndOversizedFieldsBeforePersistence()
    {
        var entity=Patient(new string('x',151),birth:DateTime.Today.AddDays(1));
        entity.Observacao=new string('x',2001);entity.Genero=99;
        var result=PacienteDomainBehavior.Apply(entity,Context(DomainOperation.Alteracao));
        Assert.False(result.IsValid);Assert.Equal(4,result.Errors.Count);
    }
    [Fact] public void MainClinicalRegistrationsAcceptMinimalValidDataAndKeepOptionalRelationships()
    {
        Assert.True(ClinicaDomainBehavior.Apply(new ClinicaFactory(null!).Create(null,"Clínica fictícia","Endereço fictício","11999990000",1),Context()).IsValid);
        Assert.True(ProfissionalDomainBehavior.Apply(new ProfissionalFactory(null!).Create(null,"Profissional fictício",null,"11999990000",null,null),Context()).IsValid);
        Assert.True(EspecialidadeDomainBehavior.Apply(new EspecialidadeFactory(null!).Create(null,"Psicologia"),Context()).IsValid);
        Assert.True(GrupoServicoDomainBehavior.Apply(new GrupoServicoFactory(null!).Create(null,"Atendimentos"),Context()).IsValid);
        Assert.True(ServicoDomainBehavior.Apply(new ServicoFactory(null!).Create(null,null,"Atendimento",0m,2),Context()).IsValid);
        Assert.True(DisponibilidadeAgendaDomainBehavior.Apply(new DisponibilidadeAgendaFactory(null!).Create(null,3,DateTime.Today),Context()).IsValid);
    }
    [Fact] public void FinancialRegistrationsValidateAmountAndOptionsWithoutRejectingZeroServicePriceOrNegativeBalance()
    {
        var plan=new PlanoContaFactory(null!).Create(null,"1.1","Conta fictícia",1);
        Assert.True(PlanoContaDomainBehavior.Apply(plan,Context()).IsValid);
        plan.Tipo=99;Assert.False(PlanoContaDomainBehavior.Apply(plan,Context()).IsValid);
        var movement=new MovimentoFinanceiroFactory(null!).Create(null,"origem",1,10m,DateTime.Today,null,1);
        Assert.True(MovimentoFinanceiroDomainBehavior.Apply(movement,Context()).IsValid);
        movement.Valor=-1;movement.Status=99;movement.ContaDebitoId=0;
        Assert.Equal(3,MovimentoFinanceiroDomainBehavior.Apply(movement,Context()).Errors.Count);
        var balance=new MovimentacaoFinanceiraFactory(null!).Create(null,null,null,10m,2,DateTime.Today,-10m);
        Assert.True(MovimentacaoFinanceiraDomainBehavior.Apply(balance,Context()).IsValid);
        balance.TipoMovimentacao=0;balance.Valor=10.123m;
        Assert.Equal(2,MovimentacaoFinanceiraDomainBehavior.Apply(balance,Context()).Errors.Count);
    }
    [Fact] public void ReadAndDeleteDoNotDemandRegistrationFields()
    {
        Assert.True(PacienteDomainBehavior.Apply(Patient("",""),Context(DomainOperation.Remocao)).IsValid);
    }
}
