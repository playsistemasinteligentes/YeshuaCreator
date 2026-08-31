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
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record BuscarContextoPlanejamentoTransporteInputCommand : ICommand
{
    public DateTime EmbarqueDe { get; set; }
    public DateTime EmbarqueAte { get; set; }
    public string PlantaId { get; set; }
    public int LimitePedidos { get; set; }
}

public partial record BuscarContextoPlanejamentoTransporteOutputCommand : ICommand
{
    public string ContextoId { get; set; }
    public DateTime GeradoEm { get; set; }
    public int QuantidadePedidos { get; set; }
    public int QuantidadeCargas { get; set; }
    public List<PlanejamentoLenteResumo> Lentes { get; set; }
}

public partial record PlanejamentoLenteResumo : ICommand
{
    public string LenteId { get; set; }
    public string Descricao { get; set; }
    public string Niveis { get; set; }
    public bool ExpansaoRemota { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup