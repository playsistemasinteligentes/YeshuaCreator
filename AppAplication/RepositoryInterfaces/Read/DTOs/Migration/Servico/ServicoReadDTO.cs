using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Servico
{
    public struct ServicoDTO
    {
    public int id { get; set; }
    public int gruposervicoid { get; set; }
    public string nome { get; set; }
    public Decimal valor { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration