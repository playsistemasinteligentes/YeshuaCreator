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
                    public partial class VeiculoEntity : IVeiculoEntity
{
    public int? Id { get; set; }
    public string VEI_PLACA { get; set; }
    public int TIP_ID { get; set; }
    public Decimal? VEI_CAPACIDADE_M3 { get; set; }
    public Decimal? VEI_CAPACIDADE_LARGURA { get; set; }
    public Decimal? VEI_CAPACIDADE_COMPRIMENTO { get; set; }
    public Decimal? VEI_CAPACIDADE_ALTURA { get; set; }
    public string VEI_MODELO { get; set; }
    public string VEI_NOME_MOTORISTA { get; set; }
    public string VEI_DADOS_CONTATO { get; set; }
    public string VEI_CPF_MOTORISTA { get; set; }
    public string TCA_ID { get; set; }
    public DateTime? VEI_EMISSAO { get; set; }
    public DateTime? VEI_VENCIMENTO { get; set; }
    public string VEI_STATUS { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal VeiculoEntity(int? id, string vei_placa, int tip_id, Decimal? vei_capacidade_m3, Decimal? vei_capacidade_largura, Decimal? vei_capacidade_comprimento, Decimal? vei_capacidade_altura, string vei_modelo, string vei_nome_motorista, string vei_dados_contato, string vei_cpf_motorista, string tca_id, DateTime? vei_emissao, DateTime? vei_vencimento, string vei_status ){
 Id = id; 
 VEI_PLACA = vei_placa; 
 TIP_ID = tip_id; 
 VEI_CAPACIDADE_M3 = vei_capacidade_m3; 
 VEI_CAPACIDADE_LARGURA = vei_capacidade_largura; 
 VEI_CAPACIDADE_COMPRIMENTO = vei_capacidade_comprimento; 
 VEI_CAPACIDADE_ALTURA = vei_capacidade_altura; 
 VEI_MODELO = vei_modelo; 
 VEI_NOME_MOTORISTA = vei_nome_motorista; 
 VEI_DADOS_CONTATO = vei_dados_contato; 
 VEI_CPF_MOTORISTA = vei_cpf_motorista; 
 TCA_ID = tca_id; 
 VEI_EMISSAO = (vei_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : vei_emissao; 
 VEI_VENCIMENTO = (vei_vencimento < (new DateTime(1800, 1, 1))) ? DateTime.Now : vei_vencimento; 
 VEI_STATUS = vei_status; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(VEI_PLACA))
   this._erroMensagem.Add("VEI PLACA deve ser informado.");
   if (TIP_ID == null)
   this._erroMensagem.Add("TIP ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration