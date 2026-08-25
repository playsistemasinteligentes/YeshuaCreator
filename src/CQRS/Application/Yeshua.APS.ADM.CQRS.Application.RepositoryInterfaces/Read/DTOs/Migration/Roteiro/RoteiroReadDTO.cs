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
    public string maquinaid { get; set; }
    public string produtoid { get; set; }
    public int sequenciatransformacao { get; set; }
    public string grupomaquinaid { get; set; }
    public Decimal pecasporpulso { get; set; }
    public Decimal prioridadeinformada { get; set; }
    public string acao { get; set; }
    public Decimal performance { get; set; }
    public Decimal temposetup { get; set; }
    public Decimal temposetupajuste { get; set; }
    public int proximasequenciatransformacao { get; set; }
    public string status { get; set; }
    public Decimal hierarquiasequenciatransformacao { get; set; }
    public int avaliacusto { get; set; }
    public string operacoes { get; set; }
    public string excecaooperacoes { get; set; }
    public Decimal percentualiniciopassoanterior { get; set; }
    public string linhadireta { get; set; }
    public int templatedetestesid { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration