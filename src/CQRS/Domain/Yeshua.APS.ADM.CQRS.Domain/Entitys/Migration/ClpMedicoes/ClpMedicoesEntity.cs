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
                    public partial class ClpMedicoesEntity : IClpMedicoesEntity
{
    public int? Id { get; set; }
    public int Id2 { get; set; }
    public string MaquinaId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public DateTime? Emissao { get; set; }
    public Decimal Quantidade { get; set; }
    public Decimal? Grupo { get; set; }
    public int? Status { get; set; }
    public string TurnoId { get; set; }
    public string TurmaId { get; set; }
    public int IdLoteClp { get; set; }
    public string OcorrenciaId { get; set; }
    public int? Fase { get; set; }
    public string ClpOrigem { get; set; }
    public int? CLP_LOTE { get; set; }
    public int? COMPACTA { get; set; }
    public string BOL_ID { get; set; }
    public int? COR_SEQUENCIA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ClpMedicoesEntity(int? id, int id2, string maquinaid, DateTime datainicio, DateTime datafim, DateTime? emissao, Decimal quantidade, Decimal? grupo, int? status, string turnoid, string turmaid, int idloteclp, string ocorrenciaid, int? fase, string clporigem, int? clp_lote, int? compacta, string bol_id, int? cor_sequencia ){
 Id = id; 
 Id2 = id2; 
 MaquinaId = maquinaid; 
 DataInicio = (datainicio < (new DateTime(1800, 1, 1))) ? DateTime.Now : datainicio; 
 DataFim = (datafim < (new DateTime(1800, 1, 1))) ? DateTime.Now : datafim; 
 Emissao = (emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : emissao; 
 Quantidade = quantidade; 
 Grupo = grupo; 
 Status = status; 
 TurnoId = turnoid; 
 TurmaId = turmaid; 
 IdLoteClp = idloteclp; 
 OcorrenciaId = ocorrenciaid; 
 Fase = fase; 
 ClpOrigem = clporigem; 
 CLP_LOTE = clp_lote; 
 COMPACTA = compacta; 
 BOL_ID = bol_id; 
 COR_SEQUENCIA = cor_sequencia; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (Id2 == null)
   this._erroMensagem.Add("Id2 deve ser informado.");
   if(string.IsNullOrEmpty(MaquinaId))
   this._erroMensagem.Add("MaquinaId deve ser informado.");
   if (DataInicio == null || DataInicio < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DataInicio deve ser informado.");
   if (DataFim == null || DataFim < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DataFim deve ser informado.");
   if (Quantidade == null)
   this._erroMensagem.Add("Quantidade deve ser informado.");
   if (IdLoteClp == null)
   this._erroMensagem.Add("IdLoteClp deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration