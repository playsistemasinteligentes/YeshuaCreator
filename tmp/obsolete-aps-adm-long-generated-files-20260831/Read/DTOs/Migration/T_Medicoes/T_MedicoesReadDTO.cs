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
    public partial record T_MedicoesDTO
    {
    public int id { get; set; }
    public int med_id { get; set; }
    public int ind_id { get; set; }
    public int met_id { get; set; }
    public int uni_id { get; set; }
    public DateTime med_data { get; set; }
    public string med_valor { get; set; }
    public string med_ac_ano { get; set; }
    public string med_datamedicao { get; set; }
    public Decimal med_ponderacao { get; set; }
    public string dim_id { get; set; }
    public string dim_descricao { get; set; }
    public string dim_subdimensao_id { get; set; }
    public string dim_sub_descricao { get; set; }
    public string per_id { get; set; }
    public string per_descricao { get; set; }
    public string fat_id { get; set; }
    public string fat_descricao { get; set; }
    public string med_sql { get; set; }
    public string dom_empresa { get; set; }
    public string dom_filial { get; set; }
    public string med_valor_disper { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration