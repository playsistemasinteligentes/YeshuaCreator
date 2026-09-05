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
    public class TransportadoraQueryWrite : QueryBase, ITransportadoraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TransportadoraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTransportadoraQuery(ITransportadoraEntity Transportadora)
        {
            this.Query = $@" INSERT INTO [Transportadora] ([TRA_ID], [TRA_NOME], [TRA_EMAIL], [TRA_RESPONSAVEL], [TRA_FONE], [TRA_ID_INTEGRACAO], [TRA_ID_INTEGRACAO_ERP], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@TRA_ID, @TRA_NOME, @TRA_EMAIL, @TRA_RESPONSAVEL, @TRA_FONE, @TRA_ID_INTEGRACAO, @TRA_ID_INTEGRACAO_ERP, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TRA_ID = Transportadora.TRA_ID,
                TRA_NOME = Transportadora.TRA_NOME,
                TRA_EMAIL = Transportadora.TRA_EMAIL,
                TRA_RESPONSAVEL = Transportadora.TRA_RESPONSAVEL,
                TRA_FONE = Transportadora.TRA_FONE,
                TRA_ID_INTEGRACAO = Transportadora.TRA_ID_INTEGRACAO,
                TRA_ID_INTEGRACAO_ERP = Transportadora.TRA_ID_INTEGRACAO_ERP,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransportadoraQuery(ITransportadoraEntity Transportadora)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_ID] = @TRA_ID, [TRA_NOME] = @TRA_NOME, [TRA_EMAIL] = @TRA_EMAIL, [TRA_RESPONSAVEL] = @TRA_RESPONSAVEL, [TRA_FONE] = @TRA_FONE, [TRA_ID_INTEGRACAO] = @TRA_ID_INTEGRACAO, [TRA_ID_INTEGRACAO_ERP] = @TRA_ID_INTEGRACAO_ERP, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_ID = Transportadora.TRA_ID,
                TRA_NOME = Transportadora.TRA_NOME,
                TRA_EMAIL = Transportadora.TRA_EMAIL,
                TRA_RESPONSAVEL = Transportadora.TRA_RESPONSAVEL,
                TRA_FONE = Transportadora.TRA_FONE,
                TRA_ID_INTEGRACAO = Transportadora.TRA_ID_INTEGRACAO,
                TRA_ID_INTEGRACAO_ERP = Transportadora.TRA_ID_INTEGRACAO_ERP,
                Changed = Transportadora.Changed,
                UserId = _executionContext.UserId,
                Id = Transportadora.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_ID(int id, string value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_ID] = @TRA_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_NOME(int id, string value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_NOME] = @TRA_NOME WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_NOME = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_EMAIL(int id, string value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_EMAIL] = @TRA_EMAIL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_EMAIL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_RESPONSAVEL(int id, string value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_RESPONSAVEL] = @TRA_RESPONSAVEL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_RESPONSAVEL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_FONE(int id, string value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_FONE] = @TRA_FONE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_FONE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_ID_INTEGRACAO(int id, string value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_ID_INTEGRACAO] = @TRA_ID_INTEGRACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_ID_INTEGRACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_ID_INTEGRACAO_ERP(int id, string value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TRA_ID_INTEGRACAO_ERP] = @TRA_ID_INTEGRACAO_ERP WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_ID_INTEGRACAO_ERP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Transportadora] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTransportadoraQuery(ITransportadoraEntity Transportadora)
        {
            this.Query = $@" DELETE FROM [Transportadora] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Transportadora.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration