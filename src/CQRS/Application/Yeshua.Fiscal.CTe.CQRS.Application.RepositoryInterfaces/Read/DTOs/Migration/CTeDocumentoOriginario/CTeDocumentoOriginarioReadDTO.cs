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
    public partial record CTeDocumentoOriginarioDTO
    {
    public int id { get; set; }
    public int ctesolicitacaofiscalid { get; set; }
    public string tipodocumento { get; set; }
    public string chaveacesso { get; set; }
    public string numero { get; set; }
    public string serie { get; set; }
    public string emitentedocumento { get; set; }
    public string destinatariodocumento { get; set; }
    public Decimal valordocumento { get; set; }
    public Decimal pesobruto { get; set; }
    public string snapshotjson { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration