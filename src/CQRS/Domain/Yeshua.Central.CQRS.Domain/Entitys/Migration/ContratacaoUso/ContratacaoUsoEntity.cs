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
                    public partial class ContratacaoUsoEntity : IContratacaoUsoEntity
{
    public string? Id { get; set; }
    public string Oferta { get; set; }
    public int Quantidade { get; set; }
    public Decimal Creditos { get; set; }
    public DateTime CriadaEmUtc { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal ContratacaoUsoEntity(string? id, string oferta, int quantidade, Decimal creditos, DateTime criadaemutc ){
 Id = id;
 Oferta = oferta;
 Quantidade = quantidade;
 Creditos = creditos;
 CriadaEmUtc = (criadaemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadaemutc;
 Deleted = false;
 Changed = DateTime.Now;
 OperationalEntityId = Guid.NewGuid().ToString("N");
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Oferta))
   this._erroMensagem.Add("Oferta deve ser informado.");
   if(CriadaEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criada em UTC deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration