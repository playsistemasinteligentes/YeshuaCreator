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
    public class PedidoPlanejavelQueryWrite : QueryBase, IPedidoPlanejavelQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PedidoPlanejavelQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPedidoPlanejavelQuery(IPedidoPlanejavelEntity PedidoPlanejavel)
        {
            this.Query = $@" INSERT INTO [PedidoPlanejavel] ([PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo]) VALUES(@PedidoId, @ClienteId, @ClienteNome, @Estado, @Municipio, @Regiao, @Bairro, @RotaId, @EmbarqueAlvo, @DataEntregaDe, @DataEntregaAte, @Peso, @Volume, @SaldoAExpedir, @Status, @CargaAtualId, @VersaoPlanejamento, @AlertasResumo) ";
            this.Parameters = new
            {
                PedidoId = PedidoPlanejavel.PedidoId,
                ClienteId = PedidoPlanejavel.ClienteId,
                ClienteNome = PedidoPlanejavel.ClienteNome,
                Estado = PedidoPlanejavel.Estado,
                Municipio = PedidoPlanejavel.Municipio,
                Regiao = PedidoPlanejavel.Regiao,
                Bairro = PedidoPlanejavel.Bairro,
                RotaId = PedidoPlanejavel.RotaId,
                EmbarqueAlvo = PedidoPlanejavel.EmbarqueAlvo,
                DataEntregaDe = PedidoPlanejavel.DataEntregaDe,
                DataEntregaAte = PedidoPlanejavel.DataEntregaAte,
                Peso = PedidoPlanejavel.Peso,
                Volume = PedidoPlanejavel.Volume,
                SaldoAExpedir = PedidoPlanejavel.SaldoAExpedir,
                Status = PedidoPlanejavel.Status,
                CargaAtualId = PedidoPlanejavel.CargaAtualId,
                VersaoPlanejamento = PedidoPlanejavel.VersaoPlanejamento,
                AlertasResumo = PedidoPlanejavel.AlertasResumo,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePedidoPlanejavelQuery(IPedidoPlanejavelEntity PedidoPlanejavel)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [ClienteId] = @ClienteId, [ClienteNome] = @ClienteNome, [Estado] = @Estado, [Municipio] = @Municipio, [Regiao] = @Regiao, [Bairro] = @Bairro, [RotaId] = @RotaId, [EmbarqueAlvo] = @EmbarqueAlvo, [DataEntregaDe] = @DataEntregaDe, [DataEntregaAte] = @DataEntregaAte, [Peso] = @Peso, [Volume] = @Volume, [SaldoAExpedir] = @SaldoAExpedir, [Status] = @Status, [CargaAtualId] = @CargaAtualId, [VersaoPlanejamento] = @VersaoPlanejamento, [AlertasResumo] = @AlertasResumo WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ClienteId = PedidoPlanejavel.ClienteId,
                ClienteNome = PedidoPlanejavel.ClienteNome,
                Estado = PedidoPlanejavel.Estado,
                Municipio = PedidoPlanejavel.Municipio,
                Regiao = PedidoPlanejavel.Regiao,
                Bairro = PedidoPlanejavel.Bairro,
                RotaId = PedidoPlanejavel.RotaId,
                EmbarqueAlvo = PedidoPlanejavel.EmbarqueAlvo,
                DataEntregaDe = PedidoPlanejavel.DataEntregaDe,
                DataEntregaAte = PedidoPlanejavel.DataEntregaAte,
                Peso = PedidoPlanejavel.Peso,
                Volume = PedidoPlanejavel.Volume,
                SaldoAExpedir = PedidoPlanejavel.SaldoAExpedir,
                Status = PedidoPlanejavel.Status,
                CargaAtualId = PedidoPlanejavel.CargaAtualId,
                VersaoPlanejamento = PedidoPlanejavel.VersaoPlanejamento,
                AlertasResumo = PedidoPlanejavel.AlertasResumo,
                PedidoId = PedidoPlanejavel.PedidoId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClienteId(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [ClienteId] = @ClienteId WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ClienteId = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClienteNome(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [ClienteNome] = @ClienteNome WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ClienteNome = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstado(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [Estado] = @Estado WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Estado = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipio(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [Municipio] = @Municipio WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Municipio = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRegiao(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [Regiao] = @Regiao WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Regiao = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBairro(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [Bairro] = @Bairro WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Bairro = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRotaId(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [RotaId] = @RotaId WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                RotaId = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmbarqueAlvo(string pedidoid, DateTime value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [EmbarqueAlvo] = @EmbarqueAlvo WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                EmbarqueAlvo = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataEntregaDe(string pedidoid, DateTime value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [DataEntregaDe] = @DataEntregaDe WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                DataEntregaDe = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataEntregaAte(string pedidoid, DateTime value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [DataEntregaAte] = @DataEntregaAte WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                DataEntregaAte = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePeso(string pedidoid, Decimal value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [Peso] = @Peso WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Peso = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolume(string pedidoid, Decimal value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [Volume] = @Volume WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Volume = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSaldoAExpedir(string pedidoid, Decimal value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [SaldoAExpedir] = @SaldoAExpedir WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                SaldoAExpedir = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [Status] = @Status WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Status = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaAtualId(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [CargaAtualId] = @CargaAtualId WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                CargaAtualId = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVersaoPlanejamento(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [VersaoPlanejamento] = @VersaoPlanejamento WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                VersaoPlanejamento = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAlertasResumo(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [PedidoPlanejavel] SET [AlertasResumo] = @AlertasResumo WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                AlertasResumo = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePedidoPlanejavelQuery(IPedidoPlanejavelEntity PedidoPlanejavel)
        {
            this.Query = $@" DELETE FROM [PedidoPlanejavel] WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                PedidoId = PedidoPlanejavel.PedidoId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration