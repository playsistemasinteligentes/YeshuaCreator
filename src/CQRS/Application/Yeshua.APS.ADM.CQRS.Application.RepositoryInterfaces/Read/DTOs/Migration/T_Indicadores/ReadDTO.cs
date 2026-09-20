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
    public partial record T_IndicadoresDTO
    {
    public int ind_id { get; set; }
    public string ind_descricao { get; set; } = string.Empty;
    public int neg_id { get; set; }
    public string desc_calculo { get; set; } = string.Empty;
    public int ind_tipocomparador { get; set; }
    public int ind_grafico { get; set; }
    public string ind_conexao { get; set; } = string.Empty;
    public DateTime ind_dtcriacao { get; set; }
    public string resposavelind { get; set; } = string.Empty;
    public string resposavelcarga { get; set; } = string.Empty;
    public string procextracao { get; set; } = string.Empty;
    public string per_id { get; set; } = string.Empty;
    public string dim_id { get; set; } = string.Empty;
    public string dom_empresa { get; set; } = string.Empty;
    public string dom_filial { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration