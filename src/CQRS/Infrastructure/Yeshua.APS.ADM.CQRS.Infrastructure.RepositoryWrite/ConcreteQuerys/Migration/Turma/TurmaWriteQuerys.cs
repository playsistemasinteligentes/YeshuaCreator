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
    public class TurmaQueryWrite : QueryBase, ITurmaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TurmaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTurmaQuery(ITurmaEntity Turma)
        {
            this.Query = $@" INSERT INTO [Turma] ([Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@Id, @Descricao, @TURM_HORA_INI_DIA1, @TURM_HORA_FIM_DIA1, @TURM_HORA_INI_DIA2, @TURM_HORA_FIM_DIA2, @TURM_HORA_INI_DIA3, @TURM_HORA_FIM_DIA3, @TURM_HORA_INI_DIA4, @TURM_HORA_FIM_DIA4, @TURM_HORA_INI_DIA5, @TURM_HORA_FIM_DIA5, @TURM_HORA_INI_DIA6, @TURM_HORA_FIM_DIA6, @TURM_HORA_INI_DIA7, @TURM_HORA_FIM_DIA7, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = Turma.Id,
                Descricao = Turma.Descricao,
                TURM_HORA_INI_DIA1 = Turma.TURM_HORA_INI_DIA1,
                TURM_HORA_FIM_DIA1 = Turma.TURM_HORA_FIM_DIA1,
                TURM_HORA_INI_DIA2 = Turma.TURM_HORA_INI_DIA2,
                TURM_HORA_FIM_DIA2 = Turma.TURM_HORA_FIM_DIA2,
                TURM_HORA_INI_DIA3 = Turma.TURM_HORA_INI_DIA3,
                TURM_HORA_FIM_DIA3 = Turma.TURM_HORA_FIM_DIA3,
                TURM_HORA_INI_DIA4 = Turma.TURM_HORA_INI_DIA4,
                TURM_HORA_FIM_DIA4 = Turma.TURM_HORA_FIM_DIA4,
                TURM_HORA_INI_DIA5 = Turma.TURM_HORA_INI_DIA5,
                TURM_HORA_FIM_DIA5 = Turma.TURM_HORA_FIM_DIA5,
                TURM_HORA_INI_DIA6 = Turma.TURM_HORA_INI_DIA6,
                TURM_HORA_FIM_DIA6 = Turma.TURM_HORA_FIM_DIA6,
                TURM_HORA_INI_DIA7 = Turma.TURM_HORA_INI_DIA7,
                TURM_HORA_FIM_DIA7 = Turma.TURM_HORA_FIM_DIA7,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurmaQuery(ITurmaEntity Turma)
        {
            this.Query = $@" UPDATE [Turma] SET [Descricao] = @Descricao, [TURM_HORA_INI_DIA1] = @TURM_HORA_INI_DIA1, [TURM_HORA_FIM_DIA1] = @TURM_HORA_FIM_DIA1, [TURM_HORA_INI_DIA2] = @TURM_HORA_INI_DIA2, [TURM_HORA_FIM_DIA2] = @TURM_HORA_FIM_DIA2, [TURM_HORA_INI_DIA3] = @TURM_HORA_INI_DIA3, [TURM_HORA_FIM_DIA3] = @TURM_HORA_FIM_DIA3, [TURM_HORA_INI_DIA4] = @TURM_HORA_INI_DIA4, [TURM_HORA_FIM_DIA4] = @TURM_HORA_FIM_DIA4, [TURM_HORA_INI_DIA5] = @TURM_HORA_INI_DIA5, [TURM_HORA_FIM_DIA5] = @TURM_HORA_FIM_DIA5, [TURM_HORA_INI_DIA6] = @TURM_HORA_INI_DIA6, [TURM_HORA_FIM_DIA6] = @TURM_HORA_FIM_DIA6, [TURM_HORA_INI_DIA7] = @TURM_HORA_INI_DIA7, [TURM_HORA_FIM_DIA7] = @TURM_HORA_FIM_DIA7, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Descricao = Turma.Descricao,
                TURM_HORA_INI_DIA1 = Turma.TURM_HORA_INI_DIA1,
                TURM_HORA_FIM_DIA1 = Turma.TURM_HORA_FIM_DIA1,
                TURM_HORA_INI_DIA2 = Turma.TURM_HORA_INI_DIA2,
                TURM_HORA_FIM_DIA2 = Turma.TURM_HORA_FIM_DIA2,
                TURM_HORA_INI_DIA3 = Turma.TURM_HORA_INI_DIA3,
                TURM_HORA_FIM_DIA3 = Turma.TURM_HORA_FIM_DIA3,
                TURM_HORA_INI_DIA4 = Turma.TURM_HORA_INI_DIA4,
                TURM_HORA_FIM_DIA4 = Turma.TURM_HORA_FIM_DIA4,
                TURM_HORA_INI_DIA5 = Turma.TURM_HORA_INI_DIA5,
                TURM_HORA_FIM_DIA5 = Turma.TURM_HORA_FIM_DIA5,
                TURM_HORA_INI_DIA6 = Turma.TURM_HORA_INI_DIA6,
                TURM_HORA_FIM_DIA6 = Turma.TURM_HORA_FIM_DIA6,
                TURM_HORA_INI_DIA7 = Turma.TURM_HORA_INI_DIA7,
                TURM_HORA_FIM_DIA7 = Turma.TURM_HORA_FIM_DIA7,
                Changed = Turma.Changed,
                UserId = _executionContext.UserId,
                Id = Turma.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(string id, string value)
        {
            this.Query = $@" UPDATE [Turma] SET [Descricao] = @Descricao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_INI_DIA1(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_INI_DIA1] = @TURM_HORA_INI_DIA1 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_INI_DIA1 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_FIM_DIA1(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_FIM_DIA1] = @TURM_HORA_FIM_DIA1 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_FIM_DIA1 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_INI_DIA2(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_INI_DIA2] = @TURM_HORA_INI_DIA2 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_INI_DIA2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_FIM_DIA2(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_FIM_DIA2] = @TURM_HORA_FIM_DIA2 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_FIM_DIA2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_INI_DIA3(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_INI_DIA3] = @TURM_HORA_INI_DIA3 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_INI_DIA3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_FIM_DIA3(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_FIM_DIA3] = @TURM_HORA_FIM_DIA3 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_FIM_DIA3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_INI_DIA4(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_INI_DIA4] = @TURM_HORA_INI_DIA4 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_INI_DIA4 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_FIM_DIA4(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_FIM_DIA4] = @TURM_HORA_FIM_DIA4 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_FIM_DIA4 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_INI_DIA5(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_INI_DIA5] = @TURM_HORA_INI_DIA5 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_INI_DIA5 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_FIM_DIA5(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_FIM_DIA5] = @TURM_HORA_FIM_DIA5 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_FIM_DIA5 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_INI_DIA6(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_INI_DIA6] = @TURM_HORA_INI_DIA6 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_INI_DIA6 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_FIM_DIA6(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_FIM_DIA6] = @TURM_HORA_FIM_DIA6 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_FIM_DIA6 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_INI_DIA7(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_INI_DIA7] = @TURM_HORA_INI_DIA7 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_INI_DIA7 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_HORA_FIM_DIA7(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [TURM_HORA_FIM_DIA7] = @TURM_HORA_FIM_DIA7 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURM_HORA_FIM_DIA7 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string id, int value)
        {
            this.Query = $@" UPDATE [Turma] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string id, bool value)
        {
            this.Query = $@" UPDATE [Turma] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turma] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string id, int value)
        {
            this.Query = $@" UPDATE [Turma] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTurmaQuery(ITurmaEntity Turma)
        {
            this.Query = $@" DELETE FROM [Turma] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Turma.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration