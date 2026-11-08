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
    public partial record CTeComplementoIcmsFiscalDTO
    {
    public int id { get; set; }
    public int ctesolicitacaofiscalid { get; set; }
    public Decimal valorprestacaocomplementar { get; set; }
    public string cst { get; set; } = string.Empty;
    public Decimal valorbasecalculo { get; set; }
    public Decimal aliquotaicms { get; set; }
    public Decimal valoricms { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration