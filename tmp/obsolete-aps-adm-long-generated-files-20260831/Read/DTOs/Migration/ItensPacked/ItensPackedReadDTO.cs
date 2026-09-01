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
    public partial record ItensPackedDTO
    {
    public int id { get; set; }
    public int ipa_id { get; set; }
    public string car_id { get; set; }
    public string pro_id { get; set; }
    public string ord_id { get; set; }
    public Decimal ipa_coordc { get; set; }
    public Decimal ipa_coordl { get; set; }
    public Decimal ipa_coorda { get; set; }
    public Decimal ipa_dimc { get; set; }
    public Decimal ipa_diml { get; set; }
    public Decimal ipa_dima { get; set; }
    public Decimal ipa_qtd_por_palete { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration