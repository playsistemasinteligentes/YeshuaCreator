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
    public partial record BoletimEstudoDTO
    {
    public int id { get; set; }
    public string bol_id { get; set; }
    public string bol_id_origem { get; set; }
    public string bol_solver { get; set; }
    public string bol_integracao { get; set; }
    public Decimal bol_sequencia { get; set; }
    public Decimal grp_pap_gramatura_programado { get; set; }
    public string grp_id_programado { get; set; }
    public string grp_papel1_programado { get; set; }
    public string grp_papel2_programado { get; set; }
    public string grp_papel3_programado { get; set; }
    public string grp_papel4_programado { get; set; }
    public string grp_papel5_programado { get; set; }
    public string bol_status_interface { get; set; }
    public string bol_tipo { get; set; }
    public int bol_formato { get; set; }
    public Decimal bol_gramatura_papeis_programados { get; set; }
    public Decimal bol_gramatura_papeis_realizado { get; set; }
    public Decimal bol_custo_papeis_programados { get; set; }
    public Decimal bol_custo_papeis_realizado { get; set; }
    public Decimal bol_gramatura_resina_programados { get; set; }
    public Decimal bol_custo_resina_programados { get; set; }
    public int bol_refile_obrigatorio { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration