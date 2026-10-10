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
    public class FotoQueryWrite : QueryBase, IFotoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public FotoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirFotoQuery(IFotoEntity Foto)
        {
            this.Query = $@" INSERT INTO [Foto] ([StorageKey], [NomeOriginal], [ContentType], [HashArquivo], [CapturadaEmUtc], [Largura], [Altura], [Status], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@StorageKey, @NomeOriginal, @ContentType, @HashArquivo, @CapturadaEmUtc, @Largura, @Altura, @Status, @OperationalEntityId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                StorageKey = Foto.StorageKey,
                NomeOriginal = Foto.NomeOriginal,
                ContentType = Foto.ContentType,
                HashArquivo = Foto.HashArquivo,
                CapturadaEmUtc = Foto.CapturadaEmUtc,
                Largura = Foto.Largura,
                Altura = Foto.Altura,
                Status = Foto.Status,
                OperationalEntityId = Foto.OperationalEntityId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFotoQuery(IFotoEntity Foto)
        {
            this.Query = $@" UPDATE [Foto] SET [StorageKey] = @StorageKey, [NomeOriginal] = @NomeOriginal, [ContentType] = @ContentType, [HashArquivo] = @HashArquivo, [CapturadaEmUtc] = @CapturadaEmUtc, [Largura] = @Largura, [Altura] = @Altura, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                StorageKey = Foto.StorageKey,
                NomeOriginal = Foto.NomeOriginal,
                ContentType = Foto.ContentType,
                HashArquivo = Foto.HashArquivo,
                CapturadaEmUtc = Foto.CapturadaEmUtc,
                Largura = Foto.Largura,
                Altura = Foto.Altura,
                Status = Foto.Status,
                Changed = Foto.Changed,
                UserId = _executionContext.UserId,
                Id = Foto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [Foto] SET [StorageKey] = @StorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                StorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNomeOriginal(int id, string value)
        {
            this.Query = $@" UPDATE [Foto] SET [NomeOriginal] = @NomeOriginal WHERE [Id] = @Id ";
            this.Parameters = new
            {
                NomeOriginal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateContentType(int id, string value)
        {
            this.Query = $@" UPDATE [Foto] SET [ContentType] = @ContentType WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ContentType = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHashArquivo(int id, string value)
        {
            this.Query = $@" UPDATE [Foto] SET [HashArquivo] = @HashArquivo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                HashArquivo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCapturadaEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Foto] SET [CapturadaEmUtc] = @CapturadaEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CapturadaEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLargura(int id, int value)
        {
            this.Query = $@" UPDATE [Foto] SET [Largura] = @Largura WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Largura = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAltura(int id, int value)
        {
            this.Query = $@" UPDATE [Foto] SET [Altura] = @Altura WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Altura = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [Foto] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [Foto] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Foto] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Foto] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Foto] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Foto] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteFotoQuery(IFotoEntity Foto)
        {
            this.Query = $@" DELETE FROM [Foto] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Foto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration