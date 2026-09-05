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
    public class MDFePercursoQueryWrite : QueryBase, IMDFePercursoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFePercursoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFePercursoQuery(IMDFePercursoEntity MDFePercurso)
        {
            this.Query = $@" INSERT INTO [MDFePercurso] ([MDFeSolicitacaoFiscalId], [UF], [Ordem], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@MDFeSolicitacaoFiscalId, @UF, @Ordem, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFePercurso.MDFeSolicitacaoFiscalId,
                UF = MDFePercurso.UF,
                Ordem = MDFePercurso.Ordem,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFePercursoQuery(IMDFePercursoEntity MDFePercurso)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId, [UF] = @UF, [Ordem] = @Ordem, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFePercurso.MDFeSolicitacaoFiscalId,
                UF = MDFePercurso.UF,
                Ordem = MDFePercurso.Ordem,
                Changed = MDFePercurso.Changed,
                UserId = _executionContext.UserId,
                Id = MDFePercurso.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUF(int id, string value)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [UF] = @UF WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UF = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrdem(int id, int value)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [Ordem] = @Ordem WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ordem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFePercurso] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFePercursoQuery(IMDFePercursoEntity MDFePercurso)
        {
            this.Query = $@" DELETE FROM [MDFePercurso] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MDFePercurso.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration