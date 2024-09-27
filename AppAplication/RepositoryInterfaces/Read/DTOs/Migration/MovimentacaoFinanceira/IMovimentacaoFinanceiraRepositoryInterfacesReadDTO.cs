using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.MovimentacaoFinanceira
{
    public struct MovimentacaoFinanceiraDTO
    {
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public int ServicoId { get; set; }
    public Decimal Valor { get; set; }
    public int TipoMovimentacao { get; set; }
    public DateTime DataMovimentacao { get; set; }
    public Decimal SaldoAtual { get; set; }
    }
}
