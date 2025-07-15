using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record DisponibilidadeAgendaDTO
    {
    public int id { get; set; }
    public int profissionalid { get; set; }
    public DateTime datahora { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration