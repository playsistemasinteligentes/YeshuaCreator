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
    public partial record VeiculoDTO
    {
    public int id { get; set; }
    public string vei_placa { get; set; }
    public string vei_uf { get; set; }
    public int tip_id { get; set; }
    public Decimal vei_capacidade_m3 { get; set; }
    public Decimal vei_capacidade_largura { get; set; }
    public Decimal vei_capacidade_comprimento { get; set; }
    public Decimal vei_capacidade_altura { get; set; }
    public string vei_modelo { get; set; }
    public string vei_nome_motorista { get; set; }
    public string vei_dados_contato { get; set; }
    public string vei_cpf_motorista { get; set; }
    public string tca_id { get; set; }
    public DateTime vei_emissao { get; set; }
    public DateTime vei_vencimento { get; set; }
    public string vei_status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration