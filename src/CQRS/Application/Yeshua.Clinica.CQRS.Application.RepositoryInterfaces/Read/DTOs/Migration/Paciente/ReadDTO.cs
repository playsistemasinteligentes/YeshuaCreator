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
    public partial record PacienteDTO
    {
    public int id { get; set; }
    public string nome { get; set; } = string.Empty;
    public string telefone { get; set; } = string.Empty;
    public DateTime datanascimento { get; set; }
    public int genero { get; set; }
    public string escolaridade { get; set; } = string.Empty;
    public string profissao { get; set; } = string.Empty;
    public string endereco { get; set; } = string.Empty;
    public string nomeresponsavel { get; set; } = string.Empty;
    public string telefoneresponsavel { get; set; } = string.Empty;
    public string observacao { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration