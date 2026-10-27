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
    public class RevisaoRegistroSessaoQueryWrite : QueryBase, IRevisaoRegistroSessaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RevisaoRegistroSessaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRevisaoRegistroSessaoQuery(IRevisaoRegistroSessaoEntity RevisaoRegistroSessao)
        {
            this.Query = $@" INSERT INTO [RevisaoRegistroSessao] ([SessaoId], [Versao], [AutorUserId], [RevisadoEm], [Motivo], [Registro], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId]) OUTPUT INSERTED.[Id] VALUES(@SessaoId, @Versao, @AutorUserId, @RevisadoEm, @Motivo, @Registro, @TenantID, @Deleted, @Changed, @UserId, @OperationalEntityId) ";
            this.Parameters = new
            {
                SessaoId = RevisaoRegistroSessao.SessaoId,
                Versao = RevisaoRegistroSessao.Versao,
                AutorUserId = RevisaoRegistroSessao.AutorUserId,
                RevisadoEm = RevisaoRegistroSessao.RevisadoEm,
                Motivo = RevisaoRegistroSessao.Motivo,
                Registro = RevisaoRegistroSessao.Registro,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                OperationalEntityId = RevisaoRegistroSessao.OperationalEntityId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRevisaoRegistroSessaoQuery(IRevisaoRegistroSessaoEntity RevisaoRegistroSessao)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [SessaoId] = @SessaoId, [Versao] = @Versao, [AutorUserId] = @AutorUserId, [RevisadoEm] = @RevisadoEm, [Motivo] = @Motivo, [Registro] = @Registro, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SessaoId = RevisaoRegistroSessao.SessaoId,
                Versao = RevisaoRegistroSessao.Versao,
                AutorUserId = RevisaoRegistroSessao.AutorUserId,
                RevisadoEm = RevisaoRegistroSessao.RevisadoEm,
                Motivo = RevisaoRegistroSessao.Motivo,
                Registro = RevisaoRegistroSessao.Registro,
                Changed = RevisaoRegistroSessao.Changed,
                UserId = _executionContext.UserId,
                Id = RevisaoRegistroSessao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSessaoId(int id, int value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [SessaoId] = @SessaoId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SessaoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVersao(int id, int value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [Versao] = @Versao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Versao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAutorUserId(int id, int value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [AutorUserId] = @AutorUserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AutorUserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRevisadoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [RevisadoEm] = @RevisadoEm WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RevisadoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMotivo(int id, string value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [Motivo] = @Motivo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Motivo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRegistro(int id, string value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [Registro] = @Registro WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Registro = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [RevisaoRegistroSessao] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRevisaoRegistroSessaoQuery(IRevisaoRegistroSessaoEntity RevisaoRegistroSessao)
        {
            this.Query = $@" DELETE FROM [RevisaoRegistroSessao] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = RevisaoRegistroSessao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration