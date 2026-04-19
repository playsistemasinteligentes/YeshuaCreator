using Dominio.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Saga
{
    public class PsychologyStep : SagaStepBase
    {
        public PsychologyStep(string key) : base(key) { }
    }
}
