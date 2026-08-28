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
    public partial record ItenCargaDTO
    {
    public int id { get; set; }
    public string car_id { get; set; }
    public string ord_id { get; set; }
    public DateTime itc_entrega_planejada { get; set; }
    public DateTime itc_entrega_realizada { get; set; }
    public int itc_ordem_entrega { get; set; }
    public Decimal itc_qtd_planejada { get; set; }
    public Decimal itc_qtd_realizada { get; set; }
    public string ord_hash_key { get; set; }
    public string not_id { get; set; }
    public DateTime not_emissao { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration