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
    public class MDFeVeiculoQueryWrite : QueryBase, IMDFeVeiculoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeVeiculoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFeVeiculoQuery(IMDFeVeiculoEntity MDFeVeiculo)
        {
            this.Query = $@" INSERT INTO [MDFeVeiculo] ([MDFeSolicitacaoFiscalId], [Placa], [Renavam], [Tara], [CapacidadeKg], [CapacidadeM3], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@MDFeSolicitacaoFiscalId, @Placa, @Renavam, @Tara, @CapacidadeKg, @CapacidadeM3, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeVeiculo.MDFeSolicitacaoFiscalId,
                Placa = MDFeVeiculo.Placa,
                Renavam = MDFeVeiculo.Renavam,
                Tara = MDFeVeiculo.Tara,
                CapacidadeKg = MDFeVeiculo.CapacidadeKg,
                CapacidadeM3 = MDFeVeiculo.CapacidadeM3,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeVeiculoQuery(IMDFeVeiculoEntity MDFeVeiculo)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId, [Placa] = @Placa, [Renavam] = @Renavam, [Tara] = @Tara, [CapacidadeKg] = @CapacidadeKg, [CapacidadeM3] = @CapacidadeM3, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeVeiculo.MDFeSolicitacaoFiscalId,
                Placa = MDFeVeiculo.Placa,
                Renavam = MDFeVeiculo.Renavam,
                Tara = MDFeVeiculo.Tara,
                CapacidadeKg = MDFeVeiculo.CapacidadeKg,
                CapacidadeM3 = MDFeVeiculo.CapacidadeM3,
                Changed = MDFeVeiculo.Changed,
                UserId = _executionContext.UserId,
                Id = MDFeVeiculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlaca(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [Placa] = @Placa WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Placa = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRenavam(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [Renavam] = @Renavam WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Renavam = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTara(int id, Decimal value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [Tara] = @Tara WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Tara = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCapacidadeKg(int id, Decimal value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [CapacidadeKg] = @CapacidadeKg WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CapacidadeKg = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCapacidadeM3(int id, Decimal value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [CapacidadeM3] = @CapacidadeM3 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CapacidadeM3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeVeiculo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFeVeiculoQuery(IMDFeVeiculoEntity MDFeVeiculo)
        {
            this.Query = $@" DELETE FROM [MDFeVeiculo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MDFeVeiculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration