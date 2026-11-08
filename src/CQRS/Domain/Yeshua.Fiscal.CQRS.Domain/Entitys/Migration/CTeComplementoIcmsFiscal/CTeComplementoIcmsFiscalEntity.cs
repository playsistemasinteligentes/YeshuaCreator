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
                    public partial class CTeComplementoIcmsFiscalEntity : ICTeComplementoIcmsFiscalEntity
{
    public int? Id { get; set; }
    public int CTeSolicitacaoFiscalId { get; set; }
    public Decimal ValorPrestacaoComplementar { get; set; }
    public string CST { get; set; }
    public Decimal ValorBaseCalculo { get; set; }
    public Decimal AliquotaICMS { get; set; }
    public Decimal ValorICMS { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal CTeComplementoIcmsFiscalEntity(int? id, int ctesolicitacaofiscalid, Decimal valorprestacaocomplementar, string cst, Decimal valorbasecalculo, Decimal aliquotaicms, Decimal valoricms ){
 Id = id; 
 CTeSolicitacaoFiscalId = ctesolicitacaofiscalid; 
 ValorPrestacaoComplementar = valorprestacaocomplementar; 
 CST = cst; 
 ValorBaseCalculo = valorbasecalculo; 
 AliquotaICMS = aliquotaicms; 
 ValorICMS = valoricms; 
 Deleted = false; 
 Changed = DateTime.Now; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CST))
   this._erroMensagem.Add("CST ICMS deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration