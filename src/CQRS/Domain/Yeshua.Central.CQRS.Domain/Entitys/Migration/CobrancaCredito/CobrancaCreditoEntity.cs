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
                    public partial class CobrancaCreditoEntity : ICobrancaCreditoEntity
{
    public string? Id { get; set; }
    public Decimal Creditos { get; set; }
    public Decimal Valor { get; set; }
    public int Status { get; set; }
    public DateTime CriadaEmUtc { get; set; }
    public DateTime VenceEmUtc { get; set; }
    public string Moeda { get; set; }
    public string Provedor { get; set; }
    public DateTime? PagaEmUtc { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal CobrancaCreditoEntity(string? id, Decimal creditos, Decimal valor, int status, DateTime criadaemutc, DateTime venceemutc, string moeda, string provedor, DateTime? pagaemutc ){
 Id = id;
 Creditos = creditos;
 Valor = valor;
 Status = status;
 CriadaEmUtc = (criadaemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadaemutc;
 VenceEmUtc = (venceemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : venceemutc;
 Moeda = moeda;
 Provedor = provedor;
 PagaEmUtc = pagaemutc.HasValue && pagaemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : pagaemutc;
 Deleted = false;
 Changed = DateTime.Now;
 OperationalEntityId = Guid.NewGuid().ToString("N");
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(CriadaEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criada em UTC deve ser informado.");
   if(VenceEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Vencimento UTC deve ser informado.");
   if(string.IsNullOrEmpty(Moeda))
   this._erroMensagem.Add("Moeda deve ser informado.");
   if(string.IsNullOrEmpty(Provedor))
   this._erroMensagem.Add("Provedor deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration