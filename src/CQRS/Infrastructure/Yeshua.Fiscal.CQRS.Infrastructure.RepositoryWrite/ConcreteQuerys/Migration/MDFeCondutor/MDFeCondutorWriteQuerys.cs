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
    public class MDFeCondutorQueryWrite : QueryBase, IMDFeCondutorQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeCondutorQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFeCondutorQuery(IMDFeCondutorEntity MDFeCondutor)
        {
            this.Query = $@" INSERT INTO [MDFeCondutor] ([MDFeSolicitacaoFiscalId], [Nome], [Documento], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@MDFeSolicitacaoFiscalId, @Nome, @Documento, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeCondutor.MDFeSolicitacaoFiscalId,
                Nome = MDFeCondutor.Nome,
                Documento = MDFeCondutor.Documento,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeCondutorQuery(IMDFeCondutorEntity MDFeCondutor)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId, [Nome] = @Nome, [Documento] = @Documento, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeCondutor.MDFeSolicitacaoFiscalId,
                Nome = MDFeCondutor.Nome,
                Documento = MDFeCondutor.Documento,
                Changed = MDFeCondutor.Changed,
                UserId = _executionContext.UserId,
                Id = MDFeCondutor.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [Nome] = @Nome WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [Documento] = @Documento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Documento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeCondutor] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFeCondutorQuery(IMDFeCondutorEntity MDFeCondutor)
        {
            this.Query = $@" DELETE FROM [MDFeCondutor] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MDFeCondutor.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration