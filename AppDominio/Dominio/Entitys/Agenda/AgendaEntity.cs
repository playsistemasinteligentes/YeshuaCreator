using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entitys.Agenda
{
    public struct AgendaEntity
    {
        private AutoIncremento Id { get; set; }
        private List<AgendamentoEntity> Agenda { get;}
    }
}
