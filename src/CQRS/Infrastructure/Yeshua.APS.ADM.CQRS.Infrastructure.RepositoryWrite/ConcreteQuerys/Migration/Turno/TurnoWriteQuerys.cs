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
    public class TurnoQueryWrite : QueryBase, ITurnoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TurnoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTurnoQuery(ITurnoEntity Turno)
        {
            this.Query = $@" INSERT INTO [Turno] ([Id], [Descricao], [TURN_PRIORIDADE], [TURN_HORA_INI_DIA1], [TURN_HORA_FIM_DIA1], [TURN_HORA_INI_DIA2], [TURN_HORA_FIM_DIA2], [TURN_HORA_INI_DIA3], [TURN_HORA_FIM_DIA3], [TURN_HORA_INI_DIA4], [TURN_HORA_FIM_DIA4], [TURN_HORA_INI_DIA5], [TURN_HORA_FIM_DIA5], [TURN_HORA_INI_DIA6], [TURN_HORA_FIM_DIA6], [TURN_HORA_INI_DIA7], [TURN_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@Id, @Descricao, @TURN_PRIORIDADE, @TURN_HORA_INI_DIA1, @TURN_HORA_FIM_DIA1, @TURN_HORA_INI_DIA2, @TURN_HORA_FIM_DIA2, @TURN_HORA_INI_DIA3, @TURN_HORA_FIM_DIA3, @TURN_HORA_INI_DIA4, @TURN_HORA_FIM_DIA4, @TURN_HORA_INI_DIA5, @TURN_HORA_FIM_DIA5, @TURN_HORA_INI_DIA6, @TURN_HORA_FIM_DIA6, @TURN_HORA_INI_DIA7, @TURN_HORA_FIM_DIA7, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = Turno.Id,
                Descricao = Turno.Descricao,
                TURN_PRIORIDADE = Turno.TURN_PRIORIDADE,
                TURN_HORA_INI_DIA1 = Turno.TURN_HORA_INI_DIA1,
                TURN_HORA_FIM_DIA1 = Turno.TURN_HORA_FIM_DIA1,
                TURN_HORA_INI_DIA2 = Turno.TURN_HORA_INI_DIA2,
                TURN_HORA_FIM_DIA2 = Turno.TURN_HORA_FIM_DIA2,
                TURN_HORA_INI_DIA3 = Turno.TURN_HORA_INI_DIA3,
                TURN_HORA_FIM_DIA3 = Turno.TURN_HORA_FIM_DIA3,
                TURN_HORA_INI_DIA4 = Turno.TURN_HORA_INI_DIA4,
                TURN_HORA_FIM_DIA4 = Turno.TURN_HORA_FIM_DIA4,
                TURN_HORA_INI_DIA5 = Turno.TURN_HORA_INI_DIA5,
                TURN_HORA_FIM_DIA5 = Turno.TURN_HORA_FIM_DIA5,
                TURN_HORA_INI_DIA6 = Turno.TURN_HORA_INI_DIA6,
                TURN_HORA_FIM_DIA6 = Turno.TURN_HORA_FIM_DIA6,
                TURN_HORA_INI_DIA7 = Turno.TURN_HORA_INI_DIA7,
                TURN_HORA_FIM_DIA7 = Turno.TURN_HORA_FIM_DIA7,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurnoQuery(ITurnoEntity Turno)
        {
            this.Query = $@" UPDATE [Turno] SET [Descricao] = @Descricao, [TURN_PRIORIDADE] = @TURN_PRIORIDADE, [TURN_HORA_INI_DIA1] = @TURN_HORA_INI_DIA1, [TURN_HORA_FIM_DIA1] = @TURN_HORA_FIM_DIA1, [TURN_HORA_INI_DIA2] = @TURN_HORA_INI_DIA2, [TURN_HORA_FIM_DIA2] = @TURN_HORA_FIM_DIA2, [TURN_HORA_INI_DIA3] = @TURN_HORA_INI_DIA3, [TURN_HORA_FIM_DIA3] = @TURN_HORA_FIM_DIA3, [TURN_HORA_INI_DIA4] = @TURN_HORA_INI_DIA4, [TURN_HORA_FIM_DIA4] = @TURN_HORA_FIM_DIA4, [TURN_HORA_INI_DIA5] = @TURN_HORA_INI_DIA5, [TURN_HORA_FIM_DIA5] = @TURN_HORA_FIM_DIA5, [TURN_HORA_INI_DIA6] = @TURN_HORA_INI_DIA6, [TURN_HORA_FIM_DIA6] = @TURN_HORA_FIM_DIA6, [TURN_HORA_INI_DIA7] = @TURN_HORA_INI_DIA7, [TURN_HORA_FIM_DIA7] = @TURN_HORA_FIM_DIA7, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Descricao = Turno.Descricao,
                TURN_PRIORIDADE = Turno.TURN_PRIORIDADE,
                TURN_HORA_INI_DIA1 = Turno.TURN_HORA_INI_DIA1,
                TURN_HORA_FIM_DIA1 = Turno.TURN_HORA_FIM_DIA1,
                TURN_HORA_INI_DIA2 = Turno.TURN_HORA_INI_DIA2,
                TURN_HORA_FIM_DIA2 = Turno.TURN_HORA_FIM_DIA2,
                TURN_HORA_INI_DIA3 = Turno.TURN_HORA_INI_DIA3,
                TURN_HORA_FIM_DIA3 = Turno.TURN_HORA_FIM_DIA3,
                TURN_HORA_INI_DIA4 = Turno.TURN_HORA_INI_DIA4,
                TURN_HORA_FIM_DIA4 = Turno.TURN_HORA_FIM_DIA4,
                TURN_HORA_INI_DIA5 = Turno.TURN_HORA_INI_DIA5,
                TURN_HORA_FIM_DIA5 = Turno.TURN_HORA_FIM_DIA5,
                TURN_HORA_INI_DIA6 = Turno.TURN_HORA_INI_DIA6,
                TURN_HORA_FIM_DIA6 = Turno.TURN_HORA_FIM_DIA6,
                TURN_HORA_INI_DIA7 = Turno.TURN_HORA_INI_DIA7,
                TURN_HORA_FIM_DIA7 = Turno.TURN_HORA_FIM_DIA7,
                Changed = Turno.Changed,
                UserId = _executionContext.UserId,
                Id = Turno.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(string id, string value)
        {
            this.Query = $@" UPDATE [Turno] SET [Descricao] = @Descricao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_PRIORIDADE(string id, int value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_PRIORIDADE] = @TURN_PRIORIDADE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_PRIORIDADE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_INI_DIA1(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_INI_DIA1] = @TURN_HORA_INI_DIA1 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_INI_DIA1 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_FIM_DIA1(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_FIM_DIA1] = @TURN_HORA_FIM_DIA1 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_FIM_DIA1 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_INI_DIA2(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_INI_DIA2] = @TURN_HORA_INI_DIA2 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_INI_DIA2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_FIM_DIA2(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_FIM_DIA2] = @TURN_HORA_FIM_DIA2 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_FIM_DIA2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_INI_DIA3(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_INI_DIA3] = @TURN_HORA_INI_DIA3 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_INI_DIA3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_FIM_DIA3(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_FIM_DIA3] = @TURN_HORA_FIM_DIA3 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_FIM_DIA3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_INI_DIA4(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_INI_DIA4] = @TURN_HORA_INI_DIA4 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_INI_DIA4 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_FIM_DIA4(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_FIM_DIA4] = @TURN_HORA_FIM_DIA4 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_FIM_DIA4 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_INI_DIA5(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_INI_DIA5] = @TURN_HORA_INI_DIA5 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_INI_DIA5 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_FIM_DIA5(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_FIM_DIA5] = @TURN_HORA_FIM_DIA5 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_FIM_DIA5 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_INI_DIA6(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_INI_DIA6] = @TURN_HORA_INI_DIA6 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_INI_DIA6 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_FIM_DIA6(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_FIM_DIA6] = @TURN_HORA_FIM_DIA6 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_FIM_DIA6 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_INI_DIA7(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_INI_DIA7] = @TURN_HORA_INI_DIA7 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_INI_DIA7 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_HORA_FIM_DIA7(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [TURN_HORA_FIM_DIA7] = @TURN_HORA_FIM_DIA7 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TURN_HORA_FIM_DIA7 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string id, int value)
        {
            this.Query = $@" UPDATE [Turno] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string id, bool value)
        {
            this.Query = $@" UPDATE [Turno] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string id, DateTime value)
        {
            this.Query = $@" UPDATE [Turno] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string id, int value)
        {
            this.Query = $@" UPDATE [Turno] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTurnoQuery(ITurnoEntity Turno)
        {
            this.Query = $@" DELETE FROM [Turno] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Turno.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration