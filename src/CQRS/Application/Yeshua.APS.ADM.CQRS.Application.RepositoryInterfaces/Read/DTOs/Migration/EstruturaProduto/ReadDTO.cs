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
    public partial record EstruturaProdutoDTO
    {
    public int id { get; set; }
    public DateTime est_data_validade { get; set; }
    public string pro_id_produto { get; set; }
    public string pro_id_componente { get; set; }
    public Decimal est_quant { get; set; }
    public DateTime est_data_inclusao { get; set; }
    public Decimal est_base_producao { get; set; }
    public string est_tipo_requisicao { get; set; }
    public string est_codigo_de_excecao { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration