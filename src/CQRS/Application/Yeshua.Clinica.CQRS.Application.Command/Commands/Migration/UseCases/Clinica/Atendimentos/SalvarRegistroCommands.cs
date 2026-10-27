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
public partial record SalvarRegistroInputCommand : ICommand
{
    public int SessaoId { get; set; }
    public int Versao { get; set; }
    public string Prontuario { get; set; } = string.Empty;
    public string QueixaPrincipal { get; set; } = string.Empty;
    public string RegistroDocumental { get; set; } = string.Empty;
    public string ObjetivosCurtoPrazo { get; set; } = string.Empty;
    public string ObjetivosLongoPrazo { get; set; } = string.Empty;
    public string ExerciciosTarefasSugeridas { get; set; } = string.Empty;
    public string EncaminhamentoOutrosProfissionais { get; set; } = string.Empty;
    public string FrequenciaSugeridaSessooes { get; set; } = string.Empty;
    public string InformacoesRelevantesFuturasConsultas { get; set; } = string.Empty;
    public bool Revisado { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public int IncorporarSagaId { get; set; }
}

public partial record SalvarRegistroOutputCommand : ICommand
{
    public int SessaoId { get; set; }
    public int Versao { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup