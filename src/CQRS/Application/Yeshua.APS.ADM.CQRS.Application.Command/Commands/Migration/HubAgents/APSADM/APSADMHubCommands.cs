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
    public partial class APSADMHubCommand : ICommand
    {
    }

public partial record PlanejamentoLenteResumo : ICommand
{
    public string LenteId { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Niveis { get; set; } = string.Empty;
    public bool ExpansaoRemota { get; set; }
}

public partial record PlanejamentoNoLenteResumo : ICommand
{
    public string NoId { get; set; } = string.Empty;
    public string ParentNoId { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public int QuantidadePedidos { get; set; }
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public bool TemFilhos { get; set; }
}

public partial record PedidoPlanejamentoEnvelope : ICommand
{
    public string PedidoId { get; set; } = string.Empty;
    public string ClienteNome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Municipio { get; set; } = string.Empty;
    public string Regiao { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string RotaId { get; set; } = string.Empty;
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public DateTime EmbarqueAlvo { get; set; }
    public string VersaoPlanejamento { get; set; } = string.Empty;
    public string AlertasResumo { get; set; } = string.Empty;
}

public partial record PedidoPlanejamentoRef : ICommand
{
    public string PedidoId { get; set; } = string.Empty;
    public string VersaoPlanejamento { get; set; } = string.Empty;
}

public partial record CargaPlanejamentoEnvelope : ICommand
{
    public string CargaId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public int QuantidadePedidos { get; set; }
    public string AlertasResumo { get; set; } = string.Empty;
}

public partial record OpcaoPlanejamentoEnvelope : ICommand
{
    public string OpcaoId { get; set; } = string.Empty;
    public string GrupoDecisaoId { get; set; } = string.Empty;
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public decimal CustoEstimado { get; set; }
    public decimal AderenciaCubagem { get; set; }
    public string RiscoResumo { get; set; } = string.Empty;
    public string PedidosResumo { get; set; } = string.Empty;
}

public partial record CenarioPlanejamentoEnvelope : ICommand
{
    public string CenarioId { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Objetivo { get; set; } = string.Empty;
    public int QuantidadeCargas { get; set; }
    public int QuantidadePedidosNaoAtendidos { get; set; }
    public decimal CustoTotal { get; set; }
    public string AlertasResumo { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup