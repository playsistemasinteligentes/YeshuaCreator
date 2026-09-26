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
    public partial record T_AGENDA_SCHEDULEDTO
    {
    public int id { get; set; }
    public int age_id { get; set; }
    public DateTime age_data_especifica { get; set; }
    public string age_horario_inicio { get; set; } = string.Empty;
    public string age_horario_fim { get; set; } = string.Empty;
    public string age_segunda { get; set; } = string.Empty;
    public string age_terca { get; set; } = string.Empty;
    public string age_quarta { get; set; } = string.Empty;
    public string age_quinta { get; set; } = string.Empty;
    public string age_sexta { get; set; } = string.Empty;
    public string age_sabado { get; set; } = string.Empty;
    public string age_domingo { get; set; } = string.Empty;
    public Decimal age_intervalo { get; set; }
    public string age_ordem_execucao { get; set; } = string.Empty;
    public string age_parametros { get; set; } = string.Empty;
    public string age_excecao { get; set; } = string.Empty;
    public string age_descricao { get; set; } = string.Empty;
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration