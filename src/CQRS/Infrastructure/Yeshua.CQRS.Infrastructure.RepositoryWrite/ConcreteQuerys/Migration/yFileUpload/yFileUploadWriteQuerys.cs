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
    public class yFileUploadQueryWrite : QueryBase, IyFileUploadQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yFileUploadQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryFileUploadQuery(IyFileUploadEntity yFileUpload)
        {
            this.Query = $@" INSERT INTO yFileUpload (Type, Status, FilePath, FileSize, EntityType, EntityId, CreatedAt, CompletedAt, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Type, @Status, @FilePath, @FileSize, @EntityType, @EntityId, @CreatedAt, @CompletedAt, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Type = yFileUpload.Type,
                Status = yFileUpload.Status,
                FilePath = yFileUpload.FilePath,
                FileSize = yFileUpload.FileSize,
                EntityType = yFileUpload.EntityType,
                EntityId = yFileUpload.EntityId,
                CreatedAt = yFileUpload.CreatedAt,
                CompletedAt = yFileUpload.CompletedAt,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyFileUploadQuery(IyFileUploadEntity yFileUpload)
        {
            this.Query = $@" UPDATE yFileUpload SET Type = @Type, Status = @Status, FilePath = @FilePath, FileSize = @FileSize, EntityType = @EntityType, EntityId = @EntityId, CreatedAt = @CreatedAt, CompletedAt = @CompletedAt, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = yFileUpload.Type,
                Status = yFileUpload.Status,
                FilePath = yFileUpload.FilePath,
                FileSize = yFileUpload.FileSize,
                EntityType = yFileUpload.EntityType,
                EntityId = yFileUpload.EntityId,
                CreatedAt = yFileUpload.CreatedAt,
                CompletedAt = yFileUpload.CompletedAt,
                Changed = yFileUpload.Changed,
                UserId = _executionContext.UserId,
                Id = yFileUpload.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(int id, string value)
        {
            this.Query = $@" UPDATE yFileUpload SET Type = @Type WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE yFileUpload SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFilePath(int id, string value)
        {
            this.Query = $@" UPDATE yFileUpload SET FilePath = @FilePath WHERE Id = @Id ";
            this.Parameters = new
            {
                FilePath = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFileSize(int id, long value)
        {
            this.Query = $@" UPDATE yFileUpload SET FileSize = @FileSize WHERE Id = @Id ";
            this.Parameters = new
            {
                FileSize = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityType(int id, string value)
        {
            this.Query = $@" UPDATE yFileUpload SET EntityType = @EntityType WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityType = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityId(int id, string value)
        {
            this.Query = $@" UPDATE yFileUpload SET EntityId = @EntityId WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yFileUpload SET CreatedAt = @CreatedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CreatedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCompletedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yFileUpload SET CompletedAt = @CompletedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CompletedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yFileUpload SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yFileUpload SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yFileUpload SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yFileUpload SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyFileUploadQuery(IyFileUploadEntity yFileUpload)
        {
            this.Query = $@" DELETE FROM yFileUpload WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yFileUpload.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration