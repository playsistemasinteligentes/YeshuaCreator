using Repositorio.Outputs.DTOs.DisponibilidadeAgenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda
{
    public interface IDisponibilidadeAgendaReadRepository
    {
        public IEnumerable<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(object command);
        public DisponibilidadeAgendaDTO getById();
        public IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration