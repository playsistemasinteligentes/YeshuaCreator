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
    public class CertificadoDigitalQueryWrite : QueryBase, ICertificadoDigitalQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CertificadoDigitalQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCertificadoDigitalQuery(ICertificadoDigitalEntity CertificadoDigital)
        {
            this.Query = $@" INSERT INTO [CertificadoDigital] ([Apelido], [DocumentoTitular], [StorageKey], [Thumbprint], [ValidoDe], [ValidoAte], [Ativo], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@Apelido, @DocumentoTitular, @StorageKey, @Thumbprint, @ValidoDe, @ValidoAte, @Ativo, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Apelido = CertificadoDigital.Apelido,
                DocumentoTitular = CertificadoDigital.DocumentoTitular,
                StorageKey = CertificadoDigital.StorageKey,
                Thumbprint = CertificadoDigital.Thumbprint,
                ValidoDe = CertificadoDigital.ValidoDe,
                ValidoAte = CertificadoDigital.ValidoAte,
                Ativo = CertificadoDigital.Ativo,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCertificadoDigitalQuery(ICertificadoDigitalEntity CertificadoDigital)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [Apelido] = @Apelido, [DocumentoTitular] = @DocumentoTitular, [StorageKey] = @StorageKey, [Thumbprint] = @Thumbprint, [ValidoDe] = @ValidoDe, [ValidoAte] = @ValidoAte, [Ativo] = @Ativo, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Apelido = CertificadoDigital.Apelido,
                DocumentoTitular = CertificadoDigital.DocumentoTitular,
                StorageKey = CertificadoDigital.StorageKey,
                Thumbprint = CertificadoDigital.Thumbprint,
                ValidoDe = CertificadoDigital.ValidoDe,
                ValidoAte = CertificadoDigital.ValidoAte,
                Ativo = CertificadoDigital.Ativo,
                Changed = CertificadoDigital.Changed,
                UserId = _executionContext.UserId,
                Id = CertificadoDigital.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateApelido(int id, string value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [Apelido] = @Apelido WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Apelido = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoTitular(int id, string value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [DocumentoTitular] = @DocumentoTitular WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoTitular = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [StorageKey] = @StorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                StorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateThumbprint(int id, string value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [Thumbprint] = @Thumbprint WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Thumbprint = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidoDe(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [ValidoDe] = @ValidoDe WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidoDe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidoAte(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [ValidoAte] = @ValidoAte WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidoAte = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAtivo(int id, int value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [Ativo] = @Ativo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ativo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [CertificadoDigital] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCertificadoDigitalQuery(ICertificadoDigitalEntity CertificadoDigital)
        {
            this.Query = $@" DELETE FROM [CertificadoDigital] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = CertificadoDigital.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration