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
    public class CalendarioDisponibilidadeVeiculosQueryWrite : QueryBase, ICalendarioDisponibilidadeVeiculosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CalendarioDisponibilidadeVeiculosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCalendarioDisponibilidadeVeiculosQuery(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos)
        {
            this.Query = $@" INSERT INTO CalendarioDisponibilidadeVeiculos (CDV_ID, CDV_DATA_DE, CDV_DATA_ATE, CDV_SEGUNDA, CDV_TERCA, CDV_QUARTA, CDV_QUINTA, CDV_SEXTA, CDV_SABADO, CDV_DOMINGO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CDV_ID, @CDV_DATA_DE, @CDV_DATA_ATE, @CDV_SEGUNDA, @CDV_TERCA, @CDV_QUARTA, @CDV_QUINTA, @CDV_SEXTA, @CDV_SABADO, @CDV_DOMINGO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CDV_ID = CalendarioDisponibilidadeVeiculos.CDV_ID,
                CDV_DATA_DE = CalendarioDisponibilidadeVeiculos.CDV_DATA_DE,
                CDV_DATA_ATE = CalendarioDisponibilidadeVeiculos.CDV_DATA_ATE,
                CDV_SEGUNDA = CalendarioDisponibilidadeVeiculos.CDV_SEGUNDA,
                CDV_TERCA = CalendarioDisponibilidadeVeiculos.CDV_TERCA,
                CDV_QUARTA = CalendarioDisponibilidadeVeiculos.CDV_QUARTA,
                CDV_QUINTA = CalendarioDisponibilidadeVeiculos.CDV_QUINTA,
                CDV_SEXTA = CalendarioDisponibilidadeVeiculos.CDV_SEXTA,
                CDV_SABADO = CalendarioDisponibilidadeVeiculos.CDV_SABADO,
                CDV_DOMINGO = CalendarioDisponibilidadeVeiculos.CDV_DOMINGO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCalendarioDisponibilidadeVeiculosQuery(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_ID = @CDV_ID, CDV_DATA_DE = @CDV_DATA_DE, CDV_DATA_ATE = @CDV_DATA_ATE, CDV_SEGUNDA = @CDV_SEGUNDA, CDV_TERCA = @CDV_TERCA, CDV_QUARTA = @CDV_QUARTA, CDV_QUINTA = @CDV_QUINTA, CDV_SEXTA = @CDV_SEXTA, CDV_SABADO = @CDV_SABADO, CDV_DOMINGO = @CDV_DOMINGO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_ID = CalendarioDisponibilidadeVeiculos.CDV_ID,
                CDV_DATA_DE = CalendarioDisponibilidadeVeiculos.CDV_DATA_DE,
                CDV_DATA_ATE = CalendarioDisponibilidadeVeiculos.CDV_DATA_ATE,
                CDV_SEGUNDA = CalendarioDisponibilidadeVeiculos.CDV_SEGUNDA,
                CDV_TERCA = CalendarioDisponibilidadeVeiculos.CDV_TERCA,
                CDV_QUARTA = CalendarioDisponibilidadeVeiculos.CDV_QUARTA,
                CDV_QUINTA = CalendarioDisponibilidadeVeiculos.CDV_QUINTA,
                CDV_SEXTA = CalendarioDisponibilidadeVeiculos.CDV_SEXTA,
                CDV_SABADO = CalendarioDisponibilidadeVeiculos.CDV_SABADO,
                CDV_DOMINGO = CalendarioDisponibilidadeVeiculos.CDV_DOMINGO,
                Changed = CalendarioDisponibilidadeVeiculos.Changed,
                UserId = _executionContext.UserId,
                Id = CalendarioDisponibilidadeVeiculos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_ID(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_ID = @CDV_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_DATA_DE(int id, DateTime value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_DATA_DE = @CDV_DATA_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_DATA_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_DATA_ATE(int id, DateTime value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_DATA_ATE = @CDV_DATA_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_DATA_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_SEGUNDA(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_SEGUNDA = @CDV_SEGUNDA WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_SEGUNDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_TERCA(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_TERCA = @CDV_TERCA WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_TERCA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_QUARTA(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_QUARTA = @CDV_QUARTA WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_QUARTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_QUINTA(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_QUINTA = @CDV_QUINTA WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_QUINTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_SEXTA(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_SEXTA = @CDV_SEXTA WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_SEXTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_SABADO(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_SABADO = @CDV_SABADO WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_SABADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_DOMINGO(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET CDV_DOMINGO = @CDV_DOMINGO WHERE Id = @Id ";
            this.Parameters = new
            {
                CDV_DOMINGO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE CalendarioDisponibilidadeVeiculos SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCalendarioDisponibilidadeVeiculosQuery(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos)
        {
            this.Query = $@" DELETE FROM CalendarioDisponibilidadeVeiculos WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = CalendarioDisponibilidadeVeiculos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration