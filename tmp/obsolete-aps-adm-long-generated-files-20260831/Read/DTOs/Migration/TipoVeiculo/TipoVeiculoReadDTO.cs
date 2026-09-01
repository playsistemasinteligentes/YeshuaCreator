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
    public partial record TipoVeiculoDTO
    {
    public int id { get; set; }
    public int tip_id { get; set; }
    public string tip_descricao { get; set; }
    public int tip_qtd_disponivel { get; set; }
    public Decimal tip_valor_km { get; set; }
    public Decimal tip_valor_diaria { get; set; }
    public Decimal tip_valor_ajudante { get; set; }
    public Decimal tip_qtd_eixos { get; set; }
    public Decimal tip_velocidade_media { get; set; }
    public Decimal tip_capacidade_altura { get; set; }
    public Decimal tip_capacidade_comprimento { get; set; }
    public Decimal tip_capacidade_largura { get; set; }
    public Decimal tip_capacidade_altura_pescoco_e { get; set; }
    public Decimal tip_capacidade_comprimento_pescoco_e { get; set; }
    public Decimal tip_capacidade_largura_pescoco_e { get; set; }
    public Decimal tip_capacidade_altura_pescoco_d { get; set; }
    public Decimal tip_capacidade_comprimento_pescoco_d { get; set; }
    public Decimal tip_capacidade_largura_pescoco_d { get; set; }
    public Decimal tip_capacidade_m3 { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration