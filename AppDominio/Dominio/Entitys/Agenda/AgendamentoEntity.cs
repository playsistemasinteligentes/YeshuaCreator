using Dominio.Entitys.Paciente;
using Dominio.TiposPrimitivos;

namespace Dominio.Entitys.Agenda
{
    public struct AgendamentoEntity
    {
        private AgendaEntity Agenda { get; set; }
        private DataHora Inicio { get; set; }
        private DataHora Fim { get; set; } 
        private PacienteEntity Paciente { get; set; }
    }
}
