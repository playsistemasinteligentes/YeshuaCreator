using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.DisponibilidadeAgenda
{
    public partial interface IDisponibilidadeAgendaWriteRepository
    {
        void Insert(IDisponibilidadeAgendaEntity disponibilidadeagenda);
        void Update(IDisponibilidadeAgendaEntity disponibilidadeagenda);
        void Delete(IDisponibilidadeAgendaEntity disponibilidadeagenda);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration