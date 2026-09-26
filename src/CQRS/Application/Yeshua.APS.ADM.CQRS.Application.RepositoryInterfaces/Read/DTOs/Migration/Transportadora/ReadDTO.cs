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
    public partial record TransportadoraDTO
    {
    public int id { get; set; }
    public string tra_id { get; set; } = string.Empty;
    public string tra_nome { get; set; } = string.Empty;
    public string tra_cnpj { get; set; } = string.Empty;
    public string tra_inscricao_estadual { get; set; } = string.Empty;
    public string tra_rntrc { get; set; } = string.Empty;
    public string tra_email { get; set; } = string.Empty;
    public string tra_responsavel { get; set; } = string.Empty;
    public string tra_fone { get; set; } = string.Empty;
    public string tra_id_integracao { get; set; } = string.Empty;
    public string tra_id_integracao_erp { get; set; } = string.Empty;
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration