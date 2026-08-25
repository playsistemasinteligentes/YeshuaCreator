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
public partial record CadastrarRoteiroInputCommand : ICommand
{
    public string MAQ_ID { get; set; }
    public string PRO_ID { get; set; }
    public string GMA_ID { get; set; }
    public int ROT_SEQ_TRANFORMACAO { get; set; }
    public decimal ROT_PECAS_POR_PULSO { get; set; }
    public string ROT_ACAO { get; set; }
    public decimal ROT_PERFORMANCE { get; set; }
    public decimal ROT_TEMPO_SETUP_AJUSTE { get; set; }
    public string ROT_STATUS { get; set; }
}

public partial record CadastrarRoteiroOutputCommand : ICommand
{
    public bool Cadastrado { get; set; }
    public string MAQ_ID { get; set; }
    public string PRO_ID { get; set; }
    public int ROT_SEQ_TRANFORMACAO { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup