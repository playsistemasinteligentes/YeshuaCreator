// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Command.Interfaces;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record AbrirConfiguracaoClinicaInputCommand : ICommand
{
}

public partial record AbrirConfiguracaoClinicaOutputCommand : ICommand
{
    public int SagaId { get; set; }
    public int SagaStepId { get; set; }
    public int Etapa { get; set; }
    public bool Concluida { get; set; }
    public List<ClinicaInicialInfo> Clinicas { get; set; } = default!;
    public List<ProfissionalInicialInfo> Profissionais { get; set; } = default!;
    public List<ServicoInicialInfo> Servicos { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup