using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.MovimentacaoFinanceira
{
    public struct MovimentacaoFinanceiraDTO
    {
    public int id { get; set; }
    public int pacienteid { get; set; }
    public int servicoid { get; set; }
    public Decimal valor { get; set; }
    public int tipomovimentacao { get; set; }
    public DateTime datamovimentacao { get; set; }
    public Decimal saldoatual { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration