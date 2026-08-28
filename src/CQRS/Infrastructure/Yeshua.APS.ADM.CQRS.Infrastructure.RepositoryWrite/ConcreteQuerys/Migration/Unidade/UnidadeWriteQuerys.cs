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
    public class UnidadeQueryWrite : QueryBase, IUnidadeQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public UnidadeQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUnidadeQuery(IUnidadeEntity Unidade)
        {
            this.Query = $@" INSERT INTO Unidade (DEESCRICAO, UN, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.UNI_ID VALUES(@DEESCRICAO, @UN, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DEESCRICAO = Unidade.DEESCRICAO,
                UN = Unidade.UN,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUnidadeQuery(IUnidadeEntity Unidade)
        {
            this.Query = $@" UPDATE Unidade SET DEESCRICAO = @DEESCRICAO, UN = @UN, Changed = @Changed, UserId = @UserId WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                DEESCRICAO = Unidade.DEESCRICAO,
                UN = Unidade.UN,
                Changed = Unidade.Changed,
                UserId = _executionContext.UserId,
                UNI_ID = Unidade.UNI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDEESCRICAO(int uni_id, string value)
        {
            this.Query = $@" UPDATE Unidade SET DEESCRICAO = @DEESCRICAO WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                DEESCRICAO = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUN(int uni_id, string value)
        {
            this.Query = $@" UPDATE Unidade SET UN = @UN WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                UN = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int uni_id, int value)
        {
            this.Query = $@" UPDATE Unidade SET TenantID = @TenantID WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                TenantID = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int uni_id, bool value)
        {
            this.Query = $@" UPDATE Unidade SET Deleted = @Deleted WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                Deleted = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int uni_id, DateTime value)
        {
            this.Query = $@" UPDATE Unidade SET Changed = @Changed WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                Changed = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int uni_id, int value)
        {
            this.Query = $@" UPDATE Unidade SET UserId = @UserId WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                UserId = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUnidadeQuery(IUnidadeEntity Unidade)
        {
            this.Query = $@" DELETE FROM Unidade WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                UNI_ID = Unidade.UNI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration