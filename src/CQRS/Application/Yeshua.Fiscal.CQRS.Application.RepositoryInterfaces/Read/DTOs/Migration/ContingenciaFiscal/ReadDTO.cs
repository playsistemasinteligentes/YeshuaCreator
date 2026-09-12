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
    public partial record ContingenciaFiscalDTO
    {
    public int id { get; set; }
    public int emissaofiscaltransporteid { get; set; }
    public int entradafiscalcontingenciaid { get; set; }
    public string correlationid { get; set; } = string.Empty;
    public string cargaid { get; set; } = string.Empty;
    public int tiposolicitante { get; set; }
    public int ambiente { get; set; }
    public string emitentedocumento { get; set; } = string.Empty;
    public string tomadordocumento { get; set; } = string.Empty;
    public string transportadordocumento { get; set; } = string.Empty;
    public int quantidadedocumentos { get; set; }
    public int quantidadecte { get; set; }
    public int quantidademdfe { get; set; }
    public Decimal valorcarga { get; set; }
    public Decimal pesobruto { get; set; }
    public string ultimamensagem { get; set; } = string.Empty;
    public DateTime criadoemutc { get; set; }
    public DateTime atualizadoemutc { get; set; }
    public DateTime concluidoemutc { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration