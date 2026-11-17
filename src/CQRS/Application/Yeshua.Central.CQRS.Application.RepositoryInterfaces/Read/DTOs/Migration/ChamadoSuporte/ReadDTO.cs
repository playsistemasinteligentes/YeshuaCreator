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
    public partial record ChamadoSuporteDTO
    {
    public string id { get; set; } = string.Empty;
    public string aplicativo { get; set; } = string.Empty;
    public string modulo { get; set; } = string.Empty;
    public string tela { get; set; } = string.Empty;
    public string titulotela { get; set; } = string.Empty;
    public string rota { get; set; } = string.Empty;
    public string caminho { get; set; } = string.Empty;
    public string versao { get; set; } = string.Empty;
    public string fusohorario { get; set; } = string.Empty;
    public string momentoclienteutc { get; set; } = string.Empty;
    public string assunto { get; set; } = string.Empty;
    public string descricao { get; set; } = string.Empty;
    public int status { get; set; }
    public DateTime criadoemutc { get; set; }
    public DateTime abertoemutc { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration