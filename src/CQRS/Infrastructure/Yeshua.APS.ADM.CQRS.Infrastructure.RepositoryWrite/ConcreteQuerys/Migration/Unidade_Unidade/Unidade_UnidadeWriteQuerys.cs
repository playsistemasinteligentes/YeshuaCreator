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
    public class Unidade_UnidadeQueryWrite : QueryBase, IUnidade_UnidadeQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public Unidade_UnidadeQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUnidade_UnidadeQuery(IUnidade_UnidadeEntity Unidade_Unidade)
        {
            this.Query = $@" INSERT INTO Unidade_Unidade (UNI_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.UNI_ID VALUES(@UNI_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                UNI_DESCRICAO = Unidade_Unidade.UNI_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUnidade_UnidadeQuery(IUnidade_UnidadeEntity Unidade_Unidade)
        {
            this.Query = $@" UPDATE Unidade_Unidade SET UNI_DESCRICAO = @UNI_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                UNI_DESCRICAO = Unidade_Unidade.UNI_DESCRICAO,
                Changed = Unidade_Unidade.Changed,
                UserId = _executionContext.UserId,
                UNI_ID = Unidade_Unidade.UNI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_DESCRICAO(int uni_id, string value)
        {
            this.Query = $@" UPDATE Unidade_Unidade SET UNI_DESCRICAO = @UNI_DESCRICAO WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                UNI_DESCRICAO = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int uni_id, int value)
        {
            this.Query = $@" UPDATE Unidade_Unidade SET TenantID = @TenantID WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                TenantID = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int uni_id, bool value)
        {
            this.Query = $@" UPDATE Unidade_Unidade SET Deleted = @Deleted WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                Deleted = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int uni_id, DateTime value)
        {
            this.Query = $@" UPDATE Unidade_Unidade SET Changed = @Changed WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                Changed = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int uni_id, int value)
        {
            this.Query = $@" UPDATE Unidade_Unidade SET UserId = @UserId WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                UserId = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUnidade_UnidadeQuery(IUnidade_UnidadeEntity Unidade_Unidade)
        {
            this.Query = $@" DELETE FROM Unidade_Unidade WHERE UNI_ID = @UNI_ID ";
            this.Parameters = new
            {
                UNI_ID = Unidade_Unidade.UNI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration