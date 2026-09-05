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
                    public partial class MDFeEntity : IMDFeEntity
{
    public int? Id { get; set; }
    public string ChaveAcesso { get; set; }
    public int Serie { get; set; }
    public int Numero { get; set; }
    public string UfCarregamento { get; set; }
    public string UfDescarregamento { get; set; }
    public string PlacaVeiculo { get; set; }
    public DateTime EmitidoEm { get; set; }
    public DateTime? AutorizadoEm { get; set; }
    public DateTime? IniciadoEm { get; set; }
    public DateTime? EncerradoEm { get; set; }
    public DateTime? CanceladoEm { get; set; }
    public int Situacao { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MDFeEntity(int? id, string chaveacesso, int serie, int numero, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime emitidoem, DateTime? autorizadoem, DateTime? iniciadoem, DateTime? encerradoem, DateTime? canceladoem, int situacao ){
 Id = id; 
 ChaveAcesso = chaveacesso; 
 Serie = serie; 
 Numero = numero; 
 UfCarregamento = ufcarregamento; 
 UfDescarregamento = ufdescarregamento; 
 PlacaVeiculo = placaveiculo; 
 EmitidoEm = (emitidoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : emitidoem; 
 AutorizadoEm = (autorizadoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : autorizadoem; 
 IniciadoEm = (iniciadoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : iniciadoem; 
 EncerradoEm = (encerradoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : encerradoem; 
 CanceladoEm = (canceladoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : canceladoem; 
 Situacao = situacao; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(ChaveAcesso))
   this._erroMensagem.Add("Chave de Acesso deve ser informado.");
   if(string.IsNullOrEmpty(UfCarregamento))
   this._erroMensagem.Add("UF de Carregamento deve ser informado.");
   if(string.IsNullOrEmpty(UfDescarregamento))
   this._erroMensagem.Add("UF de Descarregamento deve ser informado.");
   if(string.IsNullOrEmpty(PlacaVeiculo))
   this._erroMensagem.Add("Placa do Veiculo deve ser informado.");
   if(EmitidoEm == null || EmitidoEm < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Emitido em deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration