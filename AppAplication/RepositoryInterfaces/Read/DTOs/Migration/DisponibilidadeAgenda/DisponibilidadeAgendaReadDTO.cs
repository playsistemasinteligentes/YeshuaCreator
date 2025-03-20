using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.DisponibilidadeAgenda
{
    public struct DisponibilidadeAgendaDTO
    {
    public int id { get; set; }
    public int profissionalid { get; set; }
    public DateTime datahora { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration