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
    public string ind_descricao { get; set; }
    public int neg_id { get; set; }
    public string desc_calculo { get; set; }
    public int ind_tipocomparador { get; set; }
    public int ind_grafico { get; set; }
    public string ind_conexao { get; set; }
    public DateTime ind_dtcriacao { get; set; }
    public string resposavelind { get; set; }
    public string resposavelcarga { get; set; }
    public string procextracao { get; set; }
    public string per_id { get; set; }
    public string dim_id { get; set; }
    public string dom_empresa { get; set; }
    public string dom_filial { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration