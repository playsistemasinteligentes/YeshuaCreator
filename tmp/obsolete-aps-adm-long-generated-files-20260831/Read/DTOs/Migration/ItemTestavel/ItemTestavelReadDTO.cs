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
    public partial record ItemTestavelDTO
    {
    public int id { get; set; }
    public int ite_id { get; set; }
    public string ite_descricao { get; set; }
    public string ite_obs { get; set; }
    public int ite_numero_de_testes { get; set; }
    public string ite_condicional_de_avaliacao { get; set; }
    public Decimal ite_valor_da_condicional { get; set; }
    public string ite_valor_calculado_da_condicional { get; set; }
    public string ite_tipo_avaliacao_final { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration