using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record MovimentoFinanceiroDTO
    {
    public int id { get; set; }
    public string idorigem { get; set; }
    public int contadebitoid { get; set; }
    public Decimal valor { get; set; }
    public DateTime datamovimento { get; set; }
    public DateTime datavencimento { get; set; }
    public int status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration