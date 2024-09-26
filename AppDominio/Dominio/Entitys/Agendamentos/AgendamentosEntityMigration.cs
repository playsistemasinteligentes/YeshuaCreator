
using System;
using Dominio.TiposPrimitivos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entitys.Agendamentos
{
    public partial class AgendamentosEntity
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set; }
        public int ServicoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; }
        public AgendamentosEntity(int id, int pacienteid, int profissionalid, int servicoid, DateTime datahora, string status)
        {
            Id = id;
            PacienteId = pacienteid;
            ProfissionalId = profissionalid;
            ServicoId = servicoid;
            DataHora = datahora;
            Status = status;
        }

        public bool isValid()
        {
            return true;
        }
    }
}