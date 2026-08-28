// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class ConsultasQueryWrite : QueryBase, IConsultasQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ConsultasQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirConsultasQuery(IConsultasEntity Consultas)
        {
            this.Query = $@" INSERT INTO Consultas (CON_CASAS_DECIMAIS, CON_CONEXAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CON_CASAS_DECIMAIS, @CON_CONEXAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CON_CASAS_DECIMAIS = Consultas.CON_CASAS_DECIMAIS,
                CON_CONEXAO = Consultas.CON_CONEXAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConsultasQuery(IConsultasEntity Consultas)
        {
            this.Query = $@" UPDATE Consultas SET CON_CASAS_DECIMAIS = @CON_CASAS_DECIMAIS, CON_CONEXAO = @CON_CONEXAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CON_CASAS_DECIMAIS = Consultas.CON_CASAS_DECIMAIS,
                CON_CONEXAO = Consultas.CON_CONEXAO,
                Changed = Consultas.Changed,
                UserId = _executionContext.UserId,
                Id = Consultas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_CASAS_DECIMAIS(int id, string value)
        {
            this.Query = $@" UPDATE Consultas SET CON_CASAS_DECIMAIS = @CON_CASAS_DECIMAIS WHERE Id = @Id ";
            this.Parameters = new
            {
                CON_CASAS_DECIMAIS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_CONEXAO(int id, string value)
        {
            this.Query = $@" UPDATE Consultas SET CON_CONEXAO = @CON_CONEXAO WHERE Id = @Id ";
            this.Parameters = new
            {
                CON_CONEXAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Consultas SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Consultas SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Consultas SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Consultas SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteConsultasQuery(IConsultasEntity Consultas)
        {
            this.Query = $@" DELETE FROM Consultas WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Consultas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration