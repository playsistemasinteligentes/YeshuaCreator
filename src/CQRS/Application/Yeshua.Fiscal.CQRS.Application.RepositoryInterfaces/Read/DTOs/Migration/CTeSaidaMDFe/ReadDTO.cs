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
    public partial record CTeSaidaMDFeDTO
    {
    public int id { get; set; }
    public int ctetentativaemissaoid { get; set; }
    public string correlationid { get; set; } = string.Empty;
    public string chaveacessocte { get; set; } = string.Empty;
    public string snapshothash { get; set; } = string.Empty;
    public string outboxmessageid { get; set; } = string.Empty;
    public DateTime publicadoemutc { get; set; }
    public string ultimoerro { get; set; } = string.Empty;
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration