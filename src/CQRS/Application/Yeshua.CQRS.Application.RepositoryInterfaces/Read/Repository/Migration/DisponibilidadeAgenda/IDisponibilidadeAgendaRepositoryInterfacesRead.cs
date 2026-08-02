using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IDisponibilidadeAgendaReadRepository
    {
        public DataPagination<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(ICommandRead command );
        public IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(object command );
        public IEnumerable<DisponibilidadeAgendaTenantIDDTO> getDisponibilidadeAgendaReadFKTenantID(object command );
        public IEnumerable<DisponibilidadeAgendaUserIdDTO> getDisponibilidadeAgendaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByProfissionalId(int value );
        public bool ExistsByDataHora(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public DisponibilidadeAgendaDTO FirstById(int value );
        public DisponibilidadeAgendaDTO FirstByProfissionalId(int value );
        public DisponibilidadeAgendaDTO FirstByDataHora(DateTime value );
        public DisponibilidadeAgendaDTO FirstByTenantID(int value );
        public DisponibilidadeAgendaDTO FirstByDeleted(bool value );
        public DisponibilidadeAgendaDTO FirstByChanged(DateTime value );
        public DisponibilidadeAgendaDTO FirstByUserId(int value );
        public IEnumerable<DisponibilidadeAgendaDTO> GetAllById(int value );
        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByProfissionalId(int value );
        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByDataHora(DateTime value );
        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByTenantID(int value );
        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByDeleted(bool value );
        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration