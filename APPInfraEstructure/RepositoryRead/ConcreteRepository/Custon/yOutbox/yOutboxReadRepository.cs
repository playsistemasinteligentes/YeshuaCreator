using Dapper;
using Newtonsoft.Json.Linq;
using Repositorio.Outputs;
using System.Collections.Generic;
using System.Linq;

namespace Read.Repository
{
    public partial class yOutboxReadRepository
    {
        public IReadOnlyList<int> getToWorker(string tipo, int limite)
        {
            var sql = @" UPDATE TOP (@Limit) yOutbox
                            SET Status = 1 -- Processando
                            OUTPUT INSERTED.Id
                            WHERE Type = @Type
                              AND Status = 0
                              AND Deleted = 0
                        ";

            var result = _connection.Query<int>(sql, new
            {
                Type = tipo,
                Limit = limite
            });

            return result.ToList();
        }
    }
}//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration