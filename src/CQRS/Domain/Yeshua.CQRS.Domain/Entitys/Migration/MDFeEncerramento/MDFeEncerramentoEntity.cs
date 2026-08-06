
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class MDFeEncerramentoEntity : IMDFeEncerramentoEntity
{
    public int? Id { get; set; }
    public int MDFeId { get; set; }
    public string ChaveAcesso { get; set; }
    public string UfCarregamento { get; set; }
    public string UfDescarregamento { get; set; }
    public string PlacaVeiculo { get; set; }
    public DateTime SolicitadoEm { get; set; }
    public DateTime? AutorizadoEm { get; set; }
    public string Protocolo { get; set; }
    public string CodigoRetorno { get; set; }
    public string MensagemRetorno { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MDFeEncerramentoEntity(int? id, int mdfeid, string chaveacesso, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime solicitadoem, DateTime? autorizadoem, string protocolo, string codigoretorno, string mensagemretorno ){
 Id = id; 
 MDFeId = mdfeid; 
 ChaveAcesso = chaveacesso; 
 UfCarregamento = ufcarregamento; 
 UfDescarregamento = ufdescarregamento; 
 PlacaVeiculo = placaveiculo; 
 SolicitadoEm = (solicitadoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : solicitadoem; 
 AutorizadoEm = (autorizadoem < (new DateTime(1800, 1, 1))) ? DateTime.Now : autorizadoem; 
 Protocolo = protocolo; 
 CodigoRetorno = codigoretorno; 
 MensagemRetorno = mensagemretorno; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (MDFeId == null)
   this._erroMensagem.Add("MDF-e deve ser informado.");
   if(string.IsNullOrEmpty(ChaveAcesso))
   this._erroMensagem.Add("Chave de Acesso deve ser informado.");
   if(string.IsNullOrEmpty(UfCarregamento))
   this._erroMensagem.Add("UF de Carregamento deve ser informado.");
   if(string.IsNullOrEmpty(UfDescarregamento))
   this._erroMensagem.Add("UF de Descarregamento deve ser informado.");
   if(string.IsNullOrEmpty(PlacaVeiculo))
   this._erroMensagem.Add("Placa do Veiculo deve ser informado.");
   if (SolicitadoEm == null || SolicitadoEm < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Solicitado em deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration