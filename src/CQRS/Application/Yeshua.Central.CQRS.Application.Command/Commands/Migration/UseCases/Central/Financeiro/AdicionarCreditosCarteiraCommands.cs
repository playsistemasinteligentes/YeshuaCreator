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
public partial record AdicionarCreditosCarteiraInputCommand : ICommand
{
    public string RequestId { get; set; } = string.Empty;
    public string CobrancaId { get; set; } = string.Empty;
    public string Oferta { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal Creditos { get; set; }
}

public partial record AdicionarCreditosCarteiraOutputCommand : ICommand
{
    public decimal Saldo { get; set; }
    public bool Simulacao { get; set; }
    public string CobrancaId { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string Direitos { get; set; } = string.Empty;
    public List<OfertaFinanceiraInfo> Ofertas { get; set; } = default!;
    public List<DireitoFinanceiroInfo> Contratacoes { get; set; } = default!;
    public List<MovimentoFinanceiroInfo> Movimentos { get; set; } = default!;
    public List<CobrancaFinanceiraInfo> Cobrancas { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup