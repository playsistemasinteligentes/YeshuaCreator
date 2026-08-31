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
public partial record CatalogarExperienciaPlanejamentoTransporteInputCommand : ICommand
{
    public int Tipo { get; set; }
    public string Referencia { get; set; }
    public string PedidoId { get; set; }
    public string ClienteId { get; set; }
    public string Municipio { get; set; }
    public string Regiao { get; set; }
    public string RotaId { get; set; }
    public string Observacao { get; set; }
}

public partial record CatalogarExperienciaPlanejamentoTransporteOutputCommand : ICommand
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup