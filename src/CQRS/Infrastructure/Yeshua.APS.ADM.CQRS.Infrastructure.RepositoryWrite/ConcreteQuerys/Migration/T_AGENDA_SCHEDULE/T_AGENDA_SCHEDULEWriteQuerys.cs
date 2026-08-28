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
    public class T_AGENDA_SCHEDULEQueryWrite : QueryBase, IT_AGENDA_SCHEDULEQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_AGENDA_SCHEDULEQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_AGENDA_SCHEDULEQuery(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE)
        {
            this.Query = $@" INSERT INTO T_AGENDA_SCHEDULE (AGE_DATA_ESPECIFICA, AGE_HORARIO_INICIO, AGE_HORARIO_FIM, AGE_SEGUNDA, AGE_TERCA, AGE_QUARTA, AGE_QUINTA, AGE_SEXTA, AGE_SABADO, AGE_DOMINGO, AGE_INTERVALO, AGE_ORDEM_EXECUCAO, AGE_PARAMETROS, AGE_EXCECAO, AGE_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@AGE_DATA_ESPECIFICA, @AGE_HORARIO_INICIO, @AGE_HORARIO_FIM, @AGE_SEGUNDA, @AGE_TERCA, @AGE_QUARTA, @AGE_QUINTA, @AGE_SEXTA, @AGE_SABADO, @AGE_DOMINGO, @AGE_INTERVALO, @AGE_ORDEM_EXECUCAO, @AGE_PARAMETROS, @AGE_EXCECAO, @AGE_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                AGE_DATA_ESPECIFICA = T_AGENDA_SCHEDULE.AGE_DATA_ESPECIFICA,
                AGE_HORARIO_INICIO = T_AGENDA_SCHEDULE.AGE_HORARIO_INICIO,
                AGE_HORARIO_FIM = T_AGENDA_SCHEDULE.AGE_HORARIO_FIM,
                AGE_SEGUNDA = T_AGENDA_SCHEDULE.AGE_SEGUNDA,
                AGE_TERCA = T_AGENDA_SCHEDULE.AGE_TERCA,
                AGE_QUARTA = T_AGENDA_SCHEDULE.AGE_QUARTA,
                AGE_QUINTA = T_AGENDA_SCHEDULE.AGE_QUINTA,
                AGE_SEXTA = T_AGENDA_SCHEDULE.AGE_SEXTA,
                AGE_SABADO = T_AGENDA_SCHEDULE.AGE_SABADO,
                AGE_DOMINGO = T_AGENDA_SCHEDULE.AGE_DOMINGO,
                AGE_INTERVALO = T_AGENDA_SCHEDULE.AGE_INTERVALO,
                AGE_ORDEM_EXECUCAO = T_AGENDA_SCHEDULE.AGE_ORDEM_EXECUCAO,
                AGE_PARAMETROS = T_AGENDA_SCHEDULE.AGE_PARAMETROS,
                AGE_EXCECAO = T_AGENDA_SCHEDULE.AGE_EXCECAO,
                AGE_DESCRICAO = T_AGENDA_SCHEDULE.AGE_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_AGENDA_SCHEDULEQuery(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_ID = @AGE_ID, AGE_DATA_ESPECIFICA = @AGE_DATA_ESPECIFICA, AGE_HORARIO_INICIO = @AGE_HORARIO_INICIO, AGE_HORARIO_FIM = @AGE_HORARIO_FIM, AGE_SEGUNDA = @AGE_SEGUNDA, AGE_TERCA = @AGE_TERCA, AGE_QUARTA = @AGE_QUARTA, AGE_QUINTA = @AGE_QUINTA, AGE_SEXTA = @AGE_SEXTA, AGE_SABADO = @AGE_SABADO, AGE_DOMINGO = @AGE_DOMINGO, AGE_INTERVALO = @AGE_INTERVALO, AGE_ORDEM_EXECUCAO = @AGE_ORDEM_EXECUCAO, AGE_PARAMETROS = @AGE_PARAMETROS, AGE_EXCECAO = @AGE_EXCECAO, AGE_DESCRICAO = @AGE_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_ID = T_AGENDA_SCHEDULE.AGE_ID,
                AGE_DATA_ESPECIFICA = T_AGENDA_SCHEDULE.AGE_DATA_ESPECIFICA,
                AGE_HORARIO_INICIO = T_AGENDA_SCHEDULE.AGE_HORARIO_INICIO,
                AGE_HORARIO_FIM = T_AGENDA_SCHEDULE.AGE_HORARIO_FIM,
                AGE_SEGUNDA = T_AGENDA_SCHEDULE.AGE_SEGUNDA,
                AGE_TERCA = T_AGENDA_SCHEDULE.AGE_TERCA,
                AGE_QUARTA = T_AGENDA_SCHEDULE.AGE_QUARTA,
                AGE_QUINTA = T_AGENDA_SCHEDULE.AGE_QUINTA,
                AGE_SEXTA = T_AGENDA_SCHEDULE.AGE_SEXTA,
                AGE_SABADO = T_AGENDA_SCHEDULE.AGE_SABADO,
                AGE_DOMINGO = T_AGENDA_SCHEDULE.AGE_DOMINGO,
                AGE_INTERVALO = T_AGENDA_SCHEDULE.AGE_INTERVALO,
                AGE_ORDEM_EXECUCAO = T_AGENDA_SCHEDULE.AGE_ORDEM_EXECUCAO,
                AGE_PARAMETROS = T_AGENDA_SCHEDULE.AGE_PARAMETROS,
                AGE_EXCECAO = T_AGENDA_SCHEDULE.AGE_EXCECAO,
                AGE_DESCRICAO = T_AGENDA_SCHEDULE.AGE_DESCRICAO,
                Changed = T_AGENDA_SCHEDULE.Changed,
                UserId = _executionContext.UserId,
                Id = T_AGENDA_SCHEDULE.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_ID = @AGE_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_DATA_ESPECIFICA(int id, DateTime value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_DATA_ESPECIFICA = @AGE_DATA_ESPECIFICA WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_DATA_ESPECIFICA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_HORARIO_INICIO(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_HORARIO_INICIO = @AGE_HORARIO_INICIO WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_HORARIO_INICIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_HORARIO_FIM(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_HORARIO_FIM = @AGE_HORARIO_FIM WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_HORARIO_FIM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_SEGUNDA(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_SEGUNDA = @AGE_SEGUNDA WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_SEGUNDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_TERCA(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_TERCA = @AGE_TERCA WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_TERCA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_QUARTA(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_QUARTA = @AGE_QUARTA WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_QUARTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_QUINTA(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_QUINTA = @AGE_QUINTA WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_QUINTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_SEXTA(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_SEXTA = @AGE_SEXTA WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_SEXTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_SABADO(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_SABADO = @AGE_SABADO WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_SABADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_DOMINGO(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_DOMINGO = @AGE_DOMINGO WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_DOMINGO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_INTERVALO(int id, Decimal value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_INTERVALO = @AGE_INTERVALO WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_INTERVALO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_ORDEM_EXECUCAO(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_ORDEM_EXECUCAO = @AGE_ORDEM_EXECUCAO WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_ORDEM_EXECUCAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_PARAMETROS(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_PARAMETROS = @AGE_PARAMETROS WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_PARAMETROS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_EXCECAO(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_EXCECAO = @AGE_EXCECAO WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_EXCECAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAGE_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET AGE_DESCRICAO = @AGE_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                AGE_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE T_AGENDA_SCHEDULE SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_AGENDA_SCHEDULEQuery(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE)
        {
            this.Query = $@" DELETE FROM T_AGENDA_SCHEDULE WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = T_AGENDA_SCHEDULE.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration