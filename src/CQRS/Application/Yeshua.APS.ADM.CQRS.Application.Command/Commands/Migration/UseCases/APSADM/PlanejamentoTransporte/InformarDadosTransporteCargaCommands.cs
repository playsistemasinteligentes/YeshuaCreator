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
public partial record InformarDadosTransporteCargaInputCommand : ICommand
{
    public string CargaId { get; set; }
    public string TransportadoraId { get; set; }
    public string VeiculoPlaca { get; set; }
    public int TipoVeiculoId { get; set; }
    public string VeiculoUf { get; set; }
    public string CondutorNome { get; set; }
    public string CondutorCpf { get; set; }
    public string Observacao { get; set; }
}

public partial record InformarDadosTransporteCargaOutputCommand : ICommand
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public string CargaId { get; set; }
    public string ProximoStep { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup