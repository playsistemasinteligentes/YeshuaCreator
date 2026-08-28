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
                    public partial class T_MedicoesEntity : IT_MedicoesEntity
{
    public int? Id { get; set; }
    public int MED_ID { get; set; }
    public int? IND_ID { get; set; }
    public int? MET_ID { get; set; }
    public int? UNI_ID { get; set; }
    public DateTime MED_DATA { get; set; }
    public string MED_VALOR { get; set; }
    public string MED_AC_ANO { get; set; }
    public string MED_DATAMEDICAO { get; set; }
    public Decimal? MED_PONDERACAO { get; set; }
    public string DIM_ID { get; set; }
    public string DIM_DESCRICAO { get; set; }
    public string DIM_SUBDIMENSAO_ID { get; set; }
    public string DIM_SUB_DESCRICAO { get; set; }
    public string PER_ID { get; set; }
    public string PER_DESCRICAO { get; set; }
    public string FAT_ID { get; set; }
    public string FAT_DESCRICAO { get; set; }
    public string MED_SQL { get; set; }
    public string DOM_EMPRESA { get; set; }
    public string DOM_FILIAL { get; set; }
    public string MED_VALOR_DISPER { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_MedicoesEntity(int? id, int med_id, int? ind_id, int? met_id, int? uni_id, DateTime med_data, string med_valor, string med_ac_ano, string med_datamedicao, Decimal? med_ponderacao, string dim_id, string dim_descricao, string dim_subdimensao_id, string dim_sub_descricao, string per_id, string per_descricao, string fat_id, string fat_descricao, string med_sql, string dom_empresa, string dom_filial, string med_valor_disper ){
 Id = id; 
 MED_ID = med_id; 
 IND_ID = ind_id; 
 MET_ID = met_id; 
 UNI_ID = uni_id; 
 MED_DATA = (med_data < (new DateTime(1800, 1, 1))) ? DateTime.Now : med_data; 
 MED_VALOR = med_valor; 
 MED_AC_ANO = med_ac_ano; 
 MED_DATAMEDICAO = med_datamedicao; 
 MED_PONDERACAO = med_ponderacao; 
 DIM_ID = dim_id; 
 DIM_DESCRICAO = dim_descricao; 
 DIM_SUBDIMENSAO_ID = dim_subdimensao_id; 
 DIM_SUB_DESCRICAO = dim_sub_descricao; 
 PER_ID = per_id; 
 PER_DESCRICAO = per_descricao; 
 FAT_ID = fat_id; 
 FAT_DESCRICAO = fat_descricao; 
 MED_SQL = med_sql; 
 DOM_EMPRESA = dom_empresa; 
 DOM_FILIAL = dom_filial; 
 MED_VALOR_DISPER = med_valor_disper; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (MED_ID == null)
   this._erroMensagem.Add("MED ID deve ser informado.");
   if (MED_DATA == null || MED_DATA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("MED DATA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration