using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entitys.Proficional
{
    public struct ProficionalEntity
    {
        private AutoIncremento Id { get; set; }
        private Nome Nome { get; set; }

    }
}
