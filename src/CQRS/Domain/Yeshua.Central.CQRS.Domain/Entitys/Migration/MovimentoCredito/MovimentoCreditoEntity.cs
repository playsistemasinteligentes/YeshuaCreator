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
                    public partial class MovimentoCreditoEntity : IMovimentoCreditoEntity
{
    public string? Id { get; set; }
    public string Tipo { get; set; }
    public string Referencia { get; set; }
    public Decimal Quantidade { get; set; }
    public Decimal SaldoApos { get; set; }
    public DateTime CriadoEmUtc { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal MovimentoCreditoEntity(string? id, string tipo, string referencia, Decimal quantidade, Decimal saldoapos, DateTime criadoemutc ){
 Id = id;
 Tipo = tipo;
 Referencia = referencia;
 Quantidade = quantidade;
 SaldoApos = saldoapos;
 CriadoEmUtc = (criadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadoemutc;
 Deleted = false;
 Changed = DateTime.Now;
 OperationalEntityId = Guid.NewGuid().ToString("N");
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Tipo))
   this._erroMensagem.Add("Tipo deve ser informado.");
   if(string.IsNullOrEmpty(Referencia))
   this._erroMensagem.Add("Referencia deve ser informado.");
   if(CriadoEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado em UTC deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration