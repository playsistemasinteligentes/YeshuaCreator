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
                    public partial class BoletimEntity : IBoletimEntity
{
    public int? Id { get; set; }
    public string BOL_ID { get; set; }
    public string BOL_ID_ORIGEM { get; set; }
    public string BOL_SOLVER { get; set; }
    public string BOL_INTEGRACAO { get; set; }
    public Decimal? BOL_SEQUENCIA { get; set; }
    public Decimal GRP_PAP_GRAMATURA_PROGRAMADO { get; set; }
    public string GRP_ID_PROGRAMADO { get; set; }
    public string GRP_PAPEL1_PROGRAMADO { get; set; }
    public string GRP_PAPEL2_PROGRAMADO { get; set; }
    public string GRP_PAPEL3_PROGRAMADO { get; set; }
    public string GRP_PAPEL4_PROGRAMADO { get; set; }
    public string GRP_PAPEL5_PROGRAMADO { get; set; }
    public string BOL_STATUS_INTERFACE { get; set; }
    public string BOL_TIPO { get; set; }
    public int? BOL_FORMATO { get; set; }
    public Decimal? BOL_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
    public Decimal? BOL_GRAMATURA_PAPEIS_REALIZADO { get; set; }
    public Decimal? BOL_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
    public Decimal? BOL_CUSTO_PAPEIS_REALIZADO { get; set; }
    public Decimal? BOL_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
    public Decimal? BOL_CUSTO_RESINA_PROGRAMADOS { get; set; }
    public int? BOL_REFILE_OBRIGATORIO { get; set; }
    public string BOL_OBS { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal BoletimEntity(int? id, string bol_id, string bol_id_origem, string bol_solver, string bol_integracao, Decimal? bol_sequencia, Decimal grp_pap_gramatura_programado, string grp_id_programado, string grp_papel1_programado, string grp_papel2_programado, string grp_papel3_programado, string grp_papel4_programado, string grp_papel5_programado, string bol_status_interface, string bol_tipo, int? bol_formato, Decimal? bol_gramatura_papeis_programados, Decimal? bol_gramatura_papeis_realizado, Decimal? bol_custo_papeis_programados, Decimal? bol_custo_papeis_realizado, Decimal? bol_gramatura_resina_programados, Decimal? bol_custo_resina_programados, int? bol_refile_obrigatorio, string bol_obs ){
 Id = id; 
 BOL_ID = bol_id; 
 BOL_ID_ORIGEM = bol_id_origem; 
 BOL_SOLVER = bol_solver; 
 BOL_INTEGRACAO = bol_integracao; 
 BOL_SEQUENCIA = bol_sequencia; 
 GRP_PAP_GRAMATURA_PROGRAMADO = grp_pap_gramatura_programado; 
 GRP_ID_PROGRAMADO = grp_id_programado; 
 GRP_PAPEL1_PROGRAMADO = grp_papel1_programado; 
 GRP_PAPEL2_PROGRAMADO = grp_papel2_programado; 
 GRP_PAPEL3_PROGRAMADO = grp_papel3_programado; 
 GRP_PAPEL4_PROGRAMADO = grp_papel4_programado; 
 GRP_PAPEL5_PROGRAMADO = grp_papel5_programado; 
 BOL_STATUS_INTERFACE = bol_status_interface; 
 BOL_TIPO = bol_tipo; 
 BOL_FORMATO = bol_formato; 
 BOL_GRAMATURA_PAPEIS_PROGRAMADOS = bol_gramatura_papeis_programados; 
 BOL_GRAMATURA_PAPEIS_REALIZADO = bol_gramatura_papeis_realizado; 
 BOL_CUSTO_PAPEIS_PROGRAMADOS = bol_custo_papeis_programados; 
 BOL_CUSTO_PAPEIS_REALIZADO = bol_custo_papeis_realizado; 
 BOL_GRAMATURA_RESINA_PROGRAMADOS = bol_gramatura_resina_programados; 
 BOL_CUSTO_RESINA_PROGRAMADOS = bol_custo_resina_programados; 
 BOL_REFILE_OBRIGATORIO = bol_refile_obrigatorio; 
 BOL_OBS = bol_obs; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(BOL_ID))
   this._erroMensagem.Add("BOL ID deve ser informado.");
   if (GRP_PAP_GRAMATURA_PROGRAMADO == null)
   this._erroMensagem.Add("GRP PAP GRAMATURA PROGRAMADO deve ser informado.");
   if(string.IsNullOrEmpty(GRP_ID_PROGRAMADO))
   this._erroMensagem.Add("GRP ID PROGRAMADO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration