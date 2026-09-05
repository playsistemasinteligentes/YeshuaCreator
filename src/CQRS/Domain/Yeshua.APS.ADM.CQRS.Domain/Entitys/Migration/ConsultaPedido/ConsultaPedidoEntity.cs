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
                    public partial class ConsultaPedidoEntity : IConsultaPedidoEntity
{
    public string PedidoId { get; set; }
    public string ClienteId { get; set; }
    public string ClienteNome { get; set; }
    public string RazaoSocial { get; set; }
    public string ProdutoId { get; set; }
    public string ProdutoDescricao { get; set; }
    public string Status { get; set; }
    public string Estagio { get; set; }
    public DateTime DataEntregaDe { get; set; }
    public DateTime DataEntregaAte { get; set; }
    public DateTime? EmbarqueAlvo { get; set; }
    public Decimal Quantidade { get; set; }
    public Decimal SaldoAProduzir { get; set; }
    public Decimal? SaldoAExpedir { get; set; }
    public string CorFila { get; set; }
    public string PedidoCliente { get; set; }
    private List<string> _erroMensagem = null;
 internal ConsultaPedidoEntity(string pedidoid, string clienteid, string clientenome, string razaosocial, string produtoid, string produtodescricao, string status, string estagio, DateTime dataentregade, DateTime dataentregaate, DateTime? embarquealvo, Decimal quantidade, Decimal saldoaproduzir, Decimal? saldoaexpedir, string corfila, string pedidocliente ){
 PedidoId = pedidoid; 
 ClienteId = clienteid; 
 ClienteNome = clientenome; 
 RazaoSocial = razaosocial; 
 ProdutoId = produtoid; 
 ProdutoDescricao = produtodescricao; 
 Status = status; 
 Estagio = estagio; 
 DataEntregaDe = (dataentregade < (new DateTime(1800, 1, 1))) ? DateTime.Now : dataentregade; 
 DataEntregaAte = (dataentregaate < (new DateTime(1800, 1, 1))) ? DateTime.Now : dataentregaate; 
 EmbarqueAlvo = (embarquealvo < (new DateTime(1800, 1, 1))) ? DateTime.Now : embarquealvo; 
 Quantidade = quantidade; 
 SaldoAProduzir = saldoaproduzir; 
 SaldoAExpedir = saldoaexpedir; 
 CorFila = corfila; 
 PedidoCliente = pedidocliente; 
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
   if(string.IsNullOrEmpty(ProdutoId))
   this._erroMensagem.Add("Produto deve ser informado.");
   if(string.IsNullOrEmpty(ProdutoDescricao))
   this._erroMensagem.Add("Descricao do Produto deve ser informado.");
   if(string.IsNullOrEmpty(Estagio))
   this._erroMensagem.Add("Estagio deve ser informado.");
   if(DataEntregaDe == null || DataEntregaDe < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Entrega de deve ser informado.");
   if(DataEntregaAte == null || DataEntregaAte < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Entrega ate deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration