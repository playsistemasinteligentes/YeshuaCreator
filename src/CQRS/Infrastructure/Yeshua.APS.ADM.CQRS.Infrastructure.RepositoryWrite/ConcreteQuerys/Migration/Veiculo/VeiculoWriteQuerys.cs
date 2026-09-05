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
    public class VeiculoQueryWrite : QueryBase, IVeiculoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public VeiculoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirVeiculoQuery(IVeiculoEntity Veiculo)
        {
            this.Query = $@" INSERT INTO [Veiculo] ([VEI_PLACA], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@VEI_PLACA, @TIP_ID, @VEI_CAPACIDADE_M3, @VEI_CAPACIDADE_LARGURA, @VEI_CAPACIDADE_COMPRIMENTO, @VEI_CAPACIDADE_ALTURA, @VEI_MODELO, @VEI_NOME_MOTORISTA, @VEI_DADOS_CONTATO, @VEI_CPF_MOTORISTA, @TCA_ID, @VEI_EMISSAO, @VEI_VENCIMENTO, @VEI_STATUS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                VEI_PLACA = Veiculo.VEI_PLACA,
                TIP_ID = Veiculo.TIP_ID,
                VEI_CAPACIDADE_M3 = Veiculo.VEI_CAPACIDADE_M3,
                VEI_CAPACIDADE_LARGURA = Veiculo.VEI_CAPACIDADE_LARGURA,
                VEI_CAPACIDADE_COMPRIMENTO = Veiculo.VEI_CAPACIDADE_COMPRIMENTO,
                VEI_CAPACIDADE_ALTURA = Veiculo.VEI_CAPACIDADE_ALTURA,
                VEI_MODELO = Veiculo.VEI_MODELO,
                VEI_NOME_MOTORISTA = Veiculo.VEI_NOME_MOTORISTA,
                VEI_DADOS_CONTATO = Veiculo.VEI_DADOS_CONTATO,
                VEI_CPF_MOTORISTA = Veiculo.VEI_CPF_MOTORISTA,
                TCA_ID = Veiculo.TCA_ID,
                VEI_EMISSAO = Veiculo.VEI_EMISSAO,
                VEI_VENCIMENTO = Veiculo.VEI_VENCIMENTO,
                VEI_STATUS = Veiculo.VEI_STATUS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVeiculoQuery(IVeiculoEntity Veiculo)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_PLACA] = @VEI_PLACA, [TIP_ID] = @TIP_ID, [VEI_CAPACIDADE_M3] = @VEI_CAPACIDADE_M3, [VEI_CAPACIDADE_LARGURA] = @VEI_CAPACIDADE_LARGURA, [VEI_CAPACIDADE_COMPRIMENTO] = @VEI_CAPACIDADE_COMPRIMENTO, [VEI_CAPACIDADE_ALTURA] = @VEI_CAPACIDADE_ALTURA, [VEI_MODELO] = @VEI_MODELO, [VEI_NOME_MOTORISTA] = @VEI_NOME_MOTORISTA, [VEI_DADOS_CONTATO] = @VEI_DADOS_CONTATO, [VEI_CPF_MOTORISTA] = @VEI_CPF_MOTORISTA, [TCA_ID] = @TCA_ID, [VEI_EMISSAO] = @VEI_EMISSAO, [VEI_VENCIMENTO] = @VEI_VENCIMENTO, [VEI_STATUS] = @VEI_STATUS, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_PLACA = Veiculo.VEI_PLACA,
                TIP_ID = Veiculo.TIP_ID,
                VEI_CAPACIDADE_M3 = Veiculo.VEI_CAPACIDADE_M3,
                VEI_CAPACIDADE_LARGURA = Veiculo.VEI_CAPACIDADE_LARGURA,
                VEI_CAPACIDADE_COMPRIMENTO = Veiculo.VEI_CAPACIDADE_COMPRIMENTO,
                VEI_CAPACIDADE_ALTURA = Veiculo.VEI_CAPACIDADE_ALTURA,
                VEI_MODELO = Veiculo.VEI_MODELO,
                VEI_NOME_MOTORISTA = Veiculo.VEI_NOME_MOTORISTA,
                VEI_DADOS_CONTATO = Veiculo.VEI_DADOS_CONTATO,
                VEI_CPF_MOTORISTA = Veiculo.VEI_CPF_MOTORISTA,
                TCA_ID = Veiculo.TCA_ID,
                VEI_EMISSAO = Veiculo.VEI_EMISSAO,
                VEI_VENCIMENTO = Veiculo.VEI_VENCIMENTO,
                VEI_STATUS = Veiculo.VEI_STATUS,
                Changed = Veiculo.Changed,
                UserId = _executionContext.UserId,
                Id = Veiculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_PLACA(int id, string value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_PLACA] = @VEI_PLACA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_PLACA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(int id, int value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [TIP_ID] = @TIP_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_CAPACIDADE_M3(int id, Decimal value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_CAPACIDADE_M3] = @VEI_CAPACIDADE_M3 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_CAPACIDADE_M3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_CAPACIDADE_LARGURA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_CAPACIDADE_LARGURA] = @VEI_CAPACIDADE_LARGURA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_CAPACIDADE_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_CAPACIDADE_COMPRIMENTO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_CAPACIDADE_COMPRIMENTO] = @VEI_CAPACIDADE_COMPRIMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_CAPACIDADE_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_CAPACIDADE_ALTURA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_CAPACIDADE_ALTURA] = @VEI_CAPACIDADE_ALTURA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_CAPACIDADE_ALTURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_MODELO(int id, string value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_MODELO] = @VEI_MODELO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_MODELO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_NOME_MOTORISTA(int id, string value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_NOME_MOTORISTA] = @VEI_NOME_MOTORISTA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_NOME_MOTORISTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_DADOS_CONTATO(int id, string value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_DADOS_CONTATO] = @VEI_DADOS_CONTATO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_DADOS_CONTATO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_CPF_MOTORISTA(int id, string value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_CPF_MOTORISTA] = @VEI_CPF_MOTORISTA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_CPF_MOTORISTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTCA_ID(int id, string value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [TCA_ID] = @TCA_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TCA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_EMISSAO] = @VEI_EMISSAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_VENCIMENTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_VENCIMENTO] = @VEI_VENCIMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_VENCIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [VEI_STATUS] = @VEI_STATUS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Veiculo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteVeiculoQuery(IVeiculoEntity Veiculo)
        {
            this.Query = $@" DELETE FROM [Veiculo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Veiculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration