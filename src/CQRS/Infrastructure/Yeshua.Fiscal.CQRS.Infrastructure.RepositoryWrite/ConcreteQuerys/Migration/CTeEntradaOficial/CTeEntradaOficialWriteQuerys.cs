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
    public class CTeEntradaOficialQueryWrite : QueryBase, ICTeEntradaOficialQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeEntradaOficialQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeEntradaOficialQuery(ICTeEntradaOficialEntity CTeEntradaOficial)
        {
            this.Query = $@" INSERT INTO [CTeEntradaOficial] ([CorrelationId], [SourceApplication], [SourceModule], [SourceMessageId], [MessageType], [MessageVersion], [ReceivedAtUtc], [PayloadHash], [PayloadStorageKey], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CorrelationId, @SourceApplication, @SourceModule, @SourceMessageId, @MessageType, @MessageVersion, @ReceivedAtUtc, @PayloadHash, @PayloadStorageKey, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CorrelationId = CTeEntradaOficial.CorrelationId,
                SourceApplication = CTeEntradaOficial.SourceApplication,
                SourceModule = CTeEntradaOficial.SourceModule,
                SourceMessageId = CTeEntradaOficial.SourceMessageId,
                MessageType = CTeEntradaOficial.MessageType,
                MessageVersion = CTeEntradaOficial.MessageVersion,
                ReceivedAtUtc = CTeEntradaOficial.ReceivedAtUtc,
                PayloadHash = CTeEntradaOficial.PayloadHash,
                PayloadStorageKey = CTeEntradaOficial.PayloadStorageKey,
                Status = CTeEntradaOficial.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeEntradaOficialQuery(ICTeEntradaOficialEntity CTeEntradaOficial)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [CorrelationId] = @CorrelationId, [SourceApplication] = @SourceApplication, [SourceModule] = @SourceModule, [SourceMessageId] = @SourceMessageId, [MessageType] = @MessageType, [MessageVersion] = @MessageVersion, [ReceivedAtUtc] = @ReceivedAtUtc, [PayloadHash] = @PayloadHash, [PayloadStorageKey] = @PayloadStorageKey, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = CTeEntradaOficial.CorrelationId,
                SourceApplication = CTeEntradaOficial.SourceApplication,
                SourceModule = CTeEntradaOficial.SourceModule,
                SourceMessageId = CTeEntradaOficial.SourceMessageId,
                MessageType = CTeEntradaOficial.MessageType,
                MessageVersion = CTeEntradaOficial.MessageVersion,
                ReceivedAtUtc = CTeEntradaOficial.ReceivedAtUtc,
                PayloadHash = CTeEntradaOficial.PayloadHash,
                PayloadStorageKey = CTeEntradaOficial.PayloadStorageKey,
                Status = CTeEntradaOficial.Status,
                Changed = CTeEntradaOficial.Changed,
                UserId = _executionContext.UserId,
                Id = CTeEntradaOficial.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceApplication(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [SourceApplication] = @SourceApplication WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceApplication = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceModule(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [SourceModule] = @SourceModule WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceModule = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceMessageId(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [SourceMessageId] = @SourceMessageId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceMessageId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMessageType(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [MessageType] = @MessageType WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MessageType = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMessageVersion(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [MessageVersion] = @MessageVersion WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MessageVersion = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateReceivedAtUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [ReceivedAtUtc] = @ReceivedAtUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ReceivedAtUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayloadHash(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [PayloadHash] = @PayloadHash WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PayloadHash = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayloadStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [PayloadStorageKey] = @PayloadStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PayloadStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [CTeEntradaOficial] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeEntradaOficialQuery(ICTeEntradaOficialEntity CTeEntradaOficial)
        {
            this.Query = $@" DELETE FROM [CTeEntradaOficial] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = CTeEntradaOficial.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration