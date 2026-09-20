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
    public partial record FeedbackDTO
    {
    public int id { get; set; }
    public DateTime datainicial { get; set; }
    public DateTime datafinal { get; set; }
    public string maquinaid { get; set; } = string.Empty;
    public string ocorrenciaid { get; set; } = string.Empty;
    public string turnoid { get; set; } = string.Empty;
    public string turmaid { get; set; } = string.Empty;
    public int usuarioid { get; set; }
    public string orderid { get; set; } = string.Empty;
    public string produtoid { get; set; } = string.Empty;
    public string observacoes { get; set; } = string.Empty;
    public Decimal grupo { get; set; }
    public string diaturma { get; set; } = string.Empty;
    public int sequenciatransformacao { get; set; }
    public int sequenciarepeticao { get; set; }
    public Decimal quantidadepulsos { get; set; }
    public Decimal quantidadepecasporpulso { get; set; }
    public Decimal fee_qtd_total_producao_ajustada { get; set; }
    public string bol_id { get; set; } = string.Empty;
    public int cor_sequencia { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration