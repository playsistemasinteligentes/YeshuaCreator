using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IDisponibilidadeAgendaWriteRepository
    {
        void Insert(IDisponibilidadeAgendaEntity disponibilidadeagenda);
        void Update(IDisponibilidadeAgendaEntity disponibilidadeagenda);
        void Delete(IDisponibilidadeAgendaEntity disponibilidadeagenda);
        public void UpdateProfissionalId(IDisponibilidadeAgendaEntity entity);
        public void UpdateDataHora(IDisponibilidadeAgendaEntity entity);
        public void UpdateTenantID(IDisponibilidadeAgendaEntity entity);
        public void UpdateDeleted(IDisponibilidadeAgendaEntity entity);
        public void UpdateChanged(IDisponibilidadeAgendaEntity entity);
        public void UpdateUserId(IDisponibilidadeAgendaEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration