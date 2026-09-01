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
    public partial record TurnoDTO
    {
    public string id { get; set; }
    public string descricao { get; set; }
    public int turn_prioridade { get; set; }
    public DateTime turn_hora_ini_dia1 { get; set; }
    public DateTime turn_hora_fim_dia1 { get; set; }
    public DateTime turn_hora_ini_dia2 { get; set; }
    public DateTime turn_hora_fim_dia2 { get; set; }
    public DateTime turn_hora_ini_dia3 { get; set; }
    public DateTime turn_hora_fim_dia3 { get; set; }
    public DateTime turn_hora_ini_dia4 { get; set; }
    public DateTime turn_hora_fim_dia4 { get; set; }
    public DateTime turn_hora_ini_dia5 { get; set; }
    public DateTime turn_hora_fim_dia5 { get; set; }
    public DateTime turn_hora_ini_dia6 { get; set; }
    public DateTime turn_hora_fim_dia6 { get; set; }
    public DateTime turn_hora_ini_dia7 { get; set; }
    public DateTime turn_hora_fim_dia7 { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration