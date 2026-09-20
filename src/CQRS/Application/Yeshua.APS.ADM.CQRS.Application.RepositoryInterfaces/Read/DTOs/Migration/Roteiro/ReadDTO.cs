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
    public partial record RoteiroDTO
    {
    public int id { get; set; }
    public string maquinaid { get; set; } = string.Empty;
    public string produtoid { get; set; } = string.Empty;
    public int sequenciatransformacao { get; set; }
    public string grupomaquinaid { get; set; } = string.Empty;
    public Decimal pecasporpulso { get; set; }
    public Decimal prioridadeinformada { get; set; }
    public string acao { get; set; } = string.Empty;
    public Decimal performance { get; set; }
    public Decimal temposetup { get; set; }
    public Decimal temposetupajuste { get; set; }
    public int proximasequenciatransformacao { get; set; }
    public string status { get; set; } = string.Empty;
    public Decimal hierarquiasequenciatransformacao { get; set; }
    public int avaliacusto { get; set; }
    public string operacoes { get; set; } = string.Empty;
    public string excecaooperacoes { get; set; } = string.Empty;
    public Decimal percentualiniciopassoanterior { get; set; }
    public string linhadireta { get; set; } = string.Empty;
    public int templatedetestesid { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration