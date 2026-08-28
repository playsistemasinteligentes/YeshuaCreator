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
    public class ImpressoraQueryWrite : QueryBase, IImpressoraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ImpressoraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirImpressoraQuery(IImpressoraEntity Impressora)
        {
            this.Query = $@" INSERT INTO Impressora (IMP_IP, IMP_NOME, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.IMP_ID VALUES(@IMP_IP, @IMP_NOME, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IMP_IP = Impressora.IMP_IP,
                IMP_NOME = Impressora.IMP_NOME,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateImpressoraQuery(IImpressoraEntity Impressora)
        {
            this.Query = $@" UPDATE Impressora SET IMP_IP = @IMP_IP, IMP_NOME = @IMP_NOME, Changed = @Changed, UserId = @UserId WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                IMP_IP = Impressora.IMP_IP,
                IMP_NOME = Impressora.IMP_NOME,
                Changed = Impressora.Changed,
                UserId = _executionContext.UserId,
                IMP_ID = Impressora.IMP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIMP_IP(int imp_id, string value)
        {
            this.Query = $@" UPDATE Impressora SET IMP_IP = @IMP_IP WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                IMP_IP = value,
                IMP_ID = imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIMP_NOME(int imp_id, string value)
        {
            this.Query = $@" UPDATE Impressora SET IMP_NOME = @IMP_NOME WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                IMP_NOME = value,
                IMP_ID = imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int imp_id, int value)
        {
            this.Query = $@" UPDATE Impressora SET TenantID = @TenantID WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                TenantID = value,
                IMP_ID = imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int imp_id, bool value)
        {
            this.Query = $@" UPDATE Impressora SET Deleted = @Deleted WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                Deleted = value,
                IMP_ID = imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int imp_id, DateTime value)
        {
            this.Query = $@" UPDATE Impressora SET Changed = @Changed WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                Changed = value,
                IMP_ID = imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int imp_id, int value)
        {
            this.Query = $@" UPDATE Impressora SET UserId = @UserId WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                UserId = value,
                IMP_ID = imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteImpressoraQuery(IImpressoraEntity Impressora)
        {
            this.Query = $@" DELETE FROM Impressora WHERE IMP_ID = @IMP_ID ";
            this.Parameters = new
            {
                IMP_ID = Impressora.IMP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration