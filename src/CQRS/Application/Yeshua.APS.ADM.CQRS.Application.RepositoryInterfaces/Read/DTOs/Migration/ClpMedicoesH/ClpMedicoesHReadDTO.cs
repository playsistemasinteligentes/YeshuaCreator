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
    public partial record ClpMedicoesHDTO
    {
    public int id { get; set; }
    public string maquina_id { get; set; }
    public DateTime data_ini { get; set; }
    public DateTime data_fim { get; set; }
    public DateTime clp_emissao { get; set; }
    public Decimal qtd { get; set; }
    public Decimal grupo { get; set; }
    public int status { get; set; }
    public string urn_id { get; set; }
    public string urm_id { get; set; }
    public int id_lote_clp { get; set; }
    public string oco_id { get; set; }
    public int fase { get; set; }
    public string clp_origem { get; set; }
    public int clp_lote { get; set; }
    public int compacta { get; set; }
    public string bol_id { get; set; }
    public int cor_sequencia { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration