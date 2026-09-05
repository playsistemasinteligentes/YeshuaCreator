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
    public class RestricoesDeRodagemQueryWrite : QueryBase, IRestricoesDeRodagemQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RestricoesDeRodagemQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRestricoesDeRodagemQuery(IRestricoesDeRodagemEntity RestricoesDeRodagem)
        {
            this.Query = $@" INSERT INTO [RestricoesDeRodagem] ([RES_ID], [RES_TIPO], [RES_HORA_INI], [RES_HORA_FIM], [RES_VELOCIDADE_HORA_RUSH], [TVE_ID], [MAP_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@RES_ID, @RES_TIPO, @RES_HORA_INI, @RES_HORA_FIM, @RES_VELOCIDADE_HORA_RUSH, @TVE_ID, @MAP_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                RES_ID = RestricoesDeRodagem.RES_ID,
                RES_TIPO = RestricoesDeRodagem.RES_TIPO,
                RES_HORA_INI = RestricoesDeRodagem.RES_HORA_INI,
                RES_HORA_FIM = RestricoesDeRodagem.RES_HORA_FIM,
                RES_VELOCIDADE_HORA_RUSH = RestricoesDeRodagem.RES_VELOCIDADE_HORA_RUSH,
                TVE_ID = RestricoesDeRodagem.TVE_ID,
                MAP_ID = RestricoesDeRodagem.MAP_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRestricoesDeRodagemQuery(IRestricoesDeRodagemEntity RestricoesDeRodagem)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [RES_ID] = @RES_ID, [RES_TIPO] = @RES_TIPO, [RES_HORA_INI] = @RES_HORA_INI, [RES_HORA_FIM] = @RES_HORA_FIM, [RES_VELOCIDADE_HORA_RUSH] = @RES_VELOCIDADE_HORA_RUSH, [TVE_ID] = @TVE_ID, [MAP_ID] = @MAP_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RES_ID = RestricoesDeRodagem.RES_ID,
                RES_TIPO = RestricoesDeRodagem.RES_TIPO,
                RES_HORA_INI = RestricoesDeRodagem.RES_HORA_INI,
                RES_HORA_FIM = RestricoesDeRodagem.RES_HORA_FIM,
                RES_VELOCIDADE_HORA_RUSH = RestricoesDeRodagem.RES_VELOCIDADE_HORA_RUSH,
                TVE_ID = RestricoesDeRodagem.TVE_ID,
                MAP_ID = RestricoesDeRodagem.MAP_ID,
                Changed = RestricoesDeRodagem.Changed,
                UserId = _executionContext.UserId,
                Id = RestricoesDeRodagem.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRES_ID(int id, int value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [RES_ID] = @RES_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RES_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRES_TIPO(int id, string value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [RES_TIPO] = @RES_TIPO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RES_TIPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRES_HORA_INI(int id, string value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [RES_HORA_INI] = @RES_HORA_INI WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RES_HORA_INI = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRES_HORA_FIM(int id, string value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [RES_HORA_FIM] = @RES_HORA_FIM WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RES_HORA_FIM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRES_VELOCIDADE_HORA_RUSH(int id, Decimal value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [RES_VELOCIDADE_HORA_RUSH] = @RES_VELOCIDADE_HORA_RUSH WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RES_VELOCIDADE_HORA_RUSH = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTVE_ID(int id, int value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [TVE_ID] = @TVE_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TVE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAP_ID(int id, int value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [MAP_ID] = @MAP_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MAP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [RestricoesDeRodagem] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRestricoesDeRodagemQuery(IRestricoesDeRodagemEntity RestricoesDeRodagem)
        {
            this.Query = $@" DELETE FROM [RestricoesDeRodagem] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = RestricoesDeRodagem.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration