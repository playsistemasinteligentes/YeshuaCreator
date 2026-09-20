// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration
// </yeshua>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record RoteiroPedidoDTO
    {
    public string pedidoid { get; set; } = string.Empty;
    public string maquinaid { get; set; } = string.Empty;
    public string produtoid { get; set; } = string.Empty;
    public int sequenciatransformacao { get; set; }
    public string statuscadastro { get; set; } = string.Empty;
    public string tipoplanejamento { get; set; } = string.Empty;
    public int calendarioid { get; set; }
    public Decimal hierarquiasequenciatransformacao { get; set; }
    public int proximasequenciatransformacao { get; set; }
    public Decimal performance { get; set; }
    public Decimal temposetup { get; set; }
    public Decimal temposetupajuste { get; set; }
    public Decimal pecasporpulso { get; set; }
    public Decimal prioridadeinformada { get; set; }
    public string status { get; set; } = string.Empty;
    public string operacoes { get; set; } = string.Empty;
    public string excecaooperacoes { get; set; } = string.Empty;
    public string linhadireta { get; set; } = string.Empty;
    public int avaliacusto { get; set; }
    public Decimal percentualiniciopassoanterior { get; set; }
    public Decimal maquinalargurautil { get; set; }
    public Decimal grupotipo { get; set; }
    public Decimal grupoperformancemetrolinear { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration