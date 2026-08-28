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
    public partial record OndaDTO
    {
    public string ond_id { get; set; }
    public Decimal ond_espessura { get; set; }
    public Decimal ond_peso_cola { get; set; }
    public Decimal ond_rendimento_onda_1 { get; set; }
    public Decimal ond_rendimento_onda_2 { get; set; }
    public int ond_profundidade_vinco { get; set; }
    public string ond_id_integracao { get; set; }
    public int vin_id { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration