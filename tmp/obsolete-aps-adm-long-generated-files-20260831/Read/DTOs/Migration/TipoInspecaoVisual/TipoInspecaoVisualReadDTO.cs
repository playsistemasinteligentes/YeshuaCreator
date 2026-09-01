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
    public partial record TipoInspecaoVisualDTO
    {
    public int id { get; set; }
    public int tiv_id { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public string tiv_nome { get; set; }
    public string tiv_descricao { get; set; }
    public string tiv_fechamento { get; set; }
    public string tiv_amostra_aleatoria { get; set; }
    public int tiv_n_amostras { get; set; }
    public string tiv_medida { get; set; }
    public Decimal tiv_especificacao { get; set; }
    public Decimal tiv_tol_mais { get; set; }
    public Decimal tiv_tol_menos { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration