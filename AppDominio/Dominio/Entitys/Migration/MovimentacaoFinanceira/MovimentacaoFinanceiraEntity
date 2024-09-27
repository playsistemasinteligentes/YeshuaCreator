
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
                public int Id { get; set; }
    public int PacienteId { get; set; }
    public int ServicoId { get; set; }
    public Decimal Valor { get; set; }
    public int TipoMovimentacao { get; set; }
    public DateTime DataMovimentacao { get; set; }
    public Decimal SaldoAtual { get; set; }
 public MovimentacaoFinanceiraEntity(int id, int pacienteid, int servicoid, Decimal valor, int tipomovimentacao, DateTime datamovimentacao, Decimal saldoatual ){
 Id = id; 
 PacienteId = pacienteid; 
 ServicoId = servicoid; 
 Valor = valor; 
 TipoMovimentacao = tipomovimentacao; 
 DataMovimentacao = datamovimentacao; 
 SaldoAtual = saldoatual; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }