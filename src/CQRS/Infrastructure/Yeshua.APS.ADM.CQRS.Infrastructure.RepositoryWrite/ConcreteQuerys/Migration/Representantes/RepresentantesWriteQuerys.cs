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
    public class RepresentantesQueryWrite : QueryBase, IRepresentantesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RepresentantesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRepresentantesQuery(IRepresentantesEntity Representantes)
        {
            this.Query = $@" INSERT INTO [Representantes] ([REP_ID], [REP_NOME], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@REP_ID, @REP_NOME, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                REP_ID = Representantes.REP_ID,
                REP_NOME = Representantes.REP_NOME,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRepresentantesQuery(IRepresentantesEntity Representantes)
        {
            this.Query = $@" UPDATE [Representantes] SET [REP_ID] = @REP_ID, [REP_NOME] = @REP_NOME, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                REP_ID = Representantes.REP_ID,
                REP_NOME = Representantes.REP_NOME,
                Changed = Representantes.Changed,
                UserId = _executionContext.UserId,
                Id = Representantes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREP_ID(int id, int value)
        {
            this.Query = $@" UPDATE [Representantes] SET [REP_ID] = @REP_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                REP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREP_NOME(int id, string value)
        {
            this.Query = $@" UPDATE [Representantes] SET [REP_NOME] = @REP_NOME WHERE [Id] = @Id ";
            this.Parameters = new
            {
                REP_NOME = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Representantes] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Representantes] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Representantes] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Representantes] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRepresentantesQuery(IRepresentantesEntity Representantes)
        {
            this.Query = $@" DELETE FROM [Representantes] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Representantes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration