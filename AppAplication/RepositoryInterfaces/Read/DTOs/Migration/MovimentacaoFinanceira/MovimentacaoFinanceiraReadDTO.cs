using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record MovimentacaoFinanceiraDTO
    {
    public int id { get; set; }
    public int pacienteid { get; set; }
    public int servicoid { get; set; }
    public Decimal valor { get; set; }
    public int tipomovimentacao { get; set; }
    public DateTime datamovimentacao { get; set; }
    public Decimal saldoatual { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration