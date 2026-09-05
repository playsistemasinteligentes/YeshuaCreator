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
                    public partial class CorridasOnduladeiraEstudoEntity : ICorridasOnduladeiraEstudoEntity
{
    public int? Id { get; set; }
    public string BOL_ID { get; set; }
    public string BOL_ID_ORIGEM { get; set; }
    public Decimal? PRO_LARGURA_PECA { get; set; }
    public Decimal? PRO_LARGURA_PECA_PROGRAMADO { get; set; }
    public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
    public Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO { get; set; }
    public Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO { get; set; }
    public string PRO_VINCOS_RECALCULADOS { get; set; }
    public string COR_SOLVER { get; set; }
    public Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
    public Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
    public Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
    public Decimal? COR_CUSTO_RESINA_PROGRAMADOS { get; set; }
    public Decimal? COR_TOLERANCIA_MENOS { get; set; }
    public Decimal? COR_TOLERANCIA_MAIS { get; set; }
    public int? COR_PILHAS_POR_PALETE { get; set; }
    public Decimal? COR_M_LINEAR_REALIZADO { get; set; }
    public string PRO_ID_PALETE { get; set; }
    public string COR_STATUS_PALETE { get; set; }
    public Decimal? COR_GRUPO_PRODUTIVO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CorridasOnduladeiraEstudoEntity(int? id, string bol_id, string bol_id_origem, Decimal? pro_largura_peca, Decimal? pro_largura_peca_programado, Decimal? pro_comprimento_peca, Decimal? pro_comprimento_peca_programado, Decimal? pro_utilizou_refile_obrigatorio, string pro_vincos_recalculados, string cor_solver, Decimal? cor_gramatura_papeis_programados, Decimal? cor_custo_papeis_programados, Decimal? cor_gramatura_resina_programados, Decimal? cor_custo_resina_programados, Decimal? cor_tolerancia_menos, Decimal? cor_tolerancia_mais, int? cor_pilhas_por_palete, Decimal? cor_m_linear_realizado, string pro_id_palete, string cor_status_palete, Decimal? cor_grupo_produtivo ){
 Id = id; 
 BOL_ID = bol_id; 
 BOL_ID_ORIGEM = bol_id_origem; 
 PRO_LARGURA_PECA = pro_largura_peca; 
 PRO_LARGURA_PECA_PROGRAMADO = pro_largura_peca_programado; 
 PRO_COMPRIMENTO_PECA = pro_comprimento_peca; 
 PRO_COMPRIMENTO_PECA_PROGRAMADO = pro_comprimento_peca_programado; 
 PRO_UTILIZOU_REFILE_OBRIGATORIO = pro_utilizou_refile_obrigatorio; 
 PRO_VINCOS_RECALCULADOS = pro_vincos_recalculados; 
 COR_SOLVER = cor_solver; 
 COR_GRAMATURA_PAPEIS_PROGRAMADOS = cor_gramatura_papeis_programados; 
 COR_CUSTO_PAPEIS_PROGRAMADOS = cor_custo_papeis_programados; 
 COR_GRAMATURA_RESINA_PROGRAMADOS = cor_gramatura_resina_programados; 
 COR_CUSTO_RESINA_PROGRAMADOS = cor_custo_resina_programados; 
 COR_TOLERANCIA_MENOS = cor_tolerancia_menos; 
 COR_TOLERANCIA_MAIS = cor_tolerancia_mais; 
 COR_PILHAS_POR_PALETE = cor_pilhas_por_palete; 
 COR_M_LINEAR_REALIZADO = cor_m_linear_realizado; 
 PRO_ID_PALETE = pro_id_palete; 
 COR_STATUS_PALETE = cor_status_palete; 
 COR_GRUPO_PRODUTIVO = cor_grupo_produtivo; 
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