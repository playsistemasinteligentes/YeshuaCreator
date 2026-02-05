
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class MovimentoFinanceiroEntity : IMovimentoFinanceiroEntity
{
    public int? Id { get; set; }
    public string IdOrigem { get; set; }
    public int ContaDebitoId { get; set; }
    public int ContaCreditoId { get; set; }
    public Decimal Valor { get; set; }
    public DateTime DataMovimento { get; set; }
    public DateTime? DataVencimento { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MovimentoFinanceiroEntity(int? id, string idorigem, int contadebitoid, int contacreditoid, Decimal valor, DateTime datamovimento, DateTime? datavencimento, int status ){
 Id = id; 
 IdOrigem = idorigem; 
 ContaDebitoId = contadebitoid; 
 ContaCreditoId = contacreditoid; 
 Valor = valor; 
 DataMovimento = (datamovimento < (new DateTime(1800, 1, 1))) ? DateTime.Now : datamovimento; 
 DataVencimento = (datavencimento < (new DateTime(1800, 1, 1))) ? DateTime.Now : datavencimento; 
 Status = status; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(IdOrigem))
   this._erroMensagem.Add("Identificador de Origem deve ser informado.");
   if (ContaDebitoId == null)
   this._erroMensagem.Add("Conta Débito deve ser informado.");
   if (ContaCreditoId == null)
   this._erroMensagem.Add("Conta Crédito deve ser informado.");
   if (Valor == null)
   this._erroMensagem.Add("Valor do Movimento deve ser informado.");
   if (DataMovimento == null || DataMovimento < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Data do Movimento deve ser informado.");
   if (Status == null)
   this._erroMensagem.Add("Status do Movimento deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration