// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class CTeTentativaEmissaoEntity : ICTeTentativaEmissaoEntity
{
    public int? Id { get; set; }
    public int CTeSolicitacaoFiscalId { get; set; }
    public string? ChaveAcesso { get; set; }
    public int? Numero { get; set; }
    public int? Serie { get; set; }
    public int Tentativa { get; set; }
    public string? XmlAssinadoStorageKey { get; set; }
    public string? XmlProcStorageKey { get; set; }
    public string? XmlHash { get; set; }
    public string? CodigoRetorno { get; set; }
    public string? MensagemRetorno { get; set; }
    public string? ProtocoloAutorizacao { get; set; }
    public DateTime? EnviadoEmUtc { get; set; }
    public DateTime? AutorizadoEmUtc { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal CTeTentativaEmissaoEntity(int? id, int ctesolicitacaofiscalid, string? chaveacesso, int? numero, int? serie, int tentativa, string? xmlassinadostoragekey, string? xmlprocstoragekey, string? xmlhash, string? codigoretorno, string? mensagemretorno, string? protocoloautorizacao, DateTime? enviadoemutc, DateTime? autorizadoemutc, int status ){
 Id = id; 
 CTeSolicitacaoFiscalId = ctesolicitacaofiscalid; 
 ChaveAcesso = chaveacesso; 
 Numero = numero; 
 Serie = serie; 
 Tentativa = tentativa; 
 XmlAssinadoStorageKey = xmlassinadostoragekey; 
 XmlProcStorageKey = xmlprocstoragekey; 
 XmlHash = xmlhash; 
 CodigoRetorno = codigoretorno; 
 MensagemRetorno = mensagemretorno; 
 ProtocoloAutorizacao = protocoloautorizacao; 
 EnviadoEmUtc = enviadoemutc.HasValue && enviadoemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : enviadoemutc; 
 AutorizadoEmUtc = autorizadoemutc.HasValue && autorizadoemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : autorizadoemutc; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration