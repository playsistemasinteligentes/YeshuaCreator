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
    public partial record EntradaFiscalContingenciaDTO
    {
    public int id { get; set; }
    public string correlationid { get; set; } = string.Empty;
    public string cargaid { get; set; } = string.Empty;
    public int tiposolicitante { get; set; }
    public int ambiente { get; set; }
    public string sourceapplication { get; set; } = string.Empty;
    public string sourcemodule { get; set; } = string.Empty;
    public string sourcemessageid { get; set; } = string.Empty;
    public string emitentefiscaldocumento { get; set; } = string.Empty;
    public string tomadordocumento { get; set; } = string.Empty;
    public string transportadordocumento { get; set; } = string.Empty;
    public string remetentedocumento { get; set; } = string.Empty;
    public string destinatariodocumento { get; set; } = string.Empty;
    public string ufinicio { get; set; } = string.Empty;
    public string uffim { get; set; } = string.Empty;
    public string municipioiniciocodigoibge { get; set; } = string.Empty;
    public string municipiofimcodigoibge { get; set; } = string.Empty;
    public string rntrc { get; set; } = string.Empty;
    public string placaveiculo { get; set; } = string.Empty;
    public string ufveiculo { get; set; } = string.Empty;
    public string condutordocumento { get; set; } = string.Empty;
    public string condutornome { get; set; } = string.Empty;
    public int quantidadedocumentos { get; set; }
    public Decimal valorcarga { get; set; }
    public Decimal pesobruto { get; set; }
    public Decimal volume { get; set; }
    public string pendenciasjson { get; set; } = string.Empty;
    public string snapshotjson { get; set; } = string.Empty;
    public string emissaofiscalcorrelationid { get; set; } = string.Empty;
    public int emissaofiscalsagaid { get; set; }
    public DateTime criadoemutc { get; set; }
    public DateTime atualizadoemutc { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration