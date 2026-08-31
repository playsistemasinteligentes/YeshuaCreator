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
                    public partial class PedidoPlanejavelEntity : IPedidoPlanejavelEntity
{
    public string PedidoId { get; set; }
    public string ClienteId { get; set; }
    public string ClienteNome { get; set; }
    public string Estado { get; set; }
    public string Municipio { get; set; }
    public string Regiao { get; set; }
    public string Bairro { get; set; }
    public string RotaId { get; set; }
    public DateTime? EmbarqueAlvo { get; set; }
    public DateTime? DataEntregaDe { get; set; }
    public DateTime? DataEntregaAte { get; set; }
    public Decimal? Peso { get; set; }
    public Decimal? Volume { get; set; }
    public Decimal? SaldoAExpedir { get; set; }
    public string Status { get; set; }
    public string CargaAtualId { get; set; }
    public string VersaoPlanejamento { get; set; }
    public string AlertasResumo { get; set; }
    private List<string> _erroMensagem = null;
 internal PedidoPlanejavelEntity(string pedidoid, string clienteid, string clientenome, string estado, string municipio, string regiao, string bairro, string rotaid, DateTime? embarquealvo, DateTime? dataentregade, DateTime? dataentregaate, Decimal? peso, Decimal? volume, Decimal? saldoaexpedir, string status, string cargaatualid, string versaoplanejamento, string alertasresumo ){
 PedidoId = pedidoid; 
 ClienteId = clienteid; 
 ClienteNome = clientenome; 
 Estado = estado; 
 Municipio = municipio; 
 Regiao = regiao; 
 Bairro = bairro; 
 RotaId = rotaid; 
 EmbarqueAlvo = (embarquealvo < (new DateTime(1800, 1, 1))) ? DateTime.Now : embarquealvo; 
 DataEntregaDe = (dataentregade < (new DateTime(1800, 1, 1))) ? DateTime.Now : dataentregade; 
 DataEntregaAte = (dataentregaate < (new DateTime(1800, 1, 1))) ? DateTime.Now : dataentregaate; 
 Peso = peso; 
 Volume = volume; 
 SaldoAExpedir = saldoaexpedir; 
 Status = status; 
 CargaAtualId = cargaatualid; 
 VersaoPlanejamento = versaoplanejamento; 
 AlertasResumo = alertasresumo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PedidoId))
   this._erroMensagem.Add("Pedido deve ser informado.");
   if(string.IsNullOrEmpty(ClienteId))
   this._erroMensagem.Add("Cliente deve ser informado.");
   if(string.IsNullOrEmpty(ClienteNome))
   this._erroMensagem.Add("Nome do Cliente deve ser informado.");
   if(string.IsNullOrEmpty(Estado))
   this._erroMensagem.Add("Estado deve ser informado.");
   if(string.IsNullOrEmpty(Municipio))
   this._erroMensagem.Add("Municipio deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration