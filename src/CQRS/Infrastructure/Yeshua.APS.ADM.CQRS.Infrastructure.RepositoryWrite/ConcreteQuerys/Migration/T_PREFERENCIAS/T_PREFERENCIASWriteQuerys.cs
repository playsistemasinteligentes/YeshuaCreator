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
    public class T_PREFERENCIASQueryWrite : QueryBase, IT_PREFERENCIASQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_PREFERENCIASQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_PREFERENCIASQuery(IT_PREFERENCIASEntity T_PREFERENCIAS)
        {
            this.Query = $@" INSERT INTO T_PREFERENCIAS (PRE_DESCRICAO, PRE_NAMESPACE, PRE_TIPO, PRE_VALOR, USE_ID, PER_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PRE_DESCRICAO, @PRE_NAMESPACE, @PRE_TIPO, @PRE_VALOR, @USE_ID, @PER_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PRE_DESCRICAO = T_PREFERENCIAS.PRE_DESCRICAO,
                PRE_NAMESPACE = T_PREFERENCIAS.PRE_NAMESPACE,
                PRE_TIPO = T_PREFERENCIAS.PRE_TIPO,
                PRE_VALOR = T_PREFERENCIAS.PRE_VALOR,
                USE_ID = T_PREFERENCIAS.USE_ID,
                PER_ID = T_PREFERENCIAS.PER_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_PREFERENCIASQuery(IT_PREFERENCIASEntity T_PREFERENCIAS)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET PRE_ID = @PRE_ID, PRE_DESCRICAO = @PRE_DESCRICAO, PRE_NAMESPACE = @PRE_NAMESPACE, PRE_TIPO = @PRE_TIPO, PRE_VALOR = @PRE_VALOR, USE_ID = @USE_ID, PER_ID = @PER_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                PRE_ID = T_PREFERENCIAS.PRE_ID,
                PRE_DESCRICAO = T_PREFERENCIAS.PRE_DESCRICAO,
                PRE_NAMESPACE = T_PREFERENCIAS.PRE_NAMESPACE,
                PRE_TIPO = T_PREFERENCIAS.PRE_TIPO,
                PRE_VALOR = T_PREFERENCIAS.PRE_VALOR,
                USE_ID = T_PREFERENCIAS.USE_ID,
                PER_ID = T_PREFERENCIAS.PER_ID,
                Changed = T_PREFERENCIAS.Changed,
                UserId = _executionContext.UserId,
                Id = T_PREFERENCIAS.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRE_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET PRE_ID = @PRE_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PRE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRE_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET PRE_DESCRICAO = @PRE_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRE_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRE_NAMESPACE(int id, string value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET PRE_NAMESPACE = @PRE_NAMESPACE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRE_NAMESPACE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRE_TIPO(int id, string value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET PRE_TIPO = @PRE_TIPO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRE_TIPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRE_VALOR(int id, string value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET PRE_VALOR = @PRE_VALOR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRE_VALOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET USE_ID = @USE_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                USE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET PER_ID = @PER_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE T_PREFERENCIAS SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_PREFERENCIASQuery(IT_PREFERENCIASEntity T_PREFERENCIAS)
        {
            this.Query = $@" DELETE FROM T_PREFERENCIAS WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = T_PREFERENCIAS.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration