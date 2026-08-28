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
    public class OrcamentoQueryWrite : QueryBase, IOrcamentoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OrcamentoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOrcamentoQuery(IOrcamentoEntity Orcamento)
        {
            this.Query = $@" INSERT INTO Orcamento (REP_ID, CON_ID, ORC_TIPO_FRETE, ORC_EMISSAO, CLI_ID, VER_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@REP_ID, @CON_ID, @ORC_TIPO_FRETE, @ORC_EMISSAO, @CLI_ID, @VER_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                REP_ID = Orcamento.REP_ID,
                CON_ID = Orcamento.CON_ID,
                ORC_TIPO_FRETE = Orcamento.ORC_TIPO_FRETE,
                ORC_EMISSAO = Orcamento.ORC_EMISSAO,
                CLI_ID = Orcamento.CLI_ID,
                VER_ID = Orcamento.VER_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrcamentoQuery(IOrcamentoEntity Orcamento)
        {
            this.Query = $@" UPDATE Orcamento SET ORC_ID = @ORC_ID, REP_ID = @REP_ID, CON_ID = @CON_ID, ORC_TIPO_FRETE = @ORC_TIPO_FRETE, ORC_EMISSAO = @ORC_EMISSAO, CLI_ID = @CLI_ID, VER_ID = @VER_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ORC_ID = Orcamento.ORC_ID,
                REP_ID = Orcamento.REP_ID,
                CON_ID = Orcamento.CON_ID,
                ORC_TIPO_FRETE = Orcamento.ORC_TIPO_FRETE,
                ORC_EMISSAO = Orcamento.ORC_EMISSAO,
                CLI_ID = Orcamento.CLI_ID,
                VER_ID = Orcamento.VER_ID,
                Changed = Orcamento.Changed,
                UserId = _executionContext.UserId,
                Id = Orcamento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORC_ID(int id, int value)
        {
            this.Query = $@" UPDATE Orcamento SET ORC_ID = @ORC_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORC_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREP_ID(int id, string value)
        {
            this.Query = $@" UPDATE Orcamento SET REP_ID = @REP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                REP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_ID(int id, string value)
        {
            this.Query = $@" UPDATE Orcamento SET CON_ID = @CON_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CON_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORC_TIPO_FRETE(int id, string value)
        {
            this.Query = $@" UPDATE Orcamento SET ORC_TIPO_FRETE = @ORC_TIPO_FRETE WHERE Id = @Id ";
            this.Parameters = new
            {
                ORC_TIPO_FRETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORC_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Orcamento SET ORC_EMISSAO = @ORC_EMISSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                ORC_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(int id, string value)
        {
            this.Query = $@" UPDATE Orcamento SET CLI_ID = @CLI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CLI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_ID(int id, int value)
        {
            this.Query = $@" UPDATE Orcamento SET VER_ID = @VER_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                VER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Orcamento SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Orcamento SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Orcamento SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Orcamento SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOrcamentoQuery(IOrcamentoEntity Orcamento)
        {
            this.Query = $@" DELETE FROM Orcamento WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Orcamento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration