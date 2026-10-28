using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Patterns.Domain;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Atendimentos;

public class ServicoModeloTests
{
    private static DomainOperationContext Context(DomainOperation operation) =>
        DomainOperationContext.Create(operation,DomainEntryPoint.Crud,"Servico",tenantId:7,userId:13);

    [Theory] [InlineData(1)] [InlineData(2)]
    public void Factory_and_domain_preserve_the_selected_service_model(int model)
    {
        var entity=new ServicoFactory(null!).Create(null,null,"Serviço fictício",0m,model);
        Assert.Equal(model,entity.ModeloConsulta);
        Assert.True(ServicoDomainBehavior.Apply(entity,Context(DomainOperation.Registro)).IsValid);
        Assert.Equal(model,entity.ModeloConsulta);
    }
    [Fact] public void New_service_without_a_model_uses_complete_psychology()
    {
        var entity=new ServicoFactory(null!).Create(null,null,"Serviço fictício",0m,null);
        Assert.True(ServicoDomainBehavior.Apply(entity,Context(DomainOperation.Registro)).IsValid);
        Assert.Equal(1,entity.ModeloConsulta);
    }
    [Fact] public void Invalid_model_and_omitted_model_on_update_are_rejected()
    {
        var entity=new ServicoFactory(null!).Create(null,null,"Serviço fictício",0m,99);
        Assert.False(ServicoDomainBehavior.Apply(entity,Context(DomainOperation.Registro)).IsValid);
        entity.ModeloConsulta=null;
        Assert.False(ServicoDomainBehavior.Apply(entity,Context(DomainOperation.Alteracao)).IsValid);
    }
}
