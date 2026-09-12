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
    public partial record CTeTentativaEmissaoDTO
    {
    public int id { get; set; }
    public int ctesolicitacaofiscalid { get; set; }
    public string chaveacesso { get; set; } = string.Empty;
    public int numero { get; set; }
    public int serie { get; set; }
    public int tentativa { get; set; }
    public string xmlassinadostoragekey { get; set; } = string.Empty;
    public string xmlprocstoragekey { get; set; } = string.Empty;
    public string xmlhash { get; set; } = string.Empty;
    public string codigoretorno { get; set; } = string.Empty;
    public string mensagemretorno { get; set; } = string.Empty;
    public string protocoloautorizacao { get; set; } = string.Empty;
    public DateTime enviadoemutc { get; set; }
    public DateTime autorizadoemutc { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration