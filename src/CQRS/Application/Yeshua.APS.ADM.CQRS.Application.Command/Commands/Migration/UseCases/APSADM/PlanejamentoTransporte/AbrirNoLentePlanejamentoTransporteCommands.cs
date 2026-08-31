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
public partial record AbrirNoLentePlanejamentoTransporteInputCommand : ICommand
{
    public string ContextoId { get; set; }
    public string LenteId { get; set; }
    public string NoId { get; set; }
    public int Nivel { get; set; }
}

public partial record AbrirNoLentePlanejamentoTransporteOutputCommand : ICommand
{
    public List<PlanejamentoNoLenteResumo> Nos { get; set; }
    public List<PedidoPlanejamentoEnvelope> Pedidos { get; set; }
}

public partial record PlanejamentoNoLenteResumo : ICommand
{
    public string NoId { get; set; }
    public string ParentNoId { get; set; }
    public string Descricao { get; set; }
    public int Nivel { get; set; }
    public int QuantidadePedidos { get; set; }
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public bool TemFilhos { get; set; }
}

public partial record PedidoPlanejamentoEnvelope : ICommand
{
    public string PedidoId { get; set; }
    public string ClienteNome { get; set; }
    public string Estado { get; set; }
    public string Municipio { get; set; }
    public string Regiao { get; set; }
    public string Bairro { get; set; }
    public string RotaId { get; set; }
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public DateTime EmbarqueAlvo { get; set; }
    public string VersaoPlanejamento { get; set; }
    public string AlertasResumo { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup