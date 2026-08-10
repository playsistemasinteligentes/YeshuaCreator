// pendencia: definir a geracao compartilhada deste repository interno para todos os aplicativos do Studio.
using Aplication.Interfaces.Services;
using IQuery.Read;
using IRepository.Read;
using Repositorio.Outputs;
using System.Collections.Generic;

namespace Read.Repository
{
    public partial class ySagaStepReadRepository 
    {
        public void SetPendingApply()
        {
            var sql = @"
                    BEGIN TRAN

                    UPDATE s
                    SET s.Status = 4, s.Payload = i.Payload
                    FROM ySagaStep s
                    INNER JOIN yInbox i ON i.CorrelationId = s.CorrelationId
                    WHERE i.Status = 0;

                    UPDATE i
                    SET i.Status = 1
                    FROM yInbox i
                    INNER JOIN ySagaStep s ON s.CorrelationId = i.CorrelationId
                    WHERE s.Status = 4 and i.Status = 0;

                    COMMIT";

            _unitOfWork.Execute(sql);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
