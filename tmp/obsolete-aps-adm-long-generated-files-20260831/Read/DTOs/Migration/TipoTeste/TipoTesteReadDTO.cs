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
    public partial record TipoTesteDTO
    {
    public Decimal tt_especificacao { get; set; }
    public string tt_origem_especificacao { get; set; }
    public string tt_imprime_no_laudo { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public int tt_id { get; set; }
    public string tt_nome { get; set; }
    public string tt_desc { get; set; }
    public Decimal tt_tol_mais { get; set; }
    public Decimal tt_tol_menos { get; set; }
    public string tt_norma { get; set; }
    public string tt_inicio_processo { get; set; }
    public int ta_id { get; set; }
    public string uni_id { get; set; }
    public int tt_n_amostras_p_teste { get; set; }
    public int tt_max_def_critico { get; set; }
    public int tt_max_def_grave { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration