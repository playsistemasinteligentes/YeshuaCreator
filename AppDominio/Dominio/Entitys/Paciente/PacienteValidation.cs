using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entitys.Paciente
{
    public struct PacienteEntity__
    {
        private AutoIncremento Id { get; set; }
        private Nome Name { get; set; }
        private Data Nascimento { get; set; }
        private WhatsApp Whatsapp { get; set; }
    }

}
