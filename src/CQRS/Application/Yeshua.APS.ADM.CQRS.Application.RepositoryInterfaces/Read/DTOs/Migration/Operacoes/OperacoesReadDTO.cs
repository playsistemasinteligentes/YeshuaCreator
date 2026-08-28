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
    public partial record OperacoesDTO
    {
    public int id { get; set; }
    public string ope_tipo_registro { get; set; }
    public string ope_id { get; set; }
    public string gma_id { get; set; }
    public string maq_id { get; set; }
    public string pro_id { get; set; }
    public string ope_excecao { get; set; }
    public int rot_seq_tranformacao { get; set; }
    public string ord_id { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration