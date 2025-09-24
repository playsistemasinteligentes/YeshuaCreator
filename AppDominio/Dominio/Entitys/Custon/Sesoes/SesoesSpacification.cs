using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entitys.Custon
{
    public class EmConciliacaoDeHorariosSpec : ISpecification<SesoesEntity>
    {
        public string Name => nameof(EmConciliacaoDeHorariosSpec);

        public bool IsSatisfiedBy(SesoesEntity entity)
        {
            return entity.StatusAgendamento == 0 || entity.PacienteId != null && entity.DataFim == null;
        }
    }

    public class ConfirmadaSpec : ISpecification<SesoesEntity>
    {
        public string Name => nameof(ConfirmadaSpec);

        public bool IsSatisfiedBy(SesoesEntity entity)
        {
            return entity.StatusAgendamento == 1;
        }
    }

    public class RealizadaSpec : ISpecification<SesoesEntity>
    {
        public string Name => nameof(RealizadaSpec);

        public bool IsSatisfiedBy(SesoesEntity entity)
        {
            return entity.StatusAgendamento == 2;
        }
    }

    public class CanceladaSpec : ISpecification<SesoesEntity>
    {
        public string Name => nameof(CanceladaSpec);

        public bool IsSatisfiedBy(SesoesEntity entity)
        {
            return entity.StatusAgendamento == 3;
        }
    }

}
