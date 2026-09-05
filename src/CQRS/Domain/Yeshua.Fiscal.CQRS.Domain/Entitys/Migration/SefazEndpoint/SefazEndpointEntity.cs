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
                    public partial class SefazEndpointEntity : ISefazEndpointEntity
{
    public int? Id { get; set; }
    public int ProdutoFiscal { get; set; }
    public string UF { get; set; }
    public int Ambiente { get; set; }
    public string Servico { get; set; }
    public string Versao { get; set; }
    public string Url { get; set; }
    public int Ativo { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal SefazEndpointEntity(int? id, int produtofiscal, string uf, int ambiente, string servico, string versao, string url, int ativo ){
 Id = id; 
 ProdutoFiscal = produtofiscal; 
 UF = uf; 
 Ambiente = ambiente; 
 Servico = servico; 
 Versao = versao; 
 Url = url; 
 Ativo = ativo; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(UF))
   this._erroMensagem.Add("UF deve ser informado.");
   if(string.IsNullOrEmpty(Servico))
   this._erroMensagem.Add("Servico deve ser informado.");
   if(string.IsNullOrEmpty(Versao))
   this._erroMensagem.Add("Versao deve ser informado.");
   if(string.IsNullOrEmpty(Url))
   this._erroMensagem.Add("URL deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration