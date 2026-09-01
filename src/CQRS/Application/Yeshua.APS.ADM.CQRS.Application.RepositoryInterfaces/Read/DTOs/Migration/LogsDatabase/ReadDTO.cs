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
    public partial record LogsDatabaseDTO
    {
    public int logs_id { get; set; }
    public string logs_table { get; set; }
    public string logs_key { get; set; }
    public string logs_key1 { get; set; }
    public string logs_key2 { get; set; }
    public string logs_key3 { get; set; }
    public string logs_key4 { get; set; }
    public string logs_column { get; set; }
    public string logs_before { get; set; }
    public string logs_after { get; set; }
    public string logs_action { get; set; }
    public DateTime logs_date { get; set; }
    public int use_id { get; set; }
    public string logs_origem { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration