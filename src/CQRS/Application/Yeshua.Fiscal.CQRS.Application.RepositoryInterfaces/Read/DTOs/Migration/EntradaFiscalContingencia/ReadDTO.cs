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
    public string correlationid { get; set; }
    public string cargaid { get; set; }
    public int tiposolicitante { get; set; }
    public int ambiente { get; set; }
    public string sourceapplication { get; set; }
    public string sourcemodule { get; set; }
    public string sourcemessageid { get; set; }
    public string emitentefiscaldocumento { get; set; }
    public string tomadordocumento { get; set; }
    public string transportadordocumento { get; set; }
    public string remetentedocumento { get; set; }
    public string destinatariodocumento { get; set; }
    public string ufinicio { get; set; }
    public string uffim { get; set; }
    public string municipioiniciocodigoibge { get; set; }
    public string municipiofimcodigoibge { get; set; }
    public string rntrc { get; set; }
    public string placaveiculo { get; set; }
    public string ufveiculo { get; set; }
    public string condutordocumento { get; set; }
    public string condutornome { get; set; }
    public int quantidadedocumentos { get; set; }
    public Decimal valorcarga { get; set; }
    public Decimal pesobruto { get; set; }
    public Decimal volume { get; set; }
    public string pendenciasjson { get; set; }
    public string snapshotjson { get; set; }
    public string emissaofiscalcorrelationid { get; set; }
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