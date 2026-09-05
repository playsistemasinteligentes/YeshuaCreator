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
    public class ProtocoloOnduladeiraQueryWrite : QueryBase, IProtocoloOnduladeiraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ProtocoloOnduladeiraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirProtocoloOnduladeiraQuery(IProtocoloOnduladeiraEntity ProtocoloOnduladeira)
        {
            this.Query = $@" INSERT INTO [ProtocoloOnduladeira] ([PTO_ID], [PTO_CHAVE], [MAQ_ID], [PTO_COMANDO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@PTO_ID, @PTO_CHAVE, @MAQ_ID, @PTO_COMANDO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PTO_ID = ProtocoloOnduladeira.PTO_ID,
                PTO_CHAVE = ProtocoloOnduladeira.PTO_CHAVE,
                MAQ_ID = ProtocoloOnduladeira.MAQ_ID,
                PTO_COMANDO = ProtocoloOnduladeira.PTO_COMANDO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProtocoloOnduladeiraQuery(IProtocoloOnduladeiraEntity ProtocoloOnduladeira)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [PTO_ID] = @PTO_ID, [PTO_CHAVE] = @PTO_CHAVE, [MAQ_ID] = @MAQ_ID, [PTO_COMANDO] = @PTO_COMANDO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PTO_ID = ProtocoloOnduladeira.PTO_ID,
                PTO_CHAVE = ProtocoloOnduladeira.PTO_CHAVE,
                MAQ_ID = ProtocoloOnduladeira.MAQ_ID,
                PTO_COMANDO = ProtocoloOnduladeira.PTO_COMANDO,
                Changed = ProtocoloOnduladeira.Changed,
                UserId = _executionContext.UserId,
                Id = ProtocoloOnduladeira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePTO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [PTO_ID] = @PTO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PTO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePTO_CHAVE(int id, string value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [PTO_CHAVE] = @PTO_CHAVE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PTO_CHAVE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [MAQ_ID] = @MAQ_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePTO_COMANDO(int id, string value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [PTO_COMANDO] = @PTO_COMANDO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PTO_COMANDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ProtocoloOnduladeira] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteProtocoloOnduladeiraQuery(IProtocoloOnduladeiraEntity ProtocoloOnduladeira)
        {
            this.Query = $@" DELETE FROM [ProtocoloOnduladeira] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ProtocoloOnduladeira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration