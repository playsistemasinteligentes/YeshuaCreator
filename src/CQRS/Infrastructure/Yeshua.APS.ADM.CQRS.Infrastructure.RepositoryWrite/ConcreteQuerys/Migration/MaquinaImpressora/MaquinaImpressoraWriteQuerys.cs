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
    public class MaquinaImpressoraQueryWrite : QueryBase, IMaquinaImpressoraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MaquinaImpressoraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMaquinaImpressoraQuery(IMaquinaImpressoraEntity MaquinaImpressora)
        {
            this.Query = $@" INSERT INTO [MaquinaImpressora] ([MAQ_ID], [IMP_ID], [MAI_FACAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[MAQ_IMP_ID] VALUES(@MAQ_ID, @IMP_ID, @MAI_FACAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MAQ_ID = MaquinaImpressora.MAQ_ID,
                IMP_ID = MaquinaImpressora.IMP_ID,
                MAI_FACAO = MaquinaImpressora.MAI_FACAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaImpressoraQuery(IMaquinaImpressoraEntity MaquinaImpressora)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [MAQ_ID] = @MAQ_ID, [IMP_ID] = @IMP_ID, [MAI_FACAO] = @MAI_FACAO, [Changed] = @Changed, [UserId] = @UserId WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                MAQ_ID = MaquinaImpressora.MAQ_ID,
                IMP_ID = MaquinaImpressora.IMP_ID,
                MAI_FACAO = MaquinaImpressora.MAI_FACAO,
                Changed = MaquinaImpressora.Changed,
                UserId = _executionContext.UserId,
                MAQ_IMP_ID = MaquinaImpressora.MAQ_IMP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int maq_imp_id, string value)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [MAQ_ID] = @MAQ_ID WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                MAQ_ID = value,
                MAQ_IMP_ID = maq_imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIMP_ID(int maq_imp_id, int value)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [IMP_ID] = @IMP_ID WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                IMP_ID = value,
                MAQ_IMP_ID = maq_imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAI_FACAO(int maq_imp_id, int value)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [MAI_FACAO] = @MAI_FACAO WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                MAI_FACAO = value,
                MAQ_IMP_ID = maq_imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int maq_imp_id, int value)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [TenantID] = @TenantID WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                TenantID = value,
                MAQ_IMP_ID = maq_imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int maq_imp_id, bool value)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [Deleted] = @Deleted WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                Deleted = value,
                MAQ_IMP_ID = maq_imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int maq_imp_id, DateTime value)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [Changed] = @Changed WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                Changed = value,
                MAQ_IMP_ID = maq_imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int maq_imp_id, int value)
        {
            this.Query = $@" UPDATE [MaquinaImpressora] SET [UserId] = @UserId WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                UserId = value,
                MAQ_IMP_ID = maq_imp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMaquinaImpressoraQuery(IMaquinaImpressoraEntity MaquinaImpressora)
        {
            this.Query = $@" DELETE FROM [MaquinaImpressora] WHERE [MAQ_IMP_ID] = @MAQ_IMP_ID ";
            this.Parameters = new
            {
                MAQ_IMP_ID = MaquinaImpressora.MAQ_IMP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration