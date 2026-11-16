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
public partial record PreverRecorrenciaConsultasInputCommand : ICommand
{
    public int PacienteId { get; set; }
    public int ServicoId { get; set; }
    public int ModeloConsulta { get; set; }
    public int VersaoModeloConsulta { get; set; }
    public string DataInicio { get; set; } = string.Empty;
    public string DataFim { get; set; } = string.Empty;
    public int IntervaloDias { get; set; }
    public string DataFinal { get; set; } = string.Empty;
    public int SessaoId { get; set; }
    public bool SerieFutura { get; set; }
}

public partial record PreverRecorrenciaConsultasOutputCommand : ICommand
{
    public string PlanoId { get; set; } = string.Empty;
    public bool Confirmado { get; set; }
    public List<OcorrenciaRecorrenciaInfo> Ocorrencias { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup