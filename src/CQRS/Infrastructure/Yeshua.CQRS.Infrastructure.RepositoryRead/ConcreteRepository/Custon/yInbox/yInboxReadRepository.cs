using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class yInboxReadRepository : IyInboxReadRepository
    {
        public IEnumerable<yInboxDTO> ClaimRunnableInbox(int limit, DateTime now)
        {
            var sql = @"
                        WITH cte AS (
                            SELECT TOP (@Limit) *
                            FROM yInbox
                            WHERE 
                                Status = @Pending
                                AND TenantID = @TenantID
                            ORDER BY CreatedAt
                        )
                        UPDATE cte
                        SET 
                            Status = @Processing,
                            RetryCount = RetryCount + 1
                        OUTPUT inserted.*";

            var inbox = _unitOfWork.Query<yInboxDTO>(sql, new
            {
                Limit = limit,
                Processing = 3,
                Pending = 0,
                TenantID = _executionContext.TenantID
            }).ToList();

            return inbox;
        }

        public void MarkAsProcessed(int id)
        {
            var sql = @"
                        UPDATE yInbox
                        SET 
                            Status = @Processed,
                            ProcessedAt = @Now
                        WHERE Id = @Id";

            _unitOfWork.Execute(sql, new
            {
                Id = id,
                Processed = 1,
                Now = DateTime.UtcNow
            });
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration