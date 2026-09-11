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
    public string tra_id { get; set; }
    public string tra_nome { get; set; }
    public string tra_cnpj { get; set; }
    public string tra_inscricao_estadual { get; set; }
    public string tra_rntrc { get; set; }
    public string tra_email { get; set; }
    public string tra_responsavel { get; set; }
    public string tra_fone { get; set; }
    public string tra_id_integracao { get; set; }
    public string tra_id_integracao_erp { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration