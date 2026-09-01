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
    public partial record TesteFisicoDTO
    {
    public int id { get; set; }
    public int tes_id { get; set; }
    public int ite_id { get; set; }
    public int usr_id { get; set; }
    public string tes_nome_tecnico { get; set; }
    public int tes_amostra { get; set; }
    public string tes_op { get; set; }
    public Decimal tes_valor_numerico { get; set; }
    public DateTime tes_valor_data { get; set; }
    public string tes_valor_texto { get; set; }
    public DateTime tes_emissao { get; set; }
    public string ord_id { get; set; }
    public string pro_id { get; set; }
    public string maq_id { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public int fpr_seq_tranformacao { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration