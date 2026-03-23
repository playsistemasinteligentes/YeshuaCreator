using Repositorio.Outputs;
using System.Collections.Generic;

namespace IRepository.Read
{
    public partial interface IyOutboxReadRepository
    {
        IReadOnlyList<int> getToWorker(string tipo, int limite);
    }
}