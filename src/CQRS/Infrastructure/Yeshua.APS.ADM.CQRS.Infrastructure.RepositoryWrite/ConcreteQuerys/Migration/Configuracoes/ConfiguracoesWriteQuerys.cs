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
    public class ConfiguracoesQueryWrite : QueryBase, IConfiguracoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ConfiguracoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirConfiguracoesQuery(IConfiguracoesEntity Configuracoes)
        {
            this.Query = $@" INSERT INTO Configuracoes (TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.CON_ID VALUES(@TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConfiguracoesQuery(IConfiguracoesEntity Configuracoes)
        {
            this.Query = $@" UPDATE Configuracoes SET Changed = @Changed, UserId = @UserId WHERE CON_ID = @CON_ID ";
            this.Parameters = new
            {
                Changed = Configuracoes.Changed,
                UserId = _executionContext.UserId,
                CON_ID = Configuracoes.CON_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int con_id, int value)
        {
            this.Query = $@" UPDATE Configuracoes SET TenantID = @TenantID WHERE CON_ID = @CON_ID ";
            this.Parameters = new
            {
                TenantID = value,
                CON_ID = con_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int con_id, bool value)
        {
            this.Query = $@" UPDATE Configuracoes SET Deleted = @Deleted WHERE CON_ID = @CON_ID ";
            this.Parameters = new
            {
                Deleted = value,
                CON_ID = con_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int con_id, DateTime value)
        {
            this.Query = $@" UPDATE Configuracoes SET Changed = @Changed WHERE CON_ID = @CON_ID ";
            this.Parameters = new
            {
                Changed = value,
                CON_ID = con_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int con_id, int value)
        {
            this.Query = $@" UPDATE Configuracoes SET UserId = @UserId WHERE CON_ID = @CON_ID ";
            this.Parameters = new
            {
                UserId = value,
                CON_ID = con_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteConfiguracoesQuery(IConfiguracoesEntity Configuracoes)
        {
            this.Query = $@" DELETE FROM Configuracoes WHERE CON_ID = @CON_ID ";
            this.Parameters = new
            {
                CON_ID = Configuracoes.CON_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration