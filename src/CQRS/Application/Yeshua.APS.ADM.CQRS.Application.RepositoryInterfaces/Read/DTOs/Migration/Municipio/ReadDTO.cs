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
    public partial record MunicipioDTO
    {
    public string mun_id { get; set; } = string.Empty;
    public string mun_nome { get; set; } = string.Empty;
    public string uf_cod { get; set; } = string.Empty;
    public string mun_codigo_ibge { get; set; } = string.Empty;
    public Decimal mun_latitude { get; set; }
    public Decimal mun_longitude { get; set; }
    public string mun_id_integracao_erp { get; set; } = string.Empty;
    public string mun_codigo_siafi { get; set; } = string.Empty;
    public string mun_codigo_cnpj { get; set; } = string.Empty;
    public Decimal mun_distancia_km { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration