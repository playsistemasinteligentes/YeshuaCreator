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
    public partial class CentralHubCommand : ICommand
    {
    }

public partial record OfertaFinanceiraInfo : ICommand
{
    public string Codigo { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Aplicativo { get; set; } = string.Empty;
    public string Recurso { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public decimal PrecoCreditos { get; set; }
    public int Meses { get; set; }
    public decimal Unidades { get; set; }
}

public partial record DireitoFinanceiroInfo : ICommand
{
    public string Recurso { get; set; } = string.Empty;
    public string ValidoAteUtc { get; set; } = string.Empty;
    public decimal UnidadesContratadas { get; set; }
}

public partial record MovimentoFinanceiroInfo : ICommand
{
    public string Tipo { get; set; } = string.Empty;
    public string Referencia { get; set; } = string.Empty;
    public decimal Quantidade { get; set; }
    public decimal SaldoApos { get; set; }
    public string CriadoEmUtc { get; set; } = string.Empty;
    public string Servico { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal SaldoAnterior { get; set; }
}

public partial record CobrancaFinanceiraInfo : ICommand
{
    public string Id { get; set; } = string.Empty;
    public decimal Creditos { get; set; }
    public decimal Valor { get; set; }
    public int Status { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup