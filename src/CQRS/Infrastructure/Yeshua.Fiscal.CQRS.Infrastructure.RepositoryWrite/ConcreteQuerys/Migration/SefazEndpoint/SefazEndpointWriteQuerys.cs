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
    public class SefazEndpointQueryWrite : QueryBase, ISefazEndpointQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public SefazEndpointQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirSefazEndpointQuery(ISefazEndpointEntity SefazEndpoint)
        {
            this.Query = $@" INSERT INTO [SefazEndpoint] ([ProdutoFiscal], [UF], [Ambiente], [Servico], [Versao], [Url], [Ativo], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@ProdutoFiscal, @UF, @Ambiente, @Servico, @Versao, @Url, @Ativo, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ProdutoFiscal = SefazEndpoint.ProdutoFiscal,
                UF = SefazEndpoint.UF,
                Ambiente = SefazEndpoint.Ambiente,
                Servico = SefazEndpoint.Servico,
                Versao = SefazEndpoint.Versao,
                Url = SefazEndpoint.Url,
                Ativo = SefazEndpoint.Ativo,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSefazEndpointQuery(ISefazEndpointEntity SefazEndpoint)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [ProdutoFiscal] = @ProdutoFiscal, [UF] = @UF, [Ambiente] = @Ambiente, [Servico] = @Servico, [Versao] = @Versao, [Url] = @Url, [Ativo] = @Ativo, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ProdutoFiscal = SefazEndpoint.ProdutoFiscal,
                UF = SefazEndpoint.UF,
                Ambiente = SefazEndpoint.Ambiente,
                Servico = SefazEndpoint.Servico,
                Versao = SefazEndpoint.Versao,
                Url = SefazEndpoint.Url,
                Ativo = SefazEndpoint.Ativo,
                Changed = SefazEndpoint.Changed,
                UserId = _executionContext.UserId,
                Id = SefazEndpoint.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoFiscal(int id, int value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [ProdutoFiscal] = @ProdutoFiscal WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ProdutoFiscal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUF(int id, string value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [UF] = @UF WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UF = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAmbiente(int id, int value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [Ambiente] = @Ambiente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ambiente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateServico(int id, string value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [Servico] = @Servico WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Servico = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVersao(int id, string value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [Versao] = @Versao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Versao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUrl(int id, string value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [Url] = @Url WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Url = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAtivo(int id, int value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [Ativo] = @Ativo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ativo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [SefazEndpoint] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteSefazEndpointQuery(ISefazEndpointEntity SefazEndpoint)
        {
            this.Query = $@" DELETE FROM [SefazEndpoint] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = SefazEndpoint.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration