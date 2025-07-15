using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.RepositoryInterfaces
{
    public interface IDisponibilidadeAgendaReadRepository
    {
        public DataPagination<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(ICommandRead command);
        public DisponibilidadeAgendaDTO getById();
        public IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(object command);
        public bool ExistsById(int value);
        public bool ExistsByProfissionalId(int value);
        public bool ExistsByDataHora(DateTime value);
        public DisponibilidadeAgendaDTO FirstById(int value);
        public DisponibilidadeAgendaDTO FirstByProfissionalId(int value);
        public DisponibilidadeAgendaDTO FirstByDataHora(DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration