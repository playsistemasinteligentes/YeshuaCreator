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
                    public partial class EstruturaProdutoEntity : IEstruturaProdutoEntity
{
    public int? Id { get; set; }
    public DateTime EST_DATA_VALIDADE { get; set; }
    public string PRO_ID_PRODUTO { get; set; }
    public string PRO_ID_COMPONENTE { get; set; }
    public Decimal EST_QUANT { get; set; }
    public DateTime EST_DATA_INCLUSAO { get; set; }
    public Decimal EST_BASE_PRODUCAO { get; set; }
    public string EST_TIPO_REQUISICAO { get; set; }
    public string EST_CODIGO_DE_EXCECAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal EstruturaProdutoEntity(int? id, DateTime est_data_validade, string pro_id_produto, string pro_id_componente, Decimal est_quant, DateTime est_data_inclusao, Decimal est_base_producao, string est_tipo_requisicao, string est_codigo_de_excecao ){
 Id = id; 
 EST_DATA_VALIDADE = (est_data_validade < (new DateTime(1800, 1, 1))) ? DateTime.Now : est_data_validade; 
 PRO_ID_PRODUTO = pro_id_produto; 
 PRO_ID_COMPONENTE = pro_id_componente; 
 EST_QUANT = est_quant; 
 EST_DATA_INCLUSAO = (est_data_inclusao < (new DateTime(1800, 1, 1))) ? DateTime.Now : est_data_inclusao; 
 EST_BASE_PRODUCAO = est_base_producao; 
 EST_TIPO_REQUISICAO = est_tipo_requisicao; 
 EST_CODIGO_DE_EXCECAO = est_codigo_de_excecao; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(EST_DATA_VALIDADE == null || EST_DATA_VALIDADE < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("EST DATA VALIDADE deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID_PRODUTO))
   this._erroMensagem.Add("PRO ID PRODUTO deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID_COMPONENTE))
   this._erroMensagem.Add("PRO ID COMPONENTE deve ser informado.");
   if(EST_DATA_INCLUSAO == null || EST_DATA_INCLUSAO < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("EST DATA INCLUSAO deve ser informado.");
   if(string.IsNullOrEmpty(EST_TIPO_REQUISICAO))
   this._erroMensagem.Add("EST TIPO REQUISICAO deve ser informado.");
   if(string.IsNullOrEmpty(EST_CODIGO_DE_EXCECAO))
   this._erroMensagem.Add("EST CODIGO DE EXCECAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration