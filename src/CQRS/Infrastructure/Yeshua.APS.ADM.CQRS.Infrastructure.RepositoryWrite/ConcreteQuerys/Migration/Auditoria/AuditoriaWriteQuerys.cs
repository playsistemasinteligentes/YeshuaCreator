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
    public class AuditoriaQueryWrite : QueryBase, IAuditoriaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public AuditoriaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirAuditoriaQuery(IAuditoriaEntity Auditoria)
        {
            this.Query = $@" INSERT INTO Auditoria (DATA, USE_ID, ROTINA, HISTORICO, CHAVE, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@DATA, @USE_ID, @ROTINA, @HISTORICO, @CHAVE, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DATA = Auditoria.DATA,
                USE_ID = Auditoria.USE_ID,
                ROTINA = Auditoria.ROTINA,
                HISTORICO = Auditoria.HISTORICO,
                CHAVE = Auditoria.CHAVE,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditoriaQuery(IAuditoriaEntity Auditoria)
        {
            this.Query = $@" UPDATE Auditoria SET DATA = @DATA, USE_ID = @USE_ID, ROTINA = @ROTINA, HISTORICO = @HISTORICO, CHAVE = @CHAVE, Changed = @Changed, UserId = @UserId WHERE ID = @ID ";
            this.Parameters = new
            {
                DATA = Auditoria.DATA,
                USE_ID = Auditoria.USE_ID,
                ROTINA = Auditoria.ROTINA,
                HISTORICO = Auditoria.HISTORICO,
                CHAVE = Auditoria.CHAVE,
                Changed = Auditoria.Changed,
                UserId = _executionContext.UserId,
                ID = Auditoria.ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDATA(int id, DateTime value)
        {
            this.Query = $@" UPDATE Auditoria SET DATA = @DATA WHERE ID = @ID ";
            this.Parameters = new
            {
                DATA = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int id, int value)
        {
            this.Query = $@" UPDATE Auditoria SET USE_ID = @USE_ID WHERE ID = @ID ";
            this.Parameters = new
            {
                USE_ID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROTINA(int id, string value)
        {
            this.Query = $@" UPDATE Auditoria SET ROTINA = @ROTINA WHERE ID = @ID ";
            this.Parameters = new
            {
                ROTINA = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHISTORICO(int id, string value)
        {
            this.Query = $@" UPDATE Auditoria SET HISTORICO = @HISTORICO WHERE ID = @ID ";
            this.Parameters = new
            {
                HISTORICO = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCHAVE(int id, string value)
        {
            this.Query = $@" UPDATE Auditoria SET CHAVE = @CHAVE WHERE ID = @ID ";
            this.Parameters = new
            {
                CHAVE = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Auditoria SET TenantID = @TenantID WHERE ID = @ID ";
            this.Parameters = new
            {
                TenantID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Auditoria SET Deleted = @Deleted WHERE ID = @ID ";
            this.Parameters = new
            {
                Deleted = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Auditoria SET Changed = @Changed WHERE ID = @ID ";
            this.Parameters = new
            {
                Changed = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Auditoria SET UserId = @UserId WHERE ID = @ID ";
            this.Parameters = new
            {
                UserId = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteAuditoriaQuery(IAuditoriaEntity Auditoria)
        {
            this.Query = $@" DELETE FROM Auditoria WHERE ID = @ID ";
            this.Parameters = new
            {
                ID = Auditoria.ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration