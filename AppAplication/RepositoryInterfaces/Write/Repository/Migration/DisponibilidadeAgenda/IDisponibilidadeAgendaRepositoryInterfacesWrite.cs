using Dominio.Entitys.DisponibilidadeAgenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.DisponibilidadeAgenda
{
    public partial interface IDisponibilidadeAgendaWriteRepository
    {
        void Insert(DisponibilidadeAgendaEntity disponibilidadeagenda);
        void Update(DisponibilidadeAgendaEntity disponibilidadeagenda);
        void Delete(DisponibilidadeAgendaEntity disponibilidadeagenda);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration