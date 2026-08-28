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
    public partial record EtiquetaDTO
    {
    public int eti_id { get; set; }
    public DateTime eti_emissao { get; set; }
    public string eti_codigo_barras { get; set; }
    public int eti_sequencia { get; set; }
    public int eti_numero_copias { get; set; }
    public string eti_status { get; set; }
    public DateTime eti_data_fabricacao { get; set; }
    public string eti_cod_barras_original { get; set; }
    public string eti_op_original { get; set; }
    public string maq_id { get; set; }
    public int imp_id { get; set; }
    public int use_id { get; set; }
    public string ord_id { get; set; }
    public string rot_pro_id { get; set; }
    public int rot_seq_tranformacao { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public Decimal eti_quantidade_palete { get; set; }
    public string eti_lote { get; set; }
    public string eti_sub_lote { get; set; }
    public int eti_imprimir_de { get; set; }
    public int eti_imprimir_ate { get; set; }
    public string bol_id { get; set; }
    public int cor_sequencia { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration