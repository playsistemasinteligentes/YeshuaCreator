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
    public partial record CTeSolicitacaoFiscalDTO
    {
    public int id { get; set; }
    public int entradaoficialid { get; set; }
    public int romaneioconsolidadoid { get; set; }
    public string correlationid { get; set; }
    public int ambiente { get; set; }
    public string ufemitente { get; set; }
    public string emitentedocumento { get; set; }
    public int produtofiscal { get; set; }
    public int tipocte { get; set; }
    public int tiposervico { get; set; }
    public int modal { get; set; }
    public int globalizado { get; set; }
    public string ufinicio { get; set; }
    public string uffim { get; set; }
    public string municipioiniciocodigoibge { get; set; }
    public string municipiofimcodigoibge { get; set; }
    public Decimal valorservico { get; set; }
    public Decimal valorcarga { get; set; }
    public string preferenciasmanifestojson { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration