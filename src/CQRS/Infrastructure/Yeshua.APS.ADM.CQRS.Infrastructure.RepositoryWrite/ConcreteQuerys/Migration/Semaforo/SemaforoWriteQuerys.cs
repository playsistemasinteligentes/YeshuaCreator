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
    public class SemaforoQueryWrite : QueryBase, ISemaforoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public SemaforoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirSemaforoQuery(ISemaforoEntity Semaforo)
        {
            this.Query = $@" INSERT INTO [Semaforo] ([SEM_ID], [SEM_STATUS], [SEM_ORIGEM], [SEM_EMISSAO], [SEM_ID_CONEXAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@SEM_ID, @SEM_STATUS, @SEM_ORIGEM, @SEM_EMISSAO, @SEM_ID_CONEXAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                SEM_ID = Semaforo.SEM_ID,
                SEM_STATUS = Semaforo.SEM_STATUS,
                SEM_ORIGEM = Semaforo.SEM_ORIGEM,
                SEM_EMISSAO = Semaforo.SEM_EMISSAO,
                SEM_ID_CONEXAO = Semaforo.SEM_ID_CONEXAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSemaforoQuery(ISemaforoEntity Semaforo)
        {
            this.Query = $@" UPDATE [Semaforo] SET [SEM_ID] = @SEM_ID, [SEM_STATUS] = @SEM_STATUS, [SEM_ORIGEM] = @SEM_ORIGEM, [SEM_EMISSAO] = @SEM_EMISSAO, [SEM_ID_CONEXAO] = @SEM_ID_CONEXAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SEM_ID = Semaforo.SEM_ID,
                SEM_STATUS = Semaforo.SEM_STATUS,
                SEM_ORIGEM = Semaforo.SEM_ORIGEM,
                SEM_EMISSAO = Semaforo.SEM_EMISSAO,
                SEM_ID_CONEXAO = Semaforo.SEM_ID_CONEXAO,
                Changed = Semaforo.Changed,
                UserId = _executionContext.UserId,
                Id = Semaforo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEM_ID(int id, string value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [SEM_ID] = @SEM_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SEM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEM_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [SEM_STATUS] = @SEM_STATUS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SEM_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEM_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [SEM_ORIGEM] = @SEM_ORIGEM WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SEM_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEM_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [SEM_EMISSAO] = @SEM_EMISSAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SEM_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEM_ID_CONEXAO(int id, string value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [SEM_ID_CONEXAO] = @SEM_ID_CONEXAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SEM_ID_CONEXAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Semaforo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteSemaforoQuery(ISemaforoEntity Semaforo)
        {
            this.Query = $@" DELETE FROM [Semaforo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Semaforo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration