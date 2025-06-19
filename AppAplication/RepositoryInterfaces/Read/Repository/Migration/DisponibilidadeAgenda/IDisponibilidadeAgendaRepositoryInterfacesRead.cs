using Repositorio.Outputs.DTOs.DisponibilidadeAgenda;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda
{
    public interface IDisponibilidadeAgendaReadRepository
    {
        public DataPagination<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(ICommandRead command);
        public DisponibilidadeAgendaDTO getById();
        public IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration