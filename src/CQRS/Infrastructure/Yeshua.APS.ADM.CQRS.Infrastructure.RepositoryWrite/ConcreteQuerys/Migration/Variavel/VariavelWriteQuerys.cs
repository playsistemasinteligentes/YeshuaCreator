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
    public class VariavelQueryWrite : QueryBase, IVariavelQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public VariavelQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirVariavelQuery(IVariavelEntity Variavel)
        {
            this.Query = $@" INSERT INTO [Variavel] ([VAR_ID], [VAR_DESCRICAO], [CON_ID], [VAR_MODO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@VAR_ID, @VAR_DESCRICAO, @CON_ID, @VAR_MODO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                VAR_ID = Variavel.VAR_ID,
                VAR_DESCRICAO = Variavel.VAR_DESCRICAO,
                CON_ID = Variavel.CON_ID,
                VAR_MODO = Variavel.VAR_MODO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVariavelQuery(IVariavelEntity Variavel)
        {
            this.Query = $@" UPDATE [Variavel] SET [VAR_ID] = @VAR_ID, [VAR_DESCRICAO] = @VAR_DESCRICAO, [CON_ID] = @CON_ID, [VAR_MODO] = @VAR_MODO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VAR_ID = Variavel.VAR_ID,
                VAR_DESCRICAO = Variavel.VAR_DESCRICAO,
                CON_ID = Variavel.CON_ID,
                VAR_MODO = Variavel.VAR_MODO,
                Changed = Variavel.Changed,
                UserId = _executionContext.UserId,
                Id = Variavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVAR_ID(int id, int value)
        {
            this.Query = $@" UPDATE [Variavel] SET [VAR_ID] = @VAR_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVAR_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [Variavel] SET [VAR_DESCRICAO] = @VAR_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VAR_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_ID(int id, int value)
        {
            this.Query = $@" UPDATE [Variavel] SET [CON_ID] = @CON_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVAR_MODO(int id, int value)
        {
            this.Query = $@" UPDATE [Variavel] SET [VAR_MODO] = @VAR_MODO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VAR_MODO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Variavel] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Variavel] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Variavel] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Variavel] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteVariavelQuery(IVariavelEntity Variavel)
        {
            this.Query = $@" DELETE FROM [Variavel] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Variavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration