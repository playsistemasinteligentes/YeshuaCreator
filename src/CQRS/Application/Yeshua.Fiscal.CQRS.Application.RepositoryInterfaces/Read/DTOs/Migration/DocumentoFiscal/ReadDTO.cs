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
    public partial record DocumentoFiscalDTO
    {
    public int id { get; set; }
    public string correlationid { get; set; }
    public int produtofiscal { get; set; }
    public string chaveacesso { get; set; }
    public int serie { get; set; }
    public int numero { get; set; }
    public int ambiente { get; set; }
    public string ufemitente { get; set; }
    public string emitentedocumento { get; set; }
    public string destinatariodocumento { get; set; }
    public string xmlstoragekey { get; set; }
    public string xmlhash { get; set; }
    public string protocoloautorizacao { get; set; }
    public string codigoretorno { get; set; }
    public string mensagemretorno { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration