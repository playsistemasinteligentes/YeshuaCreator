
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.MovimentacaoFinanceira
                {
                    public partial class MovimentacaoFinanceiraEntity
                    {
                public int? Id { get; set; }
    public int? PacienteId { get; set; }
    public int? ServicoId { get; set; }
    public Decimal Valor { get; set; }
    public int TipoMovimentacao { get; set; }
    public DateTime DataMovimentacao { get; set; }
    public Decimal SaldoAtual { get; set; }
    private List<string> _erroMensagem = null;
 public MovimentacaoFinanceiraEntity(int? id, int? pacienteid, int? servicoid, Decimal valor, int tipomovimentacao, DateTime datamovimentacao, Decimal saldoatual ){
 Id = id; 
 PacienteId = pacienteid; 
 ServicoId = servicoid; 
 Valor = valor; 
 TipoMovimentacao = tipomovimentacao; 
 DataMovimentacao = (datamovimentacao < (new DateTime(1800, 1, 1))) ? DateTime.Now : datamovimentacao; 
 SaldoAtual = saldoatual; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (Valor == null)
   this._erroMensagem.Add("Valor da Transação deve ser informado.");
   if (TipoMovimentacao == null)
   this._erroMensagem.Add("Tipo de Movimentação deve ser informado.");
   if (DataMovimentacao == null || DataMovimentacao < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Data da Movimentação deve ser informado.");
   if (SaldoAtual == null)
   this._erroMensagem.Add("Saldo Atual deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                public bool isValidInsert()
                {
                    return isValidData();
                }
                public bool isValidUpdate()
                {
                    return isValidData();
                }
                public bool isValidDelete()
                {
                    return true;
                }
                public List<string> getErroMensagens()
                {
                    return this._erroMensagem;
                }
            }
        }//Dominio.Schemas.CQRS.SourceCodeEntityMigration