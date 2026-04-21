using System.Collections.Generic;
using Repositorio.Outputs;

namespace IRepository.Read
{
    public partial interface IySagaReadRepository
    {
        /// <summary>
        /// Busca e trava (claim) sagas prontas para execução
        /// </summary>
        IEnumerable<ySagaDTO> ClaimRunnableSagas(int limit, string workerId);

        /// <summary>
        /// Libera o lock de uma saga
        /// </summary>
        void ReleaseLock(int sagaId, string workerId);

        ySagaDTO GetByCorrelationId(string correlationId);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
