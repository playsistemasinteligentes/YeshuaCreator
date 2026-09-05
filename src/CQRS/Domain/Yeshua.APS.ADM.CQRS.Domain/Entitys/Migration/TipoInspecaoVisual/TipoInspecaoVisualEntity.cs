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
                    public partial class TipoInspecaoVisualEntity : ITipoInspecaoVisualEntity
{
    public int? Id { get; set; }
    public int TIV_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string TIV_NOME { get; set; }
    public string TIV_DESCRICAO { get; set; }
    public string TIV_FECHAMENTO { get; set; }
    public string TIV_AMOSTRA_ALEATORIA { get; set; }
    public int? TIV_N_AMOSTRAS { get; set; }
    public string TIV_MEDIDA { get; set; }
    public Decimal? TIV_ESPECIFICACAO { get; set; }
    public Decimal? TIV_TOL_MAIS { get; set; }
    public Decimal? TIV_TOL_MENOS { get; set; }
    private List<string> _erroMensagem = null;
 internal TipoInspecaoVisualEntity(int? id, int tiv_id, string tiv_nome, string tiv_descricao, string tiv_fechamento, string tiv_amostra_aleatoria, int? tiv_n_amostras, string tiv_medida, Decimal? tiv_especificacao, Decimal? tiv_tol_mais, Decimal? tiv_tol_menos ){
 Id = id; 
 TIV_ID = tiv_id; 
 TIV_NOME = tiv_nome; 
 TIV_DESCRICAO = tiv_descricao; 
 TIV_FECHAMENTO = tiv_fechamento; 
 TIV_AMOSTRA_ALEATORIA = tiv_amostra_aleatoria; 
 TIV_N_AMOSTRAS = tiv_n_amostras; 
 TIV_MEDIDA = tiv_medida; 
 TIV_ESPECIFICACAO = tiv_especificacao; 
 TIV_TOL_MAIS = tiv_tol_mais; 
 TIV_TOL_MENOS = tiv_tol_menos; 
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