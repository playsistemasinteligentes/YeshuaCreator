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
                    public partial class MunicipioEntity : IMunicipioEntity
{
    public string MUN_ID { get; set; }
    public string MUN_NOME { get; set; }
    public string UF_COD { get; set; }
    public string MUN_CODIGO_IBGE { get; set; }
    public Decimal? MUN_LATITUDE { get; set; }
    public Decimal? MUN_LONGITUDE { get; set; }
    public string MUN_ID_INTEGRACAO_ERP { get; set; }
    public string MUN_CODIGO_SIAFI { get; set; }
    public string MUN_CODIGO_CNPJ { get; set; }
    public Decimal? MUN_DISTANCIA_KM { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MunicipioEntity(string mun_id, string mun_nome, string uf_cod, string mun_codigo_ibge, Decimal? mun_latitude, Decimal? mun_longitude, string mun_id_integracao_erp, string mun_codigo_siafi, string mun_codigo_cnpj, Decimal? mun_distancia_km ){
 MUN_ID = mun_id; 
 MUN_NOME = mun_nome; 
 UF_COD = uf_cod; 
 MUN_CODIGO_IBGE = mun_codigo_ibge; 
 MUN_LATITUDE = mun_latitude; 
 MUN_LONGITUDE = mun_longitude; 
 MUN_ID_INTEGRACAO_ERP = mun_id_integracao_erp; 
 MUN_CODIGO_SIAFI = mun_codigo_siafi; 
 MUN_CODIGO_CNPJ = mun_codigo_cnpj; 
 MUN_DISTANCIA_KM = mun_distancia_km; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(MUN_ID))
   this._erroMensagem.Add("MUN ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration