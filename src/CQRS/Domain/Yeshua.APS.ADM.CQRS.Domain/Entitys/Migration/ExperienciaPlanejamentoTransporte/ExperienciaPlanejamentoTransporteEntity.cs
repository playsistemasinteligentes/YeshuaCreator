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
                    public partial class ExperienciaPlanejamentoTransporteEntity : IExperienciaPlanejamentoTransporteEntity
{
    public int? Id { get; set; }
    public int Tipo { get; set; }
    public string Referencia { get; set; }
    public string PedidoId { get; set; }
    public string ClienteId { get; set; }
    public string Municipio { get; set; }
    public string Regiao { get; set; }
    public string RotaId { get; set; }
    public Decimal? Peso { get; set; }
    public Decimal? Volume { get; set; }
    public string Observacao { get; set; }
    public DateTime CriadoEm { get; set; }
    public string CriadoPor { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ExperienciaPlanejamentoTransporteEntity(int? id, int tipo, string referencia, string pedidoid, string clienteid, string municipio, string regiao, string rotaid, Decimal? peso, Decimal? volume, string observacao, DateTime criadoem, string criadopor ){
 Id = id; 
 Tipo = tipo; 
 Referencia = referencia; 
 PedidoId = pedidoid; 
 ClienteId = clienteid; 
 Municipio = municipio; 
 Regiao = regiao; 
 RotaId = rotaid; 
 Peso = peso; 
 Volume = volume; 
 Observacao = observacao; 
 CriadoEm = (criadoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadoem; 
 CriadoPor = criadopor; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (Tipo == null)
   this._erroMensagem.Add("Tipo deve ser informado.");
   if (CriadoEm == null || CriadoEm < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado Em deve ser informado.");
   if(string.IsNullOrEmpty(CriadoPor))
   this._erroMensagem.Add("Criado Por deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration