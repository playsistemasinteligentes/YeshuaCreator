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
                    public partial class MDFeVeiculoEntity : IMDFeVeiculoEntity
{
    public int? Id { get; set; }
    public int MDFeSolicitacaoFiscalId { get; set; }
    public string Placa { get; set; }
    public string? Renavam { get; set; }
    public Decimal? Tara { get; set; }
    public Decimal? CapacidadeKg { get; set; }
    public Decimal? CapacidadeM3 { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal MDFeVeiculoEntity(int? id, int mdfesolicitacaofiscalid, string placa, string? renavam, Decimal? tara, Decimal? capacidadekg, Decimal? capacidadem3 ){
 Id = id; 
 MDFeSolicitacaoFiscalId = mdfesolicitacaofiscalid; 
 Placa = placa; 
 Renavam = renavam; 
 Tara = tara; 
 CapacidadeKg = capacidadekg; 
 CapacidadeM3 = capacidadem3; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Placa))
   this._erroMensagem.Add("Placa deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration