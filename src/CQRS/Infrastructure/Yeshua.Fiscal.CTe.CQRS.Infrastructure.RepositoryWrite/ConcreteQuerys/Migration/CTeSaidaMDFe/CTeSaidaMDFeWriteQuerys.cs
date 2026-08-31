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
    public class CTeSaidaMDFeQueryWrite : QueryBase, ICTeSaidaMDFeQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeSaidaMDFeQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeSaidaMDFeQuery(ICTeSaidaMDFeEntity CTeSaidaMDFe)
        {
            this.Query = $@" INSERT INTO CTeSaidaMDFe (CTeTentativaEmissaoId, CorrelationId, ChaveAcessoCTe, SnapshotHash, OutboxMessageId, PublicadoEmUtc, UltimoErro, Status, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CTeTentativaEmissaoId, @CorrelationId, @ChaveAcessoCTe, @SnapshotHash, @OutboxMessageId, @PublicadoEmUtc, @UltimoErro, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CTeTentativaEmissaoId = CTeSaidaMDFe.CTeTentativaEmissaoId,
                CorrelationId = CTeSaidaMDFe.CorrelationId,
                ChaveAcessoCTe = CTeSaidaMDFe.ChaveAcessoCTe,
                SnapshotHash = CTeSaidaMDFe.SnapshotHash,
                OutboxMessageId = CTeSaidaMDFe.OutboxMessageId,
                PublicadoEmUtc = CTeSaidaMDFe.PublicadoEmUtc,
                UltimoErro = CTeSaidaMDFe.UltimoErro,
                Status = CTeSaidaMDFe.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeSaidaMDFeQuery(ICTeSaidaMDFeEntity CTeSaidaMDFe)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET CTeTentativaEmissaoId = @CTeTentativaEmissaoId, CorrelationId = @CorrelationId, ChaveAcessoCTe = @ChaveAcessoCTe, SnapshotHash = @SnapshotHash, OutboxMessageId = @OutboxMessageId, PublicadoEmUtc = @PublicadoEmUtc, UltimoErro = @UltimoErro, Status = @Status, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeTentativaEmissaoId = CTeSaidaMDFe.CTeTentativaEmissaoId,
                CorrelationId = CTeSaidaMDFe.CorrelationId,
                ChaveAcessoCTe = CTeSaidaMDFe.ChaveAcessoCTe,
                SnapshotHash = CTeSaidaMDFe.SnapshotHash,
                OutboxMessageId = CTeSaidaMDFe.OutboxMessageId,
                PublicadoEmUtc = CTeSaidaMDFe.PublicadoEmUtc,
                UltimoErro = CTeSaidaMDFe.UltimoErro,
                Status = CTeSaidaMDFe.Status,
                Changed = CTeSaidaMDFe.Changed,
                UserId = _executionContext.UserId,
                Id = CTeSaidaMDFe.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeTentativaEmissaoId(int id, int value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET CTeTentativaEmissaoId = @CTeTentativaEmissaoId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeTentativaEmissaoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcessoCTe(int id, string value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET ChaveAcessoCTe = @ChaveAcessoCTe WHERE Id = @Id ";
            this.Parameters = new
            {
                ChaveAcessoCTe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSnapshotHash(int id, string value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET SnapshotHash = @SnapshotHash WHERE Id = @Id ";
            this.Parameters = new
            {
                SnapshotHash = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOutboxMessageId(int id, string value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET OutboxMessageId = @OutboxMessageId WHERE Id = @Id ";
            this.Parameters = new
            {
                OutboxMessageId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePublicadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET PublicadoEmUtc = @PublicadoEmUtc WHERE Id = @Id ";
            this.Parameters = new
            {
                PublicadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUltimoErro(int id, string value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET UltimoErro = @UltimoErro WHERE Id = @Id ";
            this.Parameters = new
            {
                UltimoErro = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE CTeSaidaMDFe SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeSaidaMDFeQuery(ICTeSaidaMDFeEntity CTeSaidaMDFe)
        {
            this.Query = $@" DELETE FROM CTeSaidaMDFe WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = CTeSaidaMDFe.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration