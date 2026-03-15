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
        protected readonly ICurrentUser _currentUser;
        public yFileUploadQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryFileUploadQuery(IyFileUploadEntity yFileUpload)
        {
            this.Query = $@" INSERT INTO yFileUpload (Type, Status, FilePath, FileSize, CreatedAt, CompletedAt, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Type, @Status, @FilePath, @FileSize, @CreatedAt, @CompletedAt, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Type = yFileUpload.Type,
                Status = yFileUpload.Status,
                FilePath = yFileUpload.FilePath,
                FileSize = yFileUpload.FileSize,
                CreatedAt = yFileUpload.CreatedAt,
                CompletedAt = yFileUpload.CompletedAt,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyFileUploadQuery(IyFileUploadEntity yFileUpload)
        {
            this.Query = $@" UPDATE yFileUpload SET Type = @Type, Status = @Status, FilePath = @FilePath, FileSize = @FileSize, CreatedAt = @CreatedAt, CompletedAt = @CompletedAt, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = yFileUpload.Type,
                Status = yFileUpload.Status,
                FilePath = yFileUpload.FilePath,
                FileSize = yFileUpload.FileSize,
                CreatedAt = yFileUpload.CreatedAt,
                CompletedAt = yFileUpload.CompletedAt,
                Changed = yFileUpload.Changed,
                UserId = _currentUser.UserId,
                Id = yFileUpload.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET Type = @Type WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = entity.Type,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = entity.Status,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFilePath(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET FilePath = @FilePath WHERE Id = @Id ";
            this.Parameters = new
            {
                FilePath = entity.FilePath,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFileSize(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET FileSize = @FileSize WHERE Id = @Id ";
            this.Parameters = new
            {
                FileSize = entity.FileSize,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET CreatedAt = @CreatedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCompletedAt(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET CompletedAt = @CompletedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CompletedAt = entity.CompletedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyFileUploadEntity entity)
        {
            this.Query = $@" UPDATE yFileUpload SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
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