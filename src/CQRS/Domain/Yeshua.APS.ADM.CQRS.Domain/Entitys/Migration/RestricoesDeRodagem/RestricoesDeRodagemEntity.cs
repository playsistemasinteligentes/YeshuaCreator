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
                    public partial class RestricoesDeRodagemEntity : IRestricoesDeRodagemEntity
{
    public int? Id { get; set; }
    public int RES_ID { get; set; }
    public string RES_TIPO { get; set; }
    public string RES_HORA_INI { get; set; }
    public string RES_HORA_FIM { get; set; }
    public Decimal? RES_VELOCIDADE_HORA_RUSH { get; set; }
    public int? TVE_ID { get; set; }
    public int? MAP_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RestricoesDeRodagemEntity(int? id, int res_id, string res_tipo, string res_hora_ini, string res_hora_fim, Decimal? res_velocidade_hora_rush, int? tve_id, int? map_id ){
 Id = id; 
 RES_ID = res_id; 
 RES_TIPO = res_tipo; 
 RES_HORA_INI = res_hora_ini; 
 RES_HORA_FIM = res_hora_fim; 
 RES_VELOCIDADE_HORA_RUSH = res_velocidade_hora_rush; 
 TVE_ID = tve_id; 
 MAP_ID = map_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(RES_TIPO))
   this._erroMensagem.Add("RES TIPO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration