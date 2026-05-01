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
        void UpdateProfissionalId(int id, int value);
        void UpdateDataHora(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration