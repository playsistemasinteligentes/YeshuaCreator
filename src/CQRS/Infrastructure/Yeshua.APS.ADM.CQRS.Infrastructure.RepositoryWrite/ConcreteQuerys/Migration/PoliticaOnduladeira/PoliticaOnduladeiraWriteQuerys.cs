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
    public class PoliticaOnduladeiraQueryWrite : QueryBase, IPoliticaOnduladeiraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PoliticaOnduladeiraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPoliticaOnduladeiraQuery(IPoliticaOnduladeiraEntity PoliticaOnduladeira)
        {
            this.Query = $@" INSERT INTO [PoliticaOnduladeira] ([POL_ID], [POL_NIVEL], [POL_PROMOCAO], [POL_DIAS_ANTECIPACAO], [POL_METROS_LINEARES], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@POL_ID, @POL_NIVEL, @POL_PROMOCAO, @POL_DIAS_ANTECIPACAO, @POL_METROS_LINEARES, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                POL_ID = PoliticaOnduladeira.POL_ID,
                POL_NIVEL = PoliticaOnduladeira.POL_NIVEL,
                POL_PROMOCAO = PoliticaOnduladeira.POL_PROMOCAO,
                POL_DIAS_ANTECIPACAO = PoliticaOnduladeira.POL_DIAS_ANTECIPACAO,
                POL_METROS_LINEARES = PoliticaOnduladeira.POL_METROS_LINEARES,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePoliticaOnduladeiraQuery(IPoliticaOnduladeiraEntity PoliticaOnduladeira)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [POL_ID] = @POL_ID, [POL_NIVEL] = @POL_NIVEL, [POL_PROMOCAO] = @POL_PROMOCAO, [POL_DIAS_ANTECIPACAO] = @POL_DIAS_ANTECIPACAO, [POL_METROS_LINEARES] = @POL_METROS_LINEARES, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                POL_ID = PoliticaOnduladeira.POL_ID,
                POL_NIVEL = PoliticaOnduladeira.POL_NIVEL,
                POL_PROMOCAO = PoliticaOnduladeira.POL_PROMOCAO,
                POL_DIAS_ANTECIPACAO = PoliticaOnduladeira.POL_DIAS_ANTECIPACAO,
                POL_METROS_LINEARES = PoliticaOnduladeira.POL_METROS_LINEARES,
                Changed = PoliticaOnduladeira.Changed,
                UserId = _executionContext.UserId,
                Id = PoliticaOnduladeira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePOL_ID(int id, int value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [POL_ID] = @POL_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                POL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePOL_NIVEL(int id, int value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [POL_NIVEL] = @POL_NIVEL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                POL_NIVEL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePOL_PROMOCAO(int id, int value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [POL_PROMOCAO] = @POL_PROMOCAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                POL_PROMOCAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePOL_DIAS_ANTECIPACAO(int id, int value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [POL_DIAS_ANTECIPACAO] = @POL_DIAS_ANTECIPACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                POL_DIAS_ANTECIPACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePOL_METROS_LINEARES(int id, int value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [POL_METROS_LINEARES] = @POL_METROS_LINEARES WHERE [Id] = @Id ";
            this.Parameters = new
            {
                POL_METROS_LINEARES = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [PoliticaOnduladeira] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePoliticaOnduladeiraQuery(IPoliticaOnduladeiraEntity PoliticaOnduladeira)
        {
            this.Query = $@" DELETE FROM [PoliticaOnduladeira] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = PoliticaOnduladeira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration