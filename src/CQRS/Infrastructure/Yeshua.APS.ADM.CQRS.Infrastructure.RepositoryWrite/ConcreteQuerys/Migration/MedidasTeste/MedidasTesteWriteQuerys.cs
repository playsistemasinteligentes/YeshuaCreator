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
    public class MedidasTesteQueryWrite : QueryBase, IMedidasTesteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MedidasTesteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMedidasTesteQuery(IMedidasTesteEntity MedidasTeste)
        {
            this.Query = $@" INSERT INTO [MedidasTeste] ([MDT_ID], [MDT_DESC], [MDT_VALOR_ESPERADO], [MDT_ENCONTRADO], [UNI_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@MDT_ID, @MDT_DESC, @MDT_VALOR_ESPERADO, @MDT_ENCONTRADO, @UNI_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MDT_ID = MedidasTeste.MDT_ID,
                MDT_DESC = MedidasTeste.MDT_DESC,
                MDT_VALOR_ESPERADO = MedidasTeste.MDT_VALOR_ESPERADO,
                MDT_ENCONTRADO = MedidasTeste.MDT_ENCONTRADO,
                UNI_ID = MedidasTeste.UNI_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMedidasTesteQuery(IMedidasTesteEntity MedidasTeste)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [MDT_ID] = @MDT_ID, [MDT_DESC] = @MDT_DESC, [MDT_VALOR_ESPERADO] = @MDT_VALOR_ESPERADO, [MDT_ENCONTRADO] = @MDT_ENCONTRADO, [UNI_ID] = @UNI_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDT_ID = MedidasTeste.MDT_ID,
                MDT_DESC = MedidasTeste.MDT_DESC,
                MDT_VALOR_ESPERADO = MedidasTeste.MDT_VALOR_ESPERADO,
                MDT_ENCONTRADO = MedidasTeste.MDT_ENCONTRADO,
                UNI_ID = MedidasTeste.UNI_ID,
                Changed = MedidasTeste.Changed,
                UserId = _executionContext.UserId,
                Id = MedidasTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDT_ID(int id, int value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [MDT_ID] = @MDT_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDT_DESC(int id, string value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [MDT_DESC] = @MDT_DESC WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDT_DESC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDT_VALOR_ESPERADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [MDT_VALOR_ESPERADO] = @MDT_VALOR_ESPERADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDT_VALOR_ESPERADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDT_ENCONTRADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [MDT_ENCONTRADO] = @MDT_ENCONTRADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDT_ENCONTRADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ID(int id, string value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [UNI_ID] = @UNI_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UNI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MedidasTeste] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMedidasTesteQuery(IMedidasTesteEntity MedidasTeste)
        {
            this.Query = $@" DELETE FROM [MedidasTeste] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MedidasTeste.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration